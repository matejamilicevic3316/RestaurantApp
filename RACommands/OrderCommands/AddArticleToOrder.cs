using DataAccess;
using Domain;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.OrderCommands
{
    public class AddArticleToOrder : BaseCommand, IAddArticleToOrder
    {
        public AddArticleToOrder(RestaurantContext ctx) : base(ctx)
        {
        }

        public void Execute(OrderRequest req, Order order)
        {
            var article = context.Articles.Find(req.IdArticle);
            //var OrderToAdd = this.context.Orders.Where(p => p.IdTable == req.IdTable).Where(p => p.Active == true).FirstOrDefault();
            
            var id = order.Id;
          
            var orderArticle = this.context.OrderArticles
                .Where(p => p.IdArticle == req.IdArticle)
                .Where(p => p.IdOrder == id)
                .FirstOrDefault();
            if (orderArticle != null)
            {
                orderArticle.ArticlesNumber = orderArticle.ArticlesNumber + 1;
            }
            else
            {
                context.OrderArticles.Add(new OrderArticle
                {
                    IdArticle = req.IdArticle,
                    IdOrder = id,
                    ArticlePrice = article.Price,
                    ArticlesNumber = 1
                });
            }
            this.context.SaveChanges();
        }
    }
}
