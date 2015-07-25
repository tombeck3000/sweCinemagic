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
        public Movie() { }
        
        public Movies GetAllMovies()
        { 
            Movies movies = new Movies();
            string sql = "select m.MovieID, m.Title, m.Length, m.FSK, m.Description, m.PictureUrl, g.Name as Genre from [Movie] as m left join [Genre] as g on m.GenreID = g.GenreID";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    movies.Add(Create(reader));
                   
                }
            }
            return movies;
        }
              

        public Movie GetMovie(int movieId)
        {
            Movie retMovie = new Movie();
            string sql = "select * from [Movie] where MovieID = @movieId";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("@movieId", movieId));
            
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                retMovie = Create(reader);
                reader.Close();
            }
            
            return retMovie;
        }
        
        public static Movie Create(IDataRecord record)
        {
            return new Movie
            {
                MovieId = Convert.ToInt32(record["MovieID"].ToString()),
                Title = record["Title"].ToString(),
                Length = Convert.ToInt32(record["Length"].ToString()),
                Fsk = Convert.ToInt32(record["FSK"].ToString()),
                Description = record["Description"].ToString(),
                PictureUrl = record["PictureUrl"].ToString(),
                GenreId = Convert.ToInt32(record["GenreId"].ToString())
            };  
        }
    }
}
