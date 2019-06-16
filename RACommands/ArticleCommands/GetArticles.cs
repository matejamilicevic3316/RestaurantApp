using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticle;
using RAApplication.Responses;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.ArticleCommands
{
    public class GetArticles : BaseCommand, IGetArticles
    {
        public GetArticles(RestaurantContext ctx) : base(ctx)
        {
        }

        public PagedResponse<ArticleDTO> Execute(ArticleSearch req)
        {
            var articles = context.Articles
                .AsQueryable();

            var id = req.IdArticleType;
            if (req.Keyword != null)
            {
                articles = articles.Where(p => p.Name.ToLower().Contains(req.Keyword.ToLower()));
            }
            if (req.IdArticleType != null)
            {
                if (context.Article_types.Any(p => p.Id == req.IdArticleType))
                {
                    articles = articles.Where(p => p.IdArtical_type == req.IdArticleType);
                }
                else
                {
                    throw new NotFoundObjectException("Article Type");
                }
            }
            if (req.IdOrder != null)
            {
                articles = articles.Where(p => p.OrderArticles.Where(x => x.IdOrder == req.IdOrder).Any(y => y.IdArticle == p.Id));
            }
            var totalCount = articles.Count();

            articles = articles
               .Include(p => p.Artical_Type)
               .Include(p => p.OrderArticles)
               .Where(p => p.IsDelete == false).Skip((req.PageNumber - 1) * req.PerPage).Take(req.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / req.PerPage);


            return new PagedResponse<ArticleDTO>
            {
                CurrentPage = req.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = articles.Select(p => new ArticleDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ArticleType = p.Artical_Type.Name,
                    Image = p.Image
                })
            };
        }
    }
}
