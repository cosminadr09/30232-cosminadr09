namespace proiectAspNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfullname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Fullname");
        }
    }
}
