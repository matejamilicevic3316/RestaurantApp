using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RACommands
{
    public class DeleteRestaurantSector : BaseCommand, IDeleteRestaurantSector
    {
        public DeleteRestaurantSector(RestaurantContext context) : base(context)
        {

        }
        public void Execute(int req)
        {
            var del = context.Restaurant_Sectors.Find(req);
            if (del != null)
            {
                del.IsDelete = true;
                this.context.Restaurant_Sectors.Update(del);
                context.SaveChanges();
            }
            else
            {
                throw new NotFoundObjectException("Restaurant Sector");
            }
        }
    }
}
