using System;

namespace VideoStoreKata
{
    public class Movie
    {
        public IMovie type;
        public String Title { get; set; }

        public Movie(String title, IMovie type)
        {
            this.Title = title;
            this.type = type;
        }
    }
}
