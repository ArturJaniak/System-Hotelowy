namespace SystemHotelowyBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Phone = c.Int(nullable: false),
                        Country = c.String(),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        RoomType = c.String(),
                        RoomNo = c.String(),
                        Adults = c.Int(nullable: false),
                        Children = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservations");
        }
    }
}
