using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Electronics
{
    public partial class PayBill : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServiceClient ob = new ServiceReference1.ServiceClient();
            int s = ob.checkBalance(Convert.ToInt32(TextBox1.Text));
            Label1.Text = s.ToString();
        }
    }
}