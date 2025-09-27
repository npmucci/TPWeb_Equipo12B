<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VoucherPage.aspx.cs" Inherits="Promo_Web.VoucherPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


         <div class="d-flex justify-content-center align-items-center" style="height:70vh;">

        
        <div class="card shadow-lg p-4 rounded" style="width: 600px; background-color: #ffffff;">
            
            <!-- Título -->

            <label for="txtCodigo" class="text-center mb-4 fs-2 fw-bold d-block">
                Ingresá tu código de voucher:
            </label>
            

           <!-- Input Group -->
            <div class="input-group input-group-lg mb-3">
                 <span class="input-group-text" id="inputGroup-sizing-lg">🏷️ </span>
                 <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" aria-label="Código de voucher" aria-describedby="inputGroup-sizing-lg" />
            </div>

            <!-- Botón -->
            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="btn btn-primary btn-lg w-100" OnClick="btnSiguiente_Click" />

            <!-- Mensaje -->
            <div class="form-floating mt-4">
            <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mt-5"></asp:Label>
            </div>

        </div>

    </div>
</asp:Content>
