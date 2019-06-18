using RAApplication.Interfaces;
using RAApplication.Login;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsAuth
{
    public interface IGetLoggedUser:ICommand<LoginRequest,LoggedUser>
    {
    }
}
