using System;
using System.Collections.Generic;

namespace MoviesDB_Manager
{
    public partial class ActorMovie
    {
        public int ActorId { get; set; }
        public int MovieSerial { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
