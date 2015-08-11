using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOcinemagic;

namespace PLWebcinemagic
{
    public partial class MovieDetailPage : System.Web.UI.Page
    {
        private int movieId;
        private Movie movie;
        private List<Movie> movieWithScreenings;
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            movieId = Convert.ToInt32(Request.QueryString["id"]);
            List<Movie> allMoviesWithScreening = (List<Movie>)Session["allMoviesWithScreening"];
            movie = allMoviesWithScreening.FirstOrDefault(m => m.MovieId == movieId);
            movieWithScreenings = allMoviesWithScreening.Where(m => m.MovieId == movieId).Take(3).ToList();

            FillMovieDetails();
            FillScreeningButtons();
        }

        private void FillMovieDetails()
        {
            lblTitleValue.Text = movie.Title;
            picture.ImageUrl = movie.PictureUrl;
            lblDescriptionValue.Text = movie.Description;
            lblLengthValue.Text = movie.Length + " min";
            lblFskValue.Text = movie.Fsk.ToString();
            lblGenreValue.Text = movie.Genre;
        }

        private void FillScreeningButtons()
        {
            DateTime firstDate = movieWithScreenings[0].Date;
            DateTime secondDate = movieWithScreenings[1].Date;
            DateTime thirdDate = movieWithScreenings[2].Date;

            DateTime firstTime = movieWithScreenings[0].Time;
            DateTime secondTime = movieWithScreenings[1].Time;
            DateTime thirdTime = movieWithScreenings[2].Time;


            btn1.Text = firstDate.Day.ToString().PadLeft(2, '0') + "." + firstDate.Month.ToString().PadLeft(2, '0') + "." + firstDate.Year + ", " + firstTime.Hour.ToString().PadLeft(2, '0') + ":" + firstTime.Minute.ToString().PadLeft(2, '0');
            btn2.Text = secondDate.Day.ToString().PadLeft(2, '0') + "." + secondDate.Month.ToString().PadLeft(2, '0') + "." + secondDate.Year + ", " + secondTime.Hour.ToString().PadLeft(2, '0') + ":" + secondTime.Minute.ToString().PadLeft(2, '0');
            btn3.Text = thirdDate.Day.ToString().PadLeft(2, '0') + "." + thirdDate.Month.ToString().PadLeft(2, '0') + "." + thirdDate.Year + ", " + thirdTime.Hour.ToString().PadLeft(2, '0') + ":" + thirdTime.Minute.ToString().PadLeft(2, '0');
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Session["chosenScreening"] = movieWithScreenings[0];
            Response.Redirect("SeatReservationPage.aspx");
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            Session["chosenScreening"] = movieWithScreenings[1];
            Response.Redirect("SeatReservationPage.aspx");
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            Session["chosenScreening"] = movieWithScreenings[2];
            Response.Redirect("SeatReservationPage.aspx");
        }
    }
}