using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tp2_Azure2.Service.Domain
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int ProdutoId { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Categoria { get; set; }
        [DataMember]
        public string Preco { get; set; }
        [DataMember]
        public int Quantidade { get; set; }

        
    }
}
