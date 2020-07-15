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
    /// Interaction logic for AddActorToMovie.xaml
    /// </summary>
    public partial class AddActorToMovie : Window
    {
        public AddActorToMovie()
        {
            InitializeComponent();
        }

        private void window_opened(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    moviesComboBox.ItemsSource = (from mo in ctx.Movies
                                                  select mo.PrintTitleAndYear()).ToList();
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
            Regex name = new Regex(@"^[A-Z][A-Za-z]*(\s+[A-Z][A-Za-z]*){0,1}$");
            try
            {
                if(!IsAllTextBoxesAreFilled())
                    throw new NotCompletedException("You must fill or choose all details!");

                if((bool) !checkBox.IsChecked)
                {
                    if (!name.IsMatch(firstNameTextBox.Text.Trim()))
                        throw new ValidationException("Illegal first name!");

                    if (!name.IsMatch(lastNameTextBox.Text.Trim()))
                        throw new ValidationException("Illegal last name!");
                }

                using (var ctx = new MoviesDBContext())
                {
                    List<Movie> movies = (from mo in ctx.Movies
                                          select mo).ToList();
                    Movie movie = null;
                    foreach (Movie item in movies)
                    {
                        if (item.PrintTitleAndYear() == moviesComboBox.Text)
                            movie = item;
                    }
                    if (movie == null) return;
                    //--------------------------------------------------//

                    List<Actor> actors = (from ac in ctx.Actors
                                          where ac.Gender == 1
                                          select ac).ToList();
                    Actor actor = null;
                    if( (bool) !checkBox.IsChecked)
                    {
                        actor = new Actor
                        {
                            FirstName = firstNameTextBox.Text.Trim(),
                            LastName = lastNameTextBox.Text.Trim(),
                            Gender = 1
                        };
                        ctx.Actors.Add(actor);
                        movie.ActorMovie.Add(new ActorMovie
                        {
                            Movie = movie,
                            Actor = actor
                        });
                    }
                    else
                    {
                        foreach (Actor item in actors)
                        {
                            if (item.PrintNameAndID() == actorsComboBox.Text.Trim())
                                actor = item;
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

        private bool IsAllTextBoxesAreFilled()
        {
            if ((bool)!checkBox.IsChecked)
            {
                if (firstNameTextBox.Text == "") return false;
                if (lastNameTextBox.Text == "") return false;
            }
            else
            {
                if (actorsComboBox.Text.Trim() == "") return false;
            }
            return true;
        }

        private void checkedCB(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    actorsComboBox.IsEnabled = true;
                    firstNameTextBox.IsEnabled = false;
                    lastNameTextBox.IsEnabled = false;
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

        private void uncheckedCB(object sender, RoutedEventArgs e)
        {
            actorsComboBox.IsEnabled = false;
            firstNameTextBox.IsEnabled = true;
            lastNameTextBox.IsEnabled = true;
        }
    }
}
