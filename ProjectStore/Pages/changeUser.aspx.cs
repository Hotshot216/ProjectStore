using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ProjectStore.Pages.Admin.dashboard;
using System.Threading;
using System.Security.Cryptography;

namespace ProjectStore.Pages
{
    public partial class changeUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (Session["admin"] == null)
            {
                Response.Redirect("app.aspx");
            }
            else
            {
                string id = Request.QueryString["id"];

                lbl_user.Text = id;

                SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                myCommand.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "list_user_id";

                myCommand.Connection = myCon;
                myCon.Open();
                SqlDataReader dr = myCommand.ExecuteReader();

                while (dr.Read())
                {
                    lbl_name.Text = dr["username"].ToString();
                    lbl_profile.Text = dr["profile"].ToString();
                    lbl_active.Text = dr["active"].ToString();
                    lbl_email.Text = dr["email"].ToString();
                    lbl_address.Text = dr["address"].ToString();
                    lbl_zipCode.Text = dr["zipCode"].ToString();
                }

                myCon.Close();
            }
        }

        protected void cb_name_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_name.Checked)
            {
                case true:
                    tb_name.Enabled=true;                    
                    break;
                case false:
                    tb_name.Enabled = false;
                    tb_name.Text = "";
                    break;
                default:
                    tb_name.Enabled =false;
                    tb_name.Text = "";
                    break;
            }
        }

        protected void cb_profile_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_profile.Checked)
            {
                case true:
                    ddl_profile.Enabled = true;
                    break;
                case false:
                    ddl_profile.Enabled = false;
                    ddl_profile.SelectedIndex = 0;
                    break;
                default:
                    ddl_profile.Enabled = false;
                    ddl_profile.SelectedIndex = 0;
                    break;
            }
        }

        protected void cb_active_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_active.Checked)
            {
                case true:
                    ddl_active.Enabled = true;
                    break;
                case false:
                    ddl_active.Enabled = false;
                    ddl_active.SelectedIndex = 0;
                    break;
                default:
                    ddl_active.Enabled = false;
                    ddl_active.SelectedIndex = 0;
                    break;
            }
        }

        protected void cb_email_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_email.Checked)
            {
                case true:
                    tb_email.Enabled = true;
                    break;
                case false:
                    tb_email.Enabled = false;
                    tb_email.Text = "";
                    break;
                default:
                    tb_email.Enabled = false;
                    tb_email.Text = "";
                    break;
            }
        }

        protected void cb_address_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_address.Checked)
            {
                case true:
                    tb_address.Enabled = true;
                    break;
                case false:
                    tb_address.Enabled = false;
                    tb_address.Text = "";
                    break;
                default:
                    tb_address.Enabled = false;
                    tb_address.Text = "";
                    break;
            }
        }

        protected void cb_zipCode_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_zipCode.Checked)
            {
                case true:
                    tb_zipCode.Enabled = true;
                    break;
                case false:
                    tb_zipCode.Enabled = false;
                    tb_zipCode.Text = "";
                    break;
                default:
                    tb_zipCode.Enabled = false;
                    tb_zipCode.Text = "";
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
                SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["id"]));

            if (cb_name.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@name", tb_name.Text);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@name", "null");
            }
            if (cb_profile.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@profile", Convert.ToInt32(ddl_profile.SelectedValue));
            }
            else
            {
                myCommand.Parameters.AddWithValue("@profile", 10);
            }
            if (cb_active.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@active", Convert.ToInt32(ddl_active.SelectedValue));
            }
            else
            {
                myCommand.Parameters.AddWithValue("@active", 10);
            }
            if (cb_email.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@email", tb_email.Text);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@email", "null");
            }
            if (cb_address.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@address", tb_address.Text);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@address", "null");
            }
            if (cb_zipCode.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@zipCode", tb_zipCode.Text);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@zipCode", "null");
            }           


                SqlParameter value2 = new SqlParameter();
                value2.ParameterName = "@return";
                value2.Direction = ParameterDirection.Output;
                value2.SqlDbType = SqlDbType.VarChar;
                value2.Size = 20;
                myCommand.Parameters.Add(value2);

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "modify_user";

                myCommand.Connection = myCon;
                myCon.Open();
                myCommand.ExecuteNonQuery();

                int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);

                myCon.Close();

                if (responseSP == 1)
                {
                    lbl_error.Visible = false;
                

                }
                else
                {
                    lbl_error.Visible = true;
                }

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
           

        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            switch (pnl_delete.Visible)
            {
                case true:
                    pnl_delete.Visible = false;
                    break;
                case false:
                    pnl_delete.Visible = true;
                    break;
                default:
                    pnl_delete.Visible = false;
                    break;
            }
        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@email", Session["email"].ToString());
            myCommand.Parameters.AddWithValue("@id", Convert.ToInt32(Request.QueryString["id"]));
            myCommand.Parameters.AddWithValue("@password", EncryptString(tb_password.Text));

            SqlParameter value = new SqlParameter();
            value.ParameterName = "@return";
            value.Direction = ParameterDirection.Output;
            value.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(value);           

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "delete_user";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);
           

            myCon.Close();

            if (responseSP == 1)
            {
                lbl_warning.Visible = true;
                lbl_warning.Text = "User deleted with success. Wait 5 seconds for redirect.";

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
               "setTimeout(function() { window.location.replace('dashboard.aspx') }, 5000);", true);

            }
            else if (responseSP == 0)
            {
                lbl_warning.Visible = true;
            }
           
        }

        public static string EncryptString(string Message)
        {
            string Passphrase = "atec";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();



            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below



            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));



            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();



            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;



            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);



            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }



            // Step 6. Return the encrypted string as a base64 encoded string



            string enc = Convert.ToBase64String(Results);
            enc = enc.Replace("+", "KKK");
            enc = enc.Replace("/", "JJJ");
            enc = enc.Replace("\\", "III");
            return enc;
        }
    }
}