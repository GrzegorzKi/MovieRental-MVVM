using MovieRental.Helpers;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;
using System.Linq;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class MainWindowViewModel : ViewModelBase {

    public event Action<int?>? CustomerTabSwitchRequested;
    public event Action<int?>? MovieTabSwitchRequested;

    private ICommand? _selectCustomerToIssue;
    public ICommand SelectCustomerToIssue => _selectCustomerToIssue ??=
        new RelayCommand<CustomerViewModel>(SelectCustomerToIssueExecute, CanSelectCustomerToIssue);

    private ICommand? _selectMovieToIssue;
    public ICommand SelectMovieToIssue => _selectMovieToIssue ??=
        new RelayCommand<MovieViewModel>(SelectMovieToIssueTabExecute, CanSelectMovieToIssue);

    private ICommand? _findCustomerInList;
    public ICommand FindCustomerInList => _findCustomerInList ??=
        new RelayCommand<int?>(CustomerTabSwitchRequested!);

    private ICommand? _findMovieInList;
    public ICommand FindMovieInList => _findMovieInList ??=
        new RelayCommand<int?>(MovieTabSwitchRequested!);

    private readonly IDialogService _dialogService;

    protected CustomerViewModel? _customerToIssue;
    public CustomerViewModel? CustomerToIssue {
        get => _customerToIssue;
        set => SetProperty(ref _customerToIssue, value);
    }
    protected MovieViewModel? _movieToIssue;
    public MovieViewModel? MovieToIssue {
        get => _movieToIssue;
        set => SetProperty(ref _movieToIssue, value);
    }

    public MainWindowViewModel() {
        _dialogService = new DialogService();
    }

    internal void SelectCustomerToIssueExecute(CustomerViewModel? customerVM) {
        if (customerVM != null) {
            CustomerToIssue = customerVM;

            if (MovieToIssue != null) {
                IssueMovieToCustomer();
            } else {
                MovieTabSwitchRequested?.Invoke(null);
            }
        }
    }

    internal bool CanSelectCustomerToIssue(CustomerViewModel? e) {
        return MovieToIssue == null ||
            (e != null && e.RentedMovies.All((rm) => !(rm.MovieId.Equals(MovieToIssue.Id) && rm.DateReturned == null)));
    }

    internal void SelectMovieToIssueTabExecute(MovieViewModel? movieVM) {
        if (movieVM != null) {
            MovieToIssue = movieVM;

            if (CustomerToIssue != null) {
                IssueMovieToCustomer();
            } else {
                CustomerTabSwitchRequested?.Invoke(null);
            }
        }
    }

    internal bool CanSelectMovieToIssue(MovieViewModel? e) {
        return CustomerToIssue == null ||
            (e != null && e.RentedMovies.All((rm) => !(rm.CustomerId.Equals(CustomerToIssue.Id) && rm.DateReturned == null)));
    }

    internal void IssueMovieToCustomer() {
        if (CustomerToIssue != null && MovieToIssue != null) {
            DatabaseDao.AddRentedMovie(MovieToIssue.MovieModel, CustomerToIssue.CustomerModel);

            ResetRentalIssue();
            _dialogService.Success("Movie has been issued!", "Movie issued");
        }
    }

    internal void ResetRentalIssue() {
        CustomerToIssue = null;
        MovieToIssue = null;
    }
}
