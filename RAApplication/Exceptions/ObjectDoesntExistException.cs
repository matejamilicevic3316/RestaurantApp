using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.Exceptions
{
    public class ObjectDoesntExistException:Exception
    {
        public ObjectDoesntExistException(string entity):base($"{entity} doesnt exist")
        {

        }
    }
}
