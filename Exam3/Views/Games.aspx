<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="Exam3.Views.Games" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Juegos</title>
    
    <!-- Enlace a la versión más reciente de Bootstrap 5 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="formAgregarJuego" runat="server" enctype="multipart/form-data">
        <div class="container mt-4">
            <h2>Agregar Juego</h2>
            
            <!-- Formulario para agregar juego -->
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtCantidad" class="form-label">Cantidad:</label>
                <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio:</label>
                <asp:TextBox ID="txtPrecio" runat="server" TextMode="SingleLine" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="fileImagen" class="form-label">Imagen:</label>
                <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnAgregarJuego" runat="server" Text="Agregar Juego" OnClick="btnAgregarJuego_Click" CssClass="btn btn-primary" />
        </div>

<hr />

        <!-- Lista de juegos -->
        <div class="container mt-4">
            <h2>Lista de Juegos</h2>
            <div class="table-responsive">
                <asp:GridView ID="gvJuegos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                      <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <img src='<%# ResolveUrl(Eval("Imagen").ToString()) %>' alt="Imagen del Juego" width="100px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>