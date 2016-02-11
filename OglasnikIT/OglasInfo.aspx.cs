using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OglasnikIT
{
    public partial class OglasInfo : System.Web.UI.Page
    {
        String oglasUserID = "";
        static String oglasIdEdit = "";
        static String userTip1 = "";
        static Boolean isAdmin = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            prikaziOglas();
            if (Session["korisnik"] != null)
            {
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
                SqlCommand komanda1 = new SqlCommand();
                komanda1.Connection = konekcija;
                komanda1.CommandText = "SELECT * FROM users WHERE username='" + Session["korisnik"].ToString() + "'";
                try
                {
                    String userID = "";
                    konekcija.Open();
                    SqlDataReader citac = komanda1.ExecuteReader();
                    while (citac.Read())
                    {
                        userID = citac["userId"].ToString();
                        userTip1 = citac["tip"].ToString();

                    }
                    citac.Close();
                    if (oglasUserID.Equals(userID))
                    {
                        btnIzmeniOglas.Visible = true;
                        btnIzbrisiOglas.Visible = true;
                    }
                    if (userTip1.Equals("1"))
                    {
                        isAdmin = true;
                        btnIzbrisiOglas.Visible = true;
                    }
                    else
                    {
                        isAdmin = false;
                    }

                }
                catch (Exception ex)
                {
                    lblDatum.Text = ex.Message;
                }
                finally
                {
                    konekcija.Close();
                }
            }
            else
            {
                btnIzmeniOglas.Visible = false;
                btnIzbrisiOglas.Visible = false;
                btnOdobriOglas.Visible = false;
                isAdmin = false;
            }
            prikaziOglas();
            oglasIdEdit = Request.QueryString["id"];
        }
        public void prikaziOglas()
        {
            String userID = "";
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
            SqlCommand komanda1 = new SqlCommand();
            komanda1.Connection = konekcija;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            komanda1.CommandText = "select * from oglasi where oglasiId='" + id + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda1.ExecuteReader();
                while (citac.Read())
                {
                    lblCena.Text = citac["cena"].ToString() + " " + citac["valuta"].ToString();
                    lblNaslov.Text = citac["naslov"].ToString();


                    oglasUserID = userID = citac["userId"].ToString();
                    lblKategorija.Text = citac["kategorija"].ToString();
                    lblGrad.Text = citac["grad"].ToString();
                    if (citac["odobren"].ToString().Equals("0"))
                    {
                        if (isAdmin)
                        {
                            btnOdobriOglas.Visible = true;
                            
                        }
                        else
                        {
                            btnOdobriOglas.Visible = false;
                            //btnIzbrisiOglas.Visible = true;
                        }
                    }
                    txtOpis.Text = citac["opis"].ToString();
                    lblTelefon.Text = citac["telefon"].ToString();
                    lblDatum.Text = citac["datum"].ToString().Replace("00:00:00", "");

                    //imgS1.ImageUrl = citac["slika1"].ToString();
                    string url = citac["slikaGlavna"].ToString();
                    if (url == "")
                    {
                        imgS1.Visible = false;
                    }
                    else
                    {
                        imgSlika1.ImageUrl = url;
                        imgS1.ImageUrl = url;
                    }
                    imgS2.ImageUrl = citac["slika1"].ToString();
                    if (imgS2.ImageUrl == "")
                        imgS2.Visible = false;
                    imgS3.ImageUrl = citac["slika2"].ToString();
                    if (imgS3.ImageUrl == "")
                        imgS3.Visible = false;
                    imgS4.ImageUrl = citac["slika3"].ToString();
                    if (imgS4.ImageUrl == "")
                        imgS4.Visible = false;

                }
                citac.Close();
                lblIme.Text = userID;

            }
            catch (Exception ex)
            {
                lblDatum.Text = ex.Message;
            }
            finally
            {
                konekcija.Close();
            }
            komanda1.CommandText = "SELECT * FROM users WHERE userId='" + userID + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda1.ExecuteReader();
                while (citac.Read())
                {
                    lblIme.Text = citac["name"].ToString();

                }
                citac.Close();

            }
            catch (Exception ex)
            {
                lblDatum.Text = ex.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }

        protected void imgS1_Click(object sender, ImageClickEventArgs e)
        {
            imgSlika1.ImageUrl = imgS1.ImageUrl;

        }

        protected void imgS2_Click(object sender, ImageClickEventArgs e)
        {
            if (imgS2.ImageUrl != "")
                imgSlika1.ImageUrl = imgS2.ImageUrl;

        }

        protected void imgS3_Click(object sender, ImageClickEventArgs e)
        {
            if (imgS3.ImageUrl != "")
                imgSlika1.ImageUrl = imgS3.ImageUrl;

        }

        protected void imgS4_Click(object sender, ImageClickEventArgs e)
        {
            if (imgS4.ImageUrl != "")
                imgSlika1.ImageUrl = imgS4.ImageUrl;

        }

        protected void btnIzmeniOglas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vnesiOglas.aspx?id=" + oglasIdEdit);
        }

        protected void btnIzbrisiOglas_Click(object sender, EventArgs e)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
            SqlCommand komandaDelete = new SqlCommand();
            komandaDelete.Connection = konekcija;
            komandaDelete.CommandText = "DELETE FROM oglasi WHERE oglasiId='" + oglasIdEdit + "'";
            try
            {
                konekcija.Open();
                komandaDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                konekcija.Close();
            }
            Response.Redirect("~/userPage.aspx");
        }

        protected void btnOdobriOglas_Click(object sender, EventArgs e)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
            SqlCommand komandaDelete = new SqlCommand();
            komandaDelete.Connection = konekcija;
            komandaDelete.CommandText = "UPDATE oglasi SET odobren=1 WHERE oglasiId='" + oglasIdEdit + "'";
            try
            {
                konekcija.Open();
                komandaDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                konekcija.Close();
            }
            Response.Redirect("~/userPage.aspx");
        }
    }
}