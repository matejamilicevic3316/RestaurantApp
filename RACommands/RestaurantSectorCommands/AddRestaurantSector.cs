using DataAccess;
using Domain;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands
{
    public class AddRestaurantSector : BaseCommand, IAddRestaurantSector
    {
        IGetRestaurantSector getRestaurantSector;
        public AddRestaurantSector(RestaurantContext context,IGetRestaurantSector getRestaurantSector):base(context)
        {
            this.getRestaurantSector = getRestaurantSector;
        }
        public RestaurantSectorDTO Execute(RestaurantSectorDTO req)
        {
            if (context.Restaurant_Sectors.Any(p => p.Name == req.Name && p.IsDelete==false))
            {
                throw new ObjectAlreadyExistsException("Restaurant Sector");
            }
            else
            {
                var ResSec = new Restaurant_Sector
                {
                    Name = req.Name
                };
                this.context.Restaurant_Sectors.Add(ResSec);
                this.context.SaveChanges();
                return getRestaurantSector.Execute(ResSec.Id);
            }
        }
    }
}
