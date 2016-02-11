using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OglasnikIT
{
    public partial class loginReg : System.Web.UI.Page
    {
        SqlConnection konekcija = new SqlConnection();

        SqlCommand komanda = new SqlCommand();
        public void printAlert(String message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox usernameLogin = (TextBox)FindControl("usernameLogin");
            TextBox passwordLogin = (TextBox)FindControl("passwordLogin"); ;
            TextBox usernameRegister = (TextBox)FindControl("usernameRegister"); ;
            TextBox passwordRegister = (TextBox)FindControl("passwordRegister"); ;
            TextBox emailRegister = (TextBox)FindControl("emailRegister"); ;
            TextBox nameRegister = (TextBox)FindControl("nameRegister"); ;
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
            komanda.Connection = konekcija;

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (Session["korisnik"] == null)
            {
                if (usernameLogin.Text != "" && passwordLogin.Text != "")
                {
                    konekcija.Open();
                    String sqlReadUsers = "SELECT * FROM [users] WHERE [username]='" + usernameLogin.Text + "'";
                    komanda.CommandText = sqlReadUsers;
                    SqlDataReader citac = komanda.ExecuteReader();
                    if (citac.HasRows)
                    {
                        while (citac.Read())
                        {
                            if (citac["password"].ToString() == passwordLogin.Text)
                            {
                                Session["korisnik"] = usernameLogin.Text;
                                Response.Redirect("~/userPage.aspx");
                            }
                            else
                            {
                                printAlert("Внесовте погрешна лозинка!");
                            }
                        }
                    }
                    else
                    {
                        printAlert("Корисничкото име не постои!");
                    }
                }
                else
                {
                    printAlert("Внесете ги сите податоци!");
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Boolean canRegister = true;
            try
            {
                konekcija.Open();
                if (usernameRegister.Text != "" && emailRegister.Text != "" && passwordRegister.Text != "" && nameRegister.Text != "")
                {
                    String sqlReadUsers = "SELECT [username] FROM [users] WHERE [username]='" + usernameRegister.Text + "'";
                    String sqlInsertUser = "INSERT INTO [users] (tip, username, password, name, email)" +
                                          "VALUES (@tip, @username, @password, @name, @email)";
                    SqlCommand komanda1 = new SqlCommand();
                    komanda1.Connection = konekcija;
                    komanda1.CommandText = sqlReadUsers;
                    SqlDataReader citac = komanda1.ExecuteReader();
                    if (citac.HasRows)
                    {
                        canRegister = false;
                        printAlert("Корисничкото име веќе постои!");
                    }
                    else
                    {
                        konekcija.Close();
                        konekcija.Open();
                        if (canRegister)
                        {
                            komanda.Connection = konekcija;
                            komanda.Parameters.AddWithValue("@tip", "2");
                            komanda.Parameters.AddWithValue("@username", usernameRegister.Text);
                            komanda.Parameters.AddWithValue("@password", passwordRegister.Text);
                            komanda.Parameters.AddWithValue("@name", nameRegister.Text);
                            komanda.Parameters.AddWithValue("@email", emailRegister.Text);
                            komanda.CommandText = sqlInsertUser;
                            komanda.ExecuteNonQuery();
                            Session["korisnik"] = usernameRegister.Text;
                            Response.Redirect("~/userPage.aspx");
                        }
                    }
                    
                }
                else
                {
                    printAlert("Внесете ги сите податоци!");
                }
            }
            catch (Exception err)
            {
                printAlert(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
        }
    }
}