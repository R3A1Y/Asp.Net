Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Form

    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindGrid()
            Me.Llenar()
        End If
    End Sub

    Private Sub BindGrid()
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim query As String = "SELECT p.*, e.Descripcion FROM Persona p Inner join Estatus e on p.EstatusId = e.EstatusId"
        Using con As SqlConnection = New SqlConnection(constr)
            Using sda As SqlDataAdapter = New SqlDataAdapter(query, con)
                Using dt As DataTable = New DataTable()
                    sda.Fill(dt)
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                End Using
            End Using
        End Using
    End Sub

    Private Sub Llenar()
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim query As String = "SELECT * FROM Estatus"
        Using con As SqlConnection = New SqlConnection(constr)
            Using sda As SqlDataAdapter = New SqlDataAdapter(query, con)
                Using dt As DataTable = New DataTable()
                    sda.Fill(dt)
                    ddlEstatus.DataTextField = "Descripcion"
                    ddlEstatus.DataValueField = "EstatusId"
                    ddlEstatus.DataSource = dt
                    ddlEstatus.DataBind()

                    ddlEstatusEdit.DataTextField = "Descripcion"
                    ddlEstatusEdit.DataValueField = "EstatusId"
                    ddlEstatusEdit.DataSource = dt
                    ddlEstatusEdit.DataBind()
                End Using
            End Using
        End Using
    End Sub

    Protected Sub Search(ByVal sender As Object, ByVal e As EventArgs)

        Dim search As String = txtBuscar.Text
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim query As String = $"SELECT p.*, e.Descripcion FROM Persona p Inner join Estatus e on p.EstatusId = e.EstatusId where p.cedula like '%{search}%'"
        Using con As SqlConnection = New SqlConnection(constr)
            Using sda As SqlDataAdapter = New SqlDataAdapter(query, con)
                Using dt As DataTable = New DataTable()
                    sda.Fill(dt)
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                End Using
            End Using
        End Using

    End Sub

    Protected Sub Insert(ByVal sender As Object, ByVal e As EventArgs)

        If txtNombre.Text = "" Or txtDireccion.Text = "" Or txtCedula.Text = "" Or txtTelefono.Text = "" Then
            MsgBox("Ingrese datos")
            Exit Sub
        End If

        Dim nombre As String = txtNombre.Text
        Dim direccion As String = txtDireccion.Text
        Dim cedula As String = txtCedula.Text
        Dim telefono As String = txtTelefono.Text
        Dim estatusId As String = ddlEstatus.Text
        Dim query As String = "INSERT INTO Persona VALUES(@Nombre, @Direccion, @Cedula, @Telefono, @EstatusId)"
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        txtNombre.Text = ""
        txtDireccion.Text = ""
        txtCedula.Text = ""
        txtTelefono.Text = ""
        Using con As SqlConnection = New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query)
                cmd.Parameters.AddWithValue("@Nombre", nombre)
                cmd.Parameters.AddWithValue("@Direccion", direccion)
                cmd.Parameters.AddWithValue("@Cedula", cedula)
                cmd.Parameters.AddWithValue("@Telefono", telefono)
                cmd.Parameters.AddWithValue("@EstatusId", estatusId)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        mView.ActiveViewIndex = 0
        Me.BindGrid()
    End Sub

    Protected Sub Update(ByVal sender As Object, ByVal e As EventArgs)

        If txtNombreEdit.Text = "" Or txtDireccionEdit.Text = "" Or txtCedulaEdit.Text = "" Or txtTelefonoEdit.Text = "" Then
            MsgBox("Ingrese los datos primero")
            Exit Sub
        End If

        Dim nombre As String = txtNombreEdit.Text
        Dim direccion As String = txtDireccionEdit.Text
        Dim cedula As String = txtCedulaEdit.Text
        Dim telefono As String = txtTelefonoEdit.Text
        Dim estatusId As String = ddlEstatusEdit.Text
        Dim query As String = "UPDATE Persona SET Nombre=@Nombre, Direccion=@Direccion, Cedula=@Cedula, Telefono=@Telefono, EstatusId=@EstatusId WHERE Cedula=@Cedula"
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString

        txtNombreEdit.Text = ""
        txtDireccionEdit.Text = ""
        txtCedulaEdit.Text = ""
        txtTelefonoEdit.Text = ""

        Using con As SqlConnection = New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query)
                cmd.Parameters.AddWithValue("@Id", ID)
                cmd.Parameters.AddWithValue("@Nombre", nombre)
                cmd.Parameters.AddWithValue("@Direccion", direccion)
                cmd.Parameters.AddWithValue("@Cedula", cedula)
                cmd.Parameters.AddWithValue("@Telefono", telefono)
                cmd.Parameters.AddWithValue("@EstatusId", estatusId)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        mView.ActiveViewIndex = 0
        Me.BindGrid()
    End Sub

    Protected Sub Delete(ByVal sender As Object, ByVal e As EventArgs)

        Dim cedula As String = CType(sender, Button).CommandArgument
        Dim query As String = "DELETE FROM Persona WHERE Cedula = @Cedula"
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Using con As SqlConnection = New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand(query)
                cmd.Parameters.AddWithValue("@Cedula", cedula)
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using

        End Using

        Me.BindGrid()
    End Sub

    Protected Sub Consult(ByVal sender As Object, ByVal e As EventArgs)

        mView.ActiveViewIndex = 2
        Me.Llenar()
        Dim buscar As String = CType(sender, Button).CommandArgument
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim query As String = $"Select top 1* From Persona Where Cedula like '%{buscar}%'"
        Using con As SqlConnection = New SqlConnection(constr)
            Using sda As SqlDataAdapter = New SqlDataAdapter(query, con)
                Using dt As DataTable = New DataTable()
                    sda.Fill(dt)
                    txtNombreEdit.Text = dt.Rows(0)("Nombre").ToString()
                    txtDireccionEdit.Text = dt.Rows(0)("Direccion").ToString()
                    txtCedulaEdit.Text = dt.Rows(0)("Cedula").ToString()
                    txtTelefonoEdit.Text = dt.Rows(0)("Telefono").ToString()
                    ddlEstatusEdit.SelectedValue = dt.Rows(0)("EstatusId")
                End Using
            End Using
        End Using

    End Sub

    Protected Sub btnlimpiar_Click(sender As Object, e As EventArgs)

        txtNombre.Text = ""
        txtDireccion.Text = ""
        txtCedula.Text = ""
        txtTelefono.Text = ""
        txtNombreEdit.Text = ""
        txtDireccionEdit.Text = ""
        txtCedulaEdit.Text = ""
        txtTelefonoEdit.Text = ""

    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs)
        mView.ActiveViewIndex = 1
    End Sub

    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs)
        mView.ActiveViewIndex = 0
    End Sub

End Class