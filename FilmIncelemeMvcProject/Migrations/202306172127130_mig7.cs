namespace FilmIncelemeMvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatigId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatigId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "MovieId", "dbo.Movies");
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "MovieId" });
            DropTable("dbo.Ratings");
        }
    }
}
