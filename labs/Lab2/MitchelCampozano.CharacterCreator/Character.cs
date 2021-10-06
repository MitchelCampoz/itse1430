using System;

namespace MitchelCampozano.CharacterCreator
{
    public class Character
    {
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

        /// <summary>
        /// Creates a new instance of a character
        /// </summary>
        /// <returns>
        /// Returns a new character
        /// </returns>
        public Character Recruit ()
        {
            var character = new Character();
            character.Name = Name;
            character.Profession = Profession;
            character.Race = Race;
            character.Biography = Biography;
            character.Strength = Strength;
            character.Intelligence = Intelligence;
            character.Agility = Agility;
            character.Constitution = Constitution;
            character.Charisma = Charisma;

            return character;
        }

        /// <summary>
        /// Validates the Character object
        /// </summary>
        /// <returns>
        /// Returns a value based on invalid values
        /// </returns>
        public string Validator ()
        {
            if (String.IsNullOrEmpty(Name))
                return "Please name your character.";

            if (String.IsNullOrEmpty(Profession))
                return "Please give your character a profession.";

            if (String.IsNullOrEmpty(Race))
                return "Please give your character a race.";

            if (Strength < MinimumValue || Strength > MaximumValue)
                return "Invalid amount.";

            if (Intelligence < MinimumValue || Intelligence > MaximumValue)
                return "Invalid amount.";

            if (Agility < MinimumValue || Agility > MaximumValue)
                return "Invalid amount.";

            if (Constitution < MinimumValue || Constitution > MaximumValue)
                return "Invalid amount.";

            if (Charisma < MinimumValue || Charisma > MaximumValue)
                return "Invalid amount.";

            return null;
        }
    }
}
