using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Migrations;

namespace Persistence.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Fuel> Fuels { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Transmission> Transmissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=RentACar; Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasIndex(e => e.Name, "UK_Brands_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasIndex(e => e.ModelId, "IX_Cars_ModelId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MinFindexScore).HasColumnName("MinFIndexScore");

            entity.HasOne(d => d.Model).WithMany(p => p.Cars).HasForeignKey(d => d.ModelId);
        });

        modelBuilder.Entity<Fuel>(entity =>
        {
            entity.HasIndex(e => e.Name, "UK_Fuels_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.Property(e => e.Level).HasMaxLength(128);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_Models_BrandId");

            entity.HasIndex(e => e.FuelId, "IX_Models_FuelId");

            entity.HasIndex(e => e.TransmissionId, "IX_Models_TransmissionId");

            entity.HasIndex(e => e.Name, "UK_Models_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DailyPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Brand).WithMany(p => p.Models).HasForeignKey(d => d.BrandId);

            entity.HasOne(d => d.Fuel).WithMany(p => p.Models).HasForeignKey(d => d.FuelId);

            entity.HasOne(d => d.Transmission).WithMany(p => p.Models).HasForeignKey(d => d.TransmissionId);
        });

        modelBuilder.Entity<Transmission>(entity =>
        {
            entity.HasIndex(e => e.Name, "UK_Transmissions_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
