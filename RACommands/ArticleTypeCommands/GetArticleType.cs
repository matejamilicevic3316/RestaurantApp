using DataAccess;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticleType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.ArticleTypeCommands
{
    public class GetArticleType : BaseCommand, IGetArticleType
    {
        public GetArticleType(RestaurantContext context) : base(context)
        {

        }

        public ArticleTypeDTO Execute(int req)
        {
            
            var article = context.Article_types.AsQueryable().Where(p=>p.Id==req).Where(p=>p.IsDelete==false).FirstOrDefault();
            if (article != null)
            {
                return new ArticleTypeDTO
                {
                    Id = article.Id,
                    Name = article.Name
                };
            }
            else
            {
                throw new NotFoundObjectException("Article Type");
            }
                
        }
    }
}
