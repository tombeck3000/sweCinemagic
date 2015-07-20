using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOcinemagic;

namespace PLWebcinemagic
{
    public partial class Register : System.Web.UI.Page
    {
        User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = new User();
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            currentUser.FirstName = txtFirstName.Text;
            currentUser.LastName = txtLastName.Text;
            currentUser.EMail = txtEmail.Text;
            currentUser.Password = txtPassword.Text;

            if (currentUser.Save() == true)
            {
                Response.Redirect("Login.aspx");
            }
            
        }
    }
}