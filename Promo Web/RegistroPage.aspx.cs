using Dominio;
using Negocio;
using System;
using System.Text.RegularExpressions;

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
                LimpiarTxt();
                CambiarEstado(false);
                lblDni.Text = "Por favor, ingrese su DNI.";
                return;
            }

            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                lblDni.Text = "El DNI debe contener solo números y tener 7 u 8 dígitos.";
                lblDni.CssClass = "text-danger";
                LimpiarTxt();
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

                CambiarEstado(false);
                lblDni.Text = "Cliente ya registrado";
                lblDni.CssClass = "text-success";

            }
            else
            {
                CambiarEstado(true);
                LimpiarTxt();

                lblDni.Text = "Cliente no encontrado. Complete sus datos para registrarse.";
                lblDni.CssClass = "text-danger";

            }


        }

        protected void btnParticipar_Click(object sender, EventArgs e)

        {

            lblterminos.Text = "";

            if (!Page.IsValid)
                return; // valida todos los Validators declarativos primero

            string dni = txtDNI.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                lblDni.Text = "Por favor, ingrese su DNI.";
                return;
            }

            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                lblDni.Text = "El DNI debe contener solo números y tener 7 u 8 dígitos.";
                lblDni.CssClass = "text-danger";
                return;
            }




            if (!chkTerminos.Checked)
            {
                lblterminos.Text = "Debe aceptar los Términos y Condiciones para participar.";
                lblterminos.CssClass = "text-danger";
                return;
            }

            Page.Validate("Otros");
            if (!Page.IsValid)
                return;



            ClienteNegocio clienteNegocio = new ClienteNegocio();
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            Cliente cliente = clienteNegocio.BuscarCliente(dni);

            if (cliente == null)
            {
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

            string codigoVoucher = Session["VoucherCodigo"].ToString();
            int idArticulo = int.Parse(Request.QueryString["idArticulo"]);
            Voucher voucher = new Voucher { Codigo = codigoVoucher };
            voucherNegocio.ActualizarVoucher(voucher, cliente.Id, idArticulo);

            EnviarEmailParticipacion(cliente, codigoVoucher);
            Response.Redirect("ExitoPage.aspx", false);
        }
        private void EnviarEmailParticipacion(Cliente cliente, string codigoVoucher)
        {
            try
            {
                string asunto = "Registro exitoso en PromoGana";

                string cuerpo = "<h2>¡Hola " + cliente.Nombre + " " + cliente.Apellido + "!</h2>" +
                 "<p><b>Tu registro fue exitoso.</b></p>" +
                 "<p>Número de voucher utilizado: <b>" + codigoVoucher + "</b></p>" +
                 "<p>¡Gracias por participar en <b>PromoGana</b>!</p>" +
                 "<hr>" +
                 "<p><i>Este es un correo automático, por favor no respondas.</i></p>";


                EmailService emailService = new EmailService();
                emailService.ArmarEmail(cliente.Email, asunto, cuerpo);
                emailService.EnviarEmail();
            }
            catch (Exception ex)
            {
                throw new Exception("Error enviando email: " + ex.Message, ex);
            }
        }

        private void CambiarEstado(bool estado)
        {
            txtNombre.Enabled = estado;
            txtApellido.Enabled = estado;
            txtMail.Enabled = estado;
            txtDomicilio.Enabled = estado;
            txtCiudad.Enabled = estado;
            txtCodigoPostal.Enabled = estado;


        }

        private void LimpiarTxt()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtDomicilio.Text = "";
            txtCiudad.Text = "";
            txtCodigoPostal.Text = "";
        }

    }
}