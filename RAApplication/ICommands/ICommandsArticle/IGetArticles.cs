using RAApplication.DTO;
using RAApplication.Interfaces;
using RAApplication.Responses;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands.ICommandsArticle
{
    public interface IGetArticles:ICommand<ArticleSearch,PagedResponse<ArticleDTO>>
    {
    }
}
