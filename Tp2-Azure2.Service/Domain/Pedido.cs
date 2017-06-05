using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2_Azure2.Service.Domain
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        public Guid NumeroDoPedido { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public Pedido()
        {
            this.NumeroDoPedido = new Guid();

            this.Produtos = new List<Produto>();
        }
    }
}
