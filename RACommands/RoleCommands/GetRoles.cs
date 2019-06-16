using DataAccess;
using RAApplication.DTO;
using RAApplication.ICommands.ICommandsRole;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.RoleCommands
{
    public class GetRoles : BaseCommand, IGetRoles
    {
        public GetRoles(RestaurantContext ctx) : base(ctx)
        {

        }

        public IEnumerable<RoleDTO> Execute(RoleSearch req)
        {
            var roles= this.context.Roles.AsQueryable().Where(p=>p.IsDelete==false);
            if (req.Name != null)
            {
                roles = roles.Where(p => p.Name.ToLower().Contains(req.Name.ToLower()));
            }
            
                return roles.Select(p=>new RoleDTO
                {
                    Id=p.Id,
                    Name=p.Name
                });
            
        }
    }
}
