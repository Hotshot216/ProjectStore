using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Web.UI;

namespace ProjectStore.Pages
{
    public partial class add_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Page.Form.Enctype = "multipart/form-data";


                if (Session["login"] == null)
                {
                    Response.Redirect("app.aspx");
                }
            }
        }

        protected void btn_apply_Click(object sender, EventArgs e)
        {
            decimal ogPrice = Convert.ToDecimal(tb_price.Text);

            decimal salePrice = ogPrice - (ogPrice * 0.20m);

            tb_resalePrice.Text = salePrice.ToString("N2");
        }

        protected void btn_personalizedValue_Click(object sender, EventArgs e)
        {
            switch (tb_resalePrice.ReadOnly)
            {
                case true:
                    tb_resalePrice.ReadOnly = false;
                    break;

                case false:
                    tb_resalePrice.ReadOnly = true;
                    tb_resalePrice.Text = "";
                    break;
            }

        }

        protected void btn_addProd_Click(object sender, EventArgs e)
        {

            Stream imgStream = FileUpload1.PostedFile.InputStream;

            string contentType = FileUpload1.PostedFile.ContentType;
            int comprimento = FileUpload1.PostedFile.ContentLength;


            byte[] fotoBinario = new byte[comprimento];
            imgStream.Read(fotoBinario, 0, comprimento);

            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@name", tb_name.Text);
            myCommand.Parameters.AddWithValue("@value", Convert.ToDecimal(tb_price.Text));
            myCommand.Parameters.AddWithValue("@value_resale", Convert.ToDecimal(tb_resalePrice.Text));
            myCommand.Parameters.AddWithValue("@sales", Convert.ToInt32(tb_sales.Text));
            myCommand.Parameters.AddWithValue("@stock", Convert.ToInt32(tb_stock.Text));
            myCommand.Parameters.AddWithValue("@img_type", contentType);
            myCommand.Parameters.AddWithValue("@image", fotoBinario);

            SqlParameter value = new SqlParameter();
            value.ParameterName = "@return";
            value.Direction = ParameterDirection.Output;
            value.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(value);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "add_product";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);

            myCon.Close();

            if (responseSP == 0)
            {
                lbl_message.Visible = true;
                lbl_message.Text = "Product already exists";
            }
            else
            {
                pnl_addProduct.Visible = false;
                lbl_image.Visible = false;  
                FileUpload1.Visible = false;
                btn_addProd.Visible = false;
                pnl_success.Visible = true;

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
               "setTimeout(function() { window.location.replace('dashboard.aspx') }, 5000);", true);


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