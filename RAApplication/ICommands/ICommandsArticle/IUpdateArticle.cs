using RAApplication.Interfaces;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsArticle
{
    public interface IUpdateArticle:IUpdateCommand<ArticleRequest,int>
    {
    }
}
