using Hangfire.Server;
using HangFirePOC.Models;
using Microsoft.EntityFrameworkCore;

namespace HangFirePOC.Repositories
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<NumberDraw> NumberDraws { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aqui você pode configurar seu modelo usando Fluent API
            modelBuilder.Entity<NumberDraw>(entity =>
            {
                entity.HasKey(nd => nd.Id);
                entity.Property(nd => nd.Id)
        .HasColumnType("char(36)")
        .HasDefaultValueSql("UUID()");
                entity.Property(nd => nd.Number);

            });
        }
    }
}
