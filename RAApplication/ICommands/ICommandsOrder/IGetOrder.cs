using RAApplication.DTO;
using RAApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsOrder
{
    public interface IGetOrder:ICommand<int,OrderDTO>
    {
    }
}
