<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="ver.aspx.cs" Inherits="RodaARodaIvanaids.admin.premios.ver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="corpoChild" runat="server">
        <div class="row">
    	<div class="col-xs-12">
    		<h1>Visualização de Prêmios</h1>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Descrição</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var obj in RodaARodaIvanaids.DAL.DALPremio.SelectAll())
                       {
                          %> 
                    <tr>
                        <td><%= obj.nome %></td>
                        <td><%= obj.descricao %></td>
                        <td><a href="editar.aspx/?uid=<%= obj.id %>">Editar</a></td>
                    </tr>
                     <% } %>
                </tbody>
            </table>
    	</div>
    </div>
</asp:Content>
