using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public static class SeedDatabase
    {
        public static void Seed ( this IMovieDatabase database )
        {
            // Collection initializer syntax
            var movies = new[] {

                (new Movie() {
                    Title = "Jaws",
                    Rating = "PG",
                    RunLength = 210,
                    ReleaseYear = 1975,
                    Description = "Shark Movie"
                }),

                (new Movie() {
                    Title = "Dune",
                    Rating = "PG",
                    RunLength = 300,
                    ReleaseYear = 1982,
                    Description = "Sand Movie"
                }),

                (new Movie() {
                    Title = "Jaws 2",
                    Rating = "PG",
                    RunLength = 190,
                    ReleaseYear = 1979,
                    Description = "Shark Movie again"
                })

            };

            foreach(var movie in movies)
                database.Add(movie, out  var error);
        }
    }
}
