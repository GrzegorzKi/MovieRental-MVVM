using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRental.Model;

[Table("Customer")]
public class Customer {
    [Key]
    public int? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public virtual ICollection<RentedMovie> RentedMovies { get; } = new List<RentedMovie>();

    [Timestamp]
    public long? RowVersion { get; set; }

    public Customer()
        : this(null, "", "", "", "") { }

    public Customer(string firstName, string lastName, string address, string phone)
        : this(null, firstName, lastName, address, phone) { }

    public Customer(int? id, string firstName, string lastName, string address, string phone) {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Phone = phone;
    }

    public Customer(Customer copy) {
        Id = copy.Id;
        FirstName = copy.FirstName;
        LastName = copy.LastName;
        Address = copy.Address;
        Phone = copy.Phone;
        RentedMovies = new List<RentedMovie>(copy.RentedMovies);
    }
}
