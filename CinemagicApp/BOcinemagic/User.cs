using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

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
            set { userId = value; }
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

        public string CheckAuthorization(string userName, string password)
        {
            string retPassword = "";
            string userId = "";
            string sql = "select Password, UserID from [User] where UserName = @userName";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();

            cmd.Parameters.Add(new SqlParameter("@userName", userName));

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    retPassword = reader["Password"].ToString();
                    userId = reader["UserID"].ToString();
                }
            }
            
            if (retPassword == password)
            {
                return userId;
            }
            else
            {
                return string.Empty;
            }
            
        }

        private string HashPassword(string password)
        {
            byte[] passwordData = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
            passwordData = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordData);
            return System.Text.ASCIIEncoding.ASCII.GetString(passwordData);
        }

    }
}
