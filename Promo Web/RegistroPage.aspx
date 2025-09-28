<%@ Page Title="Registro de Usuario" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroPage.aspx.cs" Inherits="Promo_Web.RegistroPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center mb-4">Registro de Usuario</h2>
    
    <div class="container form-container mt-5">

             
        <div class="row mb-3">
             <div class="col-md-4">
                  <label for="txtDNI" class="form-label">DNI</label>
                   <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese su DNI" />
              </div>
        </div>

        <div class="row mb-3">
            <div class="col-md-4">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" />
            </div>
            <div class="col-md-4">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido" />
            </div>
            <div class="col-md-4">
                <label for="txtMail" class="form-label">Mail</label>
                <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Correo electrónico" />
            </div>
        </div>

        
        <div class="row mb-4">
            <div class="col-md-4">
                <label for="txtDomicilio" class="form-label">Domicilio</label>
                <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control" placeholder="Domicilio" />
            </div>
            <div class="col-md-4">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" placeholder="Ciudad" />
            </div>
            <div class="col-md-4">
                <label for="txtCodigoPostal" class="form-label">Código Postal</label>
                <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" placeholder="Código Postal" />
            </div>
        </div>

        <div class="form-check mb-4">
            <asp:CheckBox ID="chkTerminos" runat="server" />
            <label class="form-check-label" for="chkTerminos">
                Acepto los <a href="#" data-bs-toggle="modal" data-bs-target="#terminosModal">Términos y Condiciones</a>
            </label>
        </div>


        <div class="d-grid">
            <asp:Button ID="btnParticipar" runat="server" Text="Participar" CssClass="btn btn-primary btn-sm" />
        </div>

    </div>

   
 </asp:Content>
