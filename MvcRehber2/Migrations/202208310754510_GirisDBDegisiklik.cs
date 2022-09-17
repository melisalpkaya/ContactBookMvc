namespace MvcRehber2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GirisDBDegisiklik : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Giris", "UyeAdi", c => c.String());
            AddColumn("dbo.Giris", "UyeSoyadi", c => c.String());
            AddColumn("dbo.Giris", "UyeTelefonNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Giris", "UyeTelefonNo");
            DropColumn("dbo.Giris", "UyeSoyadi");
            DropColumn("dbo.Giris", "UyeAdi");
        }
    }
}
