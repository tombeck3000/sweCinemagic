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
        private string firstName;
        private string lastName;
        private string eMail;
        private string password;


        public string UserId
        {
            get
            {
                return userId;
            }
            internal set
            {
                userId = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string EMail
        {
            get
            {
                return eMail;
            }
            set
            {
                eMail = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


        public User() { }
        //internal User()
        //{

        //}

        public bool Save()
        {
            bool ret = false;
            string sql = "insert into [User] (UserID, FirstName, LastName, EMail, Password) values (@userId, @firstName, @lastName, @eMail, @password)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
            userId = Guid.NewGuid().ToString();

            cmd.Parameters.Add(new SqlParameter("@userId", UserId));
            cmd.Parameters.Add(new SqlParameter("@firstName", FirstName));
            cmd.Parameters.Add(new SqlParameter("@lastName", LastName));
            cmd.Parameters.Add(new SqlParameter("@eMail", EMail));
            cmd.Parameters.Add(new SqlParameter("@password", Password));

            ret = cmd.ExecuteNonQuery() > 0;

            return ret; 
        }

    }
}
