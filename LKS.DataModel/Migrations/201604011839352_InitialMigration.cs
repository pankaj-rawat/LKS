namespace LKS.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsPostId = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CommentDate = c.DateTime(nullable: false),
                        VerifiedBy = c.String(),
                        IsVerified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsPosts", t => t.NewsPostId, cascadeDelete: true)
                .Index(t => t.NewsPostId);
            
            CreateTable(
                "dbo.NewsPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false, maxLength: 150),
                        Detail = c.String(nullable: false),
                        Author = c.String(nullable: false, maxLength: 30),
                        PostDate = c.DateTime(nullable: false),
                        ImagePath = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsComments", "NewsPostId", "dbo.NewsPosts");
            DropIndex("dbo.NewsComments", new[] { "NewsPostId" });
            DropTable("dbo.NewsPosts");
            DropTable("dbo.NewsComments");
        }
    }
}
