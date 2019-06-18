using DataAccess;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsWaiter;
using RAApplication.Interfaces;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.WaiterCommands
{
    public class UpdateWaiter : BaseCommand, IUpdateWaiter
    {
        public UpdateWaiter(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(WaiterRequest req, int id)
        {
            var update = this.context.Waiters.Find(id);
            if (update != null)
            {
                if (req.FirstName!=null)
                    update.FirstName = req.FirstName;
                if (req.LastName != null)
                    update.LastName = req.LastName;
                if (req.Email != null)
                    update.Email = req.Email;
                if (req.IdRole != null)
                {
                    if (context.Roles.Any(p => p.Id == req.IdRole))
                    {
                        update.IdRole = req.IdRole;
                    }
                    else
                    {
                        throw new ObjectDoesntExistException("Role");
                    }
                }
                this.context.SaveChanges();
            }
            else
            {
                throw new NotFoundObjectException("Waiter");
            }
        }
    }
}
