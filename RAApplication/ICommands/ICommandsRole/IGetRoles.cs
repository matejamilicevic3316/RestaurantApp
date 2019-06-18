using RAApplication.DTO;
using RAApplication.Interfaces;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsRole
{
    public interface IGetRoles:ICommand<RoleSearch,IEnumerable<RoleDTO>>
    {
    }
}
