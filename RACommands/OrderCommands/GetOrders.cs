using DataAccess;
using Microsoft.EntityFrameworkCore;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.OrderCommands
{
    public class GetOrders : BaseCommand, IGetOrders
    {
        public GetOrders(RestaurantContext ctx) : base(ctx)
        {
        }

        public IEnumerable<OrderDTO> Execute(OrderSearch req)
        {
            var orders = this.context.Orders.AsQueryable().
                Include(p => p.Waiter).
                Include(p => p.Table).
                Include(p => p.OrderArticles)
                .ThenInclude(p => p.Article)
                .Where(p=>p.IsDelete==false);

            if (req.Status != null)
            {
                var status = req.Status;
                if (status == Status.active)
                {
                    orders = orders.Where(p=>p.Active == true);
                }
                if (status == Status.paid)
                {
                    orders = orders.Where(p => p.IsPaid == true);
                }
                if (status == Status.storned)
                {
                    orders = orders.Where(p => p.IsStorned == true);
                }
            }

            if (req.DateFrom!=null)
            {
                if (req.DateFrom > DateTime.Now)
                {
                    throw new ObjectDoesntExistException("Date");
                }
                orders = orders.Where(p => p.CreatedAt > req.DateFrom);
            }
            if (req.DateTo != null)
            {
                orders = orders.Where(p => p.CreatedAt < req.DateTo);
            }
            if (req.IdTable!=null)
            {
                if (context.Tables.Any(p => p.Id == req.IdTable))
                {
                    orders = orders.Where(p => p.IdTable == req.IdTable);
                }
                else
                {
                    throw new ObjectDoesntExistException("Table");
                }
            }
            if (req.IdWaiter != null)
            {
                if (context.Waiters.Any(p => p.Id == req.IdWaiter))
                {
                    orders = orders.Where(p => p.IdWaiter == req.IdWaiter);
                }
                else
                {
                    throw new ObjectDoesntExistException("Waiter");
                }
            }
            

            return orders.Select(p => new OrderDTO
            {
                Id=p.Id,
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
            });
        }
    }
}
