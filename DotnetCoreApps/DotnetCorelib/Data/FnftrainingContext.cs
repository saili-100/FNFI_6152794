using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorelib.Data;

public partial class FnftrainingContext : DbContext
{
    public FnftrainingContext()
    {
    }

    public FnftrainingContext(DbContextOptions<FnftrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptTable> DeptTables { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog = FNFTraining; Integrated Security = True; Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptTable>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__DeptTabl__6C274F014A050B75");

            entity.ToTable("DeptTable");

            entity.Property(e => e.DeptName).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB99D61A3745");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpAddress).HasMaxLength(200);
            entity.Property(e => e.EmpName).HasMaxLength(200);
            entity.Property(e => e.EmpSalary).HasColumnType("money");
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__Employee__ID__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
