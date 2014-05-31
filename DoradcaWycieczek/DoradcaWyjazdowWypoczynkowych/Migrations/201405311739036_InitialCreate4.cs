namespace DoradcaWyjazdowWypoczynkowych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Atrakcja", "Kategoria_KategoriaID", "dbo.Kategoria");
            DropIndex("dbo.Atrakcja", new[] { "Kategoria_KategoriaID" });
            CreateTable(
                "dbo.AtrakcjaKategoria",
                c => new
                    {
                        AtrakcjaKategoriaID = c.Int(nullable: false, identity: true),
                        Kategoria_KategoriaID = c.Int(),
                        Atrakcja_AtrakcjaID = c.Int(),
                    })
                .PrimaryKey(t => t.AtrakcjaKategoriaID)
                .ForeignKey("dbo.Kategoria", t => t.Kategoria_KategoriaID)
                .ForeignKey("dbo.Atrakcja", t => t.Atrakcja_AtrakcjaID)
                .Index(t => t.Kategoria_KategoriaID)
                .Index(t => t.Atrakcja_AtrakcjaID);
            
            DropColumn("dbo.Atrakcja", "Kategoria_KategoriaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Atrakcja", "Kategoria_KategoriaID", c => c.Int());
            DropIndex("dbo.AtrakcjaKategoria", new[] { "Atrakcja_AtrakcjaID" });
            DropIndex("dbo.AtrakcjaKategoria", new[] { "Kategoria_KategoriaID" });
            DropForeignKey("dbo.AtrakcjaKategoria", "Atrakcja_AtrakcjaID", "dbo.Atrakcja");
            DropForeignKey("dbo.AtrakcjaKategoria", "Kategoria_KategoriaID", "dbo.Kategoria");
            DropTable("dbo.AtrakcjaKategoria");
            CreateIndex("dbo.Atrakcja", "Kategoria_KategoriaID");
            AddForeignKey("dbo.Atrakcja", "Kategoria_KategoriaID", "dbo.Kategoria", "KategoriaID");
        }
    }
}
