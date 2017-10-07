using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class ProductDatabaseException : Exception
    {
        public ProductDatabaseException()
        {
        }

        public ProductDatabaseException(string message)
            : base(message)
        {
        }

        public ProductDatabaseException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
