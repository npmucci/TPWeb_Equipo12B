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
        protected void repArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                // Guardar el ID seleccionado
                hfSeleccionado.Value = e.CommandArgument.ToString();

                // Mostrar el botón Continuar
                btnContinuar.Visible = true;

                // Cambiar el estilo de los botones para indicar seleccionado
                foreach (RepeaterItem item in repArticulos.Items)
                {
                    Button btn = (Button)item.FindControl("btnSeleccionar");
                    if (btn != null)
                    {
                        btn.CssClass = btn.CommandArgument == hfSeleccionado.Value ? "btn btn-success" : "btn btn-primary";
                    }
                }
            }
        }

        // Redirigir al RegistroPage
        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfSeleccionado.Value))
            {
                // Pasar el ID del artículo seleccionado por querystring (opcional)
                Response.Redirect("RegistroPage.aspx?idArticulo=" + hfSeleccionado.Value);
            }
        }

        private List<Articulo> ObtenerArticulos()
        {
            // Tu método para traer los artículos de la base de datos
            // Esto es un ejemplo con artículos de prueba
            return new List<Articulo>
            {
                new Articulo { Id = 1, Nombre = "Mochila", Descripcion="Mochila de prueba", Marca = new Marca{Descripcion="Wilson"}, Categoria=new Categoria{Descripcion="Mochilas"} },
                new Articulo { Id = 2, Nombre = "Mouse", Descripcion="Mouse de prueba", Marca = new Marca{Descripcion="Logitech"}, Categoria=new Categoria{Descripcion="Periféricos"} },
                new Articulo { Id = 3, Nombre = "Teclado", Descripcion="Teclado de prueba", Marca = new Marca{Descripcion="Logitech"}, Categoria=new Categoria{Descripcion="Accesorios"} }
            };
        }
    }
}
   