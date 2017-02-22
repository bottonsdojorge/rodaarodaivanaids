<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="editar.aspx.cs" Inherits="RodaARodaIvanaids.admin.usuarios.editar" %>
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
                <label for="txtMatricula">Matricula:</label>
                <input type="text" class="form-control" id="txtMatricula" runat="server"> 
                <asp:RequiredFieldValidator ControlToValidate="txtMatricula" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Por favor, preencha"></asp:RequiredFieldValidator>
    	    </div>
    	    <div class="form-group">
                <label for="txtCpf">CPF:</label>
                <input type="text" class="form-control" id="txtCpf" runat="server">
                <asp:RequiredFieldValidator ControlToValidate="txtCpf" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Por favor, preencha"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ControlToValidate="txtCpf" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Por favor, CPF válido." ValidationExpression="([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})"></asp:RegularExpressionValidator>
            </div>
            <div class="form-check">
                <label class="form-check-label">
                    <input type="checkbox" id="checkAdmin" runat="server" class="form-check-input">
                    Usuário é administrador
                </label>
            </div>
            <asp:Button Text="Atualizar" CssClass="btn btn-primary" ID="btnAtualizar" runat="server" OnClick="btnAtualizar_Click" />
            </div>
    	</div>
    </div>
</asp:Content>
