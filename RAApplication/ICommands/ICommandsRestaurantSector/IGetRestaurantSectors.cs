using RAApplication.DTO;
using RAApplication.Interfaces;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.ICommands
{
    public interface IGetRestaurantSectors:ICommand<RestaurantSectorSearch,IEnumerable<RestaurantSectorDTO>>
    {
    }
}
