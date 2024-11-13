<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Exam3.Views.Product" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Productos</title>
    
    <!-- Enlace a la versión más reciente de Bootstrap 5 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="formAgregarProducto" runat="server" enctype="multipart/form-data">
        <div class="container mt-4">
            <h2>Agregar Producto</h2>
            
            <!-- Formulario para agregar producto -->
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtCantidad" class="form-label">Cantidad:</label>
                <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtCosto" class="form-label">Costo:</label>
                <asp:TextBox ID="txtCosto" runat="server" TextMode="Number" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="fileImagen" class="form-label">Imagen:</label>
                <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" CssClass="btn btn-primary" />
        </div>

        <!-- Lista de productos -->
        <div class="container mt-4">
            <h2>Lista de Productos</h2>
            <div class="table-responsive">
                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Costo" HeaderText="Costo" />
                        <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("Imagen")) %>' Width="100px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
