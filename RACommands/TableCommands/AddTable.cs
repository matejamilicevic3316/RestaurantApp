using DataAccess;
using Domain;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsTable;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.TableCommands
{
    public class AddTable : BaseCommand,IAddTable
    {
        private GetTable getTable;
        public AddTable(RestaurantContext ctx) : base(ctx)
        {
            getTable = new GetTable(ctx);
        }
        public TableDTO Execute(TableRequest req)
        {
            if (context.Restaurant_Sectors.Any(p => p.Id == req.IdSector))
            {
                if (context.Tables.Any(p => p.Name == req.Name && p.IsDelete==false))
                {
                    throw new ObjectAlreadyExistsException("Table");
                }
                else
                {
                    var obj = new Table
                    {
                        Name = req.Name,
                        IdRestaurant_sector = req.IdSector
                    };
                    context.Tables.Add(obj);
                    context.SaveChanges();
                    TableDTO dto = getTable.Execute(obj.Id);
                    return dto;
                }
            }
            else
            {
                throw new ObjectDoesntExistException("Restaurant Sector");
            }
        }
    }
}
