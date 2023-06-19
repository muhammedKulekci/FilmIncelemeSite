namespace FilmIncelemeMvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AverageRating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AverageRating");
        }
    }
}
