using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Tp2_Azure2.Service.Domain;

namespace Tp2_Azure2.Service.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\workspace\Tp3-Azure2\Tp2-Azure2.Service\DataBase\Database.mdf;Integrated Security=True;Connect Timeout=30")
        {
            
        }
        
        
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
