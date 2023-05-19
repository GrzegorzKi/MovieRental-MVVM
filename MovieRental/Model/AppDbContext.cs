using Microsoft.EntityFrameworkCore;
using MovieRental.Model.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq.Expressions;

namespace MovieRental.Model;

internal class AppDbContext : DbContext {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<RentedMovie> RentedMovies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string connectionString = ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString;
        string databasePath = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}{connectionString}";

        System.Diagnostics.Debug.WriteLine(databasePath);

        optionsBuilder
            .UseSqlite(connectionString);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new SeedDataMovie());
        modelBuilder.ApplyConfiguration(new SeedDataCustomer());
        modelBuilder.ApplyConfiguration(new SeedDataRentedMovie());

        base.OnModelCreating(modelBuilder);
    }

    public void ReloadEntity<TEntity>(TEntity entity)
        where TEntity : class {
        Entry(entity).Reload();
    }

    public void ReloadNavigationProperty<TEntity, TElement>(TEntity entity,
        Expression<Func<TEntity, IEnumerable<TElement>>> navigationProperty)
        where TEntity : class
        where TElement : class {
        Entry(entity).Collection(navigationProperty).Query();
    }
}
