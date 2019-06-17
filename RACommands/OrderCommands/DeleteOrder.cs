using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsOrder;
using System;
using System.Collections.Generic;
using System.Text;

namespace RACommands.OrderCommands
{
    public class DeleteOrder : BaseCommand, IDeleteOrder
    {
        public DeleteOrder(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(int req)
        {
            var delete = this.context.Orders.Find(req);
            if (delete != null)
            {
                delete.IsDelete = true;
                delete.Active = false;
                delete.IsPaid = false;
                delete.IsStorned = false;
                this.context.SaveChanges();
            }
            else
            {
                throw new ObjectDoesntExistException("Order");
            }
        }
    }
}
