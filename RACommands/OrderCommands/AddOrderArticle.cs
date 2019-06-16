using DataAccess;
using Domain;
using RAApplication.DTO;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.OrderCommands
{
    public class AddOrderArticle : BaseCommand, IAddOrderArticle
    {
        IAddArticleToOrder addOrderToArticle;
        IAddOrderAndArticle addOrderAndArticle;
        public AddOrderArticle(RestaurantContext ctx,IAddOrderAndArticle addOrderAndArticle, IAddArticleToOrder addOrderToArticle) : base(ctx)
        {
            this.addOrderToArticle = addOrderToArticle;
            this.addOrderAndArticle = addOrderAndArticle;
        }

        public void Execute(OrderRequest req)
        {
            var OrderToAdd = this.context.Orders.Where(p => p.IdTable == req.IdTable).Where(p => p.Active == true).FirstOrDefault();
            if (OrderToAdd == null)
            {
                this.addOrderAndArticle.Execute(req);
            }
            else
            {
                this.addOrderToArticle.Execute(req, OrderToAdd); 
            }
        }
    }
}
