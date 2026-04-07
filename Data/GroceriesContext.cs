using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GroceryApp.Data.Entities;

namespace GroceryApp.Data;

public partial class GroceriesContext : DbContext
{
    public GroceriesContext()
    {
    }

    public GroceriesContext(DbContextOptions<GroceriesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GroceryItem> GroceryItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroceryItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groceryitems_pkey");

            entity.ToTable("grocery_items");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('groceryitems_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.IsCompleted)
                .HasDefaultValue(false)
                .HasColumnName("iscompleted");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
