<%@ Page Title="" Language="C#" MasterPageFile="~/publico/publica.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="RodaARodaIvanaids.publico.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="corpoChild" runat="server">
    <div class="row">
    	<div class="col-xs-12">
            <h1>Fazer login</h1>
            <div class="form-group">
                <label for="txtMatricula">Matricula</label>
                <input type="text" class="form-control" required id="txtMatricula" runat="server">
            </div>
            <div class="form-group">
                <label for="txtCpf">CPF</label>
                <input type="text" class="form-control" required id="txtCpf" runat="server">
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Logar" ID="btnLogar" OnClick="btnLogar_Click"/>
    	</div>
    </div>
</asp:Content>
