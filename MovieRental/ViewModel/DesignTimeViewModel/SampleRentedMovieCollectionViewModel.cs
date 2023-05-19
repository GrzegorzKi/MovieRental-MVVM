using MovieRental.Model;
using MovieRental.ViewModel;
using System;
using System.Collections.Generic;

namespace MovieRental.DesignTimeViewModel;

public class SampleRentedMovieCollectionViewModel : RentedMovieCollectionViewModel {

    public SampleRentedMovieCollectionViewModel() : base(new List<RentedMovie>() {
        new Model.RentedMovie(
            new Model.Movie(1,"The Shawshank Redemption","1994","crime, drama","Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.",3),
            new Customer(1,"Shelly","Estrada","93117 Evansville","1-871-372-7263"),
            DateTime.Now,
            null
        ),
        new Model.RentedMovie(
            new Model.Movie(2,"The Godfather","1972","crime, drama","Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. However, his decision unintentionally puts the lives of his loved ones in grave danger.",3),
            new Customer(4,"Cade","Casey","74577 Atlanta","1-724-363-8148"),
            DateTime.Now,
            null
        ),
        new Model.RentedMovie(
            new Model.Movie(3,"The Dark Knight","2008","action, crime, drama","When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",3),
            new Customer(14,"Noah","Klein","73836 Metairie","1-127-947-2433"),
            DateTime.Now.AddDays(-2),
            null
        ),
        new Model.RentedMovie(
            new Model.Movie(4,"The Godfather: Part II","1974","crime, drama","In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",3),
            new Customer(1,"Shelly","Estrada","93117 Evansville","1-871-372-7263"),
            DateTime.Now.AddDays(-28),
            DateTime.Now
        ),
        new Model.RentedMovie(
            new Model.Movie(5,"12 Angry Men","1957","drama","Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",3),
            new Customer(11,"Louis","Strickland","94770 Jacksonville","1-430-859-3268"),
            DateTime.Now.AddDays(-1),
            null
        ),
        new Model.RentedMovie(
            new Model.Movie(6,"Schindler's List","1993","biography, drama, history","The jury in a New York City murder trial is frustrated by a single member whose skeptical caution forces them to more carefully consider the evidence before jumping to a hasty verdict.",3),
            new Customer(7,"Elijah","Mcneil","36002 Olathe","1-245-286-2854"),
            DateTime.Now.AddDays(-1),
            null
        ),
        new Model.RentedMovie(
            new Model.Movie(7,"The Lord of the Rings: The Return of the King","2003","action, adventure, fantasy","The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",3),
            new Customer(4,"Cade","Casey","74577 Atlanta","1-724-363-8148"),
            DateTime.Now.AddDays(-7),
            DateTime.Now
       ),
    }) { }
}
