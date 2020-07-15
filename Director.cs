using System;
using System.Collections.Generic;

namespace MoviesDB_Manager
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
            Oscars = new HashSet<Oscar>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Oscar> Oscars { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Id: {Id}";
        }
        public string PrintName()
        {
            return $"{FirstName} {LastName}";
        }
        public string PrintNameAndID()
        {
            return $"{FirstName} {LastName}, id: {Id}";
        }
    }
}
