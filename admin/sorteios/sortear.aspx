<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="sortear.aspx.cs" Inherits="RodaARodaIvanaids.admin.sorteios.sortear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="corpoChild" runat="server">
<div class="row">
	<div class="col-xs-12">
		<h1>Sortear sorteio</h1>
        <table class="table">
            <thead>
                <th>Dados do sorteio</th>
            </thead>
            <thead>
                <th>Nome</th>
                <th>Descrição</th>
                <th>Nº prêmios</th>
                <th>Nº inscritos</th>
            </thead>
            <tbody>
                <tr>
                    <td><%= s.nome %></td>
                <td><%= s.descricao %></td>
                <td><%= s.premios.Count %></td>
                <td><%= s.inscritos.Count %></td>
                    </tr>
            </tbody>
        </table>
        <table class="table">
            <thead>
                <th>Prêmio</th>
                <th>Sorteado</th>
            </thead>
            <tbody>
                <% foreach (var item in s.premios) { %>
                <tr>
                    <td><%= item.premio.nome %></td>
                    <td><%= item.usuarioSorteado.nome %></td>
                </tr>
                <% } %>
            </tbody>
        </table>
	</div>
</div>
</asp:Content>
