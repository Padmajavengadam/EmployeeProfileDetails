using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestEntityFrameworkMVCProj.Models
{
    public partial class AzureStorageEmulatorDb510Context : DbContext
    {
        public AzureStorageEmulatorDb510Context()
        {
        }

        public AzureStorageEmulatorDb510Context(DbContextOptions<AzureStorageEmulatorDb510Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Softlock> Softlocks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<SkillMap> SkillMap { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AzureStorageEmulatorDb510;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");



            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Softlock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Softlock");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerStatusComment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MgrLastUpdate).HasColumnType("datetime");

                entity.Property(e => e.ReqDate).HasColumnType("datetime");

                entity.Property(e => e.RequestMsg)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WfmRemark)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Users__536C85E5513A12C3");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
