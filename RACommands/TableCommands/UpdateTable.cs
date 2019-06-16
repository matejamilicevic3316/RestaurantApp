using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsTable;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.TableCommands
{
    public class UpdateTable : BaseCommand, IUpdateTable
    {
        public UpdateTable(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(TableRequest req, int tint)
        {
            if (this.context.Tables.Any(p => p.Name == req.Name))
            {
                throw new ObjectAlreadyExistsException("Table");
            }
            else
            {
                var update = this.context.Tables.Find(tint);
                if (update != null)
                {
                    if (context.Restaurant_Sectors.Any(p => p.Id == req.IdSector))
                    {
                        if (req.Name != null)
                        {
                            update.Name = req.Name;
                        }
                        this.context.SaveChanges();
                    }
                    else
                    {
                        throw new ObjectDoesntExistException("Restaurant Sector");
                    }
                }
                else
                {
                    throw new ObjectDoesntExistException("Table");
                }
            }
        }
    }
}
