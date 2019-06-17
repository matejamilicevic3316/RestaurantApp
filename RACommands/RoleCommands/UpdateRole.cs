using DataAccess;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.RoleCommands
{
    public class UpdateRole : BaseCommand, IUpdateRole
    {
        public UpdateRole(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(RoleDTO req, int i)
        {
            var update = this.context.Roles.Find(i);
            if (update == null)
            {
                throw new ObjectDoesntExistException("Role");
            }
            else
            {
                if (context.Roles.Any(p => p.Name.ToLower()==req.Name.ToLower()))
                {
                    update.Name = req.Name;
                    update.ModifiedAt = DateTime.Now;
                    this.context.SaveChanges();
                }
                else
                {
                    throw new ObjectAlreadyExistsException("Role");
                }
            }
        }
    }
}
