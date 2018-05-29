namespace proiectAspNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTotalPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalPrice");
        }
    }
}
