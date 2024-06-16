using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Spark.EquipTests.Desktop.Models;

public partial class SparcEquipTestContext : DbContext
{
    public SparcEquipTestContext()
    {
    }

    public SparcEquipTestContext(DbContextOptions<SparcEquipTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Parameter> Parameters { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SparcEquipTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parameter>(entity =>
        {
            entity.HasKey(e => new { e.ParameterId, e.TestId });

            entity.Property(e => e.ParameterId).ValueGeneratedOnAdd();
            entity.Property(e => e.MeasuredValue).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ParameterName).HasMaxLength(200);
            entity.Property(e => e.RequiredValue).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Test).WithMany(p => p.Parameters)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Parameters_Tests");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.Property(e => e.Blockname).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(200);
            entity.Property(e => e.TestDate).HasColumnType("smalldatetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
