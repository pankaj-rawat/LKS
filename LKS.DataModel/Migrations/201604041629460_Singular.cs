namespace LKS.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Singular : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NewsComments", newName: "NewsComment");
            RenameTable(name: "dbo.NewsPosts", newName: "NewsPost");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.NewsPost", newName: "NewsPosts");
            RenameTable(name: "dbo.NewsComment", newName: "NewsComments");
        }
    }
}
