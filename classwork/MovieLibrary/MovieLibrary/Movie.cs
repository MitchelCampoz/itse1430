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
    }
}
