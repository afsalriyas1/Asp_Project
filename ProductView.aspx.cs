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
    public partial class ProductView : System.Web.UI.Page
    {
        connectionClass obj = new connectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string selall = "select p_image,p_descrip,p_price from product_tab where p_id='" + Session["pdtid"] + "'";
            SqlDataReader dr = obj.fn_datareader(selall);
            while (dr.Read())
            {
                Image1.ImageUrl = dr["p_image"].ToString();
                Label1.Text = dr["p_descrip"].ToString();
                Label2.Text = dr["p_price"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
			string s = "select max(Cart_id) from cart_tab";
			string cartid = obj.fn_scalar(s);
			int cart_id = 0;
			if (cartid == "")
			{
				cart_id = 1;
			}
			else
			{
				int newregid = Convert.ToInt32(cartid);
				cart_id = newregid + 1;
			}
			string selprice = "select p_price from product_tab where p_id=" + Session["pdtid"] + "";
			string str = obj.fn_scalar(selprice);
			int tprice = Convert.ToInt32(TextBox1.Text) * Convert.ToInt32(str);
			string inscart = "insert into cart_tab values('" + cart_id + "','" + Session["userid"] + "','" + Session["pdtid"] + "','" + TextBox1.Text + "','" + tprice + "')";
			int i = obj.fn_nonquery(inscart);
			if (i == 1)
			{
				Label3.Visible = true;
				Label3.Text = "Added to cart successfully";
			}
		}

        protected void Button2_Click(object sender, EventArgs e)
        {
			Response.Redirect("userprofile.aspx");
        }
    }
}