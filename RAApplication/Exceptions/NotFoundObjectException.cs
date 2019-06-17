using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.Exceptions
{
    public class NotFoundObjectException:Exception
    {
        public NotFoundObjectException(string entity) : base($"{entity} is not found")
        {

        }
    }
}
