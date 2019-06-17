using RAApplication.Interfaces;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsOrder
{
    public interface IDecreaseArticlesOrder:IUpdateCommand<ArticleDecreaseRequest,int>
    {
    }
}
