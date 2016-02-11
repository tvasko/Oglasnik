using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OglasnikIT
{
    public partial class logOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["korisnik"] = null;
            Response.AddHeader("REFRESH", "1;URL=index.aspx");
        }
    }
}