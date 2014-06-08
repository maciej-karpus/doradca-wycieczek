namespace DoradcaWyjazdowWypoczynkowych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AddColumn("dbo.OcenaUzytkownika", "OfertaGotowa_OfertaGotowaID", c => c.Int());
            CreateIndex("dbo.OcenaUzytkownika", "OfertaGotowa_OfertaGotowaID");
            AddForeignKey("dbo.OcenaUzytkownika", "OfertaGotowa_OfertaGotowaID", "dbo.OfertaGotowa", "OfertaGotowaID");
        }
    }
}
