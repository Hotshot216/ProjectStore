using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace ProjectStore.Pages
{
    public partial class confirm_email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //USER CONFIRMATION
            if (Session["email"] == null)
            {
                Response.Redirect("app.aspx");
            }           
            else 
            {
                SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                myCommand.Parameters.AddWithValue("@email", Session["email"].ToString());

                SqlParameter value = new SqlParameter();
                value.ParameterName = "@return";
                value.Direction = ParameterDirection.Output;
                value.SqlDbType = SqlDbType.Int;
                myCommand.Parameters.Add(value);

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "check_active";

                myCommand.Connection = myCon;
                myCon.Open();
                myCommand.ExecuteNonQuery();

                int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);

                myCon.Close();

                if (responseSP == 1)
                {
                    Response.Redirect("app.aspx");
                }
                else
                {
                    enviaEmail();
                }                
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

        public void enviaEmail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient servidor = new SmtpClient();

            try
            {
                mail.From = new MailAddress("bruno.simoes.t0121525@edu.atec.pt"); //INSERIR EMAIL
                mail.To.Add(new MailAddress(Session["email"].ToString()));
                mail.Subject = "ACCOUNT ACTIVATION";
                mail.IsBodyHtml = true;
                mail.Body = "Welcome to our store.<br />To fully use our platform you need to have and active acount.<br />" +
                    "To activate your account click <a href='https://localhost:44323//Pages/account_confirmation.aspx?id=" + EncryptString(Session["email"].ToString()) + "'>here</a>!";

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


    }


}