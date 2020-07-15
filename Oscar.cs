using System;
using System.Collections.Generic;

namespace MoviesDB_Manager
{
    public partial class Oscar
    {
        public int Year { get; set; }
        public int? BestActressId { get; set; }
        public int? BestActorId { get; set; }
        public int? BestDirectorId { get; set; }
        public int? BestMotionPictureMovieSerial { get; set; }

        public virtual Actor BestActor { get; set; }
        public virtual Actor BestActress { get; set; }
        public virtual Director BestDirector { get; set; }
        public virtual Movie BestMotionPictureMovieSerialNavigation { get; set; }

        public override string ToString()
        {
           using (var ctx = new MoviesDBContext())
           {
               BestActress = ctx.Actors.Find(BestActressId);
               BestActor = ctx.Actors.Find(BestActorId);
               BestDirector = ctx.Directors.Find(BestDirectorId);
               BestMotionPictureMovieSerialNavigation = 
                   ctx.Movies.Find(BestMotionPictureMovieSerial);
           }
            return $"Year: {Year}, Best Actress: {BestActress.PrintName()}," +
                $" Best Actor: {BestActor.PrintName()}, Best Director: " +
                $"{BestDirector.PrintName()}, Best Motion Picture: " +
                $"{BestMotionPictureMovieSerialNavigation.Title}";
        }
    }
}
