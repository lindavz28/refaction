using System;
using System.Collections.Generic;

namespace Models
{
    // ProductionOption class used for saving/getting data from the SqlLiteDatabase
    // Using string for Guid as SqlLite DB isn't handling Guid type properly
    public class ProductOption
    {
        public string Id { get; set; }

        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
