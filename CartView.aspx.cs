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
    public partial class CartView : System.Web.UI.Page
    {
        connectionClass obj = new connectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridBind();
               
            }
        }
        public void gridBind()
        {
            string selall = "select product_tab.p_image,product_tab.p_descrip,cart_tab.Cart_id,cart_tab.Quantity,cart_tab.Total_price from product_tab join cart_tab on product_tab.p_id=cart_tab.Product_id where cart_tab.User_id='" + Session["userid"] + "'";
            DataSet ds = obj.fn_dataadapter(selall);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string del = "delete from cart_tab where Cart_id=" + id + "";
            obj.fn_nonquery(del);
            gridBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridBind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string selprice = "select p_price from product_tab where p_id='" + Session["pdtid"] + "'";
            string t_price = obj.fn_scalar(selprice);
            TextBox txtqty = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            int total_price = Convert.ToInt32(txtqty.Text) * Convert.ToInt32(t_price);
            string upd = "update cart_tab set Quantity='" + txtqty.Text + "',Total_price='" + total_price + "' where Cart_id=" + getid + "";
            obj.fn_nonquery(upd);
            gridBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select max(Cart_id) from cart_tab where User_id='" + Session["userid"] + "'";
            string max_id = obj.fn_scalar(s);
            for (int i = 1; i <= Convert.ToInt32(max_id); i++)
            {
                string cartid = "", userid = "", pdttid = "", pdtqty = "", tprice = "";
                string select_all = "select * from cart_tab where Cart_id=" + i + "";
                SqlDataReader dr = obj.fn_datareader(select_all);
                if (dr.Read())
                {
                    cartid = dr["Cart_id"].ToString();
                    userid = dr["User_id"].ToString();
                    pdttid = dr["Product_id"].ToString();
                    pdtqty = dr["Quantity"].ToString();
                    tprice = dr["Total_price"].ToString();

                }
                string sel_tprice = "select sum(Total_price) from cart_tab where Cart_id=" + i + "";
                string to_price = obj.fn_scalar(sel_tprice);
                string insorder = "insert into Order_tab values(" + cartid + "," + userid + "," + pdttid + "," + pdtqty + "," + tprice + ",'pending')";
                obj.fn_nonquery(insorder);
                string insbill = "insert into Bill_tab values(" + userid + ",'" + DateTime.Now.ToShortDateString() + "'," + to_price + ")";
                obj.fn_nonquery(insbill);
                string dltcart = "delete from cart_tab where Cart_id=" + i + "";
                obj.fn_nonquery(dltcart);
            }
            Label1.Visible = true;
            Label1.Text = "Order confirmed";
            gridBind();

            Response.Redirect("DisplayBill.aspx");
        }
    }
}