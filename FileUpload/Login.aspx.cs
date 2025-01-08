using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUpload
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //her kommer det en query
            //select

            //hente ut un og pw fra login
            string userName = Login1.UserName;
            string passWord=Login1.Password;

            bool ok=GetUserByUserNameAndPassword(userName, passWord);

            if (ok)
            {
                e.Authenticated = true;
                Login1.Visible = false;
                
            }
        }

        public bool GetUserByUserNameAndPassword(string user, string passWord)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from [User] where UN=@un and PW=@pw", conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@un",user ));
                cmd.Parameters.Add(new SqlParameter("@pw", passWord));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                reader.Close();
                conn.Close();
            }
            return false;
        }
    }
}