﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PLWebcinemagic
{
    public partial class BookedPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int newOrderId = Convert.ToInt32(Request.QueryString["id"]);
            lblReservationNumber.Text = newOrderId.ToString();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");
        }
    }
}