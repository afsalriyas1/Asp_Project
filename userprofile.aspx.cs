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
    public partial class userprofile : System.Web.UI.Page
    {
        connectionClass obj = new connectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s2 = "select * from category_tab";
                DataSet ds = obj.fn_dataadapter(s2);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }

        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
             int catid = Convert.ToInt32(e.CommandArgument);
            Session["catid"] = catid;
            Response.Redirect("subcat.aspx");

        }
    }
}