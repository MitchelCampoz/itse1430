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
        //public Movie()
        //{

        //}

        //// Constructor practice
        //// To do any initializing if default initializer doesn't work
        //// CTOR - DECL ::= [access] T ( Parameters ) { S* }
        //public Movie ( string title ) : this (0, title)
        //{
        //    //Initialize(title);
        //    //Title = title;
        //}

        //public Movie (int id, string title )
        //{
        //    Id = id;
        //    // Initialize(title);
        //    Title = title;
        //}

        //// Shared init but dangerous to use
        //private void Initialize ( string title )
        //{
        //    Title = title;
        //}

        // Mixed accessibility - one accessor may be more restrictive
        public int Id { get; private set; }

        // public int Id { get; } ::= compiler infers the setter is private

        // Property syntax ::= access T id { getter; setter }
        // Getter ::= get { S* }
        // Setter ::= set { S* }

        // null-coalesce ::= E ?? E (returns first non-null expression)
        // null-conditional ::= E ?. M (works with members; changes the type of the expression)
        
        /// <summary>
        /// Gets and sets the title
        /// </summary>
        public string Title
        {
            // Read: T get_Title()
            get 
            { 
                return _title ?? "";
                //if (_title == null)
                //    return "";

                //return _title;
                // return (_title != null) ? _title : "";
            }

            // Write void set_Title ( string value )
            set 
            {
                //_title = value;
                //_title = (value != null) ? value.Trim() : null;
                _title = value?.Trim();

                //Movie m;
                //int id = m?.Id ?? 0; // int?
            }
        }

        /// <summary>
        /// Gets and sets the description
        /// </summary>
        public string Description
        {
            get { return (_description != null) ? _description : ""; }

            set { _description = (value != null) ? value.Trim() : null; }
        }

        /// <summary>
        /// Gets and sets the rating
        /// </summary>
        public string Rating
        {
            get { return (_rating != null) ? _rating : ""; }

            set { _rating = (value != null) ? value.Trim() : null; }
        }

        // Full Property Syntax
        //public int RunLength
        //{
        //    get { return _runLength; }

        //    set { _runLength = value; }
        //}

        // Auto Property
        /// <summary>
        /// Gets and sets the run length
        /// </summary>
        public int RunLength { get; set; }

        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }

        //    set { _releaseYear = value; }
        //}

        /// <summary>
        /// Gets and sets the release year
        /// </summary>
        public int ReleaseYear { get; set; } = MinimumReleaseYear;

        public double ReviewRating { get; set; }
        //{
        //    get { return _reviewRating; }

        //    set { _reviewRating = value; }
        //}

        public bool IsClassic { get; set; }
        //{
        //    get { return _isClassic; }

        //    set { _isClassic = value; }
        //}
        // Fields
        // 1. Always Camel cased, TODO : for now
        // 2. Should never be public
        // 3. Always zero initialized or can default
        // 4. Cannot initialize to another field's value
        private string _title;
        private string _description;
        // private int _runLength;
        // private int _releaseYear = MinimumReleaseYear;
        // private double _reviewRating;
        private string _rating;
        // private bool _isClassic;

        public const int MinimumReleaseYear = 1900;

        //public int GetAgeInYears ()
        //{
        //    return DateTime.Now.Year - _releaseYear;
        //}
        public int AgeInYears
        {
            get { return DateTime.Now.Year - ReleaseYear; }
            //set { }
        }

        //public bool IsBlackAndWhite ()
        //{
        //    return _releaseYear < 1922;
        //}
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < 1922; }
        }
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
            movie.Title = Title;
            movie.Description = Description;
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.ReviewRating = ReviewRating;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;

            return movie;
        }

        public override string ToString ()
        {
            return $"{Title} ({ReleaseYear})";
        }

        public string Validate ( /* Movie this */ )
        {
            // Name is required
            if (String.IsNullOrEmpty(Title))
                return "Title is required";

            // Run length >= 0
            if (RunLength < 0)
                return "Run Length must be at least zero";

            // Release year >= 1900
            if (ReleaseYear < MinimumReleaseYear)
                return "Release Year must be at least " + MinimumReleaseYear;

            // Rating is required
            if (String.IsNullOrEmpty(Rating))
                return "Rating is required";
            
            return null;
        }

        private void SetDescriptionToTitle ()
        {
            Description = Title;
        }
    }
}
