<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Ingresar.aspx.vb" Inherits="Unibe.Ingresar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="UserIdH" runat="server" />

        <div>
            <div class="container mt-3">

                <div class="row mb-3">
                    <div class="col">
                        <h3 class="accordion-header"> Ingrese Su Informacion</h3>
                    </div>

                </div>
                <div class="row mb-3">
                    <div class="col-6">
                        <div>

                            <asp:Label ID="label1" runat="server" CssClass="form-label">Nombre</asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label ID="label3" runat="server" CssClass="form-label">Cedula</asp:Label>
                            <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control form-control-sm" placeholder="Cedula, Visa o pasaporte"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label ID="label6" runat="server" CssClass="form-label">Estatus</asp:Label>
                            <asp:DropDownList ID="ddlEstatus" runat="server" class="form-select form-select-sm"></asp:DropDownList>
                        </div>

                    </div>

                    <div class="col-6">

                        <div>
                            <asp:Label ID="label2" runat="server" CssClass="form-label">Direccion</asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="label4" runat="server" CssClass="form-label">Telefono</asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control form-control-sm" placeholder="000-000-0000"></asp:TextBox>
                        </div>

                    </div>
                </div>
                
                <div class="row">
                    <div class="col-6">
                        <asp:Button ID="btnAdd" runat="server" class="btn btn-success" Text="Agregar" OnClick="Insert" />
                        <asp:LinkButton ID="btnRegresar" runat="server" class="btn btn-primary" Text="Regresar" href="/Form.aspx"></asp:LinkButton>
                    </div>
                    <div class="col-6">
                        <asp:Button ID="btnlimpiar" runat="server" class="btn btn-light" Text="Limpiar" OnClick="btnlimpiar_Click" />
                    </div>
                </div>

            </div>

        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>
</body>
</html>
