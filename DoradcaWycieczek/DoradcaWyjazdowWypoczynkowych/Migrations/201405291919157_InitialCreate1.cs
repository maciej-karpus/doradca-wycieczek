namespace DoradcaWyjazdowWypoczynkowych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoria", "KategoriaNazwa", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kategoria", "KategoriaNazwa");
        }
    }
}
