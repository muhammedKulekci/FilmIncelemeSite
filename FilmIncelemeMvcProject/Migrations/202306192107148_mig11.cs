namespace FilmIncelemeMvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favorites", "UserId", "dbo.Users");
            DropIndex("dbo.Favorites", new[] { "UserId" });
            AlterColumn("dbo.Favorites", "MovieId", c => c.Int(nullable: false));
            AlterColumn("dbo.Favorites", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Favorites", "UserId");
            AddForeignKey("dbo.Favorites", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "UserId", "dbo.Users");
            DropIndex("dbo.Favorites", new[] { "UserId" });
            AlterColumn("dbo.Favorites", "UserId", c => c.Int());
            AlterColumn("dbo.Favorites", "MovieId", c => c.Int());
            CreateIndex("dbo.Favorites", "UserId");
            AddForeignKey("dbo.Favorites", "UserId", "dbo.Users", "UserId");
        }
    }
}
