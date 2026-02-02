using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Data;

public partial class AppDbContext : DbContext
{
    //make constructor to receive DbContextOptions object that take the connection string from programe.cs file
    public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    public virtual DbSet<Product> Products { get; set; }
    //we congigure the connection string in programe.cs file with dependency injection method
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=.;Initial catalog = Products;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07B0D8E7DD");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

    }
}
