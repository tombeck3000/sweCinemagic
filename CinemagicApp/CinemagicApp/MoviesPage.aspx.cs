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
        private List<Movie> allMovies;
        private List<Movie> allMoviesWithScreening;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                allMovies = Movie.GetAllMovies();
                allMoviesWithScreening = Movie.GetAllMoviesWithScreening();
                Session["allMovies"] = allMovies;
                Session["allMoviesWithScreening"] = allMoviesWithScreening;
                
                DlMovies.DataSource = allMovies;
                DlMovies.DataBind();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");
        }

        protected void ibtnPicture_Click(object sender, ImageClickEventArgs e)
        {
            string movieId = ((ImageButton) sender).CommandArgument;
            
            Response.Redirect("MovieDetailPage.aspx?id=" + movieId + "");
        }
       
    }
}