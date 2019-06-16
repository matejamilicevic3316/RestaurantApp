using RAApplication.DTO;
using RAApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsArticleType
{
    public interface IGetArticleType:ICommand<int,ArticleTypeDTO>
    {
    }
}
