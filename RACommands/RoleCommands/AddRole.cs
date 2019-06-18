using DataAccess;
using Domain;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.RoleCommands
{
    public class AddRole : BaseCommand, IAddRole
    {
        IGetRole getRole;
        public AddRole(RestaurantContext ctx,IGetRole getRole) : base(ctx)
        {
            this.getRole = getRole;
        }

        public RoleDTO Execute(RoleDTO req)
        {
            if (context.Roles.Any(p => p.Name.ToLower() == req.Name))
            {
                throw new ObjectAlreadyExistsException("Role");
            }
            else
            {
                var obj = new Role
                {
                    Name = req.Name
                };
                this.context.Roles.Add(obj);
                this.context.SaveChanges();
                return this.getRole.Execute(obj.Id);
            }
        }
    }
}
