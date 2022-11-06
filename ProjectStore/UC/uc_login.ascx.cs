using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace ProjectStore.UC
{
    public partial class login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@user", tb_username.Text);
            myCommand.Parameters.AddWithValue("@password", EncryptString(tb_password.Text));

            SqlParameter value = new SqlParameter();
            value.ParameterName = "@return";
            value.Direction = ParameterDirection.Output;
            value.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(value);

            SqlParameter value2 = new SqlParameter();
            value2.ParameterName = "@return_profile";
            value2.Direction = ParameterDirection.Output;
            value2.SqlDbType = SqlDbType.VarChar;
            value2.Size = 20;
            myCommand.Parameters.Add(value2);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "login";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);

            string profile = myCommand.Parameters["@return_profile"].Value.ToString();

            myCon.Close();

            if (responseSP == 0)
            {
                lbl_message.Visible = true;
                lbl_message.Text = "Wrong username/password.";
            }
            else if (responseSP == 2)
            {
                lbl_message.Visible = true;
                lbl_message.Text = "This account has not been activated";
                enviaEmail();
            }
            else
            {
                Session["profile"] = profile;
                Session["email"] = tb_username.Text;
                Session["login"] = "true";
                switch (profile)
                {
                    case "Admin":
                        Session["admin"] = "true";
                        Response.Redirect("dashboard.aspx"); 
                        break;

                    case "Resale":
                        Session["Resale"] = "true";
                        Response.Redirect("app.aspx");
                        break;

                    default:
                        Response.Redirect("app.aspx");
                        break;


                }
            }
        }

        public void enviaEmail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient servidor = new SmtpClient();

            try
            {
                mail.From = new MailAddress("bruno.simoes.t0121525@edu.atec.pt"); //INSERIR EMAIL
                mail.To.Add(new MailAddress(tb_username.Text));
                mail.Subject = "ACCOUNT ACTIVATION";
                mail.IsBodyHtml = true;
                mail.Body = "Welcome to our store.<br />To fully use our platform you need to have and active acount.<br />" +
                    "To activate your account click <a href='https://localhost:44323/Pages/account_confirmation.aspx?id=" + EncryptString(tb_username.Text) + "'>here</a>!";

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