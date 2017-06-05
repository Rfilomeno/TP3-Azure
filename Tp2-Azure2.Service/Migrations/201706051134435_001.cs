namespace Tp2_Azure2.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produto", "Pedido_PedidoId", "dbo.Pedido");
            DropIndex("dbo.Produto", new[] { "Pedido_PedidoId" });
            DropPrimaryKey("dbo.Pedido");
            AlterColumn("dbo.Pedido", "PedidoId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Produto", "Pedido_PedidoId", c => c.Guid());
            AddPrimaryKey("dbo.Pedido", "PedidoId");
            CreateIndex("dbo.Produto", "Pedido_PedidoId");
            AddForeignKey("dbo.Produto", "Pedido_PedidoId", "dbo.Pedido", "PedidoId");
            DropColumn("dbo.Pedido", "NumeroDoPedido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedido", "NumeroDoPedido", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Produto", "Pedido_PedidoId", "dbo.Pedido");
            DropIndex("dbo.Produto", new[] { "Pedido_PedidoId" });
            DropPrimaryKey("dbo.Pedido");
            AlterColumn("dbo.Produto", "Pedido_PedidoId", c => c.Int());
            AlterColumn("dbo.Pedido", "PedidoId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pedido", "PedidoId");
            CreateIndex("dbo.Produto", "Pedido_PedidoId");
            AddForeignKey("dbo.Produto", "Pedido_PedidoId", "dbo.Pedido", "PedidoId");
        }
    }
}
