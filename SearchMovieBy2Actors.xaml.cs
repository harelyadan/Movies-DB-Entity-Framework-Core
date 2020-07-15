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
    /// Interaction logic for SearchMovieBy2Actors.xaml
    /// </summary>
    public partial class SearchMovieBy2Actors : Window
    {
        public delegate void GetSearchInput(List<Movie> movie);
        public GetSearchInput getValueCallBack;
        public SearchMovieBy2Actors()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            try
            {
                using( var ctx = new MoviesDBContext())
                {
                    actors1ComboBox.ItemsSource = (from ac in ctx.Actors
                                                   select ac.PrintName()).ToList();
                    actors2ComboBox.ItemsSource = (from ac in ctx.Actors
                                                   select ac.PrintName()).ToList();
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new MoviesDBContext())
                {
                    List<Actor> actors = (from ac in ctx.Actors
                                          select ac).ToList();
                    Actor actor1 = null, actor2 = null;
                    foreach (Actor item in actors)
                    {
                        if (item.PrintName() == actors1ComboBox.Text)
                            actor1 = item;
                        if (item.PrintName() == actors2ComboBox.Text)
                            actor2 = item;
                    }
                    if (actor1 == null || actor2 == null) return;
                    List<Movie> movies = new List<Movie>();

                    List<ActorMovie> actorsMovie = (from am in ctx.ActorMovie
                                          select am).ToList();
                    foreach (ActorMovie am1 in actorsMovie)
                    {
                        if( am1.ActorId == actor1.Id )
                            foreach (ActorMovie am2 in actorsMovie)
                            {
                                if (am2.MovieSerial == am1.MovieSerial)
                                    if (am2.ActorId == actor2.Id)
                                        movies.Add(ctx.Movies.Find(am2.MovieSerial));
                            }
                    }

                    getValueCallBack(movies);
                    Close();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
