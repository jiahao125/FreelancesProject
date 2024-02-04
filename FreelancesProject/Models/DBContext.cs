using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FreelancesProject.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Freelancer> Freelancers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=tcp:testing125.database.windows.net,1433;Database=TestingDB;Persist Security Info=False;User ID=AdminAcc;Password=890123456Ji@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;Connect Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Freelancer>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.RowId)
                    .ValueGeneratedNever()
                    .HasColumnName("RowID");

                entity.Property(e => e.EmailAddress).HasMaxLength(200);

                entity.Property(e => e.Hobby).HasMaxLength(200);

                entity.Property(e => e.PhoneNum).HasMaxLength(20);

                entity.Property(e => e.SkillSet).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
