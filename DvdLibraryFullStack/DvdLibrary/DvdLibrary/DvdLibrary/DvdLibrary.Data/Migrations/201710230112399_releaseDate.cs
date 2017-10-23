namespace DvdLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class releaseDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dvds", "ReleaseDate", c => c.Int());
            DropColumn("dbo.Dvds", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dvds", "Date", c => c.Int());
            DropColumn("dbo.Dvds", "ReleaseDate");
        }
    }
}
