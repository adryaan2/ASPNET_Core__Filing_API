using System;
using System.Collections.Generic;
using Filing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Filing_API.Data;

public partial class FilingDbContext : DbContext
{
    public FilingDbContext()
    {
    }

    public FilingDbContext(DbContextOptions<FilingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryT> CategoryTs { get; set; }

    public virtual DbSet<ContactModT> ContactModTs { get; set; }

    public virtual DbSet<ContactT> ContactTs { get; set; }

    public virtual DbSet<DeliveryModeT> DeliveryModeTs { get; set; }

    public virtual DbSet<DirectionT> DirectionTs { get; set; }

    public virtual DbSet<DocumentContactJ> DocumentContactJs { get; set; }

    public virtual DbSet<DocumentModT> DocumentModTs { get; set; }

    public virtual DbSet<DocumentT> DocumentTs { get; set; }

    public virtual DbSet<IktatoszamModT> IktatoszamModTs { get; set; }

    public virtual DbSet<IktatoszamT> IktatoszamTs { get; set; }

    public virtual DbSet<PartnerT> PartnerTs { get; set; }

    public virtual DbSet<ProjectT> ProjectTs { get; set; }

    public virtual DbSet<UserT> UserTs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:FilingServer");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_t_pkey");

            entity.ToTable("category_t");

            entity.HasIndex(e => e.Name, "category_t_name_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ContactModT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contact_mod_t_pkey");

            entity.ToTable("contact_mod_t");

            entity.HasIndex(e => e.ContactId, "contact_mod_contact_i");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.JsonData)
                .HasMaxLength(4096)
                .HasColumnName("json_data");
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_date");

            entity.HasOne(d => d.Contact).WithMany(p => p.ContactModTs)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contact_mod_contact_fk");
        });

        modelBuilder.Entity<ContactT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contact_t_pkey");

            entity.ToTable("contact_t");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(1024)
                .HasColumnName("address");
            entity.Property(e => e.EMail)
                .HasMaxLength(255)
                .HasColumnName("e_mail");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(32)
                .HasColumnName("phone_number");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .HasColumnName("title");
        });

        modelBuilder.Entity<DeliveryModeT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("delivery_mode_t_pkey");

            entity.ToTable("delivery_mode_t");

            entity.HasIndex(e => e.Name, "delivery_mode_t_name_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DirectionT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("direction_t_pkey");

            entity.ToTable("direction_t");

            entity.HasIndex(e => e.Name, "direction_t_name_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DocumentContactJ>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_contact_j_pkey");

            entity.ToTable("document_contact_j");

            entity.HasIndex(e => e.ContactId, "document_contact_contact_i");

            entity.HasIndex(e => e.DocumentId, "document_contact_document_i");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");

            entity.HasOne(d => d.Contact).WithMany(p => p.DocumentContactJs)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_contact_contact_fk");

            entity.HasOne(d => d.Document).WithMany(p => p.DocumentContactJs)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_contact_document_fk");
        });

        modelBuilder.Entity<DocumentModT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_mod_t_pkey");

            entity.ToTable("document_mod_t");

            entity.HasIndex(e => e.DocumentId, "document_mod_document_i");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.JsonData)
                .HasMaxLength(4096)
                .HasColumnName("json_data");
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_date");

            entity.HasOne(d => d.Document).WithMany(p => p.DocumentModTs)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_mod_document_fk");
        });

        modelBuilder.Entity<DocumentT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_t_pkey");

            entity.ToTable("document_t");

            entity.HasIndex(e => e.Category, "document_category_i");

            entity.HasIndex(e => e.Direction, "document_direction_i");

            entity.HasIndex(e => e.IktatoszamId, "document_iktatoszam_i");

            entity.HasIndex(e => e.Iktatoszam, "document_t_iktatoszam_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("delivery_date");
            entity.Property(e => e.DeliveryMode).HasColumnName("delivery_mode");
            entity.Property(e => e.Direction).HasColumnName("direction");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.FilePath)
                .HasMaxLength(2048)
                .HasColumnName("file_path");
            entity.Property(e => e.Iktatoszam)
                .HasMaxLength(32)
                .HasColumnName("iktatoszam");
            entity.Property(e => e.IktatoszamId).HasColumnName("iktatoszam_id");
            entity.Property(e => e.PartnerIktatoszam)
                .HasMaxLength(32)
                .HasColumnName("partner_iktatoszam");
            entity.Property(e => e.PhysicalLocation)
                .HasMaxLength(2048)
                .HasColumnName("physical_location");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.DocumentTs)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_category_fk");

            entity.HasOne(d => d.DeliveryModeNavigation).WithMany(p => p.DocumentTs)
                .HasForeignKey(d => d.DeliveryMode)
                .HasConstraintName("document_delivery_fk");

            entity.HasOne(d => d.DirectionNavigation).WithMany(p => p.DocumentTs)
                .HasForeignKey(d => d.Direction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_direction_fk");

            entity.HasOne(d => d.IktatoszamNavigation).WithMany(p => p.DocumentTs)
                .HasForeignKey(d => d.IktatoszamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_iktatoszam_fk");
        });

        modelBuilder.Entity<IktatoszamModT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("iktatoszam_mod_t_pkey");

            entity.ToTable("iktatoszam_mod_t");

            entity.HasIndex(e => e.IktatoszamId, "iktatoszam_mod_iktatoszam_i");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.IktatoszamId).HasColumnName("iktatoszam_id");
            entity.Property(e => e.JsonData)
                .HasMaxLength(4096)
                .HasColumnName("json_data");
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_date");

            entity.HasOne(d => d.Iktatoszam).WithMany(p => p.IktatoszamModTs)
                .HasForeignKey(d => d.IktatoszamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iktatoszam_mod_iktatoszam_fk");
        });

        modelBuilder.Entity<IktatoszamT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("iktatoszam_t_pkey");

            entity.ToTable("iktatoszam_t");

            entity.HasIndex(e => e.PartnerId, "iktatoszam_partner_i");

            entity.HasIndex(e => e.ProjectId, "iktatoszam_project_i");

            entity.HasIndex(e => e.Iktatoszam, "iktatoszam_t_iktatoszam_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Iktatoszam)
                .HasMaxLength(32)
                .HasColumnName("iktatoszam");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.Partner).WithMany(p => p.IktatoszamTs)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("iktatoszam_partner_fk");

            entity.HasOne(d => d.Project).WithMany(p => p.IktatoszamTs)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("iktatoszam_project_fk");
        });

        modelBuilder.Entity<PartnerT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partner_t_pkey");

            entity.ToTable("partner_t");

            entity.HasIndex(e => e.Name, "partner_t_name_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(1024)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProjectT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_t_pkey");

            entity.ToTable("project_t");

            entity.HasIndex(e => e.Name, "project_t_name_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Subject)
                .HasMaxLength(1024)
                .HasColumnName("subject");
        });

        modelBuilder.Entity<UserT>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_t_pkey");

            entity.ToTable("user_t");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(128)
                .HasColumnName("display_name");
            entity.Property(e => e.EMail)
                .HasMaxLength(255)
                .HasColumnName("e_mail");
            entity.Property(e => e.Secret)
                .HasMaxLength(128)
                .HasColumnName("secret");
            entity.Property(e => e.UserName)
                .HasMaxLength(128)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
