using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proiectAspNet.Models
{
    public class OrderedProduct
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice {get; set;
            /*get {
                return this.Product.Price * this.Quantity;
            }
            set
            {
                this.TotalPrice=this.Product.Price * this.Quantity;
            }*/
        }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}