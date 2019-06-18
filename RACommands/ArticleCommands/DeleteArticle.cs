using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticle;
using System;
using System.Collections.Generic;
using System.Text;

namespace RACommands.ArticleCommands
{
    public class DeleteArticle : BaseCommand, IDeleteArticle
    {
        public DeleteArticle(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(int req)
        {
            var update = this.context.Articles.Find(req);
            if (update != null)
            {
                update.IsDelete = true;
                this.context.SaveChanges();
            }
            else
            {
                throw new ObjectDoesntExistException("Article");
            }
        }
    }
}
