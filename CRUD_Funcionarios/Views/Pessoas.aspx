﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Pessoas.aspx.vb" Inherits="Views_Pessoas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script>
        var params = new URLSearchParams(window.location.search);
        var success = params.get('success');
        if (success === 'true') {
            showSuccessAlert();
            window.history.replaceState(null, null, window.location.pathname); // remove o parâmetro de sucesso da URL
        }
        function showSuccessAlert() {
            Swal.fire(
                'Sucesso!',
                'Pessoa cadastrada com sucesso!',
                'success'
            )
        }
    </script>
    <asp:GridView ID="grd" AutoGenerateColumns="false" runat="server" CssClass="table table-striped" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="DATA" HeaderText="Data de Nascimento" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
            <asp:TemplateField HeaderText="Opções">
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning float-right" OnClick="btn_Editar" CommandArgument='<%# Eval("id") %>' />
                    <asp:Button ID="btnDeletar" runat="server" Text="Deletar" CssClass="btn btn-danger float-right" OnClick="btnDeletar_Click" CommandArgument='<%# Eval("id") %>' />

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="form_cadastro col-md-4 col-sm-6">
        <div>
            <asp:Label runat="server" Text="Nome" AssociatedControlID="txtNome" CssClass="d-flex mb-1 mt-5"></asp:Label>
            <asp:TextBox ID="txtNome" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Data Nascimento" AssociatedControlID="txtData" CssClass="d-flex mb-1 mt-3"></asp:Label>
            <asp:TextBox ID="txtData" CssClass="d-flex mb-2 mt-1 form-control" runat="server" MaxLength="150"></asp:TextBox>
            <asp:Calendar ID="Calendar1" runat="server" SelectionMode="Day" CssClass="d-flex mb-2 mt-1 form-control"></asp:Calendar>
        </div>
        <div>
            <asp:Label runat="server" Text="Email" AssociatedControlID="txtEmail" CssClass="d-flex mb-1 mt-3"></asp:Label>
            <asp:TextBox ID="txtEmail" CssClass="d-flex mb-2 mt-1 form-control" runat="server" MaxLength="150"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Telefone" AssociatedControlID="txtTelefone" CssClass="d-flex mb-1 mt-3"></asp:Label>
            <asp:TextBox ID="txtTelefone" CssClass="d-flex mb-2 mt-1 form-control" runat="server" MaxLength="150"></asp:TextBox>
        </div>

        <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" CssClass="btn btn-primary" />
        <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" CssClass="btn btn-success" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
    </div>

</asp:Content>

