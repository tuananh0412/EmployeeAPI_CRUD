using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI_CRUD.Models;

public partial class EmployeeApiContext : DbContext
{
    public EmployeeApiContext()
    {
    }

    public EmployeeApiContext(DbContextOptions<EmployeeApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DateCreated);
            entity.Property(e => e.IsDeleted);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
