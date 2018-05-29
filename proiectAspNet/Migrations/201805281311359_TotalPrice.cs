namespace proiectAspNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderedProducts", "TotalPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderedProducts", "TotalPrice");
        }
    }
}
