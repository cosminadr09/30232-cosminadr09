using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proiectAspNet.Models;

namespace proiectAspNet.DAL
{
    public class ShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var products = new List<Product>
            {
                new Product{Name = "Inel", Price=30, Stock=35 },
                new Product{Name = "Cercei", Price=50, Stock=100 },
                new Product{Name = "Colier", Price=45, Stock=30 },
                new Product{Name = "Bratara", Price=60, Stock=20 },
                new Product{Name = "Verigheta", Price=300, Stock=35 },
                new Product{Name = "Inel de logodna", Price=100, Stock=80 },
                new Product{Name = "Ceas barbati", Price=250, Stock=40 },
                new Product{Name = "Ceas femei", Price=170, Stock=35 },
                new Product{Name = "Inel cu diamante", Price=380, Stock=10 },
                new Product{Name = "Colier statemenet", Price=80, Stock=10 },
                new Product{Name = "Cercei cu diamante", Price=190, Stock=10 }



            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order{/*NumberOfOrders=2,*/ OrderDate=DateTime.Parse("2018-09-01")},
                new Order{/*NumberOfOrders=5,*/ OrderDate=DateTime.Parse("2018-09-02")},
                new Order{/*NumberOfOrders=7,*/ OrderDate=DateTime.Parse("2018-09-03")},
                new Order{/*NumberOfOrders=10,*/ OrderDate=DateTime.Parse("2018-09-04")},
                new Order{/*NumberOfOrders=2,*/ OrderDate=DateTime.Parse("2018-09-05")}

            };
            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();

            var orderedProducts = new List<OrderedProduct>
            {
                new OrderedProduct{OrderID=1, ProductID=5, Quantity=3},
                new OrderedProduct{OrderID=1, ProductID=6, Quantity=3},
                new OrderedProduct{OrderID=2, ProductID=3, Quantity=3},
                new OrderedProduct{OrderID=2, ProductID=4, Quantity=3},
                new OrderedProduct{OrderID=3, ProductID=5, Quantity=3},

            };
            orderedProducts.ForEach(s => context.OrderedProducts.Add(s));
            context.SaveChanges();


        }
    }
}