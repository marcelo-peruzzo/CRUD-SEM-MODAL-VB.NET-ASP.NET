<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Pessoas.aspx.vb" Inherits="Views_Pessoas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  <asp:GridView ID="grd" AutoGenerateColumns="false" runat="server" CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="Nome" HeaderText="Nome" />
        <asp:BoundField DataField="DATA" HeaderText="Data de Nascimento" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
        <asp:TemplateField HeaderText="Opções">
            <ItemTemplate>               
    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning float-right" />
    <asp:Button ID="btnDeletar" runat="server" Text="Deletar" CssClass="btn btn-danger float-right" />                
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

    <asp:Label runat="server" Text="Nome" AssociatedControlID="txtNome" CssClass="d-flex mb-1 mt-5"></asp:Label>
    <asp:TextBox ID="txtNome" runat="server" MaxLength="150" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="Data Nascimento" AssociatedControlID="txtData" CssClass="d-flex mb-1 mt-3"></asp:Label>
    <asp:TextBox ID="txtData" CssClass="d-flex mb-2 mt-1" runat="server" MaxLength="150" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="Email" AssociatedControlID="txtEmail" CssClass="d-flex mb-1 mt-3"></asp:Label>
    <asp:TextBox ID="txtEmail" CssClass="d-flex mb-2 mt-1" runat="server" MaxLength="150" Width="100px"></asp:TextBox>
    <asp:Label runat="server" Text="Telefone" AssociatedControlID="txtTelefone" CssClass="d-flex mb-1 mt-3"></asp:Label>
    <asp:TextBox ID="txtTelefone" CssClass="d-flex mb-2 mt-1" runat="server" MaxLength="150" Width="100px"></asp:TextBox>


    <%--<asp:CheckBox CssClass="mb-2 d-flex marginLabel" ID="chkAtivar" runat="server" Text="Ativar" />--%>
    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" CssClass="btn btn-primary"/>
</asp:Content>

