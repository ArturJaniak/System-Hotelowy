namespace SystemHotelowyVer3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfirstname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.AspNetUsers", "Names");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Names", c => c.String());
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
