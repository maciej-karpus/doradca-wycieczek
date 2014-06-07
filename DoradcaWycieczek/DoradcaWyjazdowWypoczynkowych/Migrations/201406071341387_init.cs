namespace DoradcaWyjazdowWypoczynkowych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OcenaUzytkownika", "Kategoria_KategoriaID", c => c.Int());
            AddForeignKey("dbo.OcenaUzytkownika", "Kategoria_KategoriaID", "dbo.Kategoria", "KategoriaID");
            CreateIndex("dbo.OcenaUzytkownika", "Kategoria_KategoriaID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OcenaUzytkownika", new[] { "Kategoria_KategoriaID" });
            DropForeignKey("dbo.OcenaUzytkownika", "Kategoria_KategoriaID", "dbo.Kategoria");
            DropColumn("dbo.OcenaUzytkownika", "Kategoria_KategoriaID");
        }
    }
}
