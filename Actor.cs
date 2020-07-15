using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MoviesDB_Manager
{
    public partial class Actor
    {
        public Actor()
        {
            ActorMovie = new HashSet<ActorMovie>();
            OscarsBestActor = new HashSet<Oscar>();
            OscarsBestActress = new HashSet<Oscar>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearBorn { get; set; }
        public int Gender { get; set; }

        public virtual ICollection<ActorMovie> ActorMovie { get; set; }
        public virtual ICollection<Oscar> OscarsBestActor { get; set; }
        public virtual ICollection<Oscar> OscarsBestActress { get; set; }

        public override string ToString()
        {
            if( Gender == 1 )
             return $"{FirstName} {LastName}, Male, Birth Year: {YearBorn}, Id: {Id}";
            return $"{FirstName} {LastName}, Female, Birth Year: {YearBorn}, Id: {Id}";
        }

        public string PrintName()
        {
            return $"{FirstName} {LastName}";
        }

        public string PrintNameAndID()
        {
            return $"{FirstName} {LastName}, id: {Id}";
        }

        public bool IsActorMovieConatain(int movieSerial, MoviesDBContext ctx)
        {
            List<ActorMovie> actorMovie = (from am in ctx.ActorMovie
                                           where Id == am.ActorId
                                           select am).ToList();
            foreach (ActorMovie item in actorMovie)
            {
                if (item.MovieSerial == movieSerial)
                    return true;
            }
            return false;
        }
    }
}
