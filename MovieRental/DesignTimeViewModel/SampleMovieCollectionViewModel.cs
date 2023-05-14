using MovieRental.Model;
using MovieRental.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieRental.DesignTimeViewModel;

public class SampleMovieCollectionViewModel : MovieColletionViewModel {

    public SampleMovieCollectionViewModel() : base(new List<Movie>() {
        new Model.Movie("The Shawshank Redemption","1994","crime, drama","",3),
        new Model.Movie("The Godfather","1972","crime, drama","",3),
        new Model.Movie("The Dark Knight","2008","action, crime, drama","",3),
        new Model.Movie("The Godfather: Part II","1974","crime, drama","",3),
        new Model.Movie("12 Angry Men","1957","drama","",3),
        new Model.Movie("Schindler's List","1993","biography, drama, history","",3),
        new Model.Movie("The Lord of the Rings: The Return of the King","2003","action, adventure, fantasy","",3),
        new Model.Movie("Pulp Fiction","1994","crime, drama","",3),
        new Model.Movie("The Lord of the Rings: The Fellowship of the Ring","2001","action, adventure, fantasy","",3),
        new Model.Movie("The Good, the Bad and the Ugly","1966","western","",3),
        new Model.Movie("Forrest Gump","1994","drama, romance","",3),
        new Model.Movie("Fight Club","1999","drama","",3),
        new Model.Movie("The Lord of the Rings: The Two Towers","2002","adventure, fantasy","",3),
        new Model.Movie("Inception","2010","action, adventure, sci-fi","",3),
        new Model.Movie("Star Wars: Episode V - The Empire Strikes Back","1980","action, adventure, fantasy","",3),
        new Model.Movie("The Matrix","1999","action, sci-fi","",3),
        new Model.Movie("Goodfellas","1990","biography, crime, drama","",3),
        new Model.Movie("One Flew Over the Cuckoo's Nest","1975","drama","",3),
        new Model.Movie("Se7en","1995","drama, mystery, thriller","",3),
        new Model.Movie("It's a Wonderful Life","1946","drama, family, fantasy","",3),
        new Model.Movie("Seven Samurai","1954","action, adventure, drama","",3),
        new Model.Movie("The Silence of the Lambs","1991","crime, drama, thriller","",3),
        new Model.Movie("Saving Private Ryan","1998","action, drama, war","",3),
        new Model.Movie("City of God","2002","crime, drama","",3),
        new Model.Movie("Interstellar","2014","adventure, drama, sci-fi","",3),
        new Model.Movie("Life Is Beautiful","1997","comedy, drama, romance","",3),
        new Model.Movie("The Green Mile","1999","crime, drama, fantasy","",3),
        new Model.Movie("Star Wars","1977","action, adventure, fantasy","",3),
        new Model.Movie("Terminator 2: Judgment Day","1991","action, sci-fi, thriller","",3),
        new Model.Movie("Back to the Future","1985","adventure, comedy, sci-fi","",3),
        new Model.Movie("Spirited Away","2001","adventure, animation, family","",3),
        new Model.Movie("The Pianist","2002","biography, drama, war","",3),
        new Model.Movie("Psycho","1960","horror, mystery, thriller","",3),
        new Model.Movie("Parasite","2019","drama, thriller","",3),
        new Model.Movie("Léon: The Professional","1994","crime, drama, thriller","",3),
        new Model.Movie("Gladiator","2000","action, drama","",3),
        new Model.Movie("The Lion King","1994","adventure, animation, drama","",3),
        new Model.Movie("American History X","1998","crime, drama","",3),
        new Model.Movie("The Departed","2006","crime, drama, thriller","",3),
        new Model.Movie("Whiplash","2014","drama, music","",3),
        new Model.Movie("The Prestige","2006","drama, mystery, thriller","",3),
        new Model.Movie("The Usual Suspects","1995","crime, drama, thriller","",3),
        new Model.Movie("Casablanca","1942","drama, romance, war","",3),
        new Model.Movie("Hotaru no haka","1988","animation, drama, war","",3),
        new Model.Movie("Seppuku","1962","action, drama, history","",3),
        new Model.Movie("Intouchables","2011","biography, comedy, drama","",3),
        new Model.Movie("Modern Times","1936","comedy, drama","",3),
        new Model.Movie("C'era una volta il West","1968","western","",3),
        new Model.Movie("Nuovo Cinema Paradiso","1988","drama","",3),
        new Model.Movie("Rear Window","1954","mystery, thriller","",3)
    }) {}
}
