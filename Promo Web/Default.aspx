<%@ Page Title="Home" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Promo_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex align-items-start justify-content-center vh-100">
          <div class="card shadow-lg p-4 text-center mt-5" style="max-width: 800px; border-radius: 15px;">

                <!-- logo -->
                <img src="https://i.ibb.co/27WpMBqC/Promo-Gana2.png" alt="Logo Empresa" class="imgLogo">
              
                
                
                <!-- bienvenida -->
                <h1 class="h3 mb-3">¡Bienvenido a nuestra promoción!</h1>
                <p class="text-muted">Estamos felices de que hayas realizado tu compra y quieras participar por un premio.</p>

                <!-- instrucciones -->
                <div class="text-start bg-light p-3 rounded mb-3">
                    <h5>Cómo participar:</h5>
                    <ol>
                          <li>Ingresa el código de tu voucher que recibiste con tu compra.</li>
                          <li>Si el código es válido y no ha sido utilizado, podrás elegir tu premio.</li>
                          <li>Una vez elegido el premio, tendrás que completar el formulario de registro con tus datos.</li>
                          <li>Cuando termines de completar tus datos, hacé click en <b>Participar</b>.</li>
                     </ol>
                    <p class="text-secondary small mb-0">🔑 Recordá que cada voucher solo puede usarse una vez.</p>
                </div>

                <!-- boton conenzar -->
                
                <asp:Button ID="btnComenzar" runat="server" Text="🎁 Comenzar" CssClass="btn btn-primary btn-lg w-100" OnClick="btnComenzar_Click" />

            </div>
        </div>
</asp:Content>
