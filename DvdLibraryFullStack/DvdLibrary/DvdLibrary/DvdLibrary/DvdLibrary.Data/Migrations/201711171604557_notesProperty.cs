namespace DvdLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notesProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dvds", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dvds", "Notes");
        }
    }
}
