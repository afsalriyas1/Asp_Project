using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electronics
{
    public partial class Category : System.Web.UI.Page
    {
        connectionClass obj = new connectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/catpic/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string s = "insert into category_tab values('" + TextBox1.Text + "','" + p + "','" + TextBox2.Text + "','" + DropDownList1.SelectedItem + "')";
            int s1 = obj.fn_nonquery(s);
        }
    }
}