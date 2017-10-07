using System;
using System.Collections.Generic;

namespace Models
{
    // Product class used for communication with callers
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
