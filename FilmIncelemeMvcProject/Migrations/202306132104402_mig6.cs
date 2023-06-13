namespace FilmIncelemeMvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role", c => c.String(maxLength: 1));
            AlterColumn("dbo.Movies", "Image", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Movies", "Trailer", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Users", "Image", c => c.String(maxLength: 1000));
            DropTable("dbo.Admins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(maxLength: 50),
                        AdminPassword = c.String(maxLength: 50),
                        AdminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminId);
            
            AlterColumn("dbo.Users", "Image", c => c.String(maxLength: 300));
            AlterColumn("dbo.Movies", "Trailer", c => c.String());
            AlterColumn("dbo.Movies", "Image", c => c.String(maxLength: 500));
            DropColumn("dbo.Users", "Role");
        }
    }
}
