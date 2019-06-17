using DataAccess;
using Domain;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticle;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.ArticleCommands
{
    public class AddArticle : BaseCommand, IAddArticle
    {
        public IGetArticle getArticle;

        public AddArticle(RestaurantContext context, IGetArticle getArticle) : base(context)
        {
            this.getArticle = getArticle;
        }

        public ArticleDTO Execute(ArticleRequest req)
        {
            if (this.context.Article_types.Any(p=>p.Id==req.ArticleTypeId))
            {
                if (context.Articles.Any(p => p.Name == req.Name && p.IsDelete==false))
                {
                    throw new ObjectAlreadyExistsException("Article");
                }
                else
                {
                    
                    var article = new Article
                    {
                        Name = req.Name,
                        IdArtical_type = req.ArticleTypeId,
                        Price = req.Price,
                        Image = req.Image
                    };
                    this.context.Articles.Add(article);
                    this.context.SaveChanges();
                    return this.getArticle.Execute(article.Id);
                }
            }
            else
            {
                throw new ObjectDoesntExistException("Article Type");
            }
        }
    }
}
