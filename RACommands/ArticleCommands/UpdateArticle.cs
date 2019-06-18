using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticle;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.ArticleCommands
{
    public class UpdateArticle : BaseCommand, IUpdateArticle
    {
        public UpdateArticle(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(ArticleRequest req, int id)
        {
            var update = this.context.Articles.Find(id);
            if (update != null)
            {
                if (req.ArticleTypeId != null)
                {
                    if (this.context.Article_types.Any(p => p.Id == req.ArticleTypeId))
                    {
                        update.IdArtical_type = req.ArticleTypeId;
                    }
                    else
                    {
                        throw new ObjectDoesntExistException("Article Type");
                    }
                }
                if(req.Name!=null)
                update.Name = req.Name;
                if(req.Price!=null)
                update.Price = req.Price;
                this.context.SaveChanges();
            }
            else
            {
                throw new ObjectDoesntExistException("Article");
            }
        }
    }
}
