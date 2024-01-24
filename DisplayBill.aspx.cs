using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Electronics
{
    public partial class DisplayBill : System.Web.UI.Page
    {
        connectionClass obj = new connectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string selall = "select * from product_tab join Order_tab on product_tab.p_id=Order_tab.Pdt_id";
                SqlDataReader dr = obj.fn_datareader(selall);
                while (dr.Read())
                {
                    Label5.Text = dr["p_name"].ToString();
                    Label6.Text = dr["Pdt_Quantity"].ToString();
                    Label7.Text = dr["Price"].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayBill.aspx");
        }
    }
}