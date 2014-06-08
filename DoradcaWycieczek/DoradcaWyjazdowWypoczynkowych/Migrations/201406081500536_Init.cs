namespace DoradcaWyjazdowWypoczynkowych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OcenaUzytkownika", "OfertaGotowa_OfertaGotowaID", "dbo.OfertaGotowa");
            DropIndex("dbo.OcenaUzytkownika", new[] { "OfertaGotowa_OfertaGotowaID" });
            DropColumn("dbo.OcenaUzytkownika", "OfertaGotowa_OfertaGotowaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OcenaUzytkownika", "OfertaGotowa_OfertaGotowaID", c => c.Int());
            CreateIndex("dbo.OcenaUzytkownika", "OfertaGotowa_OfertaGotowaID");
            AddForeignKey("dbo.OcenaUzytkownika", "OfertaGotowa_OfertaGotowaID", "dbo.OfertaGotowa", "OfertaGotowaID");
        }
    }
}
