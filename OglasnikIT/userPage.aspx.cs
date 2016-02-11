using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OglasnikIT
{
    public partial class userPage : System.Web.UI.Page
    {
        String userID = "";
        static String userTip = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            SqlConnection konekcija = new SqlConnection();
            
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
            try
            {
                konekcija.Open();
                String sqlReadUsers = "SELECT * FROM [users] WHERE [username]='" + Session["korisnik"].ToString()+ "'";
                SqlCommand komanda1 = new SqlCommand();
                komanda1.Connection = konekcija;
                komanda1.CommandText = sqlReadUsers;
                SqlDataReader citac = komanda1.ExecuteReader();
                while (citac.Read())
                {
                    userID = citac["userId"].ToString();
                    userTip = citac["tip"].ToString();
                }
                citac.Close();
            }
            catch (Exception err)
            {
               // printAlert(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            prikaziOglasi();


        }
        public void prikaziOglasi()
        {
            if (userTip == "2")
            {
                gvAdminOdobri.Visible = false;
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
                string SqlString = "Select * from oglasi";
                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandText = SqlString + " where userId='" + userID + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                DataSet ds = new DataSet();

                try
                {
                    konekcija.Open();
                    adapter.Fill(ds, "Oglasi");
                    gvOglasi1.DataSource = ds;
                    gvOglasi1.DataBind();
                    ViewState["dataset"] = ds;

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    konekcija.Close();
                }

                if (gvOglasi1.Rows.Count != 0)
                {
                    lblNemaOglasi.Visible = false;

                }
                else
                {
                    lblNemaOglasi.Visible = true;
                    lblNemaOglasi.Text = "Немате внесено ваши огласи!";
                }
                gvOglasi1.Caption = "Ваши огласи";
            }
            else
            {
                gvAdminOdobri.Visible = true;
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
                string SqlString = "Select * from oglasi";
                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandText = SqlString + " where odobren=0";

                SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                DataSet ds = new DataSet();

                try
                {
                    konekcija.Open();
                    adapter.Fill(ds, "Oglasi");
                    gvOglasi1.DataSource = ds;
                    gvOglasi1.DataBind();
                    ViewState["dataset"] = ds;

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    konekcija.Close();
                }
                if (gvOglasi1.Rows.Count != 0)
                {
                    lblNemaOglasi.Visible = false;
                    

                }
                else
                {
                    lblNemaOglasi.Visible = true;
                    lblNemaOglasi.Text = "Во моментот нема огласи кои треба да се одобрат!";
                }
                gvOglasi1.Caption = "Неодобрени огласи";
                SqlConnection konekcija1 = new SqlConnection();
                konekcija1.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
                string SqlString1 = "Select * from oglasi";
                SqlCommand komanda1 = new SqlCommand();
                komanda1.Connection = konekcija1;
                komanda1.CommandText = SqlString1+ " where odobren=1";

                SqlDataAdapter adapter1 = new SqlDataAdapter(komanda1);
                DataSet ds1 = new DataSet();

                try
                {
                    konekcija1.Open();
                    adapter1.Fill(ds1, "Oglasi");
                    gvAdminOdobri.DataSource = ds1;
                    gvAdminOdobri.DataBind();
                    ViewState["dataset1"] = ds1;

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    konekcija1.Close();
                }
                 if (gvAdminOdobri.Rows.Count != 0)
                {
                    lblNemaOdobreniOglasi.Visible = false;

                }
                else
                {
                    lblNemaOdobreniOglasi.Visible = true;
                }
            }
        }

        protected void gvOglasi1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowIndex < 0)
                return;

            int _myColumnIndex = 3;   // Substitute your value here

            string text = e.Row.Cells[_myColumnIndex].Text;

            if (text.Length > 300)
            {
                e.Row.Cells[_myColumnIndex].Text = text.Substring(0, 300) + "...";
            }
        }

        protected void gvAdminOdobri_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0)
                return;

            int _myColumnIndex = 3;   // Substitute your value here

            string text = e.Row.Cells[_myColumnIndex].Text;

            if (text.Length > 300)
            {
                e.Row.Cells[_myColumnIndex].Text = text.Substring(0, 300) + "...";
            }
        }
    }
}