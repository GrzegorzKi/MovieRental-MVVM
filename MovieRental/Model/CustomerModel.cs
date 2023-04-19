namespace MovieRental.Model;

public class CustomerModel {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public string FullName {
        get => $"{FirstName} {LastName}";
    }


    public CustomerModel(int id, string firstName, string lastName, string address, string phone) {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Phone = phone;
    }
}
