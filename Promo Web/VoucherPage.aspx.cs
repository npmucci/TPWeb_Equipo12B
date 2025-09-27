using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Promo_Web
{
    public partial class VoucherPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            string codigoIngresado = txtCodigo.Text.Trim();
            VoucherNegocio negocio = new VoucherNegocio();

            EstadoVoucher estado = negocio.ValidarVoucher(codigoIngresado);

            switch (estado)
            {
                case EstadoVoucher.Valido:
                    // Guardamos el código en Session y redirigimos
                    Session["VoucherCodigo"] = codigoIngresado;
                    Response.Redirect("SeleccionPremio.aspx");
                    break;

                case EstadoVoucher.YaUsado:
                    lblMensaje.Text = "El código ingresado ya fue utilizado.";
                    lblMensaje.CssClass = "alert alert-warning";
                    break;

                case EstadoVoucher.Inexistente:
                    lblMensaje.Text = "El código ingresado no existe.";
                    lblMensaje.CssClass = "alert alert-danger";
                    break;
            }
        }
    }
}