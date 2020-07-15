using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MoviesDB_Manager
{
    public partial class Movie
    {
        public Movie()
        {
            ActorMovie = new HashSet<ActorMovie>();
            Oscars = new HashSet<Oscar>();
        }

        public int MovieSerial { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public double ImdbScore { get; set; }
        public int? DirectorId { get; set; }

        public virtual Director Director { get; set; }
        public virtual ICollection<ActorMovie> ActorMovie { get; set; }
        public virtual ICollection<Oscar> Oscars { get; set; }

        public override string ToString()
        {
            using (var ctx = new MoviesDBContext())
            {
                Director = ctx.Directors.Find(DirectorId);
            }

            string di, coun, imdb, year;
            if (Director == null)
                di = "-NO DATA-";
            else di = Director.PrintName();

            if (Country == null)
                coun = "-NO DATA-";
            else coun = Country;

            if (ImdbScore == 0)
                imdb = "-NO DATA-";
            else imdb = ImdbScore.ToString();

            if (Year == 0)
                year = "-NO DATA-";
            else year = Year.ToString();

            return $"{Title}, {year}, Country: {coun}," +
           $" Director: {di}, MovieSerial: {MovieSerial}," +
           $" ImdbScore: {imdb}";
        }

        public string PrintTitleAndYear()
        {
            return $"{Title}, {Year}";
        }

        public bool IsActorMovieConatain( int id, MoviesDBContext ctx )
        {
            List<ActorMovie> actorMovie = (from am in ctx.ActorMovie
                                           where MovieSerial == am.MovieSerial
                                           select am).ToList();
            foreach (ActorMovie item in actorMovie)
            {
                if (item.ActorId == id)
                    return true;
            }
            return false;
        }
    }
}
