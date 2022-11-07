using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectStore.Pages
{
    public partial class soloproduct : System.Web.UI.Page
    {
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
             id = Request.QueryString["id"];

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("app.aspx");
            }

            if (Session["Resale"]!= null)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }

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
                lbl_price.Text = dr["value"].ToString() + "€";
                lbl_price2.Text = dr["value"].ToString() + "€";
                lbl_priceResale.Text = dr["value_resale"].ToString() + "€";               
                lbl_stock.Text = "Units left: " + dr["stock"].ToString();
                img_prod.ImageUrl = "data:" + dr["img_type"].ToString() + ";base64," + Convert.ToBase64String((byte[])dr["image"]);

            }

            myCon.Close();
        }

        public class product
        {
            public string id_prod { get; set; }
            public string image { get; set; }
            public string name { get; set; }
            public string value { get; set; }
            public string value_resale { get; set; }
            public string stock { get; set; }

        }

        protected void btn_addProd_Click(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Session["cart"] += id + ",";
            }
        }
    }
}