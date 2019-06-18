using DataAccess;
using Microsoft.EntityFrameworkCore;
using RAApplication.DTO;
using RAApplication.ICommands.ICommandsTable;
using RAApplication.Responses;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.TableCommands
{
    public class GetTables : BaseCommand, IGetTables
    {
        public GetTables(RestaurantContext ctx) : base(ctx)
        {
        }

        public IEnumerable<TableDTO> Execute(TableSearch req)
        {
            var tables = this.context.Tables
                .AsQueryable();

            if (req.IdRestaurantSector != null)
            {
                tables = tables.Where(p => p.IdRestaurant_sector == req.IdRestaurantSector);
            }
            if (req.IsFree != null)
            {
                if (req.IsFree == true)
                {
                    tables = tables.Where(p => p.Orders.All(x => x.Active == false));
                }
                else
                {
                    tables = tables.Where(p => p.Orders.Any(x => x.Active == true));
                }
            }
       

            tables = tables
               .Include(p => p.Restaurant_Sector)
               .Include(p => p.Orders)
               .Where(p => p.IsDelete == false);


            return tables.Select(p => new TableDTO
            {
                Id = p.Id,
                Name = p.Name,
                Sector = p.Restaurant_Sector.Name
            });
        }
    }
}
