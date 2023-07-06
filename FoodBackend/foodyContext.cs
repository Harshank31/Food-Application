using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace foodbackend.Models
{
    public partial class foodyContext : DbContext
    {
        public foodyContext()
        {
        }

        public foodyContext(DbContextOptions<foodyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logindtl> Logindtls { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Mycart> Mycarts { get; set; }
        public virtual DbSet<Orderlist> Orderlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CBEDWQLQ12;initial catalog=foody;trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logindtl>(entity =>
            {
                entity.HasKey(e => e.Custid)
                    .HasName("PK__logindtl__049D3E8191395892");

                entity.ToTable("logindtl");

                entity.Property(e => e.Custid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CustPassword)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.FoodName)
                    .HasName("PK__menu__81B4FC24C83C3BE4");

                entity.ToTable("menu");

                entity.Property(e => e.FoodName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FoodCode).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Mycart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Mycart__51BCD79738599FAF");

                entity.ToTable("Mycart");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.Custid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FoodName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Mycarts)
                    .HasForeignKey(d => d.Custid)
                    .HasConstraintName("FK__Mycart__Custid__286302EC");

                entity.HasOne(d => d.FoodNameNavigation)
                    .WithMany(p => p.Mycarts)
                    .HasForeignKey(d => d.FoodName)
                    .HasConstraintName("FK__Mycart__FoodName__29572725");
            });

            modelBuilder.Entity<Orderlist>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("PK__orderlis__C3907C74BC69775E");

                entity.ToTable("orderlist");

                entity.Property(e => e.CustAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Custid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FoodName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orderlists)
                    .HasForeignKey(d => d.Custid)
                    .HasConstraintName("FK__orderlist__Custi__2C3393D0");

                entity.HasOne(d => d.FoodNameNavigation)
                    .WithMany(p => p.Orderlists)
                    .HasForeignKey(d => d.FoodName)
                    .HasConstraintName("FK__orderlist__FoodN__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
