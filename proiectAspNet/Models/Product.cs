using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proiectAspNet.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
    }
}