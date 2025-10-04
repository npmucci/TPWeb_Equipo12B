<%@ Page Title="Registro de Usuario" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroPage.aspx.cs" Inherits="Promo_Web.RegistroPage" UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center mb-4">Registro de Usuario</h2>

    <asp:UpdatePanel ID="upFormulario" runat="server">
        <ContentTemplate>
            <div class="container form-container mt-5">

                <!-- DNI -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label for="txtDNI" class="form-label">DNI</label>
                        <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"
                            placeholder="Ingrese su DNI"
                            AutoPostBack="true" OnTextChanged="txtDNI_TextChanged" />
                        <asp:Label ID="lblDni" runat="server" CssClass="text-danger mt-1"></asp:Label>
                    </div>
                </div>

               <!-- Nombre -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"
                            placeholder="Nombre" />
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                            ControlToValidate="txtNombre"
                            ErrorMessage="El nombre no puede estar vacío"
                            CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revNombre" runat="server"
                            ControlToValidate="txtNombre"
                            ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{1,50}$"
                            ErrorMessage="El nombre solo puede contener letras"
                            CssClass="text-danger" Display="Dynamic" />
                    </div>

                    <!-- Apellido -->
                    <div class="col-md-4">
                        <label for="txtApellido" class="form-label">Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"
                            placeholder="Apellido" />
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server"
                            ControlToValidate="txtApellido"
                            ErrorMessage="El apellido no puede estar vacío"
                            CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revApellido" runat="server"
                            ControlToValidate="txtApellido"
                            ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{1,50}$"
                            ErrorMessage="El apellido solo puede contener letras"
                            CssClass="text-danger" Display="Dynamic" />
                    </div>
                    
                    <!-- Mail -->
                    <div class="col-md-4">
                        <label for="txtMail" class="form-label">Mail</label>
                        <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"
                            TextMode="Email" placeholder="Correo electrónico" />
                        <asp:RequiredFieldValidator ID="rfvMail" runat="server"
                            ControlToValidate="txtMail"
                            ErrorMessage="Debe ingresar un email"
                            CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revMail" runat="server"
                            ControlToValidate="txtMail"
                            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                            ErrorMessage="Formato de email no válido"
                            CssClass="text-danger" Display="Dynamic" />
                    </div>
                </div>

                <!-- Domicilio -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <label for="txtDomicilio" class="form-label">Domicilio</label>
                        <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control"
                            placeholder="Domicilio" />
                        <asp:RequiredFieldValidator ID="rfvDomicilio" runat="server"
                            ControlToValidate="txtDomicilio"
                            ErrorMessage="El domicilio es obligatorio"
                            CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revDomicilio" runat="server"
                            ControlToValidate="txtDomicilio"
                            ValidationExpression="^[a-zA-Z0-9\s]{1,50}$"
                            ErrorMessage="El domicilio solo puede contener letras y números"
                            CssClass="text-danger" Display="Dynamic" />
                    </div>
                    
                    <!-- Ciudad -->
                    <div class="col-md-4">
                        <label for="txtCiudad" class="form-label">Ciudad</label>
                        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control"
                            placeholder="Ciudad" />
                        <asp:RequiredFieldValidator ID="rfvCiudad" runat="server"
                            ControlToValidate="txtCiudad"
                            ErrorMessage="Debe ingresar una ciudad"
                            CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revCiudad" runat="server"
                            ControlToValidate="txtCiudad"
                            ValidationExpression="^[a-zA-Z\s]{1,50}$"
                            ErrorMessage="La ciudad solo puede contener letras"
                            CssClass="text-danger" Display="Dynamic" />
                    </div>
                    
                    <!-- Código Postal -->
                    <div class="col-md-4">
                        <label for="txtCodigoPostal" class="form-label">Código Postal</label>
                        <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control"
                            placeholder="Código Postal" />
                        <asp:RequiredFieldValidator ID="rfvCP" runat="server"
                            ControlToValidate="txtCodigoPostal"
                            ErrorMessage="Debe ingresar un código postal"
                            CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revCP" runat="server"
                            ControlToValidate="txtCodigoPostal"
                            ValidationExpression="^(\d{4}|[A-Z]\d{4}[A-Z]{3})$"
                            ErrorMessage="Formato de código postal inválido. Ej: 1000 o C1425ABC"
                            CssClass="text-danger" Display="Dynamic" />
                    </div>
                </div>

                <!-- Términos y Condiciones -->
                <div class="form-check mb-4">
                     <asp:CheckBox ID="chkTerminos" runat="server" CssClass="form-check-input" onclick="document.getElementById('<%= lblterminos.ClientID %>').innerText='';" />
                     <label class="form-check-label" for="<%= chkTerminos.ClientID %>">
                     Acepto los <a href="#" data-bs-toggle="modal" data-bs-target="#terminosModal">Términos y Condiciones</a>
                     </label>
                </div>
                <asp:Label ID="lblterminos" runat="server" CssClass="text-danger mt-1"></asp:Label>

                <!-- Botón Participar -->
                <div class="row mb-4">
                    <div class="col-12 text-center">
                        <asp:Button ID="btnParticipar" runat="server" Text="Participar"
                            CssClass="btn btn-primary btn-md" OnClick="btnParticipar_Click" />
                    </div>
                </div>

            </div>
        </ContentTemplate>

        
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtDNI" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>

    
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

 

</asp:Content>