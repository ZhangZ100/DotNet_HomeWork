using H8;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8
{
   [DbConfigurationType(typeof(MySqlEFConfiguration))]
   public class OrderContext:DbContext
    {
        public OrderContext() : base("OrderDatabase")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Goods> Goods { get; set; }
    }
}
