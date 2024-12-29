using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FakeBK.Models;

public partial class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Orgperson> Orgpeople { get; set; }

    public virtual DbSet<Relative> Relatives { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teachclass> Teachclasses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public  DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AssDB;Username=postgres;Password=p123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("class_pkey");

            entity.ToTable("class");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("course_pkey");

            entity.ToTable("course");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasColumnName("name");

            entity.HasOne(d => d.Dept).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("course_dept_id_fkey");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("department_pkey");

            entity.ToTable("department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HeadteachId).HasColumnName("headteach_id");

            //entity.HasOne(d => d.Headteach).WithMany(p => p.Departments)
            //    .HasForeignKey(d => d.HeadteachId)
            //    .OnDelete(DeleteBehavior.SetNull)
            //    .HasConstraintName("fk_head_dept");
        });

        modelBuilder.Entity<Orgperson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orgperson_pkey");

            entity.ToTable("orgperson");

            entity.Property(e => e.Id).HasColumnName("id");
            
        });

        modelBuilder.Entity<Relative>(entity =>
        {
            entity.HasKey(e => new { e.OrgpId, e.Name }).HasName("relative_pkey");

            entity.ToTable("relative");

            entity.Property(e => e.OrgpId).HasColumnName("orgp_id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name"); // Removed the computed column configuration

            entity.HasOne(d => d.Orgp).WithMany(p => p.Relatives)
                .HasForeignKey(d => d.OrgpId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("relative_orgp_id_fkey");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.OrgpId).HasColumnName("orgp_id");

           


            
        });

        modelBuilder.Entity<Teachclass>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.CourseId }).HasName("teachclass_pkey");

            entity.ToTable("teachclass");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Class).WithMany(p => p.Teachclasses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("teachclass_class_id_fkey");

            entity.HasOne(d => d.Course).WithMany(p => p.Teachclasses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("teachclass_course_id_fkey");

            //entity.HasOne(d => d.Teacher).WithMany(p => p.Teachclasses)
            //    .HasForeignKey(d => d.TeacherId)
            //    .OnDelete(DeleteBehavior.SetNull)
            //    .HasConstraintName("teachclass_teacher_id_fkey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teacher_pkey");

            entity.ToTable("teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.OrgpId).HasColumnName("orgp_id");

            entity.HasOne(d => d.Dept).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("teacher_dept_id_fkey");

            entity.HasOne(d => d.Orgp).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.OrgpId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("teacher_orgp_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
