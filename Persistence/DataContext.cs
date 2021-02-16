using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<PaymentHistory> PaymentHistories { get; set; }

        public DbSet<UserInfomationPayment> UserInfomationPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).ValueGeneratedOnAdd();

            });

            builder.Entity<UserInfomationPayment>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.HasOne(x => x.Order).WithOne(t => t.UserInfomationPayment).HasForeignKey<UserInfomationPayment>(x => x.OrderId);

            });

            builder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).ValueGeneratedOnAdd();

                entity.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);

            });

            builder.Entity<PaymentHistory>(entity =>
            {
                entity.HasKey(x => new { x.CourseId, x.UserId});

            });

            builder.Entity<UserInfomationPayment>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x=>x.Id).ValueGeneratedOnAdd();

                entity.HasOne(x => x.Order).WithOne(x => x.UserInfomationPayment).HasForeignKey<UserInfomationPayment>(x => x.OrderId);

            });
        }
    }
}
