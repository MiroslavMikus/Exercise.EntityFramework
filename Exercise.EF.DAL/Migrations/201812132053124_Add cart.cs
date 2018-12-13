namespace Exercise.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        CatalogItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Cart", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.CatalogItem", t => t.CatalogItemId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.CatalogItemId);
            
            CreateTable(
                "dbo.CatalogItem",
                c => new
                    {
                        CatalogItemId = c.Int(nullable: false, identity: true),
                        Sku = c.String(),
                        Description = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CatalogItemId);
            
            DropColumn("dbo.User", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Name", c => c.String());
            DropForeignKey("dbo.Cart", "UserId", "dbo.User");
            DropForeignKey("dbo.CartItem", "CatalogItemId", "dbo.CatalogItem");
            DropForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
            DropIndex("dbo.CartItem", new[] { "CatalogItemId" });
            DropIndex("dbo.CartItem", new[] { "CartId" });
            DropIndex("dbo.Cart", new[] { "UserId" });
            DropTable("dbo.CatalogItem");
            DropTable("dbo.CartItem");
            DropTable("dbo.Cart");
        }
    }
}
