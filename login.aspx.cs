using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electronics
{
    public partial class login : System.Web.UI.Page
    {
        connectionClass obj = new connectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            string str = "select count(reg_id) from log_tab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            string cid = obj.fn_scalar(str);
            ////int cid1 = Convert.ToInt32(cid);
            if (cid == "1")
            {
                string s1 = "select reg_id from log_tab where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string regid = obj.fn_scalar(s1);
                Session["userid"] = regid;
                string s2 = "select log_type from log_tab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string log_type = obj.fn_scalar(s2);
                if (log_type == "admin")
                {
                    Label1.Text = "welcome";
                    Response.Redirect("adminprofile.aspx");

                }
                else if (log_type == "user")
                {

                    Label1.Text = "welcome user";
                    Response.Redirect("userprofile.aspx");

                }
                else
                {
                    Label1.Text = "inavlid username or password";
                }
            }
        }
    }
}