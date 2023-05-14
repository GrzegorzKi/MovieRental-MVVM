using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace MovieRental.Model;

public class AppDbContext : DbContext {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string connectionString = ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString;
        string databasePath = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}{connectionString}";

        System.Diagnostics.Debug.WriteLine(databasePath);

        optionsBuilder
            .UseSqlite(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
}
