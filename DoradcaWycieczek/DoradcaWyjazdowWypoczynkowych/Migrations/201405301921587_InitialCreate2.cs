namespace DoradcaWyjazdowWypoczynkowych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atrakcja", "AtrakcjaNazwa", c => c.String());
            AlterColumn("dbo.OfertaGotowa", "Kod", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OfertaGotowa", "Kod", c => c.Int(nullable: false));
            DropColumn("dbo.Atrakcja", "AtrakcjaNazwa");
        }
    }
}
