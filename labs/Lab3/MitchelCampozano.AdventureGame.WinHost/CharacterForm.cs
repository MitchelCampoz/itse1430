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
            _txtStrength.Text = character.Strength;
            _txtIntelligence.Text = character.Intelligence;
            _txtAgility.Text = character.Agility;
            _txtConstitution.Text = character.Constitution;
            _txtCharisma.Text = character.Charisma;
        }

        private void OnSave (object sender, EventArgs e )
        {
            var character = new Character();

            character.Name = _txtName.Name;
        }

    }
}
