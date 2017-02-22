<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="editar.aspx.cs" Inherits="RodaARodaIvanaids.admin.premios.editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="corpoChild" runat="server">
        <div class="row">
    	<div class="col-xs-12">
    		<h1>Edição de usuários</h1>
            <div id="formEdicao" runat="server">   
    	    <div class="form-group">
                <label for="txtNome">Nome:</label>
                <input type="text" class="form-control" id="txtNome" runat="server">
                <asp:RequiredFieldValidator ControlToValidate="txtNome" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Por favor, preencha"></asp:RequiredFieldValidator>
    	    </div>
    	    <div class="form-group">
                <label for="txtDescricao">Matricula:</label>
                <input type="text" class="form-control" id="txtDescricao" runat="server"> 
                <asp:RequiredFieldValidator ControlToValidate="txtDescricao" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Por favor, preencha"></asp:RequiredFieldValidator>
    	    </div>
            <asp:Button Text="Atualizar" CssClass="btn btn-primary" ID="btnAtualizar" runat="server" OnClick="btnAtualizar_Click" />
            </div>
    	</div>
    </div>
</asp:Content>
