using KhoThoExe.Models;
using Microsoft.EntityFrameworkCore;

namespace KhoThoExe.Data
{
    public class KhoThoContext : DbContext
    {
        public KhoThoContext(DbContextOptions<KhoThoContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<WorkerJobType> WorkerJobTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkerJobType>()
                .HasKey(wj => new { wj.WorkerID, wj.JobTypeID });

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Worker)
                .WithMany()
                .HasForeignKey(r => r.WorkerID)
                .OnDelete(DeleteBehavior.Restrict); // Sử dụng Restrict

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerID)
                .OnDelete(DeleteBehavior.Cascade); // Vẫn giữ Cascade cho CustomerID

            base.OnModelCreating(modelBuilder);
        }

    }
}
