using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BHR.Models.DB
{
    public partial class DBHRDBContext : DbContext
    {
        public DBHRDBContext()
        {
        }

        public DBHRDBContext(DbContextOptions<DBHRDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContentBlock> ContentBlock { get; set; }
        public virtual DbSet<Page> Page { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=dbhrdb.cx2jht4dkjlf.us-east-2.rds.amazonaws.com,1433;Database=DBHRDB;User id=IA_admin;Password=ghCc8LfVB93KEzwYc6zy");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentBlock>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Header).IsRequired();

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.ContentBlock)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContentBl__PageI__3F466844");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
