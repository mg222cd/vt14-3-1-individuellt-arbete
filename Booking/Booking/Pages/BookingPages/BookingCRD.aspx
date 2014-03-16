<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BookingCRD.aspx.cs" Inherits="Booking.Pages.BookingPages.BookingCRD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ValidationContentPlaceHolder" runat="server">
<%--Header, Validering och meddelanden --%>
    <h2>administrera bokningar</h2>
    <div class="list">
            <%--Validering --%>
            
            <%--Meddelanden --%>
            <div class="message">
            <asp:Label ID="MessageLabel" runat="server" Visible="false" CssClass="UploadLabel"></asp:Label>
            </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<%--Bokningar--%>
<asp:ListView ID="BookingListView" runat="server"
    ItemType="Booking.Model.Booking"
    SelectMethod="BookingListView_GetData"
    DataKeyNames="BookingID" 
    Visible="true">
    <LayoutTemplate>
        <table>
            <tr>
                <th>År</th>
                <th>Vecka</th>
                <th>Stuga</th>
                <th>Pris</th>
                <th>Bokad</th>
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
                <asp:Label ID="YearLabel" runat="server" Text='<%#: Item.Year %>' ></asp:Label>
            </td>
            <td>
                <asp:Label ID="WeekLabel" runat="server" Text='<%#: Item.Week %>' ></asp:Label>
            </td>
            <td>

                <asp:Label ID="PropertyIDLabel" runat="server" Text='<%#: Item.PropertyID %>' ></asp:Label>

            </td>
            <td class="mainlist">
                <asp:Label ID="PriceLabel" runat="server" Text='<%#: Item.Price %>' ></asp:Label>
            </td>
            <td>

                <asp:Label ID="BookingIDLabel" runat="server" Text='<%#: Item.BookingID %>' ></asp:Label>

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
