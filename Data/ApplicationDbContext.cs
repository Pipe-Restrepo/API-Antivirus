using System;
using System.Collections.Generic;
using Api_Antivirus.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<bootcamp_topics> bootcamp_topics { get; set; }

    public virtual DbSet<bootcamps> bootcamps { get; set; }

    public virtual DbSet<categories> categories { get; set; }

    public virtual DbSet<institutions> institutions { get; set; }

    public virtual DbSet<opportunities> opportunities { get; set; }

    public virtual DbSet<topics> topics { get; set; }

    public virtual DbSet<user_opportunities> user_opportunities { get; set; }

    public virtual DbSet<users> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<bootcamp_topics>(entity =>
        {
            entity.HasKey(e => e.id).HasName("bootcamp_topics_pkey");

            entity.HasOne(d => d.bootcamp).WithMany(p => p.bootcamp_topics).HasConstraintName("bootcamp_topics_bootcamp_id_fkey");

            entity.HasOne(d => d.topic).WithMany(p => p.bootcamp_topics).HasConstraintName("bootcamp_topics_topic_id_fkey");
        });

        modelBuilder.Entity<bootcamps>(entity =>
        {
            entity.HasKey(e => e.id).HasName("bootcamps_pkey");

            entity.HasOne(d => d.institution).WithMany(p => p.bootcamps)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("bootcamps_institution_id_fkey");
        });

        modelBuilder.Entity<categories>(entity =>
        {
            entity.HasKey(e => e.id).HasName("categories_pkey");
        });

        modelBuilder.Entity<institutions>(entity =>
        {
            entity.HasKey(e => e.id).HasName("institutions_pkey");
        });

        modelBuilder.Entity<opportunities>(entity =>
        {
            entity.HasKey(e => e.id).HasName("opportunities_pkey");

            entity.HasOne(d => d.category).WithMany(p => p.opportunities)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("opportunities_category_id_fkey");

            entity.HasOne(d => d.institution).WithMany(p => p.opportunities)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("opportunities_institution_id_fkey");
        });

        modelBuilder.Entity<topics>(entity =>
        {
            entity.HasKey(e => e.id).HasName("topics_pkey");
        });

        modelBuilder.Entity<user_opportunities>(entity =>
        {
            entity.HasKey(e => e.id).HasName("user_opportunities_pkey");

            entity.HasOne(d => d.opportunity).WithMany(p => p.user_opportunities).HasConstraintName("user_opportunities_opportunity_id_fkey");

            entity.HasOne(d => d.user).WithMany(p => p.user_opportunities).HasConstraintName("user_opportunities_user_id_fkey");
        });

        modelBuilder.Entity<users>(entity =>
        {
            entity.HasKey(e => e.id).HasName("users_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
