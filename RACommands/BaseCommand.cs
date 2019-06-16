using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace RACommands
{
    public abstract class BaseCommand
    {
        protected RestaurantContext context { get; }
        protected BaseCommand(RestaurantContext ctx) => context = ctx;
    }
}
