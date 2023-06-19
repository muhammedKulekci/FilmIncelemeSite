namespace FilmIncelemeMvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        FavoritesId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.FavoritesId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        WishId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.WishId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.Favorites", "UserId", "dbo.Users");
            DropIndex("dbo.WishLists", new[] { "UserId" });
            DropIndex("dbo.Favorites", new[] { "UserId" });
            DropTable("dbo.WishLists");
            DropTable("dbo.Favorites");
        }
    }
}
