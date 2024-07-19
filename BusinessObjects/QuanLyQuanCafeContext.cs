using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects;

public partial class QuanLyQuanCafeContext : DbContext
{
    public QuanLyQuanCafeContext()
    {
    }

    public QuanLyQuanCafeContext(DbContextOptions<QuanLyQuanCafeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillInfo> BillInfos { get; set; }

    public virtual DbSet<Drink> Drinks { get; set; }

    public virtual DbSet<DrinkCategory> DrinkCategories { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MTRINH\\SQL2019;Database= QuanLyQuanCafe;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A686E162BB");

            entity.ToTable("Account");

            entity.Property(e => e.PassWord)
                .HasMaxLength(1000)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasDefaultValue("Noob");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bill__11F2FC6A53A108EC");

            entity.ToTable("Bill");

            entity.Property(e => e.DateCheckIn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateCheckOut).HasColumnType("datetime");

            entity.HasOne(d => d.IdTableNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.IdTable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bill__IdTable__38996AB5");
        });

        modelBuilder.Entity<BillInfo>(entity =>
        {
            entity.HasKey(e => e.BillInfoId).HasName("PK__BillInfo__82266B238DFAB85C");

            entity.ToTable("BillInfo");

            entity.Property(e => e.Count).HasColumnName("count");

            entity.HasOne(d => d.IdBillNavigation).WithMany(p => p.BillInfos)
                .HasForeignKey(d => d.IdBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillInfo__IdBill__398D8EEE");

            entity.HasOne(d => d.IdDrinkNavigation).WithMany(p => p.BillInfos)
                .HasForeignKey(d => d.IdDrink)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillInfo__IdDrin__3A81B327");
        });

        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.DrinkId).HasName("PK__Drink__C094D3E838FAA284");

            entity.ToTable("Drink");

            entity.Property(e => e.DrinkName)
                .HasMaxLength(100)
                .HasDefaultValue("Chưa đặt tên");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Drinks)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Drink__IdCategor__3B75D760");
        });

        modelBuilder.Entity<DrinkCategory>(entity =>
        {
            entity.HasKey(e => e.DrinkCategoryId).HasName("PK__DrinkCat__1C6320D291AD6DF9");

            entity.ToTable("DrinkCategory");

            entity.Property(e => e.DrinkCategoryName)
                .HasMaxLength(100)
                .HasDefaultValue("Chưa đặt tên");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__Table__7D5F01EE138580A6");

            entity.ToTable("Table");

            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasDefaultValue("Bàn chưa có tên");
            entity.Property(e => e.TableStatus)
                .HasMaxLength(100)
                .HasDefaultValue("Trống");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
