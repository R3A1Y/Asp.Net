Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class Ingresar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            UserIdH.Value = Request.QueryString("Name")
            Me.Llenar()
            Me.Consult()
        End If

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

    End Sub

    Protected Sub Consult()

        Dim buscar As String = UserIdH.Value
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim query As String = $"Select top 1* From Persona Where Cedula like '%{buscar}%'"
        Using con As SqlConnection = New SqlConnection(constr)
            Using sda As SqlDataAdapter = New SqlDataAdapter(query, con)
                Using dt As DataTable = New DataTable()
                    sda.Fill(dt)
                    txtNombre.Text = dt.Rows(0)("Nombre").ToString()
                    txtDireccion.Text = dt.Rows(0)("Direccion").ToString()
                    txtCedula.Text = dt.Rows(0)("Cedula").ToString()
                    txtTelefono.Text = dt.Rows(0)("Telefono").ToString()
                    ddlEstatus.DataTextField = dt.Rows(0)("EstatusId").ToString()
                End Using
            End Using
        End Using

    End Sub

    Protected Sub btnlimpiar_Click(sender As Object, e As EventArgs)

        txtNombre.Text = ""
        txtDireccion.Text = ""
        txtCedula.Text = ""
        txtTelefono.Text = ""

    End Sub

End Class