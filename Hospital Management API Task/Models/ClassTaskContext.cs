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

    public virtual DbSet<DoctorMaster> DoctorMasters { get; set; }

    public virtual DbSet<PatientMaster> PatientMasters { get; set; }

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

        modelBuilder.Entity<PatientMaster>(entity =>
        {
            entity.HasKey(e => e.PatientID);

            entity.ToTable("PatientMaster");

            entity.Property(e => e.PatientID).HasColumnName("PatientID");
            entity.Property(e => e.PatientName).HasMaxLength(100);
            entity.Property(e => e.ContactNo).HasMaxLength(15);
            entity.Property(e => e.Age);
            entity.Property(e => e.EarlierOperation);
            entity.Property(e => e.BloodGroup).HasMaxLength(10);
        });

        modelBuilder.Entity<DoctorMaster>(entity =>
        {
            entity.HasKey(e => e.DoctorID);

            entity.ToTable("DoctorMaster");

            entity.Property(e => e.DoctorID).HasColumnName("DoctorID");
            entity.Property(e => e.DoctorName).HasMaxLength(100);
            entity.Property(e => e.Degree).HasMaxLength(50);
            entity.Property(e => e.Experience);
            entity.Property(e => e.Specialization).HasMaxLength(40);
            entity.Property(e => e.Age);
            entity.Property(e => e.DOB).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
