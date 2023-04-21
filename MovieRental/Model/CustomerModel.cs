namespace MovieRental.Model;

public class CustomerModel {
    public int? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public string FullName {
        get => $"{FirstName} {LastName}";
    }

    public CustomerModel()
        : this(null, "", "", "", "") { }

    public CustomerModel(string firstName, string lastName, string address, string phone)
        : this(null, firstName, lastName, address, phone) { }

    public CustomerModel(int? id, string firstName, string lastName, string address, string phone) {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Phone = phone;
    }

    public CustomerModel(CustomerModel copy) {
        Id = copy.Id;
        FirstName = copy.FirstName;
        LastName = copy.LastName;
        Address = copy.Address;
        Phone = copy.Phone;
    }
}
