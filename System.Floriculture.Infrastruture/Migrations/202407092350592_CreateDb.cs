namespace System.Floriculture.Infrastruture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bi = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        totalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.ClientId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.PurchaseProducts",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PurchaseId, t.ProductId })
                .ForeignKey("dbo.Purchase", t => t.PurchaseId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.PurchaseId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.PurchaseProducts", "ProductId", "dbo.Product");
            DropForeignKey("dbo.PurchaseProducts", "PurchaseId", "dbo.Purchase");
            DropForeignKey("dbo.Purchase", "ClientId", "dbo.Client");
            DropIndex("dbo.PurchaseProducts", new[] { "ProductId" });
            DropIndex("dbo.PurchaseProducts", new[] { "PurchaseId" });
            DropIndex("dbo.Purchase", new[] { "Product_Id" });
            DropIndex("dbo.Purchase", new[] { "ClientId" });
            DropTable("dbo.PurchaseProducts");
            DropTable("dbo.Purchase");
            DropTable("dbo.Product");
            DropTable("dbo.Client");
        }
    }
}
