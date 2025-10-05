using AccesoDatos;
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Promo_Web
{
    public partial class PremioPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                // Validamos que tengamos voucher
                if (Session["VoucherCodigo"] == null)
                {
                    Response.Redirect("Default.aspx"); // volvemos al inicio
                }

                CargarArticulos();
            }
        }

        private void CargarArticulos()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaFinal = negocio.ListarArticulos();

                repArticulos.DataSource = listaFinal;
                repArticulos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar artículos: " + ex.Message;
            }
        }
        protected void repArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                
                hfSeleccionado.Value = e.CommandArgument.ToString();

                
                btnContinuar.Visible = true;

                
                foreach (RepeaterItem item in repArticulos.Items)
                {
                    Button btn = (Button)item.FindControl("btnSeleccionar");
                    if (btn != null)
                    {
                        btn.CssClass = btn.CommandArgument == hfSeleccionado.Value ? "btn btn-primary" : "btn btn-primary";
                    }
                }
            }
        }

        
        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfSeleccionado.Value))
            {
                
                Response.Redirect("RegistroPage.aspx?idArticulo=" + hfSeleccionado.Value);
            }
        }

    }
}
   