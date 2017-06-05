using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2_Azure2.Service.DAO;
using Tp2_Azure2.Service.Domain;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Tp2_Azure2.Service
{
    public class GerenciamentoDeCompra : IGerenciamentoDeCompra_V1, IGerenciamentoDeCompra_V2
    {
        CloudQueue queue;
        public GerenciamentoDeCompra()
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            queue = queueClient.GetQueueReference("pedidos");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();
        }




        public Guid RealizarPedido(Produto p)
        {
            //Produto p2 = new Produto()
            //{
            //    ProdutoId = p.ProdutoId,
            //    Nome = p.Nome,
            //    Categoria = p.Categoria,
            //    Preco = p.Preco,
            //    Quantidade = p.Quantidade
            //};
            Pedido pedido = new Pedido();
            pedido.Produtos.Add(p);
            PedidoDao dao = new PedidoDao();
            dao.Add(pedido);
            CloudQueueMessage message = new CloudQueueMessage(pedido.NumeroDoPedido.ToString());
            queue.AddMessage(message);
            return pedido.NumeroDoPedido;

        }

        public Guid RealizarPedido(List<Produto> p)
        {
            Pedido pedido = new Pedido();
            pedido.Produtos = p;
            PedidoDao dao = new PedidoDao();
            dao.Add(pedido);
            CloudQueueMessage message = new CloudQueueMessage(pedido.NumeroDoPedido.ToString());
            queue.AddMessage(message);
            return pedido.NumeroDoPedido;
        }
    }
}
