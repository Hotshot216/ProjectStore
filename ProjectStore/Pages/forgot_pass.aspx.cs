using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProjectStore.Pages
{
    public partial class forgot_pass : System.Web.UI.Page
    {
        string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        protected void Page_Load(object sender, EventArgs e)
        {

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

        public void enviaEmail()
        {
            

            MailMessage mail = new MailMessage();
            SmtpClient servidor = new SmtpClient();

            try
            {
                mail.From = new MailAddress("bruno.simoes.t0121525@edu.atec.pt"); //INSERIR EMAIL
                mail.To.Add(new MailAddress(tb_email.Text));
                mail.Subject = "PASSWORD TOKEN";
                mail.IsBodyHtml = true;
                mail.Body = "You need to insert a token to prove your identity when changing passwords.<br />" +
                    "Here is your token: <br /> <h2>"+ token +"</h2> <br />Change it <a href='https://localhost:44323//Pages/chgPwTkn.aspx?id=" + EncryptString(tb_email.Text) + "'>here</a>!";

                servidor.Host = "smtp.office365.com";
                servidor.Port = 587;

                servidor.Credentials = new NetworkCredential("bruno.simoes.t0121525@edu.atec.pt", "Sippinicetea_21"); //INSERIR CREDENCIAIS

                servidor.EnableSsl = true;

                servidor.Send(mail);

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                //}
            }
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@email", tb_email.Text);

            SqlParameter value = new SqlParameter();
            value.ParameterName = "@return";
            value.Direction = ParameterDirection.Output;
            value.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(value);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "check_email";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);

            myCon.Close();

            if (responseSP == 1)
            {
                Session["token"] = token;
                enviaEmail();
                pnl_before.Visible = false;
                pnl_after.Visible = true;
                
            }
            else
            {
                lbl_error.Visible = true;
            }
        }
    }
}