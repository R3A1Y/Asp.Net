<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Form.aspx.vb" Inherits="Unibe.Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 348px;
        }

        .auto-style3 {
            width: 370px;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>





    <form id="form1" runat="server">


        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:MultiView ID="mView" runat="server" ActiveViewIndex="0">
            <asp:View ID="Index" runat="server">

                <div class="container">

                    <div class="row">
                        <div class="col-12">

                            <nav>
                                <div class="nav nav-tabs" id="nav-tab" role="tablist">
                                    <button class="nav-link active" id="nav-seccion1-tab" data-bs-toggle="tab" data-bs-target="#nav-seccion1" type="button" role="tab" aria-controls="nav-seccion1" aria-selected="true">CRUD</button>
                                    <button class="nav-link" id="nav-seccion2-tab" data-bs-toggle="tab" data-bs-target="#nav-seccion2" type="button" role="tab" aria-controls="nav-seccion2" aria-selected="false">Informacion</button>
                                </div>
                            </nav>

                        </div>
                    </div>

                </div>

                <div class="container">

                    <div class="tab-content" id="nav-tabContent">

                        <div class="tab-pane fade show active" id="nav-seccion1" role="tabpanel" aria-labelledby="nav-seccion1-tab">

                            <div class="container">

                                <h3>Crud</h3>



                                <div class="row">
                                    <div class="col-6">
                                        <div>
                                            <asp:Label ID="label5" runat="server" CssClass="form-label">Buscar por cedula</asp:Label>

                                            <div class="input-group">
                                                <span class="input-group-text">🔎</span>
                                                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                                <asp:Button ID="btnBuscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="Search" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-6" style="text-align: end; margin-top: 24px">
                                        <asp:LinkButton ID="btnNuevo" runat="server" CssClass="btn btn-primary" Text="Nuevo" OnClick="btnNuevo_Click" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-12">
                                        <table class="table w-100">
                                            <thead class="table-dark">
                                                <tr>
                                                    <th>Nombre</th>
                                                    <th>Direccion</th>
                                                    <th>Cedula</th>
                                                    <th>Telefono</th>
                                                    <th>Estatus</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="GridView1" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDireccion" runat="server" Text='<%# Eval("Direccion") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCedula" runat="server" Text='<%# Eval("Cedula") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Eval("Telefono") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblEstatus" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnEdit" runat="server" class="btn btn-secondary" Text="Editar" CommandArgument='<%# Eval("Cedula") %>' OnClick="Consult" />
                                                                <asp:Button ID="btndelet" runat="server" class="btn btn-danger" Text="Eliminar" CommandArgument='<%# Eval("Cedula") %>' OnClick="Delete" />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="tab-pane fade" id="nav-seccion2" role="tabpanel" aria-labelledby="nav-seccion2-tab">

                            <div class="container">
                                <div class="row">
                                    <div class="col-4">
                                        <img src="https://lh3.googleusercontent.com/v--plqz3UIskeOZI5o1sfoyA6MLUEHSZh21jnRdF_fCj2J4umfwuOszibDzCNSiahRctHtiRskwJVjTskmY3AWWf6gYh06kKmhKZhX4NVQqxMERjGwA9CLFbzZqESWDrQ_g7DBPdeA=w2400" alt="CRUD" width="100%" />
                                    </div>
                                    <div class="col-4">
                                        <h3>Que es esto?</h3>
                                        <p>Esto es un CRUD Basico para desempeñar mis habilidades aprendidas en el transcurso de la pasantia</p>
                                    </div>
                                    <div class="col-4">
                                        <div class="card" style="width: 18rem;">
                                            <img src="https://www.oymas.edu.do/tools/avatar-upload/files/Vs5GTxfH2YeFitB21-mist-1-005-avatar.jpeg" class="card-img-top" alt="Perfil" />
                                            <div class="card-body">
                                                <h5 class="card-title">Ray Alvarez</h5>
                                                <p class="card-text">Programador principiante aprendiendo dia tras dias las enseñansas que recibo.</p>
                                                <a href="mailto:rayyunioralvarezrayo@gmail.com" class="btn btn-primary">Correo</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>

            </asp:View>


            <asp:View ID="Ingresar" runat="server">

                <div>
                    <div class="container mt-3">

                        <div class="row mb-3">
                            <div class="col">
                                <h3 class="accordion-header">Ingrese Su Informacion</h3>
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
                                <asp:LinkButton ID="btnRegresar" runat="server" class="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click"></asp:LinkButton>
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnlimpiar" runat="server" class="btn btn-light" Text="Limpiar" OnClick="btnlimpiar_Click" />
                            </div>
                        </div>

                    </div>

                </div>

            </asp:View>
            <asp:View ID="editar" runat="server">

                <div>
                    <div class="container mt-3">

                        <div class="row mb-3">
                            <div class="col">
                                <h3 class="accordion-header">Edite La Informacion</h3>
                            </div>

                        </div>
                        <div class="row mb-3">
                            <div class="col-6">
                                <div>

                                    <asp:Label ID="label7" runat="server" CssClass="form-label">Nombre</asp:Label>
                                    <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                </div>

                                <div>
                                    <asp:Label ID="label8" runat="server" CssClass="form-label">Cedula</asp:Label>
                                    <asp:TextBox ID="txtCedulaEdit" runat="server" ReadOnly="true" CssClass="form-control form-control-sm disabled"></asp:TextBox>
                                </div>

                                <div>
                                    <asp:Label ID="label9" runat="server" CssClass="form-label">Estatus</asp:Label>
                                    <asp:DropDownList ID="ddlEstatusEdit" runat="server" class="form-select form-select-sm"></asp:DropDownList>
                                </div>

                            </div>

                            <div class="col-6">

                                <div>
                                    <asp:Label ID="label10" runat="server" CssClass="form-label">Direccion</asp:Label>
                                    <asp:TextBox ID="txtDireccionEdit" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:Label ID="label11" runat="server" CssClass="form-label">Telefono</asp:Label>
                                    <asp:TextBox ID="txtTelefonoEdit" runat="server" CssClass="form-control form-control-sm" placeholder="000-000-0000"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Guardar" OnClick="Update" />
                                <asp:LinkButton ID="btnRegresarEdit" runat="server" class="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click"></asp:LinkButton>
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnLimpiarEdit" runat="server" class="btn btn-light" Text="Limpiar" OnClick="btnlimpiar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>
</body>
</html>
