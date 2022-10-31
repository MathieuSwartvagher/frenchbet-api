using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Models.Models
{
    public partial class frenchbetContext : DbContext
    {
        public frenchbetContext()
        {
        }

        public frenchbetContext(DbContextOptions<frenchbetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Community> Communities { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=tcp:frenchbet.database.windows.net,1433;Initial Catalog=frenchbet;Persist Security Info=False;User ID=frenchbet-admin;Password=Mathieuenigma2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Community>(entity =>
            {
                entity.HasKey(e => e.ComName);

                entity.Property(e => e.ComName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("comName");

                entity.Property(e => e.ComDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comDesc");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => new { e.ComName, e.UsrName });

                entity.Property(e => e.ComName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("comName");

                entity.Property(e => e.UsrName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("usrName");

                entity.Property(e => e.MemAskingMessage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("memAskingMessage");

                entity.Property(e => e.MemIsAdmin).HasColumnName("memIsAdmin");

                entity.Property(e => e.MemIsAsking).HasColumnName("memIsAsking");

                entity.HasOne(d => d.ComNameNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.ComName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_Communities");

                entity.HasOne(d => d.UsrNameNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.UsrName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsrName);

                entity.Property(e => e.UsrName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("usrName");

                entity.Property(e => e.UsrMail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usrMail");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
