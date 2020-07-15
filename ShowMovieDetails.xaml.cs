using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MoviesDB_Manager
{
    /// <summary>
    /// Interaction logic for ShowMovieDetails.xaml
    /// </summary>
    public partial class ShowMovieDetails : Window
    {
        public ShowMovieDetails()
        {
            InitializeComponent();
        }

        private void Window_opened(object sender, EventArgs e)
        {
            try
            {
                using( var ctx = new MoviesDBContext())
                {
                    moviesComboBox.ItemsSource = (from mo in ctx.Movies
                                                  select mo.Title).ToList();
                }
            }catch(Exception ex)
            {
                ex.ToString();
            }
        }

        private void selected_movie(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    List<Movie> movies = (from mo in ctx.Movies
                                          select mo).ToList();
                    Movie movie = null;
                    foreach (Movie item in movies)
                    {
                        if (item.Title == moviesComboBox.SelectedItem.ToString())
                            movie = item;

                    }
                    if (movie == null) return;

                    if (movie.Year == 0) yearTextBlock.Text = "-NO DATA-";
                    else yearTextBlock.Text = movie.Year.ToString();

                    if(movie.DirectorId == null) directorTextBlock.Text = "-NO DATA-";
                    else directorTextBlock.Text = ctx.Directors.Find(movie.DirectorId).PrintName();
                    
                    if(movie.Country == null) countryTextBlock.Text = "-NO DATA-";
                    else countryTextBlock.Text = movie.Country;

                    if (movie.ImdbScore == 0) imdbTextBlock.Text = "-NO DATA-";
                    else imdbTextBlock.Text = movie.ImdbScore.ToString();

                    actorsListBox.ItemsSource = (from am in ctx.ActorMovie
                                                 join ac in ctx.Actors
                                                 on am.ActorId equals ac.Id
                                                 where am.MovieSerial == movie.MovieSerial
                                                 select ac.PrintName()).ToList();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            
        }
    }
}
