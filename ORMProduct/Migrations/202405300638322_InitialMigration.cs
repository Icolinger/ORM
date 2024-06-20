    namespace ORMProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Size = c.String(),
                        Type = c.Boolean(nullable: false),
                        TypeId = c.Int(nullable: false),
                        types_type = c.Int(nullable: false),
                        types_typeSpecified = c.Boolean(nullable: false),
                        types_value = c.String(),
                        types_ProductDimensionType = c.String(),
                        ProducType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProducTypes", t => t.ProducType_Id)
                .Index(t => t.ProducType_Id);
            
            CreateTable(
                "dbo.ProducTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProducType_Id", "dbo.ProducTypes");
            DropIndex("dbo.Products", new[] { "ProducType_Id" });
            DropTable("dbo.ProducTypes");
            DropTable("dbo.Products");
        }
    }
}
