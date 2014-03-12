<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BookingListing.aspx.cs" Inherits="Booking.Pages.BookingPages.BookingListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ValidationContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<%--LISTVIEW--%>
<asp:ListView ID="Unbooked1ListView" runat="server"
    ItemType="Booking.Model.Booking"
    SelectMethod="Unbooked1ListView_GetData"
    DataKeyNames="BookingId">
    <LayoutTemplate>
        <table class="grid">
            <h2>Lediga veckor, Stuga 1 - Lillstugan</h2>
            <tr>
                <th>BookingID</th>
                <th>Vecka</th>
                <th>Pris</th>
                <th></th>
            </tr>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <%--Mall för nya rader--%>
        <tr>
            <td>
                <asp:Label ID="BookingIDLabel" runat="server" Text='<%#: Item.BookingID %>' ></asp:Label>
            </td>
            <td>
                <asp:Label ID="WeekLabel" runat="server" Text='<%#: Item.Week %>' ></asp:Label>
            </td>
            <td>
                <asp:Label ID="PriceLabel" runat="server" Text='<%#: Item.Price %>' ></asp:Label>
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
