using MovieRental.Model;
using MovieRental.ViewModel;

namespace MovieRental.DesignTimeViewModel;

public class SampleCustomerViewModel : CustomerViewModel {

    public SampleCustomerViewModel() : base(new Customer(1, "Shelly", "Estrada", "93117 Evansville", "1-871-372-7263")) {
    }

    public SampleCustomerViewModel(Customer customerModel) : base(customerModel) {}
}
