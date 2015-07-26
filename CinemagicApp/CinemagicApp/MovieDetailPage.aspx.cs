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
        private Movies currentMovies;
        private int movieId;
        private string title;
        private string pictureUrl;
        private string description;
        private int length;
        private int fsk;
        private string genre;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentMovies = (Movies)Session["allMovies"];
            movieId = Convert.ToInt32(Request.QueryString["id"]);
           
            FillMovieDetails();
            FillScreeningButtons();
        }

        private void FillMovieDetails()
        {
            foreach (Movie movie in currentMovies)
            {
                if (movie.MovieId == movieId)
                {
                    title = movie.Title;
                    pictureUrl = movie.PictureUrl;
                    description = movie.Description;
                    length = movie.Length;
                    fsk = movie.Fsk;
                    genre = movie.Genre;
                    break;
                }
            }

            lblTitleValue.Text = title;
            picture.ImageUrl = pictureUrl;
            lblDescriptionValue.Text = description;
            lblLengthValue.Text = length + " min";
            lblFskValue.Text = fsk.ToString();
            lblGenreValue.Text = genre.ToString();
        }

        private void FillScreeningButtons()
        {
            MovieScreening currentScreening = new MovieScreening();
            MovieScreenings ms = currentScreening.GetMovieScreening(movieId);

            DateTime firstDate = ms[0].Date;
            DateTime secondDate = ms[1].Date;
            DateTime thirdDate = ms[2].Date;

            DateTime firstTime = ms[0].Time;
            DateTime secondTime = ms[1].Time;
            DateTime thirdTime = ms[2].Time;


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
            Response.Redirect("SeatReservationPage.aspx");
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeatReservationPage.aspx");
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeatReservationPage.aspx");
        }
    }
}