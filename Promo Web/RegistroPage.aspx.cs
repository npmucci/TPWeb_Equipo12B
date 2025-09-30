using Dominio;
using Negocio;
using System;

namespace Promo_Web
{
    public partial class RegistroPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validamos que tengamos voucher y artículo
                if (Session["VoucherCodigo"] == null || Request.QueryString["idArticulo"] == null)
                {
                    Response.Redirect("Default.aspx"); // volvemos al inicio
                }
            }
        }

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                lblDni.Text = "Por favor, ingrese su DNI.";
                return;
            }

            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = negocio.BuscarCliente(dni);

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtMail.Text = cliente.Email;
                txtDomicilio.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCodigoPostal.Text = cliente.CP.ToString();

                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtMail.Enabled = false;
                txtDomicilio.Enabled = false;
                txtCiudad.Enabled = false;
                txtCodigoPostal.Enabled = false;

                lblDni.Text = "Cliente encontrado. Puedes continuar con la participación.";
                lblDni.CssClass = "text-success";
                Session["ClienteExistente"] = true;
            }
            else
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtMail.Enabled = true;
                txtDomicilio.Enabled = true;
                txtCiudad.Enabled = true;
                txtCodigoPostal.Enabled = true;

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtMail.Text = "";
                txtDomicilio.Text = "";
                txtCiudad.Text = "";
                txtCodigoPostal.Text = "";

                lblDni.Text = "Cliente no encontrado. Complete sus datos para registrarse.";
                lblDni.CssClass = "text-warning";
                Session["ClienteExistente"] = false;
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            string codigoVoucher = Session["VoucherCodigo"].ToString();
            int idArticulo = int.Parse(Request.QueryString["idArticulo"]);

            if (string.IsNullOrEmpty(dni))
            {
                lblDni.Text = "Por favor, ingrese su DNI.";
                return;
            }

            if (!chkTerminos.Checked)
            {
                lblterminos.Text = "Debe aceptar los Términos y Condiciones para participar.";
                lblterminos.CssClass = "text-danger";
                return;
            }

            bool clienteExistente = Session["ClienteExistente"] != null && (bool)Session["ClienteExistente"];
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            Cliente cliente = clienteNegocio.BuscarCliente(dni);

            if (!clienteExistente)
            {
                if (string.IsNullOrEmpty(txtNombre.Text) ||
                    string.IsNullOrEmpty(txtApellido.Text) ||
                    string.IsNullOrEmpty(txtMail.Text) ||
                    string.IsNullOrEmpty(txtDomicilio.Text) ||
                    string.IsNullOrEmpty(txtCiudad.Text) ||
                    string.IsNullOrEmpty(txtCodigoPostal.Text))
                {
                    lblDni.Text = "Por favor, complete todos los campos.";
                    lblDni.CssClass = "text-danger";
                    return;
                }

                Cliente nuevo = new Cliente
                {
                    Documento = dni,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtMail.Text,
                    Direccion = txtDomicilio.Text,
                    Ciudad = txtCiudad.Text,
                    CP = int.Parse(txtCodigoPostal.Text)
                };

                clienteNegocio.AgregarCliente(nuevo);
                cliente = clienteNegocio.BuscarCliente(dni);
            }

            Voucher voucher = new Voucher { Codigo = codigoVoucher };
            voucherNegocio.ActualizarVoucher(voucher, cliente.Id, idArticulo);

            Response.Redirect("ExitoPage.aspx");
        }
    }
}