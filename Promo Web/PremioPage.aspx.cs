using AccesoDatosLayer;
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
                CargarArticulos();
            }
        }

        private void CargarArticulos()
        {
            try
            {
                ArticuloDatos negocio = new ArticuloDatos();
                List<Articulo> listaFinal = negocio.ListarArticulos();

                repArticulos.DataSource = listaFinal;
                repArticulos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar artículos: " + ex.Message;
            }
        }
    }

}