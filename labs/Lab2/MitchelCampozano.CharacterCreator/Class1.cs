using System;

namespace MitchelCampozano.CharacterCreator
{
    public class Character
    {
        // Test comment here

        /// <summary>
        /// Gets and sets the name of the character
        /// </summary>
        public string Name
        {
            get { return _name ?? ""; }

            set { _name = value?.Trim(); }
        }

        /// <summary>
        /// Gets and sets the profession or class of the character
        /// </summary>
        public string Profession
        {
            get { return (_profession != null) ? _profession : ""; }

            set { _profession = (value != null) ? value.Trim() : null; }
        }

        /// <summary>
        /// Gets and sets the race of the character
        /// </summary>
        public string Race
        {
            get { return _race ?? ""; }

            set { _race = value?.Trim(); }
        }

        /// <summary>
        /// Gets and sets the potentially tragic backstory of the character
        /// </summary>
        public string Biography
        {
            get { return (_biography != null) ? _biography : ""; }

            set { _biography = (value != null) ? value.Trim() : null; }
        }

        /// <summary>
        /// Gets and sets the Strength of the character
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// Gets and sets the Intelligence of the character
        /// </summary>
        public int Intelligence { get; set; }

        /// <summary>
        /// Gets and sets the Agility of the character
        /// </summary>
        public int Agility { get; set; }

        /// <summary>
        /// Gets and sets the Constitution
        /// </summary>
        public int Constitution { get; set; }

        /// <summary>
        /// Gets and sets the Charisma of the character
        /// </summary>
        public int Charisma { get; set; }

        public const int MinimumValue = 1;
        public const int MaximumValue = 100;

        private string _name;
        private string _profession;
        private string _race;
        private string _biography;

        //private int _strength;
        //private int _intelligence;
        //private int _agility;
        //private int _constitution;
        //private int _charisma;

        public string AttributeChecker ()
        {
            if (Strength < 1 || Strength > 100)
                return "Invalid amount.";

            if (Intelligence < 1 || Intelligence > 100)
                return "Invalid amount.";

            if (Agility < 1 || Agility > 100)
                return "Invalid amount.";

            if (Constitution < 1 || Constitution > 100)
                return "Invalid amount.";

            if (Charisma < 1 || Charisma > 100)
                return "Invalid amount.";

            return null;
        }
    }
}
