<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PropertyCrud.aspx.cs" Inherits="Booking.Pages.PropertyPages.PropertyCrud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ValidationContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<%--LISTVIEW--%>
<asp:ListView ID="PropertiesListView" runat="server"
    ItemType="Booking.Model.Property"
    SelectMethod="PropertyListView_GetData"
    DataKeyNames="PropertyID" 
    Visible="true">
    <LayoutTemplate>
        <table class="maintable">
            <tr><th class="th_header">Stugor</th></tr>
            <tr>
                <th>Stugnamn</th>
                <th></th>
            </tr>
        <%--platshållare för nya rader--%>
        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <%--Mall för nya rader--%>
        <tr>
            <td>
                <asp:Label ID="PropertyNameLabel" runat="server" Text='<%#: Item.PropertyName %>' ></asp:Label>
            </td>
            <td>
            </td>
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
    <%-- Detta visas då uppgifter saknas i databasen. --%>
    <table class="grid">
        <tr>
            <td>
                Uppgifter saknas.
            </td>
        </tr>
    </table>
</EmptyDataTemplate>
</asp:ListView>
</asp:Content>
