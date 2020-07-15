using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;

namespace MoviesDB_Manager
{
    /// <summary>
    /// Interaction logic for AddOscar.xaml
    /// </summary>
    public partial class AddOscar : Window
    {
        public AddOscar()
        {
            InitializeComponent();
        }

        private void add_movie_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex name = new Regex(@"^[A-Z][A-Za-z]*(\s+[A-Z][A-Za-z]*){0,1}$");
                Regex title = new Regex(@"^[a-zA-Z0-9,.:!?\s]{1,50}$");

                if (!IsAllTextBoxesAreFilled())
                    throw new NotCompletedException("You must fill or choose all details!");

                if (!int.TryParse(yearTextBox.Text.Trim(), out int temp))
                    throw new ValidationException("Illegal year!");

                if (int.Parse(yearTextBox.Text) < 1929 || int.Parse(yearTextBox.Text) > 2020)
                    throw new ValidationException("Year must be between 1929 and 2020!");

                if((bool)!actressCheckBox.IsChecked)
                {
                    if (!name.IsMatch(actressFnTextBox.Text.Trim()))
                        throw new ValidationException("Illegal best actress first name!");

                    if (!name.IsMatch(actressLnTextBox.Text.Trim()))
                        throw new ValidationException("Illegal best actress last name!");
                }

                if ((bool)!actorCheckBox.IsChecked)
                {
                    if (!name.IsMatch(actorFnTextBox.Text.Trim()))
                        throw new ValidationException("Illegal best actor first name!");

                    if (!name.IsMatch(actorLnTextBox.Text.Trim()))
                        throw new ValidationException("Illegal best actor last name!");
                }

                if ((bool)!directorCheckBox.IsChecked)
                {
                    if (!name.IsMatch(directorFnTextBox.Text.Trim()))
                        throw new ValidationException("Illegal best director first name!");

                    if (!name.IsMatch(directorLnTextBox.Text.Trim()))
                        throw new ValidationException("Illegal best director last name!");
                }

                if ((bool)!movieCheckBox.IsChecked)
                {
                    if (!title.IsMatch(movieTextBox.Text.Trim()))
                        throw new ValidationException("Illegal movie title!");
                }

