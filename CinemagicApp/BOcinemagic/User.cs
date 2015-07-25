using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BOcinemagic
{
    public class User
    {
        private string userId = "";
        private string userName;
        private string firstName;
        private string lastName;
        private string eMail;   
        private string password;

        public string UserId
        {
            get { return userId; } 
            internal set { userId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string EMail
        {
            get { return eMail; }
            set { eMail = value; }
        }
        public string Password
        {
            get { return HashPassword(password); }
            set { password = value; }
        }
        
        public User() { }
        
        public bool SignUpRegistration()
        {
            string sql = "insert into [User] (UserID, UserName, FirstName, LastName, EMail, Password) values (@userId, @userName, @firstName, @lastName, @eMail, @password)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
            userId = Guid.NewGuid().ToString();

            cmd.Parameters.Add(new SqlParameter("@userId", UserId));
            cmd.Parameters.Add(new SqlParameter("@userName", UserName));
            cmd.Parameters.Add(new SqlParameter("@firstName", FirstName));
            cmd.Parameters.Add(new SqlParameter("@lastName", LastName));
            cmd.Parameters.Add(new SqlParameter("@eMail", EMail));
            cmd.Parameters.Add(new SqlParameter("@password", Password));
            
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool CheckAuthorization(string userName, string password)
        {
            bool retVal = false;
            string sql = "select Password from [User] where UserName = @userName";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();

            cmd.Parameters.Add(new SqlParameter("@userName", userName));
            string retPassword = cmd.ExecuteScalar().ToString();
            if (retPassword == password)
            {
                retVal = true;
            }
            
            return retVal;
        }

        private string HashPassword(string password)
        {
            byte[] passwordData = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
            passwordData = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordData);
            return System.Text.ASCIIEncoding.ASCII.GetString(passwordData);
        }

    }
}
