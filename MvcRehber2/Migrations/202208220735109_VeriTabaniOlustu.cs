namespace MvcRehber2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VeriTabaniOlustu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Giris",
                c => new
                    {
                        UyeId = c.Int(nullable: false, identity: true),
                        MailAdresi = c.String(),
                        Sifre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UyeId);
            
            CreateTable(
                "dbo.Kisis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        EvTelefon = c.String(),
                        CepTelefon = c.String(),
                        IsTelefon = c.String(),
                        EmailAdres = c.String(),
                        Adres = c.String(),
                        SehirId = c.Int(nullable: false),
                        UyeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sehirs", t => t.SehirId, cascadeDelete: true)
                .ForeignKey("dbo.Giris", t => t.UyeId, cascadeDelete: true)
                .Index(t => t.SehirId)
                .Index(t => t.UyeId);
            
            CreateTable(
                "dbo.Sehirs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SehirAdi = c.String(),
                        PlakaKodu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kisis", "UyeId", "dbo.Giris");
            DropForeignKey("dbo.Kisis", "SehirId", "dbo.Sehirs");
            DropIndex("dbo.Kisis", new[] { "UyeId" });
            DropIndex("dbo.Kisis", new[] { "SehirId" });
            DropTable("dbo.Sehirs");
            DropTable("dbo.Kisis");
            DropTable("dbo.Giris");
        }
    }
}
