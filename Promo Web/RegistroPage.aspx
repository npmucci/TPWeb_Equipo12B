<%@ Page Title="Registro de Usuario" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroPage.aspx.cs" Inherits="Promo_Web.RegistroPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center mb-4">Registro de Usuario</h2>
 <asp:UpdatePanel ID="upFormulario" runat="server">
    <ContentTemplate> 
    <div class="container form-container mt-5">
                     
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="txtDNI" class="form-label">DNI</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese su DNI" AutoPostBack="true" OnTextChanged="txtDNI_TextChanged" /> 
            </div>
            <div class="col-md-12">
                  <asp:Label ID="lblDni" runat="server" CssClass="text-danger mt-1"></asp:Label>
            </div>
        </div>


        <div class="row mb-3">
            <div class="col-md-4">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" Enabled="false" />
            </div>
            <div class="col-md-4">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido" Enabled="false"/>
            </div>
            <div class="col-md-4">
                <label for="txtMail" class="form-label">Mail</label>
                <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Correo electrónico" Enabled="false"/>
            </div>
        </div>

        
        <div class="row mb-4">
            <div class="col-md-4">
                <label for="txtDomicilio" class="form-label">Domicilio</label>
                <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control" placeholder="Domicilio" Enabled="false" />
            </div>
            <div class="col-md-4">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" placeholder="Ciudad" Enabled="false"/>
            </div>
            <div class="col-md-4">
                <label for="txtCodigoPostal" class="form-label">Código Postal</label>
                <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" placeholder="Código Postal" Enabled="false" />
            </div>
        </div>

        <div class="form-check mb-4">
            <asp:CheckBox ID="chkTerminos" runat="server" />
            <label class="form-check-label" for="chkTerminos">
                Acepto los <a href="#" data-bs-toggle="modal" data-bs-target="#terminosModal">Términos y Condiciones</a>
            </label>
        </div>
        <div>
             <asp:Label ID="lblterminos" runat="server" CssClass="text-danger mt-1"></asp:Label>
        </div>
        <div class="row mb-4">
            <div class="col-12 text-center">
                <asp:Button ID="btnParticipar" runat="server" Text="Participar" CssClass="btn btn-primary btn-md" OnClick="btnParticipar_Click" />
            </div>
        </div>        
              <div class="modal fade" id="terminosModal" tabindex="-1" aria-labelledby="terminosModalLabel" aria-hidden="true">
              <div class="modal-dialog modal-lg">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="terminosModalLabel">Términos y Condiciones - PR✪MO GANÁ </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                  </div>
                  <div class="modal-body">
                    <p><strong>1. Participación:</strong> Podrán participar personas mayores de 18 años que hayan realizado una compra y recibido un voucher con código promocional único. Cada código solo puede usarse una vez.</p>

                    <p><strong>2. Proceso:</strong> Ingresá al sitio web de la promoción, cargá el código del voucher, seleccioná un premio disponible y completá tus datos personales para registrarte en el sorteo.</p>

                    <p><strong>3. Datos Personales:</strong> Los datos solicitados (DNI, nombre, apellido, domicilio, teléfono y correo) se usarán únicamente para gestionar la promoción y contactar a los ganadores, de acuerdo con la política de privacidad.</p>

                    <p><strong>4. Condiciones Generales:</strong> Participar implica aceptar estos términos. El organizador puede descalificar a quien intente usar el sistema de forma fraudulenta.</p>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                  </div>
                </div>
              </div>
            </div>
     

    </div>
        
    </ContentTemplate>

</asp:UpdatePanel>
   
 </asp:Content>
