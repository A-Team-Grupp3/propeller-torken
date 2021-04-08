using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PropellerTorkenMain.Models.Database
{
    public partial class PropellerDataContext : DbContext
    {
        public PropellerDataContext()
        {
        }

        public PropellerDataContext(DbContextOptions<PropellerDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsInOrder> ProductsInOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PropellerData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Firstname).IsRequired();

                entity.Property(e => e.Lastname).IsRequired();

                entity.Property(e => e.PhoneNr).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.OurCustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OurCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customer");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProductsInOrder>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId });

                entity.ToTable("ProductsInOrder");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductsInOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsInOrder_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsInOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsInOrder_Products");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}