                using (var ctx = new MoviesDBContext())
                {
                    List<Actor> actors = (from ac in ctx.Actors
                                          select ac).ToList();

                    Actor bestActress = null;
                    if ((bool)!actressCheckBox.IsChecked)
                    {
                        bestActress = new Actor
                        {
                            FirstName = actressFnTextBox.Text.Trim(),
                            LastName = actressLnTextBox.Text.Trim(),
                            Gender = 0
                        };
                        ctx.Actors.Add(bestActress);
                    }
                    else
                    {
                        foreach (Actor item in actors)
                        {
                            if (item.PrintNameAndID() == actressesComboBox.Text.Trim())
                                bestActress = item;
                        }
                    }
                    if (bestActress == null) return;


                    Actor bestActor = null;
                    if ((bool)!actorCheckBox.IsChecked)
                    {
                        bestActor = new Actor
                        {
                            FirstName = actressFnTextBox.Text.Trim(),
                            LastName = actressLnTextBox.Text.Trim(),
                            Gender = 1
                        };
                        ctx.Actors.Add(bestActor);
                    }
                    else
                    {
                        foreach (Actor item in actors)
                        {
                            if (item.PrintNameAndID() == actorsComboBox.Text.Trim())
                                bestActor = item;

                        }
                    }
                    if (bestActor == null) return;


                    List<Director> directors = (from di in ctx.Directors
                                                select di).ToList();
                    Director director = null;
                    if ((bool)!actorCheckBox.IsChecked)
                    {
                        director = new Director
                        {
                            FirstName = directorFnTextBox.Text.Trim(),
                            LastName = directorLnTextBox.Text.Trim(),
                        };
                        ctx.Directors.Add(director);
                    }
                    else
                    {
                        foreach (Director item in directors)
                        {
                            if (item.PrintNameAndID() == directorsComboBox.Text.Trim() )
                                director = item;
                        }
                    }
                    if (director == null) return;


                    List<Movie> movies = (from mo in ctx.Movies
                                          select mo).ToList();
                    Movie movie = null;
                    if ((bool)!movieCheckBox.IsChecked)
                    {
                        movie = new Movie
                        {
                            Title = movieTextBox.Text.Trim()
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
                    if (movie == null) return;

                    Oscar oscar = null;
                    List<Oscar> oscars = (from os in ctx.Oscars
                                          where os.Year == int.Parse(yearTextBox.Text.Trim())
                                          select os).ToList();
                    foreach (Oscar item in oscars)
                    {
                        if (int.Parse(yearTextBox.Text) == item.Year)
                            oscar = item;
                    }
                    if( oscar == null)
                    {
                        oscar = new Oscar
                        {
                            Year = int.Parse(yearTextBox.Text.Trim()),
                            BestActress = bestActress,
                            BestActor = bestActor,
                            BestDirector = director,
                            BestMotionPictureMovieSerialNavigation = movie
                        };
                        ctx.Oscars.Add(oscar);
                        ctx.SaveChanges();
                        Close();
                    }
                    else throw new ItemExistException("Oscar in this year (" + oscar.Year.ToString() +
                            ") is already exist!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool IsAllTextBoxesAreFilled()
        {
            if (yearTextBox.Text == "") return false;

            if((bool) !actorCheckBox.IsChecked)
            {
                if (actorFnTextBox.Text == "") return false;
                if (actorLnTextBox.Text == "") return false;
            }
            else
            {
                if (actorsComboBox.Text.Trim() == "") return false;
            }

            if ((bool)!actressCheckBox.IsChecked)
            {
                if (actressFnTextBox.Text == "") return false;
                if (actressLnTextBox.Text == "") return false;
            }
            else
            {
                if (actressesComboBox.Text.Trim() == "") return false;
            }

            if ((bool)!directorCheckBox.IsChecked)
            {
                if (directorFnTextBox.Text == "") return false;
                if (directorLnTextBox.Text == "") return false;
            }
            else
            {
                if (directorsComboBox.Text.Trim() == "") return false;
            }

            if ((bool)!movieCheckBox.IsChecked)
            {
                if (movieTextBox.Text == "") return false;
            }
            else
            {
                if (moviesComboBox.Text.Trim() == "") return false;
            }
            return true;
        }

        private void actress_cb_selected(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    actressesComboBox.IsEnabled = true;
                    actressFnTextBox.IsEnabled = false;
                    actressLnTextBox.IsEnabled = false;
                    actressesComboBox.ItemsSource = (from ac in ctx.Actors
                                                     where ac.Gender == 0
                                                     select ac.PrintNameAndID()).ToList();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void actor_cb_selected(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    actorsComboBox.IsEnabled = true;
                    actorFnTextBox.IsEnabled = false;
                    actorLnTextBox.IsEnabled = false;
                    actorsComboBox.ItemsSource = (from ac in ctx.Actors
                                                  where ac.Gender == 1
                                                  select ac.PrintNameAndID()).ToList();
                    
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void director_cb_selected(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    directorsComboBox.IsEnabled = true;
                    directorFnTextBox.IsEnabled = false;
                    directorLnTextBox.IsEnabled = false;
                    directorsComboBox.ItemsSource = (from di in ctx.Directors
                                                    select di.PrintNameAndID()).ToList();
                   
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void movie_cb_selected(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    moviesComboBox.IsEnabled = true;
                    movieTextBox.IsEnabled = false;
                    moviesComboBox.ItemsSource = (from mo in ctx.Movies
                                                   select mo.PrintTitleAndYear()).ToList();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void actress_cb_Unselected(object sender, RoutedEventArgs e)
        {
            actressesComboBox.IsEnabled = false;
            actressFnTextBox.IsEnabled = true;
            actressLnTextBox.IsEnabled = true;
        }

        private void actor_cb_Unselected(object sender, RoutedEventArgs e)
        {
            actorsComboBox.IsEnabled = false;
            actorFnTextBox.IsEnabled = true;
            actorLnTextBox.IsEnabled = true;
        }

        private void director_cb_Unselected(object sender, RoutedEventArgs e)
        {
            directorsComboBox.IsEnabled = false;
            directorFnTextBox.IsEnabled = true;
            directorLnTextBox.IsEnabled = true;
        }

        private void movie_cb_Unselected(object sender, RoutedEventArgs e)
        {
            moviesComboBox.IsEnabled = false;
            movieTextBox.IsEnabled = true;
        }
    }
}
