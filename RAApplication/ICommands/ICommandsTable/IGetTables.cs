using RAApplication.DTO;
using RAApplication.Interfaces;
using RAApplication.Responses;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsTable
{
    public interface IGetTables:ICommand<TableSearch,IEnumerable<TableDTO>>
    {
    }
}
