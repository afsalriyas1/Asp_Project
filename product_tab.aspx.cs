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
    public partial class product_tab : System.Web.UI.Page
    {
        connectionClass obj = new connectionClass();
        SqlConnection con = new SqlConnection(@"server=LAPTOP-9HU5LPB4\SQLEXPRESS;database=WP;integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select cat_id,cat_name from category_tab";
                SqlDataAdapter d = new SqlDataAdapter(s, con);
                DataSet ds = new DataSet();
                d.Fill(ds);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "cat_name";
                DropDownList1.DataValueField = "cat_id";
                DropDownList1.DataBind();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            string p = DropDownList1.SelectedItem.Value;

            string p5 = "~/phs/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p5));
            string s = "insert into product_tab values('" + p + "','" + TextBox1.Text + "','" + p5 + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DropDownList2.SelectedItem + "')";
            int a = obj.fn_nonquery(s);
            if (a == 1)
            {
                Label1.Text = "inserted";

            }
        }
    }
}