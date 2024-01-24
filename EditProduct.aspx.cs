using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Electronics
{
    public partial class EditProduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-9HU5LPB4\SQLEXPRESS;database=WP;integrated security=true");

        connectionClass obj = new connectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string s = "select p_name,p_image,p_descrip,p_price,p_stock,p_status from product_tab";
                DataSet ds = obj.fn_dataadapter(s);
                GridView1.DataSource = ds;
                gridbind();

            }

        }
        public void gridbind()
        {
            string s = "select * from product_tab";
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from product_tab where p_id=" + getid + "";
            SqlCommand cmd = new SqlCommand(del, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            gridbind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridbind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridbind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtname = (TextBox)GridView1.Rows[i].Cells[0].Controls[0];
            TextBox txtdesc = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            TextBox txtprice = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];
            TextBox txtstock = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            TextBox txtstatus = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            string s = "update product_tab set p_name='" + txtname.Text + "',p_descrip='" + txtdesc.Text + "',p_price='"+txtprice.Text+"',p_stock='"+txtstock.Text+"',p_status='" + txtstatus.Text + "' where p_id=" + id + "";
            con.Open();
            int s7 = obj.fn_nonquery(s);
            con.Close();
            GridView1.EditIndex = -1;
            gridbind();

        }
    }
    }
