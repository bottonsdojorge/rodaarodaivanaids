<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="criar.aspx.cs" Inherits="RodaARodaIvanaids.admin.premios.criar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="corpoChild" runat="server">
        <div class="row">
    	<div class="col-xs-12">
    		<h1>Cadastro de novos prêmios</h1>
    	    <div class="form-group">
                <label for="txtNome">Nome:</label>
                <input type="text" class="form-control" id="txtNome" runat="server">
                <asp:RequiredFieldValidator ControlToValidate="txtNome" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Por favor, preencha"></asp:RequiredFieldValidator>
    	    </div>
    	    <div class="form-group">
                <label for="txtDescricao">Descrição:</label>
                <input type="text" class="form-control" id="txtDescricao" runat="server">
                <asp:RequiredFieldValidator ControlToValidate="txtDescricao" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Por favor, preencha"></asp:RequiredFieldValidator>
    	    </div>
            <asp:Button Text="Cadastrar" CssClass="btn btn-primary" ID="btnCadastras" runat="server" OnClick="btnCadastras_Click" />
        </div>
    </div>
</asp:Content>
