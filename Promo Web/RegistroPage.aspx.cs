using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Promo_Web
{
    public partial class RegistroPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {

            string dni = txtDNI.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                lblDni.Text = "Por favor, ingrese su DNI.";
                return;
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
        }

    }
}