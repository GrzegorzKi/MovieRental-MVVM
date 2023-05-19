using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieRental.Migrations
{
    /// <inheritdoc />
    public partial class SeedExampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "93117 Evansville", "Shelly", "Estrada", "1-871-372-7263" },
                    { 2, "92160 Evansville", "Althea", "Richardson", "(575) 618-6840" },
                    { 3, "31614 Dover", "Galena", "Kelly", "(722) 267-4538" },
                    { 4, "74577 Atlanta", "Cade", "Casey", "1-724-363-8148" },
                    { 5, "99675 Des Moines", "Candace", "Stevenson", "1-765-565-2433" },
                    { 6, "63724 Hartford", "Lacota", "Macdonald", "1-437-949-1331" },
                    { 7, "36002 Olathe", "Elijah", "Mcneil", "1-245-286-2854" },
                    { 8, "25335 Burlington", "Kelsey", "Watts", "1-271-128-2267" },
                    { 9, "77570 Atlanta", "Iola", "Williamson", "1-886-680-7164" },
                    { 10, "76957 Hilo", "Nola", "Joyce", "1-714-644-2452" },
                    { 11, "94770 Jacksonville", "Louis", "Strickland", "1-430-859-3268" },
                    { 12, "82307 Green Bay", "Lamar", "Benjamin", "1-530-552-9128" },
                    { 13, "82411 Lakewood", "Audrey", "Everett", "(548) 188-6377" },
                    { 14, "73836 Metairie", "Noah", "Klein", "1-127-947-2433" },
                    { 15, "33489 Naperville", "Lucius", "Mullen", "(667) 450-1968" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Copies", "Genre", "Plot", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 3, "crime, drama", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", "The Shawshank Redemption", "1994" },
                    { 2, 3, "crime, drama", "Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. However, his decision unintentionally puts the lives of his loved ones in grave danger.", "The Godfather", "1972" },
                    { 3, 3, "action, crime, drama", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "The Dark Knight", "2008" },
                    { 4, 3, "crime, drama", "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "The Godfather: Part II", "1974" },
                    { 5, 3, "drama", "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "12 Angry Men", "1957" },
                    { 6, 3, "biography, drama, history", "The jury in a New York City murder trial is frustrated by a single member whose skeptical caution forces them to more carefully consider the evidence before jumping to a hasty verdict.", "Schindler's List", "1993" },
                    { 7, 3, "action, adventure, fantasy", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "The Lord of the Rings: The Return of the King", "2003" },
                    { 8, 3, "crime, drama", "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "Pulp Fiction", "1994" },
                    { 9, 3, "action, adventure, fantasy", "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.", "The Lord of the Rings: The Fellowship of the Ring", "2001" },
                    { 10, 3, "western", "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "The Good, the Bad and the Ugly", "1966" },
                    { 11, 3, "drama, romance", "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "Forrest Gump", "1994" },
                    { 12, 3, "drama", "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "Fight Club", "1999" },
                    { 13, 3, "adventure, fantasy", "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.", "The Lord of the Rings: The Two Towers", "2002" },
                    { 14, 3, "action, adventure, sci-fi", "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", "Inception", "2010" },
                    { 15, 3, "action, adventure, fantasy", "When a tribal man is arrested for a case of alleged theft, his wife turns to a human-rights lawyer to help bring justice.", "Star Wars: Episode V - The Empire Strikes Back", "1980" },
                    { 16, 3, "action, sci-fi", "The story of Henry Hill and his life in the mafia, covering his relationship with his wife Karen and his mob partners Jimmy Conway and Tommy DeVito.", "The Matrix", "1999" },
                    { 17, 3, "biography, crime, drama", "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.", "Goodfellas", "1990" },
                    { 18, 3, "drama", "After the Rebels are overpowered by the Empire, Luke Skywalker begins his Jedi training with Yoda, while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett.", "One Flew Over the Cuckoo's Nest", "1975" },
                    { 19, 3, "drama, mystery, thriller", "In the Fall of 1963, a Korean War veteran and criminal pleads insanity and is admitted to a mental institution, where he rallies up the scared patients against the tyrannical nurse.", "Se7en", "1995" },
                    { 20, 3, "drama, family, fantasy", "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.", "It's a Wonderful Life", "1946" },
                    { 21, 3, "action, adventure, drama", "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", "Seven Samurai", "1954" },
                    { 22, 3, "crime, drama, thriller", "Two detectives, a rookie and a veteran, hunt a serial killer who uses the seven deadly sins as his motives.", "The Silence of the Lambs", "1991" },
                    { 23, 3, "action, drama, war", "A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.", "Saving Private Ryan", "1998" },
                    { 24, 3, "crime, drama", "Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.", "City of God", "2002" },
                    { 25, 3, "adventure, drama, sci-fi", "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.", "Interstellar", "2014" },
                    { 26, 3, "comedy, drama, romance", "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches and spirits, a world where humans are changed into beasts.", "Life Is Beautiful", "1997" },
                    { 27, 3, "crime, drama, fantasy", "In the slums of Rio, two kids' paths diverge as one struggles to become a photographer and the other a kingpin.", "The Green Mile", "1999" },
                    { 28, 3, "action, adventure, fantasy", "A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her 10-year old son John from an even more advanced and powerful cyborg.", "Star Wars", "1977" },
                    { 29, 3, "action, sci-fi, thriller", "When an open-minded Jewish waiter and his son become victims of the Holocaust, he uses a perfect mixture of will, humor and imagination to protect his son from the dangers around their camp.", "Terminator 2: Judgment Day", "1991" },
                    { 30, 3, "adventure, comedy, sci-fi", "Farmers from a village exploited by bandits hire a veteran samurai for protection, who gathers six other samurai to join him.", "Back to the Future", "1985" },
                    { 31, 3, "adventure, animation, family", "An angel is sent from Heaven to help a desperately frustrated businessman by showing him what life would have been like if he had never existed.", "Spirited Away", "2001" },
                    { 32, 3, "biography, drama, war", "When a ronin requesting seppuku at a feudal lord's palace is told of the brutal suicide of another ronin who previously visited, he reveals how their pasts are intertwined - and in doing so challenges the clan's integrity.", "The Pianist", "2002" },
                    { 33, 3, "horror, mystery, thriller", "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", "Psycho", "1960" },
                    { 34, 3, "drama, thriller", "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.", "Parasite", "2019" },
                    { 35, 3, "crime, drama, thriller", "A promising young drummer enrolls at a cut-throat music conservatory where his dreams of greatness are mentored by an instructor who will stop at nothing to realize a student's potential.", "Léon: The Professional", "1994" },
                    { 36, 3, "action, drama", "Marty McFly, a 17-year-old high school student, is accidentally sent 30 years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.", "Gladiator", "2000" },
                    { 37, 3, "adventure, animation, drama", "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in South Boston.", "The Lion King", "1994" },
                    { 38, 3, "crime, drama", "12-year-old Mathilda is reluctantly taken in by Léon, a professional assassin, after her family is murdered. An unusual relationship forms as she becomes his protégée and learns the assassin's trade.", "American History X", "1998" },
                    { 39, 3, "crime, drama, thriller", "The crew of a commercial spacecraft encounter a deadly lifeform after investigating an unknown transmission.", "The Departed", "2006" },
                    { 40, 3, "drama, music", "After a tragic accident, two stage magicians in 1890s London engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.", "Whiplash", "2014" },
                    { 41, 3, "drama, mystery, thriller", "Lion prince Simba and his father are targeted by his bitter uncle, who wants to ascend the throne himself.", "The Prestige", "2006" },
                    { 42, 3, "crime, drama, thriller", "A Polish Jewish musician struggles to survive the destruction of the Warsaw ghetto of World War II.", "The Usual Suspects", "1995" },
                    { 43, 3, "drama, romance, war", "A sole survivor tells of the twisty events leading up to a horrific gun battle on a boat, which began when five criminals met at a random police lineup.", "Casablanca", "1942" },
                    { 44, 3, "animation, drama, war", "A Phoenix secretary embezzles $40,000 from her employer's client, goes on the run and checks into a remote motel run by a young man under the domination of his mother.", "Hotaru no haka", "1988" },
                    { 45, 3, "action, drama, history", "A former neo-nazi skinhead tries to prevent his younger brother from going down the same wrong path that he did.", "Seppuku", "1962" },
                    { 46, 3, "biography, comedy, drama", "After he becomes a quadriplegic from a paragliding accident, an aristocrat hires a young man from the projects to be his caregiver.", "Intouchables", "2011" },
                    { 47, 3, "comedy, drama", "A cynical expatriate American cafe owner struggles to decide whether or not to help his former lover and her fugitive husband escape the Nazis in French Morocco.", "Modern Times", "1936" },
                    { 48, 3, "western", "A mysterious stranger with a harmonica joins forces with a notorious desperado to protect a beautiful widow from a ruthless assassin working for the railroad.", "C'era una volta il West", "1968" },
                    { 49, 3, "drama", "A young boy and his little sister struggle to survive in Japan during World War II.", "Nuovo Cinema Paradiso", "1988" },
                    { 50, 3, "mystery, thriller", "A filmmaker recalls his childhood when falling in love with the pictures at the cinema of his home village and forms a deep friendship with the cinema's projectionist.", "Rear Window", "1954" }
                });

            migrationBuilder.InsertData(
                table: "RentedMovie",
                columns: new[] { "Id", "CustomerId", "DateIssued", "DateReturned", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 5, 19, 15, 23, 11, 955, DateTimeKind.Local).AddTicks(1132), null, 1 },
                    { 2, 4, new DateTime(2023, 5, 19, 15, 23, 11, 955, DateTimeKind.Local).AddTicks(1176), null, 2 },
                    { 3, 14, new DateTime(2023, 5, 17, 15, 23, 11, 955, DateTimeKind.Local).AddTicks(1179), null, 3 },
                    { 4, 1, new DateTime(2023, 4, 21, 15, 23, 11, 955, DateTimeKind.Local).AddTicks(1181), new DateTime(2023, 5, 19, 15, 23, 11, 955, DateTimeKind.Local).AddTicks(1183), 4 },
                    { 5, 11, new DateTime(2023, 5, 18, 15, 23, 11, 955, DateTimeKind.Local).AddTicks(1186), null, 5 },
                    { 6, 7, new DateTime(2023, 5, 18, 15, 23, 11, 955, DateTimeKind.Local).AddTicks(1188), null, 6 },
                    { 7, 4, new DateTime(2023, 5, 12, 15, 23, 11, 955, DateTimeKind.Local).AddTicks(1190), new DateTime(2023, 5, 19, 15, 23, 11, 955, DateTimeKind.Local).AddTicks(1191), 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "RentedMovie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentedMovie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentedMovie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentedMovie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RentedMovie",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RentedMovie",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RentedMovie",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
