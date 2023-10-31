using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab4;

public partial class PharmacyContext : DbContext
{
    public PharmacyContext()
    {
    }

    public PharmacyContext(DbContextOptions<PharmacyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Outgoing> Outgoings { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LA9KVTH\\SQLEXPRESS;Initial Catalog=Pharmacy;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    
        
        

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.Property(e => e.ActiveSubstance).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ShortDescription).HasMaxLength(200);
            entity.Property(e => e.StorageLocation).HasMaxLength(50);
            entity.Property(e => e.UnitOfMeasurement).HasMaxLength(50);

            entity.HasOne(d => d.Producer).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.ProducerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicines_Producers");
        });

        

        

        modelBuilder.Entity<Outgoing>(entity =>
        {
            entity.ToTable("Outgoing");

            entity.Property(e => e.ImplementationDate).HasColumnType("date");
            entity.Property(e => e.SellingPrice).HasColumnType("money");

            entity.HasOne(d => d.MedicineName).WithMany(p => p.Outgoings)
                .HasForeignKey(d => d.MedicineNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Outgoing_Medicines");
        });

        

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.Property(e => e.Country).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
