using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace ProjectStore.Pages
{
    public partial class app : System.Web.UI.Page
    {

        int order;

        //ORDER TYPE
        //0 - NORMAL
        //1 - PRICE ASC
        //2 - PRICE DESC
        //3 - ALPHA ASC
        //4 - ALPHA ASC


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Resale"] != null)
            {
                pnl_normal.Visible = false;
                pnl_resale.Visible = true;
            }

            if (!Page.IsPostBack)
            {
                order = 0;
                load_products();

            }
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

        protected void load_products()
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();


            myCommand.Parameters.AddWithValue("@order", Convert.ToInt32(order));

            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.CommandText = "list_products_order";

            myCommand.Connection = myCon;
            myCon.Open();
            SqlDataReader drProd = myCommand.ExecuteReader();

            List<product> lst_products = new List<product>();

            while (drProd.Read())

            {
                product p = new product();
                p.id_prod = drProd["id_prod"].ToString();
                p.name = drProd["name"].ToString();
                p.value = drProd["value"].ToString();
                p.value_resale = drProd["value_resale"].ToString();
                p.stock = drProd["stock"].ToString();
                p.image = "data:" + drProd["img_type"].ToString() + ";base64," + Convert.ToBase64String((byte[])drProd["image"]);

                lst_products.Add(p);
            }



            myCon.Close();

            if (Session["Resale"] != null)
            {
                Repeater1.DataSource = lst_products;
                Repeater1.DataBind();
            }
            else
            {
                store_repeater.DataSource = lst_products;
                store_repeater.DataBind();
            }


        }

        protected void ddl_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddl_filter.SelectedIndex)
            {
                case 1:
                    order = 1;
                    load_products();

                    break;
                case 2:
                    order = 2;
                    load_products();

                    break;
                case 3:
                    order = 3;
                    load_products();

                    break;
                case 4:
                    order = 4;
                    load_products();

                    break;

                default:
                    order = 0;
                    load_products();

                    break;
            }



        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();


            myCommand.Parameters.AddWithValue("@search", searchbar.Text);

            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.CommandText = "search_products";



            myCommand.Connection = myCon;
            myCon.Open();
            SqlDataReader drProd = myCommand.ExecuteReader();

            List<product> lst_products = new List<product>();

            while (drProd.Read())
            {
                product p = new product();

                p.id_prod = drProd["id_prod"].ToString();
                p.name = drProd["name"].ToString();
                p.value = drProd["value"].ToString();
                p.value_resale = drProd["value_resale"].ToString();
                p.stock = drProd["stock"].ToString();
                p.image = "data:" + drProd["img_type"].ToString() + ";base64," + Convert.ToBase64String((byte[])drProd["image"]);

                lst_products.Add(p);
            }



            myCon.Close();

            if (Session["Resale"] != null)
            {
                Repeater1.DataSource = lst_products;
                Repeater1.DataBind();
            }
            else
            {
                store_repeater.DataSource = lst_products;
                store_repeater.DataBind();
            }



        }



    }
}