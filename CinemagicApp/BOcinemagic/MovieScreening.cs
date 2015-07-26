using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOcinemagic
{
    public class MovieScreening
    {
        private int movieScreeningId;
        private int movieId;
        private DateTime date;
        private DateTime time;

        public int MovieScreeningId
        {
            get { return movieScreeningId; }
            set { movieScreeningId = value; }
        }
        public int MovieId
        {
            get { return movieId; }
            set { movieId = value; }
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

        public MovieScreening() { }

        public MovieScreenings GetMovieScreening(int movieId)
        {
            MovieScreenings retMovieScreening = new MovieScreenings();
            string sql = "select top 3 * from [MovieScreening] where MovieID = @movieId order by Date, Time asc";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("@movieId", movieId));

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                retMovieScreening.Add(Create(reader));
            }

            return retMovieScreening;
        }

        public static MovieScreening Create(IDataRecord record)
        {
            return new MovieScreening
            {
                MovieScreeningId = Convert.ToInt32(record["MovieScreeningID"].ToString()),
                MovieId = Convert.ToInt32(record["MovieID"].ToString()),
                Date = Convert.ToDateTime(record["Date"].ToString()),
                Time = Convert.ToDateTime(record["Time"].ToString())
            };
        }
    }
}
