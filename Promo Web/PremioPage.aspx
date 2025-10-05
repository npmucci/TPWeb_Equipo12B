<%@ Page Title="Premios" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="PremioPage.aspx.cs" Inherits="Promo_Web.PremioPage"
    MaintainScrollPositionOnPostBack="true" %>
<%@ Import Namespace="Dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-3">Seleccioná tu premio</h1>
    <div class="container text-center mt-2">
         <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        <asp:UpdatePanel ID="upArticulos" runat="server">
            <ContentTemplate> 
                <!-- Hidden field para almacenar el artículo seleccionado --> 
                <asp:HiddenField ID="hfSeleccionado" runat="server" />
                <!-- Grilla de cards --> 
                <div class="row row-cols-1 row-cols-md-3 g-4 ">
                    <asp:Repeater ID="repArticulos" runat="server" OnItemCommand="repArticulos_ItemCommand"> 
                        <ItemTemplate>
                            <div class="col">
                             <div class="card card-container h-auto border-primary d-flex flex-column" style="max-width: 300px;">
                                <!-- Carrusel -->
                                <div id="carousel<%# Eval("Id") %>" class="carousel slide" data-bs-ride="false">
                                  <div class="carousel-inner";">
                                    <asp:Repeater ID="repImagenes" runat="server" DataSource='<%# ((Dominio.Articulo)Container.DataItem).Imagenes %>'>
                                      <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                         <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100 img-fluid" style="height:85px; object-fit:contain;" />
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

                                <!-- Cuerpo adaptativo -->
                                 <div class="card-body d-flex flex-column flex-grow-1 p-2" style="font-size:0.7rem; line-height:1;">
                                  <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                  <p class="card-text"><%# Eval("Descripcion") %></p>
                                  <p class="card-text">Marca: <%# Eval("Marca.Descripcion") %></p>
                                  <p class="card-text">Categoría: <%# Eval("Categoria.Descripcion") %></p>

                                  <!-- Botón siempre abajo -->
                                  <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn mt-auto" 
                                      Style="width:100%; height:45px; white-space:nowrap;" CommandName="Seleccionar" CommandArgument='<%# Eval("Id") %>' />
                                </div>
                              </div>
                            </div>
                                                       

                        </ItemTemplate> 

                    </asp:Repeater>

                </div> 
                <!-- Botón Continuar --> 
                <div class="d-flex justify-content-center mt-3">
                    <asp:Button ID="btnContinuar" runat="server" Text="Continuar" CssClass="btn" Visible="false" 
                        OnClick="btnContinuar_Click" Style="width:150px;" /> 

                </div>

            </ContentTemplate>

        </asp:UpdatePanel>

    </div> 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js">

    </script>

     <script type="text/javascript">
      
      Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (sender, args) {
         
          var btn = document.getElementById('<%= btnContinuar.ClientID %>');
          if (btn && btn.style.display !== "none") {
              document.getElementById('footer').scrollIntoView({ behavior: 'smooth' });
          }
      });
     </script>

</asp:Content>