using DataAccess;
using Microsoft.EntityFrameworkCore;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsWaiter;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.WaiterCommands
{
    public class GetWaiters : BaseCommand, IGetWaiters
    {
        public GetWaiters(RestaurantContext ctx) : base(ctx)
        {
        }

        public IEnumerable<WaiterDTO> Execute(WaiterSearch req)
        {
            var waiter = this.context.Waiters.AsQueryable().Include(p => p.Role);

            if (req.IdRole != null)
            {
                if (this.context.Roles.Any(p => p.Id == req.IdRole))
                {
                    return waiter.Where(p => p.IdRole == req.IdRole).Select(p => new WaiterDTO
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Role = p.Role.Name,
                        Email = p.Email
                    });
                }
                else
                {
                    throw new ObjectDoesntExistException("Role");
                }
            }
            else
            {
                return waiter.Select(p => new WaiterDTO
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Role = p.Role.Name,
                    Email = p.Email
                });
            }
        }
    }
}
