Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        AddHandler btnSave.Click, AddressOf CadastrarFunc
    End Sub


    Protected Sub CadastrarFunc(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("BDCrudVb").ConnectionString
        Dim queryCreated As String = "INSERT INTO Funcionarios(Nome, Email, Endereco, Telefone) VALUES (@nome, @email, @endereco, @fone)"
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryCreated, connection)
            command.Parameters.AddWithValue("@nome", nomeForm.Text)
            command.Parameters.AddWithValue("@email", emailForm.Text)
            command.Parameters.AddWithValue("@endereco", enderecoForm.Text)
            command.Parameters.AddWithValue("@fone", foneForm.Text)
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()
        End Using

    End Sub

End Class
