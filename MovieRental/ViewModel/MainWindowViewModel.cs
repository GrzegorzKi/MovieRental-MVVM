using MovieRental.Commands;
using MovieRental.Model;
using MovieRental.View;
using MovieRental.View.Dialogs;
using System;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class MainWindowViewModel : ViewModelBase {

    public event Action<CustomerViewModel?>? CustomerTabSwitchRequested;
    public event Action<MovieViewModel?>? MovieTabSwitchRequested;

    private ICommand? _selectCustomerToIssue;
    public ICommand SelectCustomerToIssue => _selectCustomerToIssue ??=
        new RelayCommand<CustomerViewModel>(SelectCustomerToIssueExecute /* TODO Check if movie isn't already rented to customer */);

    private ICommand? _selectMovieToIssue;
    public ICommand SelectMovieToIssue => _selectMovieToIssue ??=
        new RelayCommand<MovieViewModel>(SelectMovieToIssueTabExecute /* TODO Check if movie isn't already rented to customer */);

    private ICommand? _findCustomerInList;
    public ICommand FindCustomerInList => _findCustomerInList ??=
        new RelayCommand<CustomerViewModel?>(CustomerTabSwitchRequested!);

    private ICommand? _findMovieInList;
    public ICommand FindMovieInList => _findMovieInList ??=
        new RelayCommand<MovieViewModel>(MovieTabSwitchRequested!);

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

    internal void IssueMovieToCustomer() {
        if (CustomerToIssue != null && MovieToIssue != null) {
            DatabaseDao.AddRentedMovie(MovieToIssue.MovieModel, CustomerToIssue.CustomerModel);

            _dialogService.Success("Movie has been issued!", "Movie issued");
            ResetRentalIssue();
        }
    }

    internal void ResetRentalIssue() {
        CustomerToIssue = null;
        MovieToIssue = null;
    }
}
