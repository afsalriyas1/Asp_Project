using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electronics
{
    public partial class admin : System.Web.UI.Page
    {
        connectionClass obj = new connectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select max(reg_id) from log_tab";
            string regid = obj.fn_scalar(s);
            int reg_id = 0;
            if (regid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                reg_id = newregid + 1;
            }
            string s1 = "insert into admin_tab values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            int i = obj.fn_nonquery(s1);
            string s2 = "insert into log_tab values(" + reg_id + ",'" + TextBox4.Text + "','" + TextBox5.Text + "','admin','active')";
            int j = obj.fn_nonquery(s2);
        }
    }
}