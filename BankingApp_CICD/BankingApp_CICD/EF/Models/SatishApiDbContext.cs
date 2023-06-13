using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankingApp_CICD.EF.Models;

public partial class SatishApiDbContext : DbContext
{
    public SatishApiDbContext()
    {
    }

    public SatishApiDbContext(DbContextOptions<SatishApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountDetail> AccountDetails { get; set; }

    public virtual DbSet<AccountDetailsNew> AccountDetailsNews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:apiinstance.database.windows.net,1433;Initial Catalog=satish_apiDB;Persist Security Info=False;User ID=axaadmin;Password=Password@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AccBalance).HasColumnName("accBalance");
            entity.Property(e => e.AccId)
                .ValueGeneratedOnAdd()
                .HasColumnName("accId");
            entity.Property(e => e.AccName)
                .HasMaxLength(100)
                .HasColumnName("accName");
            entity.Property(e => e.AccNo).HasColumnName("accNo");
            entity.Property(e => e.AccType)
                .HasMaxLength(40)
                .HasColumnName("accType");
        });

        modelBuilder.Entity<AccountDetailsNew>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK__AccountD__A471AFDAF409C0BB");

            entity.ToTable("AccountDetailsNew");

            entity.Property(e => e.AccId).HasColumnName("accId");
            entity.Property(e => e.AccBalance).HasColumnName("accBalance");
            entity.Property(e => e.AccName)
                .HasMaxLength(100)
                .HasColumnName("accName");
            entity.Property(e => e.AccNo).HasColumnName("accNo");
            entity.Property(e => e.AccType)
                .HasMaxLength(40)
                .HasColumnName("accType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
