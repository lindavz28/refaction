using System;
using System.Collections.Generic;

namespace Models
{
    // Production class used for saving/getting data from the SqlLiteDatabase
    // Using string for Guid as SqlLite DB isn't handling Guid type properly
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }
    }
}
