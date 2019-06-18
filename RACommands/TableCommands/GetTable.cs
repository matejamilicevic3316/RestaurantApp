using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.TableCommands
{
    public class GetTable : BaseCommand, IGetTable
    {
        public GetTable(RestaurantContext ctx) : base(ctx)
        {
        }

        public TableDTO Execute(int req)
        {
            var table = context.Tables.AsQueryable().
                Include(t=>t.Restaurant_Sector).
                Where(p=>p.Id==req).FirstOrDefault();
        
            
            if (table != null)
            {
                return new TableDTO
                {
                    Id = table.Id,
                    Name = table.Name,
                    Sector = table.Restaurant_Sector.Name
                };
            }
            else
            {
                throw new NotFoundObjectException("Table");
            }
        }
    }
}
