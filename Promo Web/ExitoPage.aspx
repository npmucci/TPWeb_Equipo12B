<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ExitoPage.aspx.cs" Inherits="Promo_Web.ExitoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <img src="https://i.ibb.co/27WpMBqC/Promo-Gana2.png" alt="Logo Empresa" class="imgLogo">
        <p> Voucher canjeado con éxito</p>
        <h2>¡GRACIAS POR PARTICIPAR EN NUESTRA PROMO!</h2>
   
         <asp:Button ID="btnHome" runat="server" Text="Volver al inicio" CssClass="btn-home btn-md" OnClick="btnHome_Click" />
     </div>

</asp:Content>
