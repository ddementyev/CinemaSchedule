namespace CinemaSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Movie = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Movie });
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Theater = c.String(nullable: false, maxLength: 50, unicode: false),
                        Movie = c.String(nullable: false, maxLength: 50, unicode: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Time = c.Time(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.Id, t.Theater, t.Movie, t.Date, t.Time });
            
            CreateTable(
                "dbo.Theaters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Theater = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Theater });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Theaters");
            DropTable("dbo.Sessions");
            DropTable("dbo.Movies");
        }
    }
}
