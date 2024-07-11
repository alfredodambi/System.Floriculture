using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Floriculture.Domain.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace System.Floriculture.Infrastruture.Context
{
    public class MyContext : DbContext
    {
        private readonly string _connectionString;

        public MyContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MyContext() : base("ConnectionDb") { }

        public DbSet<Client> clients { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Purchase> purchases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
            base.OnModelCreating(modelBuilder);

            //Relation many-to-many
            modelBuilder.Entity<Purchase>()
                .HasMany(p => p.Products)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("PurchaseId");
                    m.MapRightKey("ProductId");
                    m.ToTable("PurchaseProducts");
                });
        }
    }
}
