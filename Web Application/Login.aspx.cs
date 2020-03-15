using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace aspnetlogin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\Projects;Initial Catalog=MyDataBase2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            
            con.Open();
            string chkusr = ("Select Count(*) from dbo.tbl_Login where UserName='" + txtUserName.Text + "' and Password ='" + txtPwd.Text + "'");

            SqlCommand com = new SqlCommand(chkusr,con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            
            
             con.Close();
         if(temp == 1)
            {
              
                con.Open();
                string  chkPasswordQuery = "Select Password from dbo.tbl_Login Where UserName='" + txtUserName.Text+"'";
                SqlCommand passcom = new SqlCommand(chkPasswordQuery,con);
                string password = passcom.ExecuteScalar().ToString();

                if(password == txtPwd.Text)
                {
                    Response.Write("Password is correct");

                }
                else
                {
                    Session["New"] = txtUserName.Text;
                    Response.Write("Password is not correct");
                }
         }
                else 
                {
                    Response.Write("User Name not correct");
                }
            }
            
           
            }
        }
    
