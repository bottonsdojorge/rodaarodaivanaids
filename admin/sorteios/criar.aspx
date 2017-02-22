﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="criar.aspx.cs" Inherits="RodaARodaIvanaids.admin.sorteios.criar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="corpoChild" runat="server">
        <div class="row">
    	<div class="col-xs-12">
    		<h1>Cadastro de novos sorteios</h1>
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
    	    <div class="form-group">
                <label for="txtData">Data:</label>
                <input type="date" class="form-control" id="txtData" runat="server">
                <asp:RequiredFieldValidator ControlToValidate="txtData" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Por favor, preencha"></asp:RequiredFieldValidator>
    	    </div>
            <div class="form-check">
                <asp:CheckBoxList ID="selectPremios" runat="server" DataSourceID="ObjectDataSource1" CssClass="form-check-input" DataTextField="nome" DataValueField="id"></asp:CheckBoxList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectAll" TypeName="RodaARodaIvanaids.DAL.DALPremio"></asp:ObjectDataSource>
            </div>
            <asp:Button Text="Cadastrar" CssClass="btn btn-primary" ID="btnCadastras" runat="server" OnClick="btnCadastras_Click" />
        </div>
    </div>
</asp:Content>
