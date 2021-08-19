namespace CodeEventsDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.myApps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppName = c.String(),
                        AppDESC = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.APP_Layers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AppID = c.Int(nullable: false),
                        LayerName = c.String(),
                        ParentLayerID = c.Int(nullable: false),
                        LayerDESC = c.String(),
                        ParentLayer_Id = c.Int(),
                        ParentLayer_AppID = c.Int(),
                    })
                .PrimaryKey(t => new { t.Id, t.AppID })
                .ForeignKey("dbo.myApps", t => t.AppID, cascadeDelete: true)
                .ForeignKey("dbo.APP_Layers", t => new { t.ParentLayer_Id, t.ParentLayer_AppID })
                .Index(t => t.AppID)
                .Index(t => new { t.ParentLayer_Id, t.ParentLayer_AppID });
            
            CreateTable(
                "dbo.CodingEvents",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventDesc = c.String(),
                        LayerID = c.Int(nullable: false),
                        AppID = c.Int(nullable: false),
                        EventTypeID = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.APP_Layers", t => new { t.LayerID, t.AppID }, cascadeDelete: true)
                .Index(t => new { t.LayerID, t.AppID });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.APP_Layers", new[] { "ParentLayer_Id", "ParentLayer_AppID" }, "dbo.APP_Layers");
            DropForeignKey("dbo.APP_Layers", "AppID", "dbo.myApps");
            DropForeignKey("dbo.CodingEvents", new[] { "LayerID", "AppID" }, "dbo.APP_Layers");
            DropIndex("dbo.CodingEvents", new[] { "LayerID", "AppID" });
            DropIndex("dbo.APP_Layers", new[] { "ParentLayer_Id", "ParentLayer_AppID" });
            DropIndex("dbo.APP_Layers", new[] { "AppID" });
            DropTable("dbo.CodingEvents");
            DropTable("dbo.APP_Layers");
            DropTable("dbo.myApps");
        }
    }
}
