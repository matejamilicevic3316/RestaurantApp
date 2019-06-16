using DataAccess;
using Microsoft.EntityFrameworkCore;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsAuth;
using RAApplication.Login;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.AuthCommands
{
    public class GetLoggedUser : BaseCommand, IGetLoggedUser
    {
        public GetLoggedUser(RestaurantContext ctx) : base(ctx)
        {
        }

        public LoggedUser Execute(LoginRequest loginRequest)
        {
            var response = this.context.Waiters.AsQueryable().Include(p=>p.Role)
                .Where(p => p.Email == loginRequest.Email && p.Password == loginRequest.Password)
                .FirstOrDefault();
            if (response != null)
            {
                return new LoggedUser
                {
                    Id = response.Id,
                    FirstName = response.FirstName,
                    LastName = response.LastName,
                    Role = response.Role.Name,
                    Email = response.Email
                };
            }
            else
            {
                throw new NotFoundObjectException("User");
            }
        }
    }
}
