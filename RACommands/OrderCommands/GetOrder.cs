using DataAccess;
using Microsoft.EntityFrameworkCore;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.OrderCommands
{
    public class GetOrder : BaseCommand, IGetOrder
    {
        public GetOrder(RestaurantContext ctx) : base(ctx)
        {
        }

        public OrderDTO Execute(int req)
        {
            
            var p = this.context.Orders.AsQueryable().
                Include(x => x.Waiter).
                Include(x => x.Table).
                Include(x => x.OrderArticles)
                .ThenInclude(x => x.Article)
                .Where(x => x.Id == req)
                .Where(x=>x.IsDelete==false)
                .FirstOrDefault();
            if (p != null)
            {
                return new OrderDTO
                {
                    Id = p.Id,
                    FullName = p.Waiter.FirstName + " " + p.Waiter.LastName,
                    Table = p.Table.Name,
                    IdTable = p.Table.Id,
                    TotalPrice = p.OrderArticles.Sum(x => x.ArticlePrice * x.ArticlesNumber),
                    Articles = p.OrderArticles.Select(x => new OrderArticlesDTO
                    {
                        ArticleName = x.Article.Name,
                        ArticleNumber = x.ArticlesNumber,
                        TotalArticlesPrice = x.ArticlesNumber * x.ArticlePrice
                    }).ToList()
                };
            }
            else
            {
                throw new NotFoundObjectException("Order");
            }
        }
    }
}
