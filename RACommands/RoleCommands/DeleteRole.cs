using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsRole;
using System;
using System.Collections.Generic;
using System.Text;

namespace RACommands.RoleCommands
{
    public class DeleteRole : BaseCommand, IDeleteRole
    {
        public DeleteRole(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(int req)
        {
            var delete = this.context.Roles.Find(req);
            if (delete != null)
            {
                delete.IsDelete = true;
                this.context.SaveChanges();
            }
            else
            {
                throw new ObjectDoesntExistException("Role");
            }
        }
    }
}
