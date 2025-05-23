﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComShop.Core.Entities.Product
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal  NewPrice { get; set; }
        public decimal  OldPrice { get; set; }
        public virtual List<Photo> Photos { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
