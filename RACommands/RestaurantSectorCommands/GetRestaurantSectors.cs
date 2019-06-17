using DataAccess;
using RAApplication.DTO;
using RAApplication.ICommands;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands
{
    public class GetRestaurantSectors : BaseCommand, IGetRestaurantSectors
    {
        public GetRestaurantSectors(RestaurantContext context) : base(context)
        {

        }

        public IEnumerable<RestaurantSectorDTO> Execute(RestaurantSectorSearch req)
        {
            var sectors = context.Restaurant_Sectors.AsQueryable();
            sectors = sectors.Where(p => p.IsDelete == false);
            if (req.Name == null)
            {
                return sectors.Select(rs=>new RestaurantSectorDTO
                {
                    Id=rs.Id,
                    Name=rs.Name
                });   
            }
            else
            {
                return sectors.Where(rs => rs.Name.ToLower().Contains(req.Name.ToLower()))
                    .Select(rs => new RestaurantSectorDTO
                    {
                        Id = rs.Id,
                        Name = rs.Name
                    });
            }
        }
    }
}
