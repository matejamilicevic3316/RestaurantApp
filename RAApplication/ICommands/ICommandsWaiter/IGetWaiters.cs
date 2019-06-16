using RAApplication.DTO;
using RAApplication.Interfaces;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsWaiter
{
    public interface IGetWaiters:ICommand<WaiterSearch,IEnumerable<WaiterDTO>>
    {
    }
}
