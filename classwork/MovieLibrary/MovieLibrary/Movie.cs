using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    // Naming rules for class
    // 1. Pascal cased
    // 2. Never prefix with T, C, or anything else
    // 3. Always nouns because they always represent an object or entity in your system

    /// <summary>
    /// Represents a movie
    /// </summary>
    public class Movie //: IValidatableObject
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
        public int Id { get; set; }

        // public int Id { get; } ::= compiler infers the setter is private

        // Property syntax ::= access T id { getter; setter }
        // Getter ::= get { S* }
        // Setter ::= set { S* }

        // null-coalesce ::= E ?? E (returns first non-null expression)
        // null-conditional ::= E ?. M (works with members; changes the type of the expression)
        
        /// <summary>
        /// Gets and sets the title
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(255)]
        public string Title
        {
            get => _title ?? "";

            set => _title = value?.Trim();

            // Read: T get_Title()
            //get { return _title ?? ""; }
            
            //if (_title == null)
                //    return "";

                //return _title;
                // return (_title != null) ? _title : "";

            // Write void set_Title ( string value )
            
            //set { _title = value?.Trim(); }
            
            //_title = value;
                //_title = (value != null) ? value.Trim() : null;
                
            //Movie m;
                //int id = m?.Id ?? 0; // int?
        }

        /// <summary>
        /// Gets and sets the description
        /// </summary>
        public string Description
        {
            get => (_description != null) ? _description : "";

            set => _description = (value != null) ? value.Trim() : null;

            //get { return (_description != null) ? _description : ""; }

            //set { _description = (value != null) ? value.Trim() : null; }
        }

        /// <summary>
        /// Gets and sets the rating
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(20)]
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
        [Range(0, 600)]
        [Display(Name = "Run Length")]
        public int RunLength { get; set; }

        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }

        //    set { _releaseYear = value; }
        //}

        /// <summary>
        /// Gets and sets the release year
        /// </summary>
        [Range(1900, 2100)]
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

        // Expression body for calculated property
        public bool IsBlackAndWhite => ReleaseYear < 1922;
        //{
        //    // get { return ReleaseYear < 1922; }
        //    get => ReleaseYear < 1922;
        //}
        // Methods - provide functionality (function inside a class)
        // Can reference fields in method

        /// <summary>
        /// Copies the movie
        /// </summary>
        /// <returns>
        /// A copy of the movie
        /// </returns> 
        public Movie Clone () => new Movie() {
           Id = Id,
           Title = Title,
           Description = Description,
           RunLength = RunLength,
           ReleaseYear = ReleaseYear,
           ReviewRating = ReviewRating,
           Rating = Rating,
           IsClassic = IsClassic
        };

        public override string ToString () => $"{Title} ({ReleaseYear})";

        //public override string ToString ()
        //{
        //    return $"{Title} ({ReleaseYear})";
        //}

        //public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        //{
            //var errors = new List<ValidationResult>();

            //// Name is required
            //if (String.IsNullOrEmpty(Title))
            //    //return "Title is required";
            //    errors.Add(new ValidationResult("Title is required!", new[] { nameof(Title) }));
             
            // Run length >= 0
            //if (RunLength < 0)
            //    errors.Add(new ValidationResult("Run Length must be at least zero", new[] { nameof(RunLength) }));

            //// Release year >= 1900
            //if (ReleaseYear < MinimumReleaseYear)
            //    errors.Add(new ValidationResult("Release Year must be at least " + MinimumReleaseYear, new[] { nameof(ReleaseYear) }));

            //// Rating is required
            //if (String.IsNullOrEmpty(Rating))
            //    errors.Add(new ValidationResult("Rating is required", new[] { nameof(Rating) }));
            
            //return errors;
        //}

        private void SetDescriptionToTitle ()
        {
            Description = Title;
        }
    }
}
