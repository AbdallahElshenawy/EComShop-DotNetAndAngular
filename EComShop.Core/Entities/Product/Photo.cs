using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComShop.Core.Entities.Product
{
    public class Photo : BaseEntity<int>
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
       // public virtual Product Product { get; set; }
    }
}
