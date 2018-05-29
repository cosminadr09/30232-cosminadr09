namespace proiectAspNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductOrderOrderedProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderedProducts", new[] { "ProductID" });
            DropIndex("dbo.OrderedProducts", new[] { "OrderID" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderedProducts");
        }
    }
}
