namespace Tp2_Azure2.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        NumeroDoPedido = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Categoria = c.String(),
                        Preco = c.String(),
                        Quantidade = c.Int(nullable: false),
                        Pedido_PedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Pedido", t => t.Pedido_PedidoId)
                .Index(t => t.Pedido_PedidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Pedido_PedidoId", "dbo.Pedido");
            DropIndex("dbo.Produto", new[] { "Pedido_PedidoId" });
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
        }
    }
}
