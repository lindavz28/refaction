using System;


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
