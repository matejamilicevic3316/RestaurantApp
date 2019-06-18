﻿using RAApplication.DTO;
using RAApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsTable
{
    public interface IGetTable:ICommand<int,TableDTO>
    {
    }
}
