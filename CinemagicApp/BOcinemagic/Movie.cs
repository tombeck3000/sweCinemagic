using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BOcinemagic
{
    public class Movie
    {
        private int movieId;
        private string title;
        private int length;
        private int fsk;
        private string description;
        private string pictureUrl;
        private int genreId;
        private string genre;
        private int movieScreeningId;
        private DateTime date;
        private DateTime time;
        

        public int MovieId
        {
            get { return movieId; }
            set { movieId = value; }
        }        
        public string Title
        {
            get { return title; }
            set { title = value; }
        }        
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public int Fsk
        {
            get { return fsk; }
            set { fsk = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }        
        public string PictureUrl
        {
            get { return pictureUrl; }
            set { pictureUrl = value; }
        }
        public int GenreId
        {
            get { return genreId; }
            set { genreId = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value;}
        }
        public int MovieScreeningId
        {
            get { return movieScreeningId; }
            set { movieScreeningId = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
        public Movie() { }
        
        public static List<Movie> GetAllMovies()
        { 
            List<Movie> movies = new List<Movie>();
            string sql = "select m.MovieID, m.Title, m.Length, m.FSK, m.Description, m.PictureUrl, g.GenreID, g.Name as Genre" +
                         " from [Movie] as m" +
                         " left join [Genre] as g" +
                         " on m.GenreID = g.GenreID";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    movies.Add(CreateMovie(reader));
                }
            }
            return movies;
        }

        public static List<Movie> GetAllMoviesWithScreening()
        {
            List<Movie> movies = new List<Movie>();
            string sql = "select m.MovieID, ms.MovieScreeningID, m.Title, ms.Date, ms.Time, m.Length, m.FSK, m.Description, m.PictureUrl, g.GenreID, g.Name as Genre " +
                         "from [Movie] as m " +
                         "left join [Genre] as g " +
                         "on m.GenreID = g.GenreID " +
                         "right join [MovieScreening] as ms " +
                         "on m.MovieID = ms.MovieID";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    movies.Add(CreateMovieWithScreening(reader));
                }
            }
            return movies;
        }

        public Movie GetMovie(int movieId)
        {
            Movie movie = new Movie();
            string sql = "select m.MovieID, m.Title, m.Length, m.FSK, m.Description, m.PictureUrl, g.GenreID, g.Name as Genre" +
                         " from [Movie] as m" +
                         " left join [Genre] as g" +
                         " on m.GenreID = g.GenreID" +
                         " where MovieID = @movieId";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("@movieId", movieId));

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                movie = CreateMovie(reader);
            }
            
            return movie;
        }
        
        public static Movie CreateMovie(IDataRecord record)
        {
            return new Movie
            {
                MovieId = Convert.ToInt32(record["MovieID"].ToString()),
                Title = record["Title"].ToString(),
                Length = Convert.ToInt32(record["Length"].ToString()),
                Fsk = Convert.ToInt32(record["FSK"].ToString()),
                Description = record["Description"].ToString(),
                PictureUrl = record["PictureUrl"].ToString(),
                GenreId = Convert.ToInt32(record["GenreID"].ToString()),
                Genre = record["Genre"].ToString()
            };  
        }

        public static Movie CreateMovieWithScreening(IDataRecord record)
        {
            return new Movie
            {
                MovieId = Convert.ToInt32(record["MovieID"].ToString()),
                MovieScreeningId = Convert.ToInt32(record["MovieScreeningId"].ToString()),
                Title = record["Title"].ToString(),
                Date = Convert.ToDateTime(record["Date"].ToString()),
                Time = Convert.ToDateTime(record["Time"].ToString()),
                Length = Convert.ToInt32(record["Length"].ToString()),
                Fsk = Convert.ToInt32(record["FSK"].ToString()),
                Description = record["Description"].ToString(),
                PictureUrl = record["PictureUrl"].ToString(),
                GenreId = Convert.ToInt32(record["GenreID"].ToString()),
                Genre = record["Genre"].ToString()
                
            };
        }
    }
}
