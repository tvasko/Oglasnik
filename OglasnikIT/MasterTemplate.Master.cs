using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OglasnikIT
{
    
    public partial class MasterTemplate : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            HyperLink logIn =(HyperLink) FindControl("linkLogin");
            HyperLink logOut = (HyperLink)FindControl("linkLogOut");
            if (Session["korisnik"] == null)
            {
                logIn.Text = "Логирај се / Регистрирај се";
                logIn.NavigateUrl = "~/loginReg.aspx";
                logOut.Visible = false;
            }
            else
            {
                String usernameString = Session["korisnik"].ToString();
                logIn.Text = usernameString;
                logIn.NavigateUrl = "~/userPage.aspx";
                logOut.Visible = true;
            }
        }
       
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["korisnik"] = null;
            Response.Redirect("~/index.aspx");
        }
    }
}