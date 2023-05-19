using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MovieRental.Model.Configuration;

internal class SeedDataMovie : IEntityTypeConfiguration<Movie> {
    public void Configure(EntityTypeBuilder<Movie> builder) {
        _ = builder.HasData(
            new Movie(1, "The Shawshank Redemption", "1994", "crime, drama", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", 3),
            new Movie(2, "The Godfather", "1972", "crime, drama", "Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. However, his decision unintentionally puts the lives of his loved ones in grave danger.", 3),
            new Movie(3, "The Dark Knight", "2008", "action, crime, drama", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 3),
            new Movie(4, "The Godfather: Part II", "1974", "crime, drama", "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", 3),
            new Movie(5, "12 Angry Men", "1957", "drama", "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", 3),
            new Movie(6, "Schindler's List", "1993", "biography, drama, history", "The jury in a New York City murder trial is frustrated by a single member whose skeptical caution forces them to more carefully consider the evidence before jumping to a hasty verdict.", 3),
            new Movie(7, "The Lord of the Rings: The Return of the King", "2003", "action, adventure, fantasy", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", 3),
            new Movie(8, "Pulp Fiction", "1994", "crime, drama", "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 3),
            new Movie(9, "The Lord of the Rings: The Fellowship of the Ring", "2001", "action, adventure, fantasy", "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.", 3),
            new Movie(10, "The Good, the Bad and the Ugly", "1966", "western", "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", 3),
            new Movie(11, "Forrest Gump", "1994", "drama, romance", "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", 3),
            new Movie(12, "Fight Club", "1999", "drama", "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", 3),
            new Movie(13, "The Lord of the Rings: The Two Towers", "2002", "adventure, fantasy", "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.", 3),
            new Movie(14, "Inception", "2010", "action, adventure, sci-fi", "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", 3),
            new Movie(15, "Star Wars: Episode V - The Empire Strikes Back", "1980", "action, adventure, fantasy", "When a tribal man is arrested for a case of alleged theft, his wife turns to a human-rights lawyer to help bring justice.", 3),
            new Movie(16, "The Matrix", "1999", "action, sci-fi", "The story of Henry Hill and his life in the mafia, covering his relationship with his wife Karen and his mob partners Jimmy Conway and Tommy DeVito.", 3),
            new Movie(17, "Goodfellas", "1990", "biography, crime, drama", "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.", 3),
            new Movie(18, "One Flew Over the Cuckoo's Nest", "1975", "drama", "After the Rebels are overpowered by the Empire, Luke Skywalker begins his Jedi training with Yoda, while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett.", 3),
            new Movie(19, "Se7en", "1995", "drama, mystery, thriller", "In the Fall of 1963, a Korean War veteran and criminal pleads insanity and is admitted to a mental institution, where he rallies up the scared patients against the tyrannical nurse.", 3),
            new Movie(20, "It's a Wonderful Life", "1946", "drama, family, fantasy", "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.", 3),
            new Movie(21, "Seven Samurai", "1954", "action, adventure, drama", "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", 3),
            new Movie(22, "The Silence of the Lambs", "1991", "crime, drama, thriller", "Two detectives, a rookie and a veteran, hunt a serial killer who uses the seven deadly sins as his motives.", 3),
            new Movie(23, "Saving Private Ryan", "1998", "action, drama, war", "A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.", 3),
            new Movie(24, "City of God", "2002", "crime, drama", "Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.", 3),
            new Movie(25, "Interstellar", "2014", "adventure, drama, sci-fi", "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.", 3),
            new Movie(26, "Life Is Beautiful", "1997", "comedy, drama, romance", "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches and spirits, a world where humans are changed into beasts.", 3),
            new Movie(27, "The Green Mile", "1999", "crime, drama, fantasy", "In the slums of Rio, two kids' paths diverge as one struggles to become a photographer and the other a kingpin.", 3),
            new Movie(28, "Star Wars", "1977", "action, adventure, fantasy", "A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her 10-year old son John from an even more advanced and powerful cyborg.", 3),
            new Movie(29, "Terminator 2: Judgment Day", "1991", "action, sci-fi, thriller", "When an open-minded Jewish waiter and his son become victims of the Holocaust, he uses a perfect mixture of will, humor and imagination to protect his son from the dangers around their camp.", 3),
            new Movie(30, "Back to the Future", "1985", "adventure, comedy, sci-fi", "Farmers from a village exploited by bandits hire a veteran samurai for protection, who gathers six other samurai to join him.", 3),
            new Movie(31, "Spirited Away", "2001", "adventure, animation, family", "An angel is sent from Heaven to help a desperately frustrated businessman by showing him what life would have been like if he had never existed.", 3),
            new Movie(32, "The Pianist", "2002", "biography, drama, war", "When a ronin requesting seppuku at a feudal lord's palace is told of the brutal suicide of another ronin who previously visited, he reveals how their pasts are intertwined - and in doing so challenges the clan's integrity.", 3),
            new Movie(33, "Psycho", "1960", "horror, mystery, thriller", "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", 3),
            new Movie(34, "Parasite", "2019", "drama, thriller", "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.", 3),
            new Movie(35, "Léon: The Professional", "1994", "crime, drama, thriller", "A promising young drummer enrolls at a cut-throat music conservatory where his dreams of greatness are mentored by an instructor who will stop at nothing to realize a student's potential.", 3),
            new Movie(36, "Gladiator", "2000", "action, drama", "Marty McFly, a 17-year-old high school student, is accidentally sent 30 years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.", 3),
            new Movie(37, "The Lion King", "1994", "adventure, animation, drama", "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in South Boston.", 3),
            new Movie(38, "American History X", "1998", "crime, drama", "12-year-old Mathilda is reluctantly taken in by Léon, a professional assassin, after her family is murdered. An unusual relationship forms as she becomes his protégée and learns the assassin's trade.", 3),
            new Movie(39, "The Departed", "2006", "crime, drama, thriller", "The crew of a commercial spacecraft encounter a deadly lifeform after investigating an unknown transmission.", 3),
            new Movie(40, "Whiplash", "2014", "drama, music", "After a tragic accident, two stage magicians in 1890s London engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.", 3),
            new Movie(41, "The Prestige", "2006", "drama, mystery, thriller", "Lion prince Simba and his father are targeted by his bitter uncle, who wants to ascend the throne himself.", 3),
            new Movie(42, "The Usual Suspects", "1995", "crime, drama, thriller", "A Polish Jewish musician struggles to survive the destruction of the Warsaw ghetto of World War II.", 3),
            new Movie(43, "Casablanca", "1942", "drama, romance, war", "A sole survivor tells of the twisty events leading up to a horrific gun battle on a boat, which began when five criminals met at a random police lineup.", 3),
            new Movie(44, "Hotaru no haka", "1988", "animation, drama, war", "A Phoenix secretary embezzles $40,000 from her employer's client, goes on the run and checks into a remote motel run by a young man under the domination of his mother.", 3),
            new Movie(45, "Seppuku", "1962", "action, drama, history", "A former neo-nazi skinhead tries to prevent his younger brother from going down the same wrong path that he did.", 3),
            new Movie(46, "Intouchables", "2011", "biography, comedy, drama", "After he becomes a quadriplegic from a paragliding accident, an aristocrat hires a young man from the projects to be his caregiver.", 3),
            new Movie(47, "Modern Times", "1936", "comedy, drama", "A cynical expatriate American cafe owner struggles to decide whether or not to help his former lover and her fugitive husband escape the Nazis in French Morocco.", 3),
            new Movie(48, "C'era una volta il West", "1968", "western", "A mysterious stranger with a harmonica joins forces with a notorious desperado to protect a beautiful widow from a ruthless assassin working for the railroad.", 3),
            new Movie(49, "Nuovo Cinema Paradiso", "1988", "drama", "A young boy and his little sister struggle to survive in Japan during World War II.", 3),
            new Movie(50, "Rear Window", "1954", "mystery, thriller", "A filmmaker recalls his childhood when falling in love with the pictures at the cinema of his home village and forms a deep friendship with the cinema's projectionist.", 3)
        );
    }
}

internal class SeedDataCustomer : IEntityTypeConfiguration<Customer> {
    public void Configure(EntityTypeBuilder<Customer> builder) {
        _ = builder.HasData(
            new Customer(1, "Shelly", "Estrada", "93117 Evansville", "1-871-372-7263"),
            new Customer(2, "Althea", "Richardson", "92160 Evansville", "(575) 618-6840"),
            new Customer(3, "Galena", "Kelly", "31614 Dover", "(722) 267-4538"),
            new Customer(4, "Cade", "Casey", "74577 Atlanta", "1-724-363-8148"),
            new Customer(5, "Candace", "Stevenson", "99675 Des Moines", "1-765-565-2433"),
            new Customer(6, "Lacota", "Macdonald", "63724 Hartford", "1-437-949-1331"),
            new Customer(7, "Elijah", "Mcneil", "36002 Olathe", "1-245-286-2854"),
            new Customer(8, "Kelsey", "Watts", "25335 Burlington", "1-271-128-2267"),
            new Customer(9, "Iola", "Williamson", "77570 Atlanta", "1-886-680-7164"),
            new Customer(10, "Nola", "Joyce", "76957 Hilo", "1-714-644-2452"),
            new Customer(11, "Louis", "Strickland", "94770 Jacksonville", "1-430-859-3268"),
            new Customer(12, "Lamar", "Benjamin", "82307 Green Bay", "1-530-552-9128"),
            new Customer(13, "Audrey", "Everett", "82411 Lakewood", "(548) 188-6377"),
            new Customer(14, "Noah", "Klein", "73836 Metairie", "1-127-947-2433"),
            new Customer(15, "Lucius", "Mullen", "33489 Naperville", "(667) 450-1968")
        );
    }
}

internal class SeedDataRentedMovie : IEntityTypeConfiguration<RentedMovie> {
    public void Configure(EntityTypeBuilder<RentedMovie> builder) {
        _ = builder.HasData(
            new Model.RentedMovie(1,1,1,DateTime.Now,null),
            new Model.RentedMovie(2,2,4,DateTime.Now,null),
            new Model.RentedMovie(3,3,14,DateTime.Now.AddDays(-2),null),
            new Model.RentedMovie(4,4,1,DateTime.Now.AddDays(-28),DateTime.Now),
            new Model.RentedMovie(5,5,11,DateTime.Now.AddDays(-1),null),
            new Model.RentedMovie(6,6,7,DateTime.Now.AddDays(-1),null),
            new Model.RentedMovie(7,7,4,DateTime.Now.AddDays(-7),DateTime.Now)
        );
    }
}
