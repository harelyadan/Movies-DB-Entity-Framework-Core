using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
    /// Interaction logic for AddMovie.xaml
    /// </summary>
    public partial class AddMovie : Window
    {

        public AddMovie()
        {
            InitializeComponent();
        }

        private void add_movie_click(object sender, RoutedEventArgs e)
        {
            Regex title = new Regex(@"^[a-zA-Z0-9,.:!?\s]{1,50}$");
            Regex country = new Regex(@"^[A-Z][A-Za-z]*(\s+[A-Z][A-Za-z]*){0,6}$");
            try
            {
                if (titleTextBox.Text.Trim() == "" )
                    throw new NotCompletedException("You must fill title!");

                if (!title.IsMatch(titleTextBox.Text.Trim()))
                    throw new ValidationException("Illegal title!");

                if(!int.TryParse(yearTextBox.Text.Trim(), out int temp))
                    throw new ValidationException("Illegal year!");

                if (int.Parse(yearTextBox.Text) < 1900 || int.Parse(yearTextBox.Text) > 2020)
                    throw new ValidationException("Year must be between 1900 and 2020!");

                if ( countryTextBox.Text.Trim() != "")
                {
                    if(!country.IsMatch(countryTextBox.Text.Trim()))
                        throw new ValidationException("Illegal country!");
                }

                if (imdbTextBox.Text.Trim() != "")
                {
                    if(!double.TryParse(imdbTextBox.Text, out double temp1))
                        throw new ValidationException("Illegal IMDB Score!");
                }

                if (double.Parse(imdbTextBox.Text) !=
                        System.Math.Round(double.Parse(imdbTextBox.Text), 1))
                    throw new ValidationException("IMDB score should be with only one digit after dot!");

                if(double.Parse(imdbTextBox.Text) < 1 || double.Parse(imdbTextBox.Text) > 10)
                    throw new ValidationException("IMDB score must be between 1 and 10!");

                using (var ctx = new MoviesDBContext())
                {
                    Movie movie = new Movie
                    {
                        Title = titleTextBox.Text.Trim(),
                        Year = int.Parse(yearTextBox.Text.Trim()),
                        Country = countryTextBox.Text.Trim(),
                        ImdbScore = System.Math.Round(double.Parse(imdbTextBox.Text), 1)
                    };
                    List<Movie> movies = (from mo in ctx.Movies
                                          select mo).ToList();
                    foreach (Movie mov in movies)
                    {
                        if (mov.Title == movie.Title && mov.Year == movie.Year)
                        {
                            throw new ItemExistException(
                                movie.PrintTitleAndYear() + " is already exist!" + '\n'
                                + "You can't add a movie with the same title and year."
                                );
                        }
                    }
                    
                    List<Director> directors = (from di in ctx.Directors
                                                select di).ToList();
                    foreach (Director dire in directors)
                        if (dire.PrintName() == directorComboBox.Text)
                            movie.Director = dire;

                    foreach (var actor in actorsListBox.Items)
                    {
                        CheckBox cb = actor as CheckBox;

                        List<Actor> actors = (from ac in ctx.Actors
                                              select ac).ToList();
                        if ((bool)cb.IsChecked)
                        {
                            ActorMovie selectedItem = new ActorMovie
                            {
                                Movie = movie,
                                Actor = GetActorFromList(actors, cb.Content.ToString())
                            };
                            movie.ActorMovie.Add(selectedItem);
                        }
                    }
                    ctx.Movies.Add(movie);
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

        private Actor GetActorFromList(List<Actor> actors, string content)
        {
            foreach (Actor actor in actors)
            {
                if (actor.PrintName() == content) return actor;
            }
            return null;
        }

        private void open_window(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    directorComboBox.ItemsSource = (from di in ctx.Directors
                                                    select di.FirstName + " " + di.LastName).ToList();
                    int actorsCount = ctx.Actors.Count();
                    List<string> actors = (from ac in ctx.Actors
                                           select ac.FirstName + " " + ac.LastName).ToList();
                    for (int i = 0; i < actors.Count; i++)
                    {
                        CheckBox cb = new CheckBox();
                        cb.Content = actors[i];
                        cb.VerticalAlignment = VerticalAlignment.Top;
                        actorsListBox.Items.Add(cb);
                    }

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
                MessageBox.Show(ex.Message);
            }
        }

    }
}
