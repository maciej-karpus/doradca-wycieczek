namespace DoradcaWyjazdowWypoczynkowych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atrakcja", "ZdjecieURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Atrakcja", "ZdjecieURL");
        }
    }
}
