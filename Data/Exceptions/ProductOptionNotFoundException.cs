using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    public class ProductOptionNotFoundException : Exception
    {
        public ProductOptionNotFoundException()
        {
        }

        public ProductOptionNotFoundException(string message)
            : base(message)
        {
        }

        public ProductOptionNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
