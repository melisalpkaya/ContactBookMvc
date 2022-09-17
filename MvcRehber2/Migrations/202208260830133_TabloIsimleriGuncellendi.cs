namespace MvcRehber2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabloIsimleriGuncellendi : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Kisis", newName: "Kisiler");
            RenameTable(name: "dbo.Sehirs", newName: "Sehirler");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Sehirler", newName: "Sehirs");
            RenameTable(name: "dbo.Kisiler", newName: "Kisis");
        }
    }
}
