using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MovieLibrary.Memory;
using MovieLibrary.Sql;

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

            UpdateUI(true);
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
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            // Confirimation
            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            // TODO: Error Handling
            try
            {
                _movies.Delete(movie.Id);
                UpdateUI();
            }catch(Exception ex)
            {
                DisplayError(ex.Message, "Delete Failed");
            };
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

            do
            {
                // ShowDialog -> DialogResult
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    // TODO: Save Movie
                    _movies.Add(dlg.Movie);
                    UpdateUI();
                    return;
                } catch (ArgumentException ex)
                {
                    DisplayError(ex.Message, "Programmer Error");
                } catch (InvalidOperationException ex)
                {
                    DisplayError(ex.Message, "Not Now");
                } catch (NotSupportedException ex)
                {
                    DisplayError("Not supported", "Failed");
                    // Do Some Logging
                    throw;
                } catch (System.IO.IOException ex)
                {
                    throw new Exception("IO failed", ex);
                }
                catch (Exception ex)
                {
                    DisplayError(ex.Message, "Failed");
                };

                
            } while (true);
        }        

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var dlg = new MovieForm();
            dlg.Movie = movie;

            do
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    _movies.Update(movie.Id, dlg.Movie);
                    UpdateUI();
                    return;
                }catch(Exception ex)
                {
                    DisplayError(ex.Message, "Update Failed");
                };
            } while (true);
        }

        

        private Movie GetSelectedMovie ()
        {
            return _listMovies.SelectedItem as Movie;
        }

        private IMovieDatabase _movies = new SqlMovieDatabase(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=MovieDb;Integrated Security=True;");
        private void UpdateUI (bool isFirstRun = false)
        {

            // IEnumerable<TextBox> onlyTextboxes = Controls.OfType<TextBox>();
            // _movies.IsOnlyAvailableInMemoryMovieDatabase();
            // Update Movie List
            // var movies = (_movie != null) ? new Movie[1] : new Movie[0];
            // if (_movie != null)
            //    movies[0] = _movie;

            var movies = _movies.GetAll();

            if (isFirstRun && !movies.Any())
            {
                if(Confirm("Do you want to seed the database", "Seed"))
                {
                    _movies.Seed();
                    //SeedDatabase.Seed(_movies);
                    movies = _movies.GetAll();

                    var firstMovie = movies.FirstOrDefault();
                }
            }

            //var movie = movies[1] = new Movie();

            //movie.Title = "Dune";
            //movie.Description = "Something";

            var bindingSource = new BindingSource();
            //bindingSource.DataSource = movies.OrderBy(x => x.Title).ThenBy(x => x.ReleaseYear).ToArray();
            bindingSource.DataSource = movies.ToArray();

            // LINQ Extension
            //movies = movies.OrderBy(x => x.Title).ThenBy(x => x.ReleaseYear);

            // LINQ Syntax
            movies = from x in movies orderby x.Title, x.ReleaseYear select x;

            // Bind the movies to the listbox
            _listMovies.DataSource = bindingSource;


        }

        private void listBox1_SelectedIndexChanged ( object sender, EventArgs e )
        {

        }
    }
}