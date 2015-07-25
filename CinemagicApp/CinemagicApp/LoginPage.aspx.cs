using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOcinemagic;

namespace PLWebcinemagic
{
    public partial class LoginPage : System.Web.UI.Page
    {
        User loginUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            loginUser = new User();

            //Get the UserName from the Registration-Page for better usability
            if (Session["currentUserName"] != null)
            {
                txtUsername.Text = Session["currentUserName"].ToString();
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            loginUser.UserName = txtUsername.Text;
            loginUser.Password = txtPassword.Text;

            if (loginUser.CheckAuthorization(loginUser.UserName, loginUser.Password) == true)
            {
                Session["loggedUser"] = loginUser;
                Response.Redirect("MoviesPage.aspx");
            }

        }
    }

}