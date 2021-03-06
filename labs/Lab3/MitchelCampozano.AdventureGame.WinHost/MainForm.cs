// Mitchel Campozano
// ITSE 1430
// AdventureGame Lab 3
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            //Confirm exit?
            if (!Confirm("Do you want to quit?", "Confirm"))
                return;

            Close();
        }

        private static bool Confirm ( string message, string title )
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dlg = new AboutBox();

            dlg.ShowDialog();
        }

        private void OnCharacterAdd ( object sender, EventArgs e )
        {
            var dlg = new CharacterForm();

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            _character = dlg.Character;
            UpdateUI();
        }

        private Character _character;

        private void UpdateUI ()
        {
            var characters = (_character != null) ? new Character[1] : new Character[0];

            if (_character != null)
                characters[0] = _character;

            var bindingsource = new BindingSource();
            bindingsource.DataSource = characters;

            _lstCharacters.DataSource = bindingsource;
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            

            var dlg = new CharacterForm( _character );
            dlg.Character = _character;

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            _character = dlg.Character;
            UpdateUI();
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            if (!Confirm($"Are you sure you would like to delete {_character.Name}?", "Delete"))
                return;

            _lstCharacters.DataSource = null;
            _character = null;
        }
    }
}
