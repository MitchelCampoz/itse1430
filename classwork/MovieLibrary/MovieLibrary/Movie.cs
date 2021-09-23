using System;

namespace MovieLibrary
{
    // Naming rules for class
    // 1. Pascal cased
    // 2. Never prefix with T, C, or anything else
    // 3. Always nouns because they always represent an object or entity in your system

    /// <summary>
    /// Represents a movie
    /// </summary>
    public class Movie
    {
        // Fields
        // 1. Always Camel cased, TODO : for now
        // 2. Should never be public
        // 3. Always zero initialized or can default
        // 4. Cannot initialize to another field's value
        public string title;
        public string description;
        public int runLength;
        public int releaseYear = 1900;
        public double reviewRating;
        public string rating;
        public bool isClassic;

        public const int MinimumReleaseYear = 1900;

        // Methods - provide functionality (function inside a class)
        // Can reference fields in method

        /// <summary>
        /// Copies the movie
        /// </summary>
        /// <returns>
        /// A copy of the movie
        /// </returns>
        public Movie Copy ()
        {
            var movie = new Movie();
            movie.title = title;
            movie.description = description;
            movie.runLength = runLength;
            movie.releaseYear = releaseYear;
            movie.reviewRating = reviewRating;
            movie.rating = rating;
            movie.isClassic = isClassic;

            return movie;
        }

        public string Validate ( /* Movie this */ )
        {
            // Name is required
            if (String.IsNullOrEmpty(title))
                return "Title is required";

            // Run length >= 0
            if (runLength < 0)
                return "Run Length must be at least zero";

            // Release year >= 1900
            if (releaseYear < MinimumReleaseYear)
                return "Release Year must be at least " + MinimumReleaseYear;
            
            return null;
        }

        private void SetDescriptionToTitle ()
        {
            description = title;
        }
    }
}
