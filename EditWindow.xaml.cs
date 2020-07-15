using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MoviesDB_Manager
{
    public partial class EditWindow : Window
    {
        private int id;
        private string item;
        public EditWindow(int id, string item)
        {
            this.id = id;
            this.item = item;
            InitializeComponent();
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    switch (item)
                    {
                        case "ActorYear":
                            if (textBox.Text.Trim() == "")
                                throw new NotCompletedException("You must insert a year.");

                            if (!int.TryParse(textBox.Text.Trim(), out int temp))
                                throw new ValidationException("Illegal birth year!");

                            if (int.Parse(textBox.Text.Trim()) > 2020
                                    || int.Parse(textBox.Text.Trim()) < 1900)
                                throw new ValidationException("Birth year must be" +
                                    "between 1900 and 2020!");

                            Actor actor = (from ac in ctx.Actors
                                           where ac.Id == id
                                           select ac).First();
                            actor.YearBorn = int.Parse(textBox.Text.Trim());
                            break;
                        case "MovieYear":
                            if (textBox.Text.Trim() == "")
                                throw new NotCompletedException("You must insert a year.");

                            if (!int.TryParse(textBox.Text.Trim(), out int temp1))
                                throw new ValidationException("Illegal year!");

                            if (int.Parse(textBox.Text.Trim()) > 2020
                                    || int.Parse(textBox.Text.Trim()) < 1900)
                                throw new ValidationException("Movie year must be" +
                                    "between 1900 and 2020!");

                            List<Movie> movies = (from mo in ctx.Movies
                                                  select mo).ToList();
                            Movie movie = (from mo in ctx.Movies
                                           where mo.MovieSerial == id
                                           select mo).First();

                            foreach (Movie item in movies)
                            {
                                if( item.Title ==  movie.Title
                                    && item.Year == int.Parse(textBox.Text.Trim() )
                                    && item.MovieSerial != movie.MovieSerial )
                                    throw new ItemExistException(
                                item.Title + " is already exist!" + '\n'
                                + "You can't have a movie with the same title and year."
                                );
                            }

                            movie.Year = int.Parse(textBox.Text.Trim());
                            break;
                        case "MovieImdb":
                            if (textBox.Text.Trim() == "")
                                throw new NotCompletedException("You must insert an IMDB score.");

                            if (!double.TryParse(textBox.Text, out double temp2))
                                throw new ValidationException("Illegal IMDB Score!");

                            if (double.Parse(textBox.Text) !=
                        System.Math.Round(double.Parse(textBox.Text), 1))
                                throw new ValidationException("IMDB score should be with only one digit after dot!");

                            if (double.Parse(textBox.Text) < 1 || double.Parse(textBox.Text) > 10)
                                throw new ValidationException("IMDB score must be between 1 and 10!");

                            List<Movie> movies1 = (from mo in ctx.Movies
                                                  select mo).ToList();
                            Movie movie1 = (from mo in ctx.Movies
                                           where mo.MovieSerial == id
                                           select mo).First();
                            movie1.ImdbScore = System.Math.Round(double.Parse(textBox.Text), 1);
                            break;
                        case "MovieCountry":
                            Regex country = new Regex(@"^[A-Z][A-Za-z]*(\s+[A-Z][A-Za-z]*){0,6}$");

                            if (textBox.Text.Trim() == "")
                                throw new NotCompletedException("You must insert a country.");

                            if (textBox.Text.Trim() != "")
                            {
                                if (!country.IsMatch(textBox.Text.Trim()))
                                    throw new ValidationException("Illegal country!");
                            }

                            List<Movie> movies2 = (from mo in ctx.Movies
                                                   select mo).ToList();
                            Movie movie2 = (from mo in ctx.Movies
                                            where mo.MovieSerial == id
                                            select mo).First();
                            movie2.Country = textBox.Text.Trim();
                            break;
                        default:
                            break;
                    }
                    ctx.SaveChanges();
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
