using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();

            //Additional init here
            //Runs at design time as well - be careful
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

        private bool Confirm ( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            if (_movie == null)
                return;

            // Confirimation
            if (!Confirm($"Are you sure you want to delete '{_movie.Title}'?", "Delete"))
                return;

            // TODO: Delete
            
            _movie = null;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dlg = new AboutBox();

            //Blocks until child form is closed
            dlg.ShowDialog();

            //Show displays modeless, not blocking
            //dlg.Show();
            //MessageBox.Show("After Show");
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var dlg = new MovieForm();
            dlg.StartPosition = FormStartPosition.CenterParent;

            // ShowDialog -> DialogResult
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            // TODO: Save Movie
            _movie = dlg.Movie;
            UpdateUI();
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            if (_movie == null)
                return;

            var dlg = new MovieForm();
            dlg.Movie = _movie;
            

            // ShowDialog -> DialogResult
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            // TODO: Save Movie
            _movie = dlg.Movie;
            UpdateUI();
        }

        // TODO: Remove this...
        private Movie _movie;

        private MovieDatabase _movies = new MovieDatabase();

        private void UpdateUI ()
        {
            // Update Movie List
            //var movies = (_movie != null) ? new Movie[1] : new Movie[0];
            //if (_movie != null)
            //    movies[0] = _movie;

            Movie[] movies = _movies.GetAll();

            var movie = movies[1] = new Movie();

            movie.Title = "Dune";
            movie.Description = "Something";

            var bindingSource = new BindingSource();
            bindingSource.DataSource = movies;

            // Bind the movies to the listbox
            _listMovies.DataSource = bindingSource;


        }

        private void listBox1_SelectedIndexChanged ( object sender, EventArgs e )
        {

        }
    }
}