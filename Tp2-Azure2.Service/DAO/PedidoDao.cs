using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2_Azure2.Service.Context;
using Tp2_Azure2.Service.Domain;

namespace Tp2_Azure2.Service.DAO
{
    public class PedidoDao
    {
        DataContext _contexto;
        public PedidoDao()
        {
            this._contexto = new DataContext();
        }

        public void Add(Pedido p)
        {
            _contexto.Pedidos.Add(p);
            _contexto.SaveChanges();
        }
    }
}
