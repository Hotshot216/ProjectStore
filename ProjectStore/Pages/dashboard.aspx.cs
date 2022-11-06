using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectStore.Pages.Admin
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("app.aspx");
            }

            Session["admin"] = "true";

            //lbl_admin.Text = Session["user"].ToString();

        }


        protected void ddl_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();


            myCommand.CommandType = CommandType.StoredProcedure;

            switch (ddl_Mode.Text)
            {
                

                case "User Dashboard":

                       


                        
                        myCommand.CommandText = "list_users";

                        myCommand.Connection = myCon;
                        myCon.Open();
                        SqlDataReader drUser = myCommand.ExecuteReader();

                        List<user> lst_users = new List<user>();

                        while (drUser.Read())
                        {
                            user u = new user();

                            u.id = drUser["id"].ToString();
                            u.name = drUser["username"].ToString();
                            //u.password = dr["password"].ToString();
                            u.profile = drUser["profile"].ToString();
                            u.active = drUser["active"].ToString();
                            u.email = drUser["email"].ToString();
                            u.address = drUser["address"].ToString();
                            u.zipCode = drUser["zipCode"].ToString();

                            lst_users.Add(u);
                        }



                        myCon.Close();

                        Repeater1.DataSource = lst_users;
                        Repeater1.DataBind();
                    

                    pnl_userDash.Visible = true;
                    pnl_prodDash.Visible = false;

                    break;

                case "Product Dashboard":                  


                    
                    myCommand.CommandText = "list_products";

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
                        p.sales = drProd["sales"].ToString();
                        p.stock = drProd["stock"].ToString();
                        p.image = "data:" + drProd["img_type"].ToString() + ";base64," + Convert.ToBase64String((byte[])drProd["image"]);                         

                        lst_products.Add(p);
                    }



                    myCon.Close();

                    Repeater2.DataSource = lst_products;
                    Repeater2.DataBind();


                    pnl_userDash.Visible = false;
                    pnl_prodDash.Visible = true;
                    break ;

                default:
                    pnl_userDash.Visible = false;
                    pnl_prodDash.Visible = false;
                    break;
            }
        }

        //BUTTON EVENTS
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_user.aspx");
        }

        protected void btn_addProd_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_product.aspx");
        }

        //CLASS DEFINITION

        public class user
        {
            public string id { get; set; }
            public string name { get; set; }
            
            public string profile { get; set; }
            public string active { get; set; }
            public string email { get; set; }
            public string address { get; set; }
            public string zipCode { get; set; }

        }

        public class product
        {
            public string id_prod { get; set; }
            public string name { get; set; }
            public string value { get; set; }
            public string value_resale { get; set; }
            public string sales { get; set; }
            public string stock { get; set; }
            public string image { get; set; }           

        }

       
    }
}