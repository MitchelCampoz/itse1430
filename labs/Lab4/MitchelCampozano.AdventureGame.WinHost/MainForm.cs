// Mitchel Campozano
// ITSE 1430
// AdventureGame Lab 4
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

            _btnNorth.Enabled = false;
            _btnSouth.Enabled = false;
            _btnEast.Enabled = false;
            _btnWest.Enabled = false;
            _btnPickItem.Enabled = false;
            _btnInventory.Enabled = false;
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
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

        private World _playerSpace = new World();

        private void UpdateQuest ()
        {
            var playerRoom = _playerSpace.GetAll();

            playerRoom.ToArray();

            var bindingsource = new BindingSource();
            bindingsource.DataSource = playerRoom;

            _lstArea.DataSource = bindingsource;
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

        private void OnNewGame ( object sender, EventArgs e )
        {
            if (_character == null)
            {
                ErrorMessage("Error", "A character must be made before you can play the game.");
                DialogResult = DialogResult.None;
                return;
            };

            Player newPlayer = new Player();
            characterToolStripMenuItem.Enabled = false;
            _btnNorth.Enabled = true;
            _btnSouth.Enabled = true;
            _btnEast.Enabled = true;
            _btnWest.Enabled = true;
            _btnPickItem.Enabled = true;
            _btnInventory.Enabled = true;

            UpdateQuest();
        }

        private void ErrorMessage ( string title, string message )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Inventory _inventory = new Inventory();

        private void OnShowInventory( object sender, EventArgs e )
        {
            var playerInventory = _inventory.GetAll();

            playerInventory.ToArray();

            var bindingsource = new BindingSource();
            bindingsource.DataSource = playerInventory;

            _lstArea.DataSource = bindingsource;
        }

        private void OnPickUp ( object sender, EventArgs e )
        {
            var item = new Item();
            _inventory.Add(item);
        }

        private void OnMoveNorth ( object sender, EventArgs e )
        {
            var player = new Player();

            player.placeY += -1;
        }

        private void OnMoveSouth ( object sender, EventArgs e )
        {
            var player = new Player();

            player.placeY += 1;
        }

        private void OnMoveEast ( object sender, EventArgs e )
        {
            var player = new Player();

            player.placeX += 1;
        }

        private void OnMoveWest ( object sender, EventArgs e )
        {
            var player = new Player();

            player.placeX += -1;
        }
    }
}
