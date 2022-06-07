using Microsoft.EntityFrameworkCore;
using InventorySystem.Entities.Entities;

namespace InventorySystem.DataAccess.Context
{
    public class SqlServerContext : DbContext
    {
        private string _connectionString;
        public SqlServerContext()
        {
            _connectionString = "Data Source = DESKTOP-OMM0BK4\\SQLEXPRESS; Initial Catalog = InventorySystem; Integrated Security = true";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }
        public DbSet<Article> Article { get; set; }
        public DbSet<Movement> Movement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey( c => new { c.IdArticle } );
            modelBuilder.Entity<Article>().Property(c => c.IdArticle).UseIdentityColumn()
                .Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Movement>().HasKey(m => new { m.IdMovement });
            modelBuilder.Entity<Movement>().Property(m => m.IdMovement).UseIdentityColumn()
                .Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            base.OnModelCreating(modelBuilder);
        }
    }
}
