<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BookingListing.aspx.cs" Inherits="Booking.Pages.BookingPages.BookingListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ValidationContentPlaceHolder" runat="server">

<div id="information">
    <p>
    Nedan visas lediga veckor för respektive stuga. Enbart hela veckor kan bokas. Bytesdag är alltid lördag.
    Slutstädning ingår ej i priset.
    </p>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<%--LISTVIEW--%>
<asp:ListView ID="Unbooked1ListView" runat="server"
    ItemType="Booking.Model.Booking"
    SelectMethod="Unbooked1ListView_GetData"
    DataKeyNames="BookingID">
    <LayoutTemplate>
        <table class="maintable">
            <h2>Stuga 1 - Lillstugan</h2>
            <tr>
                <th>Vecka</th>
                <th>Pris</th>
                <th></th>
            </tr>
        <%--platshållare för nya rader--%>
        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <%--Mall för nya rader--%>
        <tr>
            <td class="mainlist">
                <asp:Label ID="WeekLabel" runat="server" Text='<%#: Item.Week %>' ></asp:Label>
            </td>
            <td class="mainlist">
                <asp:Label ID="PriceLabel" runat="server" Text='<%#: Item.Price %>' ></asp:Label>
            </td>
            <td class="mainlist">
                <asp:LinkButton runat="server" CommandName="Insert" Text="Boka" />
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
<asp:ListView ID="Unbooked2ListView" runat="server"
    ItemType="Booking.Model.Booking"
    SelectMethod="Unbooked2ListView_GetData"
    DataKeyNames="BookingID">
    <LayoutTemplate>
        <table class="maintable">
            <h2>Stuga 2 - Huset</h2>
            <tr>
                <th>Vecka</th>
                <th>Pris</th>
                <th></th>
            </tr>
        <%--platshållare för nya rader--%>
        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <%--Mall för nya rader--%>
        <tr>
            <td class="mainlist">
                <asp:Label ID="WeekLabel" runat="server" Text='<%#: Item.Week %>' ></asp:Label>
            </td>
            <td class="mainlist">
                <asp:Label ID="PriceLabel" runat="server" Text='<%#: Item.Price %>' ></asp:Label>
            </td>
            <td class="mainlist">
                <asp:LinkButton runat="server" CommandName="Insert" Text="Boka" />
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
