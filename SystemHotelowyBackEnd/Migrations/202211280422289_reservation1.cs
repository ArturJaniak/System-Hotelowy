namespace SystemHotelowyBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "Country", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "RoomType", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "RoomNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "RoomNo", c => c.String());
            AlterColumn("dbo.Reservations", "RoomType", c => c.String());
            AlterColumn("dbo.Reservations", "Country", c => c.String());
        }
    }
}
