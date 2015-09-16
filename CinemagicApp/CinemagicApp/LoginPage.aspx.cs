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
        private User loginUser;
        private User lastRegistratedUser;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            loginUser = new User();

            //Get the UserName from the Registration-Page for better usability
            if (Session["currentUser"] != null)
            {
                lastRegistratedUser = (User)Session["currentUser"];
                txtUsername.Text = lastRegistratedUser.UserName;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            loginUser.UserName = txtUsername.Text;
            loginUser.Password = txtPassword.Text;

            string userId = loginUser.CheckAuthorization(loginUser.UserName, loginUser.Password);
            if (userId != string.Empty)
            {
                loginUser.UserId = userId.ToString();
                Session["loggedUser"] = loginUser;
                Response.Redirect("MoviesPage.aspx");
            }

        }
    }

}