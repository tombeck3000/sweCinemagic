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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeatReservationPage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeatReservationPage.aspx");
        }
    }
}