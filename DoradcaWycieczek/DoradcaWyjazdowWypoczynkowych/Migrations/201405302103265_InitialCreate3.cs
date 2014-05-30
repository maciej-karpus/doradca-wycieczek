namespace DoradcaWyjazdowWypoczynkowych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OcenaUzytkownika",
                c => new
                    {
                        OcenaUzytkownikaID = c.Int(nullable: false, identity: true),
                        GlownaOcena = c.Int(nullable: false),
                        Komfort = c.Int(nullable: false),
                        Zwiedzanie = c.Int(nullable: false),
                        Aktywnosc = c.Int(nullable: false),
                        Imprezowosc = c.Int(nullable: false),
                        BliskoNatury = c.Int(nullable: false),
                        OfertaGotowa_OfertaGotowaID = c.Int(),
                    })
                .PrimaryKey(t => t.OcenaUzytkownikaID)
                .ForeignKey("dbo.OfertaGotowa", t => t.OfertaGotowa_OfertaGotowaID)
                .Index(t => t.OfertaGotowa_OfertaGotowaID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.OcenaUzytkownika", new[] { "OfertaGotowa_OfertaGotowaID" });
            DropForeignKey("dbo.OcenaUzytkownika", "OfertaGotowa_OfertaGotowaID", "dbo.OfertaGotowa");
            DropTable("dbo.OcenaUzytkownika");
        }
    }
}
