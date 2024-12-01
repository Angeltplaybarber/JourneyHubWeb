using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JourneyHubWeb.Models;

public partial class JourneyHubContext : DbContext
{
    public JourneyHubContext()
    {
    }

    public JourneyHubContext(DbContextOptions<JourneyHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<PackagePricing> PackagePricings { get; set; }

    public virtual DbSet<PackageType> PackageTypes { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ANGEL\\SQLEXPRESS;Initial Catalog=JourneyHub;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__75A5D718D985D66C");

            entity.Property(e => e.ClientId).HasColumnName("Client_ID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__Packages__B7FCB94AFF3ECFC2");

            entity.Property(e => e.PackageId).HasColumnName("Package_ID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.TypeId).HasColumnName("Type_ID");

            entity.HasOne(d => d.Type).WithMany(p => p.Packages)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__Packages__Type_I__4CA06362");
        });

        modelBuilder.Entity<PackagePricing>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK__Package___A4821BF26C0C75EC");

            entity.ToTable("Package_Pricing");

            entity.Property(e => e.PriceId).HasColumnName("Price_ID");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.PackageId).HasColumnName("Package_ID");
            entity.Property(e => e.PricePerPerson)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Price_Per_Person");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");

            entity.HasOne(d => d.Package).WithMany(p => p.PackagePricings)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK__Package_P__Packa__4F7CD00D");
        });

        modelBuilder.Entity<PackageType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Package___FE90DDFE01C3884A");

            entity.ToTable("Package_Types");

            entity.Property(e => e.TypeId).HasColumnName("Type_ID");
            entity.Property(e => e.TypeName)
                .HasMaxLength(100)
                .HasColumnName("Type_Name");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__DA6C7FE14205F2EC");

            entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate).HasColumnName("Payment_Date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("Payment_Method");
            entity.Property(e => e.ReservationId).HasColumnName("Reservation_ID");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK__Payments__Reserv__5812160E");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__17302A8D7DCEC897");

            entity.Property(e => e.ReservationId).HasColumnName("Reservation_ID");
            entity.Property(e => e.ClientId).HasColumnName("Client_ID");
            entity.Property(e => e.NumberOfPeople).HasColumnName("Number_Of_People");
            entity.Property(e => e.PackageId).HasColumnName("Package_ID");
            entity.Property(e => e.ReservationDate).HasColumnName("Reservation_Date");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_Price");

            entity.HasOne(d => d.Client).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Reservati__Clien__5441852A");

            entity.HasOne(d => d.Package).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK__Reservati__Packa__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
