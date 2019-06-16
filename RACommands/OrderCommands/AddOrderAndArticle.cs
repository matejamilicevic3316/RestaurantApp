using DataAccess;
using Domain;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.OrderCommands
{
    public class AddOrderAndArticle : BaseCommand, IAddOrderAndArticle
    {
        public AddOrderAndArticle(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(OrderRequest req)
        {
            var article = context.Articles.Find(req.IdArticle);
            var order = new Order();
            if (this.context.Tables.Any(p => p.Id == req.IdTable))
            {
                order.IdTable = (int)req.IdTable;
            }
            else
            {
                throw new NotFoundObjectException("Table");
            }

            if (this.context.Waiters.Any(p => p.Id == req.IdWaiter))
            {
                order.IdWaiter = (int)req.IdWaiter;
            }
            else
            {
                throw new NotFoundObjectException("Waiter");
            }
            var orderArticle = new OrderArticle();
            if (this.context.Articles.Any(p => p.Id == req.IdArticle))
            {
                orderArticle.IdArticle = req.IdArticle;
            }
            else
            {
                throw new NotFoundObjectException("Article");
            }
            orderArticle.ArticlePrice = article.Price;
            orderArticle.ArticlesNumber = 1;
            orderArticle.Order = order;

            this.context.OrderArticles.Add(orderArticle);
            this.context.SaveChanges();
        }
    }
}
