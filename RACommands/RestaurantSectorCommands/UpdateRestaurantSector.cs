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
    public class UpdateRestaurantSector : BaseCommand, IUpdateRestaurantSector
    {
        public UpdateRestaurantSector(RestaurantContext context) : base(context)
        {

        }
        public void Execute(RestaurantSectorDTO req, int i)
        {
            var update = context.Restaurant_Sectors.Find(i);
            if (update == null)
            {
                throw new NotFoundObjectException("Restaurant Sector");

            }
            else
            {
                if (context.Restaurant_Sectors.Any(p => p.Name == req.Name))
                {
                    throw new ObjectAlreadyExistsException("Restaurant Sector");
                }
                else
                {
                    update.Name = req.Name;
                    update.ModifiedAt = DateTime.Now;
                    this.context.Restaurant_Sectors.Update(update);
                    context.SaveChanges();
                }
            }
        }
    }
}
