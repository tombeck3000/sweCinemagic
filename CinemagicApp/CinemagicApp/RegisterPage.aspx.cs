using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOcinemagic;

namespace PLWebcinemagic
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = new User();
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Session["currentUser"] = currentUser;
            currentUser.UserName = txtUsername.Text;
            currentUser.FirstName = txtFirstName.Text;
            currentUser.LastName = txtLastName.Text;
            currentUser.EMail = txtEmail.Text;
            currentUser.Password = txtPassword.Text;
            
            if (currentUser.SignUpRegistration())
            {
                Response.Redirect("LoginPage.aspx");
            }
            
        }
    }
}