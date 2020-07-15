using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoviesDB_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            editMovieCountry.IsEnabled = false;
            editMovieIMDB.IsEnabled = false;
            editBirthYear.IsEnabled = false;
            editMovieYear.IsEnabled = false;
        }

        #region show_windows_clicks
        private void add_movie_click(object sender, RoutedEventArgs e)
        {
            AddMovie win = new AddMovie();
            win.ShowDialog();
        }

        private void add_actor_click(object sender, RoutedEventArgs e)
        {
            AddActor win = new AddActor();
            win.ShowDialog();
        }

        private void add_director_click(object sender, RoutedEventArgs e)
        {
            AddDirector win = new AddDirector();
            win.ShowDialog();
        }

        private void add_oscar_click(object sender, RoutedEventArgs e)
        {
            AddOscar win = new AddOscar();
            win.ShowDialog();
        }

        private void add_movie2actress_click(object sender, RoutedEventArgs e)
        {
            AddMovieToActress win = new AddMovieToActress();
            win.ShowDialog();
        }

        private void add_movie2actor_click(object sender, RoutedEventArgs e)
        {
            AddMovieToActor win = new AddMovieToActor();
            win.ShowDialog();
        }

        private void add_movie2director_click(object sender, RoutedEventArgs e)
        {
            AddMovieToDirector win = new AddMovieToDirector();
            win.ShowDialog();
        }

        private void add_actress2movie_click(object sender, RoutedEventArgs e)
        {
            AddActressToMovie win = new AddActressToMovie();
            win.ShowDialog();
        }

        private void add_actor2movie_click(object sender, RoutedEventArgs e)
        {
            AddActorToMovie win = new AddActorToMovie();
            win.ShowDialog();
        }

        private void add_director2movie_click(object sender, RoutedEventArgs e)
        {
            AddDirectorToMovie win = new AddDirectorToMovie();
            win.ShowDialog();
        }

        private void search_by_year(object sender, RoutedEventArgs e)
        {
            SearchMovieByYear win = new SearchMovieByYear();
            win.getValueCallBack1 = new
                SearchMovieByYear.GetSearchInput1(GetValuesFromSearchByYear1);
            win.getValueCallBack2 = new
                SearchMovieByYear.GetSearchInput2(GetValuesFromSearchByYear2);
            win.ShowDialog();
        }

        private void search_by_actors(object sender, RoutedEventArgs e)
        {
            SearchMovieBy2Actors win = new SearchMovieBy2Actors();
            win.getValueCallBack = new
                SearchMovieBy2Actors.GetSearchInput(GetMovieListBy2Actors);
            win.ShowDialog();

        }

        private void search_by_oscarYear(object sender, RoutedEventArgs e)
        {
            SearchMovieByOscarYear win = new SearchMovieByOscarYear();
            win.getValueCallBack = new
                SearchMovieByOscarYear.GetSearchInput(GetOscarYear);
            win.ShowDialog();
        }

        private void search_by_movie(object sender, RoutedEventArgs e)
        {
            ShowMovieDetails win = new ShowMovieDetails();
            win.ShowDialog();
        }
        #endregion

        #region show_on_listBoxex_clicks

        private void show_movies(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    itemsListBox.ItemsSource = (from m in ctx.Movies
                                                select m).ToList();
                }
                entityTextBlock.Text = "Movies:";
                editMovieCountry.IsEnabled = true;
                editMovieIMDB.IsEnabled = true;
                editMovieYear.IsEnabled = true;
                editBirthYear.IsEnabled = false;
            }

            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Type: " + ex.GetType().ToString());
            }
        }

        private void show_actors(object sender, RoutedEventArgs e)
        {

            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    itemsListBox.ItemsSource = (from t in ctx.Actors
                                                select t).ToList();
                }
                entityTextBlock.Text = "Actors / Actress:";
                editMovieCountry.IsEnabled = false;
                editMovieIMDB.IsEnabled = false;
                editBirthYear.IsEnabled = true;
                editMovieYear.IsEnabled = false;
            }

            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Type: " + ex.GetType().ToString());
            }
        }
        private void show_directors(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    itemsListBox.ItemsSource = (from t in ctx.Directors
                                                select t).ToList();
                }
                entityTextBlock.Text = "Directors:";
                editMovieCountry.IsEnabled = false;
                editMovieIMDB.IsEnabled = false;
                editBirthYear.IsEnabled = false;
                editMovieYear.IsEnabled = false;
            }

            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Type: " + ex.GetType().ToString());
            }
        }

        private void show_oscars(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    itemsListBox.ItemsSource = (from t in ctx.Oscars
                                                select t).ToList();
                }
                entityTextBlock.Text = "Oscars:";
                editMovieCountry.IsEnabled = false;
                editMovieIMDB.IsEnabled = false;
                editBirthYear.IsEnabled = false;
                editMovieYear.IsEnabled = false;
            }

            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Type: " + ex.GetType().ToString());
            }
        }
        #endregion

        private void lbItems_Selection(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    switch (entityTextBlock.Text)
                    {
                        case "Movies:":
                            Movie selectedMovie = itemsListBox.SelectedItem as Movie;
                            if (selectedMovie == null) return;
                            int movieSerial = selectedMovie.MovieSerial;
                            dataListBox.ItemsSource = (from am in ctx.ActorMovie
                                                       where am.MovieSerial == movieSerial
                                                       select am.Actor).ToList();
                            detailsTextBlock.Text = "Actors:";

                            break;
                        case "Actors / Actress:":
                            Actor selectedAc = itemsListBox.SelectedItem as Actor;
                            if (selectedAc == null) return;
                            int id = selectedAc.Id;
                            dataListBox.ItemsSource = (from am in ctx.ActorMovie
                                         where am.ActorId == id
                                         select am.Movie).ToList();
                            detailsTextBlock.Text = "Movies:";
                            break;
                        case "Directors:":
                            Director selectedDi = itemsListBox.SelectedItem as Director;
                            if (selectedDi == null) return;
                            int direId = selectedDi.Id;
                            dataListBox.ItemsSource = (from mo in ctx.Movies
                                           where mo.DirectorId == direId
                                           select mo).ToList();
                            detailsTextBlock.Text = "Movies:";
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void edit_yearBorn(object sender, RoutedEventArgs e)
        {
            Actor selectedAc = itemsListBox.SelectedItem as Actor;
            if (selectedAc == null) return;
            EditWindow win = new EditWindow(selectedAc.Id, "ActorYear");
            win.ShowDialog();
        }

        private void edit_movieYear(object sender, RoutedEventArgs e)
        {
            Movie selectedMovie = itemsListBox.SelectedItem as Movie;
            if (selectedMovie == null) return;
            EditWindow win = new EditWindow(selectedMovie.MovieSerial, "MovieYear");
            win.ShowDialog();
        }
        private void edit_movieImdb(object sender, RoutedEventArgs e)
        {
            Movie selectedMovie = itemsListBox.SelectedItem as Movie;
            if (selectedMovie == null) return;
            EditWindow win = new EditWindow(selectedMovie.MovieSerial, "MovieImdb");
            win.ShowDialog();
        }
        private void edit_movieCountry(object sender, RoutedEventArgs e)
        {
            Movie selectedMovie = itemsListBox.SelectedItem as Movie;
            if (selectedMovie == null) return;
            EditWindow win = new EditWindow(selectedMovie.MovieSerial, "MovieCountry");
            win.ShowDialog();
        }

        private void GetValuesFromSearchByYear2(int year1, int year2 )
        {
            entityTextBlock.Text = "Movies:";
            editMovieCountry.IsEnabled = true;
            editMovieIMDB.IsEnabled = true;
            editMovieYear.IsEnabled = true;
            editBirthYear.IsEnabled = false;
            try
            {
                using( var ctx = new MoviesDBContext())
                {
                    itemsListBox.ItemsSource = (from mo in ctx.Movies
                                          where mo.Year >= year1 && mo.Year <= year2
                                          select mo).ToList();
                }
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Type: " + ex.GetType().ToString());
            }
        }

        private void GetValuesFromSearchByYear1(int year )
        {
            entityTextBlock.Text = "Movies:";
            editMovieCountry.IsEnabled = true;
            editMovieIMDB.IsEnabled = true;
            editMovieYear.IsEnabled = true;
            editBirthYear.IsEnabled = false;
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    itemsListBox.ItemsSource = (from mo in ctx.Movies
                                                where mo.Year == year
                                                select mo).ToList();
                }
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Type: " + ex.GetType().ToString());
            }
        }

        private void GetMovieListBy2Actors(List<Movie> movies)
        {
            entityTextBlock.Text = "Movies:";
            editMovieCountry.IsEnabled = true;
            editMovieIMDB.IsEnabled = true;
            editMovieYear.IsEnabled = true;
            editBirthYear.IsEnabled = false;
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    itemsListBox.ItemsSource = movies;
                }
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Type: " + ex.GetType().ToString());
            }

        }
        private void GetOscarYear(int year)
        {
            entityTextBlock.Text = "Movies:";
            editMovieCountry.IsEnabled = true;
            editMovieIMDB.IsEnabled = true;
            editMovieYear.IsEnabled = true;
            editBirthYear.IsEnabled = false;
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    itemsListBox.ItemsSource = (from os in ctx.Oscars
                                                where os.Year == year
                                                select os.BestMotionPictureMovieSerialNavigation
                                                ).ToList();
                }
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Type: " + ex.GetType().ToString());
            }

        }

        
    }
}
