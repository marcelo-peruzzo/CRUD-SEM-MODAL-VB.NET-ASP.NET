
Imports System.Data
Imports System.Data.SqlClient

Partial Class Views_Pessoas
    Inherits System.Web.UI.Page

    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("BDCrudVb").ConnectionString
    Dim pessoas As New Pessoas()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CarregaGrid()
        End If
    End Sub

    Public Sub CarregaGrid()
        Dim query As String = "SELECT * FROM CadastroPessoa"
        Dim dt As New DataTable()

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            Dim adapter As New SqlDataAdapter(command)

            connection.Open()
            adapter.Fill(dt) 'o método Fill preenche o DataTable dt com os resultados da consulta
            'executada pelo SqlDataAdapter.

            grd.DataSource = dt
            grd.DataBind()
        End Using
    End Sub


    Public Sub CriarPessoa()

        pessoas.Nome = txtNome.Text.Trim()
        pessoas.Data = DateTime.Parse(txtData.Text)
        pessoas.Email = txtEmail.Text.Trim()
        pessoas.Telefone = txtTelefone.Text.Trim()

        Dim query As String = "INSERT INTO CadastroPessoa(NOME, DATA, EMAIL, TELEFONE) VALUES (@Nome, @Data, @Email, @Telefone)"
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Nome", pessoas.Nome)
            command.Parameters.AddWithValue("@Data", pessoas.Data)
            command.Parameters.AddWithValue("@Email", pessoas.Email)
            command.Parameters.AddWithValue("@Telefone", pessoas.Telefone)
            connection.Open()
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        CriarPessoa()
    End Sub
End Class
