using RAApplication.DTO;
using RAApplication.Interfaces;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsWaiter
{
    public interface IAddWaiter:ICommand<WaiterRequest,WaiterDTO>
    {
    }
}
