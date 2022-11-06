using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Web.UI;

namespace ProjectStore.Pages
{
    public partial class changeProduct : System.Web.UI.Page
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

                lbl_product.Text = id;

                SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                myCommand.Parameters.AddWithValue("@id_prod", Convert.ToInt32(id));

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "list_product_id";

                myCommand.Connection = myCon;
                myCon.Open();
                SqlDataReader dr = myCommand.ExecuteReader();

                while (dr.Read())
                {
                    lbl_name.Text = dr["name"].ToString();
                    lbl_price.Text = dr["value"].ToString();
                    lbl_resalePrice.Text = dr["value_resale"].ToString();
                    lbl_sales.Text = dr["sales"].ToString();
                    lbl_stock.Text = dr["stock"].ToString();
                    img_prod.ImageUrl = "data:" + dr["img_type"].ToString() + ";base64," + Convert.ToBase64String((byte[])dr["image"]);
                    
                }

                myCon.Close();
            }
        }

        //BUTTON CHANGE
        protected void cb_name_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_name.Checked)
            {
                case true:
                    tb_name.Enabled = true;
                    break;
                case false:
                    tb_name.Enabled = false;
                    tb_name.Text = "";
                    break;
                default:
                    tb_name.Enabled = false;
                    tb_name.Text = "";
                    break;
            }
        }

        protected void cb_price_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_price.Checked)
            {
                case true:
                    tb_price.Enabled = true;
                    break;
                case false:
                    tb_price.Enabled = false;
                    tb_price.Text = "";
                    break;
                default:
                    tb_price.Enabled = false;
                    tb_price.Text = "";
                    break;
            }
        }

        protected void cb_resalePrice_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_resalePrice.Checked)
            {
                case true:
                    tb_resalePrice.Enabled = true;
                    btn_resale.Enabled = true;
                    break;
                case false:
                    tb_resalePrice.Enabled = false;
                    tb_resalePrice.Text = "";
                    btn_resale.Enabled = false;
                    break;
                default:
                    tb_resalePrice.Enabled = false;
                    tb_resalePrice.Text = "";
                    btn_resale.Enabled = false;
                    break;
            }
        }

        protected void cb_sales_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_sales.Checked)
            {
                case true:
                    tb_sales.Enabled = true;
                    break;
                case false:
                    tb_sales.Enabled = false;
                    tb_sales.Text = "";
                    break;
                default:
                    tb_sales.Enabled = false;
                    tb_sales.Text = "";
                    break;
            }
        }

        protected void cb_stock_CheckedChanged(object sender, EventArgs e)
        {
            switch (cb_stock.Checked)
            {
                case true:
                    tb_stock.Enabled = true;
                    break;
                case false:
                    tb_stock.Enabled = false;
                    tb_stock.Text = "";
                    break;
                default:
                    tb_stock.Enabled = false;
                    tb_stock.Text = "";
                    break;
            }
        }       

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@id_prod", Convert.ToInt32(Request.QueryString["id"]));

            if (cb_name.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@name", tb_name.Text);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@name", "null");
            }
            if  (cb_price.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@value", Convert.ToDecimal(tb_price.Text));
            }
            else
            {
                myCommand.Parameters.AddWithValue("@value", 121212.12);
            }
            if (cb_resalePrice.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@value_resale", Convert.ToDecimal(tb_resalePrice.Text));
            }
            else
            {
                myCommand.Parameters.AddWithValue("@value_resale", 121212.12);
            }
            if (cb_sales.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@sales", Convert.ToInt32(tb_sales.Text));
            }
            else
            {
                myCommand.Parameters.AddWithValue("@sales", 121212);
            }
            if (cb_stock.Checked == true)
            {
                myCommand.Parameters.AddWithValue("@stock", Convert.ToInt32(tb_stock.Text));
            }
            else
            {
                myCommand.Parameters.AddWithValue("@stock", 121212);
            }           


            SqlParameter value2 = new SqlParameter();
            value2.ParameterName = "@return";
            value2.Direction = ParameterDirection.Output;
            value2.SqlDbType = SqlDbType.VarChar;
            value2.Size = 20;
            myCommand.Parameters.Add(value2);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "modify_product";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);

            myCon.Close();

            if (responseSP == 1)
            {
                lbl_error.Visible = false;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            else
            {
                lbl_error.Visible = true;
            }

            

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
            myCommand.Parameters.AddWithValue("@id_prod", Convert.ToInt32(Request.QueryString["id"]));
            myCommand.Parameters.AddWithValue("@password", EncryptString(tb_password.Text));

            SqlParameter value = new SqlParameter();
            value.ParameterName = "@return";
            value.Direction = ParameterDirection.Output;
            value.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(value);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "delete_prod";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);


            myCon.Close();

            if (responseSP == 1)
            {
                lbl_warning.Visible = true;
                lbl_warning.Text = "Product deleted with success. Wait 5 seconds for redirect.";

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

       
        protected void btn_image_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            Stream imgStream = FileUpload1.PostedFile.InputStream;

            string contentType = FileUpload1.PostedFile.ContentType;
            int comprimento = FileUpload1.PostedFile.ContentLength;

            byte[] fotoBinario = new byte[comprimento];
            imgStream.Read(fotoBinario, 0, comprimento);

            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();


            myCommand.Parameters.AddWithValue("@id_prod", Convert.ToInt32(Request.QueryString["id"]));
            myCommand.Parameters.AddWithValue("@img_type", contentType);
            myCommand.Parameters.AddWithValue("@image", fotoBinario);


            SqlParameter value = new SqlParameter();
            value.ParameterName = "@return";
            value.Direction = ParameterDirection.Output;
            value.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(value);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "update_product_image";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);


            myCon.Close();

            if (responseSP == 1)
            {
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            else if (responseSP == 0)
            {
                lbl_imageText.Visible = true;
                lbl_imageText.ForeColor = System.Drawing.Color.Red;
                lbl_imageText.Text = "Something went wrong";
            }
        }

        protected void btn_resale_Click(object sender, EventArgs e)
        {
            if(tb_price.Enabled == true && tb_price.Text != "" || tb_price.Enabled == true && tb_price.Text != " ")
            {
                decimal ogPrice = Convert.ToDecimal(tb_price.Text);

                decimal salePrice = ogPrice - (ogPrice * 0.20m);

                tb_resalePrice.Text = salePrice.ToString("N2");
            }
            else
            {
                decimal ogPrice = Convert.ToDecimal(lbl_price.Text);

                decimal salePrice = ogPrice - (ogPrice * 0.20m);

                tb_resalePrice.Text = salePrice.ToString("N2");
            }
        }
    }

    
    
}