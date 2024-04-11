using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PCCC.Data.Entities;

namespace PCCC.Data;

public partial class PcccContext : DbContext
{
    public PcccContext()
    {
    }

    public PcccContext(DbContextOptions<PcccContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdsUser> AdsUsers { get; set; }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<ApartmentUser> ApartmentUsers { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<Map> Maps { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PointArea> PointAreas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StatusContact> StatusContacts { get; set; }

    public virtual DbSet<UpgradeAccount> UpgradeAccounts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdsUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PremiumAccUsers_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.AdsId).HasColumnName("AdsID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Advertisements_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<ApartmentUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ApartmentUsers_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(256);
            entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.MapId).HasColumnName("MapID");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Areas_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.PointAreaId).HasColumnName("PointAreaID");
            entity.Property(e => e.Type).HasColumnType("character varying");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Buildings_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Address).HasColumnType("character varying");
            entity.Property(e => e.ApartmentUserId).HasColumnName("ApartmentUserID");
            entity.Property(e => e.Image).HasColumnType("character varying");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Contents_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Color).HasColumnType("character varying");
            entity.Property(e => e.Icon).HasColumnType("character varying");
            entity.Property(e => e.Image).HasColumnType("character varying");
            entity.Property(e => e.Link).HasColumnType("character varying");
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<Map>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Maps_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.BuiildingId).HasColumnName("BuiildingID");
            entity.Property(e => e.DisplayName).HasMaxLength(256);
            entity.Property(e => e.Image).HasColumnType("character varying");
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("News_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Image).HasColumnType("character varying");
            entity.Property(e => e.Title).HasColumnType("character varying");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Permissions_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<PointArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PointAreas_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Roles_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.DisplayName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);
        });

        modelBuilder.Entity<StatusContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("StatusContact_pkey");

            entity.ToTable("StatusContact");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Gmail).HasMaxLength(128);
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.Phone).HasColumnType("character varying");
            entity.Property(e => e.ReferralCode).HasMaxLength(10);
            entity.Property(e => e.Title).HasMaxLength(256);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<UpgradeAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UpgradeAccounts_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasColumnType("character varying");
            entity.Property(e => e.ApartmentUserId).HasColumnName("ApartmentUserID");
            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.CreatorUserName).HasColumnType("character varying");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FullName).HasColumnType("character varying");
            entity.Property(e => e.Password).HasColumnType("character varying");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.UpgradeAccId).HasColumnName("UpgradeAccID");
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UserRoles_pkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
