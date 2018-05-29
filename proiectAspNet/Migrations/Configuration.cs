namespace proiectAspNet.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using proiectAspNet.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<proiectAspNet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "proiectAspNet.Models.ApplicationDbContext";
        }

        protected override void Seed(proiectAspNet.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
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
                new Order{/*NumberOfOrders=2,*/ OrderDate=DateTime.Parse("2018-09-01"), TotalPrice=100},
                new Order{/*NumberOfOrders=5,*/ OrderDate=DateTime.Parse("2018-09-02"), TotalPrice=100},
                new Order{/*NumberOfOrders=7,*/ OrderDate=DateTime.Parse("2018-09-03"), TotalPrice=100},
                new Order{/*NumberOfOrders=10,*/ OrderDate=DateTime.Parse("2018-09-04"), TotalPrice=100},
                new Order{/*NumberOfOrders=2,*/ OrderDate=DateTime.Parse("2018-09-05"), TotalPrice=100}

            };
            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();

            var orderedProducts = new List<OrderedProduct>
            {
                //TotalPrice=products.Single(p=>p.ID==5).Price*3
                new OrderedProduct{OrderID=1, ProductID=5, Quantity=3,TotalPrice=900 },
                new OrderedProduct{OrderID=1, ProductID=6, Quantity=3, TotalPrice=300},
                new OrderedProduct{OrderID=2, ProductID=3, Quantity=3, TotalPrice=135},
                new OrderedProduct{OrderID=2, ProductID=4, Quantity=3, TotalPrice=180},
                new OrderedProduct{OrderID=3, ProductID=5, Quantity=2, TotalPrice=600},

            };
            orderedProducts.ForEach(s => context.OrderedProducts.Add(s));
            context.SaveChanges();
        }
    }
}
