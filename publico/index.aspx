<%@ Page Title="" Language="C#" MasterPageFile="~/publico/publica.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RodaARodaIvanaids.publico.index" %>
<asp:Content ID="Content" ContentPlaceHolderId="corpoChild" runat="server">
    <div class="row">
    	<div class="col-xs-12">
    		<h1>Lista de Sorteios - Página pública</h1>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Descrição</th>
                        <th>Data</th>
                        <th>Número de inscritos</th>
                        <th>Sorteado</th>
                        <th>Prêmios</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var obj in RodaARodaIvanaids.DAL.DALSorteio.SelectAll())
                       {
                          %> 
                    <tr>
                        <td><%= obj.nome %></td>
                        <td><%= obj.descricao %></td>
                        <td><%= obj.data %></td>
                        <td><%= obj.inscritos.Count %></td>
                        <td><%= (obj.sorteado) ? "Sim" : "Não" %></td>
                        <td><% foreach (var item in obj.premios) { Response.Write(item.premio.nome + ", "); } %></td>
                        <td><% if (!obj.sorteado && Session["idautenticado"] != null) {  %><a href="?uid=<%=obj.id %>">Inscrever</a><% } %></td>
                    </tr>
                     <% } %>
                </tbody>
            </table>
    	</div>
    </div>
</asp:Content>