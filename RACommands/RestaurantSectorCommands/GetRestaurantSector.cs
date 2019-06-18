using DataAccess;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands
{
    public class GetRestaurantSector : BaseCommand, IGetRestaurantSector
    {
        public GetRestaurantSector(RestaurantContext context) : base(context)
        {

        }
        public RestaurantSectorDTO Execute(int req)
        {
            if(this.context.Restaurant_Sectors.Find(req)!=null)
            {
                var sector = context.Restaurant_Sectors.Find(req);
                var ResDto = new RestaurantSectorDTO
                {
                    Id = sector.Id,
                    Name = sector.Name
                };
                return ResDto;
            }
            else
            {
                throw new NotFoundObjectException("Restaurant Sector");
            }
        }
    }
}
