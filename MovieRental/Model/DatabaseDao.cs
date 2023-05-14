using Microsoft.EntityFrameworkCore;
using MovieRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.Model;

internal static class DatabaseDao {

    public static event Action? CustomersChanged;
    public static event Action? MoviesChanged;
    public static event Action? MoviesRentedChanged;

    public static IEnumerable<CustomerViewModel> GetCustomerViewModels() {
        using var context = new AppDbContext();

        return context.Customers
            .Include(p => p.RentedMovies)
            .Select(e => new CustomerViewModel(e)).ToList();
    }

    public static async Task<IEnumerable<CustomerViewModel>> GetCustomerViewModelsAsync() {
        using var context = new AppDbContext();

        return await context.Customers
            .Include(p => p.RentedMovies)
            .Select(e => new CustomerViewModel(e)).ToListAsync();
    }

    public static IEnumerable<MovieViewModel> GetMovieViewModels() {
        using var context = new AppDbContext();

        return context.Movies
            .Include(p => p.RentedMovies)
            .Select(e => new MovieViewModel(e)).ToList();
    }

    public static async Task<IEnumerable<MovieViewModel>> GetMovieViewModelsAsync() {
        using var context = new AppDbContext();

        return await context.Movies
            .Include(p => p.RentedMovies)
            .Select(e => new MovieViewModel(e)).ToListAsync();
    }

    public static void UpdateCustomer(Customer customer) {
        using var context = new AppDbContext();

        if (customer.Id == null) {
            context.Customers.Add(customer);
            context.SaveChanges();
        } else {
            var dbCustomer = context.Customers.Find(customer.Id);
            if (dbCustomer == null)
                return;
            context.Entry(dbCustomer).CurrentValues.SetValues(customer);
            context.SaveChanges();
        }

        CustomersChanged?.Invoke();
    }

    public static bool DeleteCustomer(Customer customer) {
        using var context = new AppDbContext();

        var dbCustomer = context.Customers.Find(customer.Id);
        if (dbCustomer == null) {
            return false;
        }

        context.Customers.Remove(dbCustomer);
        context.SaveChanges();

        CustomersChanged?.Invoke();
        return true;
    }

    public static void UpdateMovie(Movie movie) {
        using var context = new AppDbContext();

        if (movie.Id == null) {
            context.Movies.Add(movie);
            context.SaveChanges();
        } else {
            var dbMovie = context.Movies.Find(movie.Id);
            if (dbMovie == null)
                return;
            context.Entry(dbMovie).CurrentValues.SetValues(movie);
            context.SaveChanges();
        }

        MoviesChanged?.Invoke();
    }

    public static bool DeleteMovie(Movie movie) {
        using var context = new AppDbContext();

        var dbMovie = context.Movies.Find(movie.Id);
        if (dbMovie == null)
            return false;

        context.Movies.Remove(dbMovie);
        context.SaveChanges();

        MoviesChanged?.Invoke();
        return true;
    }

    public static void AddRentedMovie(Movie movieToIssue, Customer customerToIssue) {
        using var context = new AppDbContext();

        var rentedMovie = new RentedMovie((int) movieToIssue.Id!, (int) customerToIssue.Id!, DateTime.Now, null);
        context.Add(rentedMovie);
        context.SaveChanges();

        CustomersChanged?.Invoke();
        MoviesChanged?.Invoke();
        MoviesRentedChanged?.Invoke();
    }
}
