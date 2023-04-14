
Imports System.Data
Imports System.Data.SqlClient

Partial Class Views_Pessoas
    Inherits System.Web.UI.Page
    'Instanciando a conexão do banco, recebendo os dados da ConnectionStrings no arquivo Web.config
    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("BDCrudVb").ConnectionString
    'Instanciando um novo objeto Pessoas, da classe Pessoas.vb com seus metodos
    Dim pessoas As New Pessoas()
    Dim updateId As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CarregaGrid()
        End If
    End Sub

    'Metodo para carregar a GridView do arquivo Pessoas.aspx, com os dados inseridos na tebela do Banco
    Public Sub CarregaGrid()
        Dim query As String = "SELECT * FROM CadastroPessoa"
        Dim dt As New DataTable
        btnAtualizar.Visible = False
        btnCancelar.Visible = False
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            Dim adapter As New SqlDataAdapter(command)

            connection.Open()
            adapter.Fill(dt)

            grd.DataSource = dt
            grd.DataBind()
        End Using
        'Passar campos vazios para toda vez que add/editar/cancelar, limpe os campos text
        txtNome.Text = ""
        txtData.Text = ""
        txtEmail.Text = ""
        txtTelefone.Text = ""
    End Sub

    'Metodo que cria uma nova pessoa ao preencher os campos Text e clicar no botão "Adicionar"
    Public Sub CreatePeople()
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

    'Metodo que trata o Evento do botão "Adicionar" e aciona o metodo "CreatePeople()"
    'para gerar uma nova pessoa, e chama o metodo CarregaGrid() para listar o novos dados na GridView
    Private Sub BtnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        CreatePeople()
        CarregaGrid()
    End Sub

    'Carrega os dados do banco para os campos text, quando é clicado no botão "Editar"
    Public Sub LoadDataEdit(ByVal id As Integer)
        Dim queryNome As String = "SELECT *FROM CadastroPessoa where ID = @id"
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryNome, connection)
            command.Parameters.AddWithValue("@id", id)
            connection.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()
            Dim lTextBox As New List(Of TextBox) From {txtNome, txtData, txtEmail, txtTelefone}
            If reader.Read = True Then
                For Each textBox As TextBox In lTextBox
                    textBox.Text = reader(textBox.ID.Replace("txt", "").ToString)
                Next
            End If
        End Using
    End Sub

    Protected Sub Btn_Editar(sender As Object, e As EventArgs)
        btnAdicionar.Visible = False
        btnAtualizar.Visible = True
        btnCancelar.Visible = True
        pessoas.Id = Integer.Parse(CType(sender, Button).CommandArgument)
        LoadDataEdit(pessoas.Id)
        Session("IdEditar") = pessoas.Id
    End Sub

    Protected Sub UpdatePeople(id As Integer)
        id = Convert.ToInt32(Session("IdEditar"))
        pessoas.Nome = txtNome.Text.Trim()
        pessoas.Data = DateTime.Parse(txtData.Text)
        pessoas.Email = txtEmail.Text.Trim()
        pessoas.Telefone = txtTelefone.Text.Trim()
        Dim queryUpdate As String = "UPDATE CadastroPessoa SET NOME = @Nome, DATA = @Data, EMAIL = @Email, TELEFONE = @Telefone WHERE ID = @ID"
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim commandUpdate As New SqlCommand(queryUpdate, connection)
            commandUpdate.Parameters.AddWithValue("@ID", id)
            commandUpdate.Parameters.AddWithValue("@Nome", pessoas.Nome)
            commandUpdate.Parameters.AddWithValue("@Data", pessoas.Data)
            commandUpdate.Parameters.AddWithValue("@Email", pessoas.Email)
            commandUpdate.Parameters.AddWithValue("@Telefone", pessoas.Telefone)
            commandUpdate.ExecuteNonQuery()
        End Using
    End Sub

    Protected Sub BtnDeletar_Click(sender As Object, e As EventArgs)
        'A função CType converte o objeto sender em um objeto Button.
        'A função Integer.Parse converte o valor do parâmetro CommandArgument, que é uma string, em um inteiro.
        Dim pessoas As New Pessoas()
        pessoas.Id = Integer.Parse(CType(sender, Button).CommandArgument)
        DeletePeople(pessoas.Id)
        CarregaGrid()
    End Sub

    Public Sub DeletePeople(ByVal id As Integer)
        Dim query As String = "DELETE FROM CadastroPessoa WHERE ID = @id"
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@id", id)
            connection.Open()
            command.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnAdicionar.Visible = True
        CarregaGrid()
    End Sub

    Private Sub btnAtualizar_Click(sender As Object, e As EventArgs) Handles btnAtualizar.Click
        UpdatePeople(pessoas.Id)
        Session.Remove("IdEditar")
        CarregaGrid()
    End Sub
End Class
