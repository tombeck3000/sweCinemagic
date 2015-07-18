using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLWebcinemagic
{
    public partial class MovieDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeatReservation.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeatReservation.aspx");
        }
    }
}