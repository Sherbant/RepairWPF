using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RepairWPF.Models;

public partial class RepairDbContext : DbContext
{
    public RepairDbContext()
    {
    }

    public RepairDbContext(DbContextOptions<RepairDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2FQDAQ9\\SQLEXPRESS;Database=RepairDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07AC72318E");

            entity.HasOne(d => d.Master).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__Master__403A8C7D");

            entity.HasOne(d => d.Request).WithMany(p => p.Comments)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__Reques__412EB0B6");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Requests__3214EC072C0BAE70");

            entity.Property(e => e.HomeTechModel).HasMaxLength(100);
            entity.Property(e => e.HomeTechType).HasMaxLength(50);

            entity.HasOne(d => d.Client).WithMany(p => p.RequestClients)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Requests__Client__3C69FB99");

            entity.HasOne(d => d.Master).WithMany(p => p.RequestMasters)
                .HasForeignKey(d => d.MasterId)
                .HasConstraintName("FK__Requests__Master__3D5E1FD2");

            entity.HasOne(d => d.Status).WithMany(p => p.Requests)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Requests__Status__3B75D760");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Statuses__3214EC07A82BCBF8");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0787874DFF");

            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
