using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Models;

public partial class ClassTaskContext : DbContext
{
    public ClassTaskContext()
    {
    }

    public ClassTaskContext(DbContextOptions<ClassTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HospitalMaster> HospitalMasters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HospitalMaster>(entity =>
        {
            entity.HasKey(e => e.HospitalId);

            entity.ToTable("HospitalMaster");

            entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
            entity.Property(e => e.ContactNumber).HasMaxLength(50);
            entity.Property(e => e.EmailAddress).HasMaxLength(30);
            entity.Property(e => e.HospitalAddress).HasMaxLength(100);
            entity.Property(e => e.HospitalName).HasMaxLength(100);
            entity.Property(e => e.OpeningDate).HasColumnType("datetime");
            entity.Property(e => e.OwnerName).HasMaxLength(70);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudentGender).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
