using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddMovieToActor.xaml
    /// </summary>
    public partial class AddMovieToActor : Window
    {
        public AddMovieToActor()
        {
            InitializeComponent();
        }

        private void window_opened(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    actorsComboBox.ItemsSource = (from ac in ctx.Actors
                                                  where ac.Gender == 1
                                                     select ac.PrintName()).ToList();
                    
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("data is not in the correct format");
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Type: " + ex.GetType().ToString());
            }
        }

        
        private void add_click(object sender, RoutedEventArgs e)
        {
            Regex title = new Regex(@"^[a-zA-Z0-9,.:!?\s]{1,50}$");

            try
            {
                if( (bool) !checkBox.IsChecked)
                {
                    if (titleTextBox.Text.Trim() == "")
                        throw new NotCompletedException("You must insert movie title!");
                    if (!title.IsMatch(titleTextBox.Text.Trim()))
                        throw new ValidationException("Illegal title!");
                }
                else
                {
                    if( moviesComboBox.Text.Trim() == "" )
                        throw new NotCompletedException("You must choose movie!");
                }
                    

                using (var ctx = new MoviesDBContext())
                {
                    List<Actor> actors = (from ac in ctx.Actors
                                          where ac.Gender == 1
                                          select ac).ToList();
                    Actor actor = null;
                    foreach (Actor item in actors)
                    {
                        if (item.PrintName() == actorsComboBox.Text)
                            actor = item;
                    }
                    if (actor == null) return;
                    //--------------------------------------------------//

                    List<Movie> movies = (from mo in ctx.Movies
                                                select mo).ToList();
                    Movie movie = null;
                    if ((bool)!checkBox.IsChecked)
                    {
                        movie = new Movie
                        {
                            Title = titleTextBox.Text.Trim()
                        };
                        ctx.Movies.Add(movie);
                    }
                    else
                    {
                        foreach (Movie item in movies)
                        {
                            if (item.PrintTitleAndYear() == moviesComboBox.Text.Trim())
                                movie = item;
                        }
                    }

                    if (!(from am in ctx.ActorMovie
                          where actor.Id == am.ActorId
                          && movie.MovieSerial == am.MovieSerial
                          select am).Any())
                    {
                        ctx.ActorMovie.Add(new ActorMovie
                        {
                            Movie = movie,
                            Actor = actor
                        });
                    }
                    ctx.SaveChanges();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void checkedCB(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    moviesComboBox.IsEnabled = true;
                    titleTextBox.IsEnabled = false;
                    moviesComboBox.ItemsSource = (from mo in ctx.Movies
                                                     select mo.PrintTitleAndYear()).ToList();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void uncheckedCB(object sender, RoutedEventArgs e)
        {
            moviesComboBox.IsEnabled = false;
            titleTextBox.IsEnabled = true;
        }
    }
}