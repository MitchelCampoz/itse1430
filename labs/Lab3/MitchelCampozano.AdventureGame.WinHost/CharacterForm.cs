using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MitchelCampozano.AdventureGame.WinHost
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
                LoadCharacter(Character);
        }

        private void LoadCharacter ( Character character )
        {
            _txtName.Text = character.Name;
            _cbProfession.Text = character.Profession;
            _cbRace.Text = character.Race;
            _txtBiography.Text = character.Biography;
            _txtStrength.Text = character.Strength.ToString();
            _txtIntelligence.Text = character.Intelligence.ToString();
            _txtAgility.Text = character.Agility.ToString();
            _txtConstitution.Text = character.Constitution.ToString();
            _txtCharisma.Text = character.Charisma.ToString();
        }

        private void OnSave (object sender, EventArgs e )
        {
            var character = new Character();

            character.Name = _txtName.Text;
            character.Profession = _cbProfession.Text;
            character.Race = _cbRace.Text;
            character.Biography = _txtBiography.Text;
            character.Strength = GetInt32(_txtStrength);
            character.Intelligence = GetInt32(_txtIntelligence);
            character.Agility = GetInt32(_txtAgility);
            character.Constitution = GetInt32(_txtIntelligence);
            character.Charisma = GetInt32(_txtCharisma);

            var error = character.Validator();
            if (!String.IsNullOrEmpty(error))
            {
                ErrorMessage(error, "Error");
                DialogResult = DialogResult.None;
                return;
            };

            Character = character;

            DialogResult = DialogResult.OK;
        }

        private int GetInt32 ( Control control )
        {
            var text = control.Text;

            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        private void ErrorMessage (string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
