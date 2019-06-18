using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.OrderCommands
{
    public class DecreaseArticlesOrder : BaseCommand, IDecreaseArticlesOrder
    {
        IDeleteOrder deleteOrder;
        public DecreaseArticlesOrder(RestaurantContext ctx,IDeleteOrder deleteOrder) : base(ctx)
        {
            this.deleteOrder = deleteOrder;
        }

        public void Execute(ArticleDecreaseRequest req, int IdOrder)
        {
            var IdArticle = req.IdArticle;
            var articleOrder = this.context.OrderArticles.AsQueryable()
                .Where(p => p.IdArticle == IdArticle)
                .Where(p => p.IdOrder == IdOrder).FirstOrDefault();
            if (req.DeleteAll == 1)
            {
                this.context.OrderArticles.Remove(articleOrder);
                this.context.SaveChanges();
                if (!this.context.OrderArticles.Any(p => p.IdOrder == articleOrder.IdOrder))
                {
                    this.deleteOrder.Execute(articleOrder.IdOrder);
                }
            }
            else
            {
                if (req.DeleteAll == 0)
                {
                    articleOrder.ArticlesNumber = articleOrder.ArticlesNumber - 1;
                    if (articleOrder.ArticlesNumber == 0)
                    {
                        this.context.OrderArticles.Remove(articleOrder);
                        this.context.SaveChanges();
                        if (!this.context.OrderArticles.Any(p => p.IdOrder == articleOrder.IdOrder))
                        {
                            this.deleteOrder.Execute(articleOrder.IdOrder);
                        }
                    }
                }
                else
                {
                    throw new ObjectDoesntExistException("Number");
                }
            }
            this.context.SaveChanges();
        }
    }
}
