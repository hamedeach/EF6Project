namespace CodeEventsDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoIDColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CodingEvents", new[] { "LayerID", "AppID" }, "dbo.APP_Layers");
            DropForeignKey("dbo.APP_Layers", new[] { "ParentLayer_Id", "ParentLayer_AppID" }, "dbo.APP_Layers");
            DropPrimaryKey("dbo.APP_Layers");
            AlterColumn("dbo.APP_Layers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.APP_Layers", new[] { "Id", "AppID" });
            AddForeignKey("dbo.CodingEvents", new[] { "LayerID", "AppID" }, "dbo.APP_Layers", new[] { "Id", "AppID" }, cascadeDelete: true);
            AddForeignKey("dbo.APP_Layers", new[] { "ParentLayer_Id", "ParentLayer_AppID" }, "dbo.APP_Layers", new[] { "Id", "AppID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.APP_Layers", new[] { "ParentLayer_Id", "ParentLayer_AppID" }, "dbo.APP_Layers");
            DropForeignKey("dbo.CodingEvents", new[] { "LayerID", "AppID" }, "dbo.APP_Layers");
            DropPrimaryKey("dbo.APP_Layers");
            AlterColumn("dbo.APP_Layers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.APP_Layers", new[] { "Id", "AppID" });
            AddForeignKey("dbo.APP_Layers", new[] { "ParentLayer_Id", "ParentLayer_AppID" }, "dbo.APP_Layers", new[] { "Id", "AppID" });
            AddForeignKey("dbo.CodingEvents", new[] { "LayerID", "AppID" }, "dbo.APP_Layers", new[] { "Id", "AppID" }, cascadeDelete: true);
        }
    }
}
