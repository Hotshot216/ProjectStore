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
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("app.aspx");
                }

                SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                myCommand.Parameters.AddWithValue("@email", Session["email"].ToString());

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "list_user_email";

                myCommand.Connection = myCon;
                myCon.Open();
                SqlDataReader dr = myCommand.ExecuteReader();

                while (dr.Read())
                {
                    tb_name.Text = dr["username"].ToString();
                    tb_email.Text = dr["email"].ToString();
                    tb_address.Text = dr["address"].ToString();
                    tb_zipCode.Text = dr["zipCode"].ToString();

                }

                myCon.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            tb_name.ReadOnly = false;
            tb_email.ReadOnly = false;
            tb_address.ReadOnly = false;
            tb_zipCode.ReadOnly = false;

            btn_cancel.Visible = true;
            btn_update.Visible = true;

            btn_change.Visible = false;

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            tb_name.ReadOnly = true;
            tb_email.ReadOnly = true;
            tb_address.ReadOnly = true;
            tb_zipCode.ReadOnly = true;

            btn_cancel.Visible = false;
            btn_update.Visible = false;

            btn_change.Visible = true;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectStoreConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Parameters.AddWithValue("@email_og", Session["email"].ToString());
            myCommand.Parameters.AddWithValue("@name", tb_name.Text);
            myCommand.Parameters.AddWithValue("@email", tb_email.Text);
            myCommand.Parameters.AddWithValue("@address", tb_address.Text);
            myCommand.Parameters.AddWithValue("@zipCode", tb_zipCode.Text);

            SqlParameter value = new SqlParameter();
            value.ParameterName = "@return";
            value.Direction = ParameterDirection.Output;
            value.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(value);

            SqlParameter value2 = new SqlParameter();
            value2.ParameterName = "@return_active";
            value2.Direction = ParameterDirection.Output;
            value2.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(value2);

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "change_profile";

            myCommand.Connection = myCon;
            myCon.Open();
            myCommand.ExecuteNonQuery();

            int responseSP = Convert.ToInt32(myCommand.Parameters["@return"].Value);

            int responseSP2 = Convert.ToInt32(myCommand.Parameters["@return_active"].Value);

            myCon.Close();

            if (responseSP == 1)
            {
                //Response.Redirect("profile.aspx");
                //UpdatePanel1.Update();
                if(responseSP2 == 0)
                {
                    Session.Abandon();
                    Response.Redirect("login.aspx");
                }


                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                lbl_error.Visible = true;
            }

          

        }
    }
}