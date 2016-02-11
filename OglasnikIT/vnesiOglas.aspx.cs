using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OglasnikIT
{
    public partial class vnesiOglas : System.Web.UI.Page
    {
        UserInfo korisnikInfo;
        static string imgPath1 = "";
        static string imgPath2 = "";
        static string imgPath3 = "";
        static string imgPath4 = "";
        static string odobren = "0";
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

            if (Session["korisnik"] == null)
            {
                Response.Redirect("~/loginReg.aspx");
            }
            else
            {
               
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                try
                {
                    konekcija.Open();
                    String sqlReadUsers = "SELECT * FROM [users] WHERE [username]='" + Session["korisnik"].ToString() + "'";
                    komanda.CommandText = sqlReadUsers;
                    SqlDataReader citac = komanda.ExecuteReader();
                    while (citac.Read())
                    {
                        korisnikInfo = new UserInfo((int)Int16.Parse(citac["userId"].ToString()), (int)Int64.Parse(citac["tip"].ToString()), citac["username"].ToString(), citac["password"].ToString(), citac["name"].ToString(), citac["email"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    printAlert(ex.ToString());

                }
                finally
                {
                    konekcija.Close();
                }
                if (!IsPostBack)
                {
                    imgPath1 = "";
                    imgPath2 = "";
                    imgPath3 = "";
                    imgPath4 = "";
                    odobren = "0";
                    if (Request.QueryString["id"] != null)
                    {
                        izmeniOglas(Request.QueryString["id"]);
                    }
                    else
                    {
                        //RequiredFieldValidator8.ControlToValidate = "FileUpload";
                    }
                }

            }


        }
        public void izmeniOglas(String oglasIdIzmeni)
        {

            String userID = "";
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
            SqlCommand komanda1 = new SqlCommand();
            komanda1.Connection = konekcija;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            komanda1.CommandText = "select * from oglasi where oglasiId='" + oglasIdIzmeni + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda1.ExecuteReader();
                while (citac.Read())
                {
                    txtCena.Text = citac["cena"].ToString();
                    rblValuta.SelectedValue = citac["valuta"].ToString();
                    txtNaslov.Text = citac["naslov"].ToString();


                    String oglasUserID = userID = citac["userId"].ToString();
                    ddlKategorii.SelectedValue = citac["kategorija"].ToString();
                    ddlGrad.SelectedValue = citac["grad"].ToString();

                    txtOpis.Text = citac["opis"].ToString();
                    txtTelefon.Text = citac["telefon"].ToString();
                    // lblDatum.Text = citac["datum"].ToString().Replace("00:00:00", "");
                    imgPath1 = citac["slikaGlavna"].ToString();
                    // FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + imgPath1);
                    imgPath2 = citac["slika1"].ToString();
                    //   FileUpload2.PostedFile.SaveAs(Server.MapPath(".") + imgPath2);
                    imgPath3 = citac["slika2"].ToString();
                    //   FileUpload3.PostedFile.SaveAs(Server.MapPath(".") + imgPath3);
                    imgPath4 = citac["slika3"].ToString();
                    // FileUpload4.PostedFile.SaveAs(Server.MapPath(".") + imgPath4);
                    //  RequiredFieldValidator8.ControlToValidate = null;
                    // RequiredFieldValidator8.Enabled = false;
                    odobren = citac["odobren"].ToString();

                }
                citac.Close();

            }
            catch (Exception ex)
            {
                //  lblDatum.Text = ex.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }
        public String getLastId()
        {
            String lastID = "1";
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            try
            {
                konekcija.Open();
                String sqlReadUsers = "SELECT * FROM oglasi";
                komanda.CommandText = sqlReadUsers;
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    lastID = citac["oglasiId"].ToString();
                }
                citac.Close();
            }
            catch (Exception ex)
            {
                printAlert(ex.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            return lastID;
        }
        protected void btnVnesiOglas_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string ext1 = System.IO.Path.GetExtension(FileUpload1.FileName);
                String str1 = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext1;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str1);
                imgPath1 = "~//uploads//" + str1.ToString();
            }

            if (FileUpload2.HasFile)
            {
                string ext2 = System.IO.Path.GetExtension(FileUpload2.FileName);
                String str2 = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext2;
                FileUpload2.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str2);
                imgPath2 = "~//uploads//" + str2.ToString();
            }

            if (FileUpload3.HasFile)
            {
                string ext3 = System.IO.Path.GetExtension(FileUpload3.FileName);
                String str3 = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext3;
                FileUpload3.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str3);
                imgPath3 = "~//uploads//" + str3.ToString();
            }

            if (FileUpload4.HasFile)
            {
                string ext4 = System.IO.Path.GetExtension(FileUpload4.FileName);
                String str4 = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext4;
                FileUpload4.PostedFile.SaveAs(Server.MapPath(".") + "//uploads//" + str4);
                imgPath4 = "~//uploads//" + str4.ToString();
            }

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
            SqlCommand komanda = new SqlCommand();
            SqlCommand komandaDelete = new SqlCommand();
            komanda.Connection = konekcija;
            komandaDelete.Connection = konekcija;

            DateTime datum = DateTime.Now;
            komanda.Parameters.AddWithValue("@naslov", txtNaslov.Text);
            printAlert(txtNaslov.Text);
            komanda.Parameters.AddWithValue("@opis", txtOpis.Text);
            komanda.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komanda.Parameters.AddWithValue("@slikaGlavna", imgPath1);
            komanda.Parameters.AddWithValue("@slika1", imgPath2);
            komanda.Parameters.AddWithValue("@slika2", imgPath3);
            komanda.Parameters.AddWithValue("@slika3", imgPath4);
            komanda.Parameters.AddWithValue("@kategorija", ddlKategorii.SelectedItem.Text.ToString());
            komanda.Parameters.AddWithValue("@grad", ddlGrad.SelectedItem.Text);
            komanda.Parameters.AddWithValue("@cena", txtCena.Text);
            komanda.Parameters.AddWithValue("@valuta", rblValuta.SelectedItem.Value.ToString());
            komanda.Parameters.AddWithValue("@datum", datum);
            komanda.Parameters.AddWithValue("@userId", korisnikInfo.UserId);

            if (Request.QueryString["id"] != null)
            {
                komanda.Parameters.AddWithValue("@odobren", odobren);
                komanda.CommandText = "INSERT INTO [oglasi] (naslov,opis,telefon,slikaGlavna,slika1,slika2,slika3,kategorija,grad,cena,valuta,datum,userId,odobren) VALUES (@naslov,@opis,@telefon,@slikaGlavna,@slika1,@slika2,@slika3,@kategorija,@grad,@cena,@valuta,@datum,@userId,@odobren)";

                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    printAlert(ex.ToString());

                }
                finally
                {
                    konekcija.Close();
                }

                komandaDelete.CommandText = "DELETE FROM oglasi WHERE oglasiId='" + Request.QueryString["id"] + "'";
                try
                {
                    konekcija.Open();
                    printAlert(txtNaslov.Text);
                    komandaDelete.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    printAlert(ex.ToString());

                }
                finally
                {
                    konekcija.Close();
                }

            }
            else
            {
                komanda.Parameters.AddWithValue("@odobren", 0);
                komanda.CommandText = "INSERT INTO [oglasi] (naslov,opis,telefon,slikaGlavna,slika1,slika2,slika3,kategorija,grad,cena,valuta,datum,userId,odobren) VALUES (@naslov,@opis,@telefon,@slikaGlavna,@slika1,@slika2,@slika3,@kategorija,@grad,@cena,@valuta,@datum,@userId,@odobren)";

                try
                {
                    konekcija.Open();
                    komanda.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    printAlert(ex.ToString());

                }
                finally
                {
                    konekcija.Close();
                }

            }


            Response.Redirect("~/OglasInfo.aspx?id=" + getLastId());
        }
    }
}