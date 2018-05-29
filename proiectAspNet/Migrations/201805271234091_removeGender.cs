namespace proiectAspNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeGender : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
