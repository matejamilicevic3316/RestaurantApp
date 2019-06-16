using DataAccess;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsRole;
using System;
using System.Collections.Generic;
using System.Text;

namespace RACommands.RoleCommands
{
    public class GetRole : BaseCommand, IGetRole
    {
        public GetRole(RestaurantContext ctx) : base(ctx)
        {
        }

        public RoleDTO Execute(int req)
        {
            var role = context.Roles.Find(req);
            if (role!=null)
            {
                return new RoleDTO
                {
                    Id=role.Id,
                    Name=role.Name
                };
            }
            else
            {
                throw new NotFoundObjectException("Role");
            }
        }
    }
}
