using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjectStore.Pages
{

    public partial class checkout : System.Web.UI.Page
    {
        //string id;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["cart"] != null)
            {
                string cart = Session["cart"].ToString();
                String[] cartItem = cart.Split(',');

                List<product> lst_items = new List<product>();

                SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                for (int i = 0; i < cartItem.Length; i++)
                {
                    product p = new product();



                   int item = int.Parse(cartItem[i]);

                    myCommand.Parameters.AddWithValue("@id_prod", item);

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandText = "list_product_id";

                    myCommand.Connection = myCon;
                    myCon.Open();
                    SqlDataReader dr = myCommand.ExecuteReader();

                       
                    while (dr.Read())
                    {
                        p.name = dr["name"].ToString();
                        p.value = dr["value"].ToString() + "€";
                        p.value_resale = dr["value_resale"].ToString() + "€";
                        p.stock = "Units left: " + dr["stock"].ToString();
                        p.image = "data:" + dr["img_type"].ToString() + ";base64," + Convert.ToBase64String((byte[])dr["image"]);
                        
                    }                    

                    myCon.Close();

                    p.id_prod = cartItem[i];

                    lst_items.Add(p);
                }

                

                Repeater1.DataSource = lst_items;
                Repeater1.DataBind();
            }
            else
            {




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
    }
}