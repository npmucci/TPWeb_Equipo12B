<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PremioPage.aspx.cs" Inherits="Promo_Web.PremioPage" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card.selected {
            border: 3px solid #0a53be; 
            box-shadow: 0 0 12px rgba(0, 123, 255, 0.5);
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1>Seleccioná tu premio</h1>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" />

        <!-- Hidden field para almacenar el artículo seleccionado -->
        <asp:HiddenField ID="hfSeleccionado" runat="server" />

        <asp:Repeater ID="repArticulos" runat="server" OnItemCommand="repArticulos_ItemCommand">
            <ItemTemplate>
                <div class="card mb-3" style="max-width: 520px;">
                    <div class="row g-0">
                        <div class="col-md-4">
                            <!-- Carrusel  -->
                            <div id="carousel<%# Eval("Id") %>" class="carousel slide" data-bs-ride="false">
                                <div class="carousel-inner" style="width:100%; height:200px;">
                                    <asp:Repeater ID="repImagenes" runat="server" DataSource='<%# ((Dominio.Articulo)Container.DataItem).Imagenes %>'>
                                        <ItemTemplate>
                                            <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                                <img src='<%# Eval("ImagenUrl") %>' class="d-block mx-auto img-fluid" style="max-height:200px; width:auto;" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon"></span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("Id") %>" data-bs-slide="next">
                                    <span class="carousel-control-next-icon"></span>
                                </button>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <p>Marca: <%# Eval("Marca.Descripcion") %></p>
                                <p>Categoría: <%# Eval("Categoria.Descripcion") %></p>

                                <!-- Botón Seleccionar -->
                                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" 
                                    CssClass="btn btn-primary" CommandName="Seleccionar" 
                                    CommandArgument='<%# Eval("Id") %>' />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <!-- Botón Continuar (oculto al inicio) -->
        <asp:Button ID="btnContinuar" runat="server" Text="Continuar" CssClass="btn btn-success mt-3" 
                    Visible="false" OnClick="btnContinuar_Click" />
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>