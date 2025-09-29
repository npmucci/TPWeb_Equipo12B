<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PremioPage.aspx.cs" Inherits="Promo_Web.PremioPage" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1>Seleccioná tu premio</h1>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" />

        <asp:Repeater ID="repArticulos" runat="server">
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
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    

</asp:Content>