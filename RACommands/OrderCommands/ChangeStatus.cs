using DataAccess;
using Microsoft.EntityFrameworkCore;
using RAApplication.DTO;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.OrderCommands
{
    public class ChangeStatus : BaseCommand, IChangeStatus
    {
        public ChangeStatus(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(StatusRequest req, int i)
        {
            var change = this.context.Orders.AsQueryable().Where(p => p.Id == i).FirstOrDefault();
            if (req.status == Status.paid)
            {
                change.Active = false;
                change.IsPaid = true;
                change.IsStorned = false;
                change.ModifiedAt = DateTime.Now;
            }
            if (req.status == Status.storned)
            {
                change.Active = false;
                change.IsStorned = true;
                change.IsPaid = false;

                change.ModifiedAt = DateTime.Now;
            }
            if (req.status == Status.active)
            {
                change.Active = true;
                change.IsStorned = false;
                change.IsPaid = false;
                change.IsDelete = false;

                change.ModifiedAt = DateTime.Now;
            }
            this.context.SaveChanges();
        }
    }
}
