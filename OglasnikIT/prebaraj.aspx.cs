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
    public partial class prebaraj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                prikaziOglasi();
                
            }
        }
        protected void btnPrebaraj_Click(object sender, EventArgs e)
        {
            prebarajOglasi();
            if (gvOglasi.Rows.Count != 0)
            {
                Label1.Visible = false;

            }
            else
            {
                Label1.Visible = true;
            }
        }

        public void prebarajOglasi()
        {

            String grad = ddlLokacija.SelectedItem.Text.ToString();
            string SqlString;
            String naslov = txtPrebaraj.Text.ToString();
            String kategorija = ddlKategorii.SelectedItem.Text;

            if (naslov.Length > 0 && kategorija.Equals("Сите категории") && grad.Equals("Цела Македонија"))
            {

                SqlString = "Select * from oglasi where odobren='1' and naslov LIKE '" + "%" + naslov + "%" + "'";
            }
            else if (kategorija.Equals("Сите категории") && grad.Equals("Цела Македонија"))
            {
                SqlString = "Select * from oglasi where odobren='1'";
            }

            else if (grad.Equals("Цела Македонија"))
            {

                SqlString = "Select * from oglasi where odobren='1' and naslov LIKE '" + "%" + naslov + "%" + "' AND kategorija='" + ddlKategorii.SelectedItem.Text.ToString() + "'";
            }
            else if (kategorija.Equals("Сите категории"))
            {
                SqlString = "Select * from oglasi where odobren='1' and naslov LIKE '" + "%" + naslov + "%" + "' AND grad='" + ddlLokacija.SelectedItem.Text.ToString() + "'";
            }

            else
            {
                SqlString = "Select * from oglasi where odobren='1' and naslov LIKE '" + "%" + naslov + "%" + "' AND kategorija='" + ddlKategorii.SelectedItem.Text.ToString() + "' AND grad='" + ddlLokacija.SelectedItem.Text.ToString() + "'";
            }


            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";

            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = SqlString;

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Oglasi");
                gvOglasi.DataSource = ds;
                gvOglasi.DataBind();
                ViewState["dataset"] = ds;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                konekcija.Close();
            }

        }

        public void prikaziOglasi()
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=BOSS\\SQLEXPRESS;Initial Catalog=OglasnikDB;Integrated Security=True";
            string grad = "";

            if (Request.QueryString["grad"] != null)
            {
                grad = Request.QueryString["grad"];
            }
            else
            {
                grad = "Цела Македонија";
            }
            string SqlString = "Select * from oglasi where odobren='1'";
            if (grad == "Цела Македонија")
            {
                SqlString = "SELECT * FROM oglasi where odobren='1'";
            }
            else
            {
                SqlString = "Select * from oglasi where odobren='1' and grad='" + grad + "'";
            }
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = SqlString ;

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Oglasi");
                gvOglasi.DataSource = ds;
                gvOglasi.DataBind();
                ViewState["dataset"] = ds;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                konekcija.Close();
            }
        }

        protected void gvOglasi_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvOglasi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}