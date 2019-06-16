using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace RACommands.TableCommands
{
    public class DeleteTable : BaseCommand, IDeleteTable
    {
        public DeleteTable(RestaurantContext ctx) : base(ctx)
        {
           
        }

        public void Execute(int req)
        {
            var delete = this.context.Tables.Find(req);
            if (delete != null)
            {
                delete.IsDelete = true;
                this.context.SaveChanges();
            }
            else
            {
                throw new ObjectDoesntExistException("Table");
            }
        }
    }
}
