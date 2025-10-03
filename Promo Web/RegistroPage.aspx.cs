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



        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                lblNombre.Text = "El nombre no puede estar vacío";
            }
            else if (nombre.Length > 50)
            {
                lblNombre.Text = "El nombre no puede tener más de 50 caracteres";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                lblNombre.Text = "El nombre solo puede contener letras";
            }
            else
            {
                lblNombre.Text = "";
            }
        }

        protected void txtApellido_TextChanged(object sender, EventArgs e)
        {
            string apellido = txtApellido.Text.Trim();

            if (string.IsNullOrWhiteSpace(apellido))
            {
                lblApellido.Text = "El apellido no puede estar vacío";
            }
            else if (apellido.Length > 50)
            {
                lblApellido.Text = "El apellido no puede tener más de 50 caracteres";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                lblApellido.Text = "El apellido solo puede contener letras y espacios";
            }
            else
            {
                lblApellido.Text = "";
            }
        }

        protected void txtMail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                lblMail.Text = "Debe ingresar un email";
            }
            else if (txtMail.Text.Length > 50)
            {
                lblMail.Text = "El email no puede superar los 50 caracteres";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(
                         txtMail.Text,
                         @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMail.Text = "Formato de email no válido";
            }
            else
            {
                lblMail.Text = "";
            }
        }

        protected void txtDomicilio_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDomicilio.Text))
            {
                lblDomicilio.Text = "El domicilio es obligatorio";
            }
            else if (txtDomicilio.Text.Length > 50)
            {
                lblDomicilio.Text = "El domicilio no puede superar los 50 caracteres";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(
                         txtDomicilio.Text,
                         @"^[a-zA-Z0-9\s]+$"))
            {
                lblDomicilio.Text = "El domicilio solo puede contener letras y números";
            }
            else
            {
                lblDomicilio.Text = "";
            }
        }

        protected void txtCiudad_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                lblCiudad.Text = "Debe ingresar una ciudad";
            }
            else if (txtCiudad.Text.Length > 50)
            {
                lblCiudad.Text = "La ciudad no puede superar los 50 caracteres";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(
                         txtCiudad.Text,
                         @"^[a-zA-Z\s]+$"))
            {
                lblCiudad.Text = "La ciudad solo puede contener letras";
            }
            else
            {
                lblCiudad.Text = "";
            }
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            string cp = txtCodigoPostal.Text.Trim();

            if (string.IsNullOrWhiteSpace(cp))
            {
                lblCodigoPostal.Text = "Debe ingresar un código postal.";
            }
            else if (cp.Length > 8)
            {
                lblCodigoPostal.Text = "El código postal no puede superar los 8 caracteres.";
            }
            else if (!Regex.IsMatch(cp, @"^(\d{4}|[A-Z]\d{4}[A-Z]{3})$", RegexOptions.IgnoreCase))
            {
                lblCodigoPostal.Text = "Formato de código postal inválido. Ej: 1000 o C1425ABC.";
            }
            else
            {
                lblCodigoPostal.Text = "";
            }
        }
        private bool validarCampos()
        {
            bool todoOk = true;

            // Nombre
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                lblNombre.Text = "El nombre no puede estar vacío";
                todoOk = false;
            }
            else if (nombre.Length > 50)
            {
                lblNombre.Text = "El nombre no puede tener más de 50 caracteres";
                todoOk = false;
            }
            else if (!Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                lblNombre.Text = "El nombre solo puede contener letras";
                todoOk = false;
            }
            else
            {
                lblNombre.Text = "";
            }

            // Apellido
            string apellido = txtApellido.Text.Trim();
            if (string.IsNullOrWhiteSpace(apellido))
            {
                lblApellido.Text = "El apellido no puede estar vacío";
                todoOk = false;
            }
            else if (apellido.Length > 50)
            {
                lblApellido.Text = "El apellido no puede tener más de 50 caracteres";
                todoOk = false;
            }
            else if (!Regex.IsMatch(apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                lblApellido.Text = "El apellido solo puede contener letras y espacios";
                todoOk = false;
            }
            else
            {
                lblApellido.Text = "";
            }

            // Mail
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                lblMail.Text = "Debe ingresar un email";
                todoOk = false;
            }
            else if (txtMail.Text.Length > 50)
            {
                lblMail.Text = "El email no puede superar los 50 caracteres";
                todoOk = false;
            }
            else if (!Regex.IsMatch(txtMail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMail.Text = "Formato de email no válido";
                todoOk = false;
            }
            else
            {
                lblMail.Text = "";
            }

            // Domicilio
            if (string.IsNullOrWhiteSpace(txtDomicilio.Text))
            {
                lblDomicilio.Text = "El domicilio es obligatorio";
                todoOk = false;
            }
            else if (txtDomicilio.Text.Length > 50)
            {
                lblDomicilio.Text = "El domicilio no puede superar los 50 caracteres";
                todoOk = false;
            }
            else if (!Regex.IsMatch(txtDomicilio.Text, @"^[a-zA-Z0-9\s]+$"))
            {
                lblDomicilio.Text = "El domicilio solo puede contener letras y números";
                todoOk = false;
            }
            else
            {
                lblDomicilio.Text = "";
            }

            // Ciudad
            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                lblCiudad.Text = "Debe ingresar una ciudad";
                todoOk = false;
            }
            else if (txtCiudad.Text.Length > 50)
            {
                lblCiudad.Text = "La ciudad no puede superar los 50 caracteres";
                todoOk = false;
            }
            else if (!Regex.IsMatch(txtCiudad.Text, @"^[a-zA-Z\s]+$"))
            {
                lblCiudad.Text = "La ciudad solo puede contener letras";
                todoOk = false;
            }
            else
            {
                lblCiudad.Text = "";
            }

            // Código Postal
            string cp = txtCodigoPostal.Text.Trim();
            if (string.IsNullOrWhiteSpace(cp))
            {
                lblCodigoPostal.Text = "Debe ingresar un código postal.";
                todoOk = false;
            }
            else if (cp.Length > 8)
            {
                lblCodigoPostal.Text = "El código postal no puede superar los 8 caracteres.";
                todoOk = false;
            }
            else if (!Regex.IsMatch(cp, @"^(\d{4}|[A-Z]\d{4}[A-Z]{3})$", RegexOptions.IgnoreCase))
            {
                lblCodigoPostal.Text = "Formato de código postal inválido. Ej: 1000 o C1425ABC.";
                todoOk = false;
            }
            else
            {
                lblCodigoPostal.Text = "";
            }

            return todoOk;
        }
        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
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

            lblterminos.Text = ""; // Limpiamos primero cualquier mensaje antiguo para que no quede el mensaje luego de tildar el ckeckbox

            if (!chkTerminos.Checked)
            {
                lblterminos.Text = "Debe aceptar los Términos y Condiciones para participar.";
                lblterminos.CssClass = "text-danger";
                return;
            }

            if (!validarCampos())
            {
                return;
            }

            
            bool clienteExistente = Session["ClienteExistente"] != null && (bool)Session["ClienteExistente"];
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            Cliente cliente = clienteNegocio.BuscarCliente(dni);

            if (!clienteExistente)
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

    }
}