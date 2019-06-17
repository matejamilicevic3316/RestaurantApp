using DataAccess;
using Microsoft.EntityFrameworkCore;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.ArticleCommands
{
    public class GetArticle : BaseCommand, IGetArticle
    {
        public GetArticle(RestaurantContext ctx) : base(ctx)
        {
        }

        public ArticleDTO Execute(int req)
        {
            var article = this.context.Articles.AsQueryable().Include(p => p.Artical_Type).Where(p=>p.IsDelete==false).Where(p=>p.Id==req).FirstOrDefault();
            if (article != null)
            {
                return new ArticleDTO
                {
                    Id = article.Id,
                    Name = article.Name,
                    ArticleType = article.Artical_Type.Name,
                    Price = article.Price
                };
            }
            else
            {
                throw new NotFoundObjectException("Article");
            }
        }
    }
}
