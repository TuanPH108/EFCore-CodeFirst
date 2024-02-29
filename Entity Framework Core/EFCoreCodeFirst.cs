using Entity_Framework_Core.Objects;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Core
{
    public class EFCoreCodeFirst : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<UserOrderProduct> UserOrderProducts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=ep-sweet-unit-a1ll43ev.ap-southeast-1.aws.neon.tech;Username=ph.hoangtuan18;Password=eswJv84NGEDO;Database=PostgreeSample");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 1 User - n Order
            _ = modelBuilder.Entity<User>()
                .HasMany(s => s.UserOrder)
                .WithOne(s => s.User);

            //// 1 Product - 1 User Order Product
            //_ = modelBuilder.Entity<Product>()
            //    .HasOne(s => s.UserOrderProduct)
            //    .WithOne(s => s.Product);

            //// 1 User Order - n User Order Product
            //_ = modelBuilder.Entity<UserOrder>()
            //    .HasMany(s => s.UserOrderProduct)
            //    .WithOne(s => s.UserOrder);
        }
    }
}
