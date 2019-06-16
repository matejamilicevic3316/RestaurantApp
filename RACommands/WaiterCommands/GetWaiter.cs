using DataAccess;
using Microsoft.EntityFrameworkCore;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsWaiter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.WaiterCommands
{
    public class GetWaiter : BaseCommand, IGetWaiter
    {
        public GetWaiter(RestaurantContext ctx) : base(ctx)
        {
        }

        public WaiterDTO Execute(int req)
        {
            var waiter = context.Waiters.AsQueryable().Include(p => p.Role).Where(x=>x.Id==req).FirstOrDefault();
            if (waiter != null)
            {
                return new WaiterDTO
                {
                    Id = waiter.Id,
                    FirstName = waiter.FirstName,
                    LastName = waiter.LastName,
                    Role = waiter.Role.Name,
                    Email = waiter.Email
                };
            }
            else
            {
                throw new NotFoundObjectException("Waiter");
            }
        }
    }
}
