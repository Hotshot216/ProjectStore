using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectStore.UC
{
    public partial class uc_register : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();                       

            myCommand.Parameters.AddWithValue("@email", tb_email.Text);
            myCommand.Parameters.AddWithValue("@password", EncryptString(tb_password.Text));
            myCommand.Parameters.AddWithValue("@name", tb_firstName.Text + " " + tb_lastName.Text);
            myCommand.Parameters.AddWithValue("@address", tb_address.Text);
            myCommand.Parameters.AddWithValue("@zipCode", tb_zipCode.Text);

            SqlParameter value = new SqlParameter();
            value.ParameterName = "@return";
            value.Direction = ParameterDirection.Output;
            value.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(value);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "user_register";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);

            myCon.Close();

            if (responseSP == 0)
            {
                lbl_message.Visible = true;
                lbl_message.Text = "User already exists";
            }
            else
            {
                Session["email"] = tb_email.Text;
                Response.Redirect("confirm_email.aspx");                
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