using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOcinemagic;

namespace PLWebcinemagic
{
    public partial class MoviesPage : System.Web.UI.Page
    {
        Movie currentMovie;
        Movies currentMovies;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentMovie = new Movie();
                currentMovies = new Movies();
                Movie xxx = currentMovie.GetMovie(3);
                Movies yyy = currentMovie.GetAllMovies();

                Session["allMovies"] = currentMovie.GetAllMovies();

                //GvMovies.DataSource = yyy;
                //GvMovies.DataBind();

                DlMovies.DataSource = yyy;
                DlMovies.DataBind();
            }
            
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");
        }

        protected void ibtnPicture_Click(object sender, ImageClickEventArgs e)
        {
            string arguments = ((ImageButton) sender).CommandArgument;

            string movieId = arguments.Substring(0, arguments.IndexOf(","));
            string title = arguments.Substring(arguments.IndexOf(",") + 1);
            
                Response.Redirect("MovieDetailPage.aspx?id=" + movieId + "&title=" + title + "");
        }
       
    }
}