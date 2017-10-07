using System;
using System.Collections.Generic;

namespace Models
{
    // ProductOption class used for communication with callers
    public class ProductOptionDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
