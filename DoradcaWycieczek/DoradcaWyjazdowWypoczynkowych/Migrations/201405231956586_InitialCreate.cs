namespace DoradcaWyjazdowWypoczynkowych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atrakcja",
                c => new
                    {
                        AtrakcjaID = c.Int(nullable: false, identity: true),
                        Lokalizacja = c.String(),
                        Kategoria_KategoriaID = c.Int(),
                    })
                .PrimaryKey(t => t.AtrakcjaID)
                .ForeignKey("dbo.Kategoria", t => t.Kategoria_KategoriaID)
                .Index(t => t.Kategoria_KategoriaID);
            
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        KategoriaID = c.Int(nullable: false, identity: true),
                        Komfort = c.Int(nullable: false),
                        Zwiedzanie = c.Int(nullable: false),
                        Aktywnosc = c.Int(nullable: false),
                        Imprezowosc = c.Int(nullable: false),
                        BliskoNatury = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KategoriaID);
            
            CreateTable(
                "dbo.OfertaGotowa",
                c => new
                    {
                        OfertaGotowaID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                        Data = c.DateTime(nullable: false),
                        Komfort = c.Int(nullable: false),
                        Zwiedzanie = c.Int(nullable: false),
                        Aktywnosc = c.Int(nullable: false),
                        Imprezowosc = c.Int(nullable: false),
                        BliskoNatury = c.Int(nullable: false),
                        CzasTrwania = c.Int(nullable: false),
                        Koszt = c.Double(nullable: false),
                        Kod = c.Int(nullable: false),
                        Transport = c.String(),
                        LiczbaOsob = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OfertaGotowaID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Atrakcja", new[] { "Kategoria_KategoriaID" });
            DropForeignKey("dbo.Atrakcja", "Kategoria_KategoriaID", "dbo.Kategoria");
            DropTable("dbo.OfertaGotowa");
            DropTable("dbo.Kategoria");
            DropTable("dbo.Atrakcja");
        }
    }
}
