using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Thermometer.Database
{
    public partial class databaseContext : DbContext
    {
        public databaseContext()
        {
        }

        public databaseContext(DbContextOptions<databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=./database.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Timestamp);

                entity.ToTable("log");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("NUMERIC")
                    .HasColumnName("timestamp");

                entity.Property(e => e.Co2)
                    .HasColumnType("NUMERIC")
                    .HasColumnName("co2");

                entity.Property(e => e.Humi)
                    .HasColumnType("NUMERIC")
                    .HasColumnName("humi");

                entity.Property(e => e.Temp)
                    .HasColumnType("NUMERIC")
                    .HasColumnName("temp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
