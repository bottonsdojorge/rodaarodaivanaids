<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="ver.aspx.cs" Inherits="RodaARodaIvanaids.admin.usuarios.ver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="corpoChild" runat="server">
    <div class="row">
    	<div class="col-xs-12">
    		<h1>Visualização de Usuários</h1>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Matricula</th>
                        <th>CPF</th>
                        <th>Administrador?</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var obj in RodaARodaIvanaids.DAL.DALUsuario.SelectAll())
                       {
                          %> 
                    <tr>
                        <td><%= obj.nome %></td>
                        <td><%= obj.matricula %></td>
                        <td><%= obj.cpf %></td>
                        <td><%= (obj.admin) ? "Sim" : "Não" %></td>
                        <td><a href="editar.aspx/?uid=<%= obj.id %>">Editar</a></td>
                    </tr>
                     <% } %>
                </tbody>
            </table>
    	</div>
    </div>
</asp:Content>
