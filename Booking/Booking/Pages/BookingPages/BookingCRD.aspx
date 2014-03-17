<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BookingCRD.aspx.cs" Inherits="Booking.Pages.BookingPages.BookingCRD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ValidationContentPlaceHolder" runat="server">
<%--Header, Validering och meddelanden --%>
    <h2>administrera bokningar</h2>
    <div class="list">
            <%--Validering --%>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade! Korrigera och försök igen." 
                    CssClass="ValidationSummaryErrors" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Fel inträffade! Korrigera och försök igen."
                    ValidationGroup="InsertGroup" ShowModelStateErrors="false" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="Fel inträffade! Korrigera och försök igen." 
                    ValidationGroup="EditGroup" ShowModelStateErrors="false"/>
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
    DeleteMethod="BookingListView_DeleteItem"
    InsertMethod="BookingListView_InsertItem"
    DataKeyNames="BookingID, CustomerID, PropertyID"
    OnItemDataBound="BookingListView_ItemDataBound" 
    InsertItemPosition="FirstItem"
    Visible="true">
<%--Kolumnrubriker--%>
<LayoutTemplate>
    <table class="grid">
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
<%--Visar lista--%>
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
        <td>
            <asp:Label ID="PriceLabel" runat="server" Text='<%#: Item.Price %>' ></asp:Label>
        </td>
        <td>
            <asp:Label ID="CustomerIDLabel" runat="server" Text='<%#: Item.CustomerID %>' ></asp:Label>
        </td>
        <td class="command">
                <asp:LinkButton runat="server" CommandName="Delete" Text="Radera" CausesValidation="false" 
                OnClientClick='<%# String.Format("return confirm(\"Vill du verkligen radera bokningen?\")") %>' />
        </td>
    </tr>
</ItemTemplate>
<%--Detta visas då uppgifter saknas i databasen.--%>
<EmptyDataTemplate>
<table class="grid">
    <tr>
        <td>
            Uppgifter saknas.
        </td>
    </tr>
</table>
</EmptyDataTemplate>
<%--Lägg till Bokning--%>
<InsertItemTemplate>
    <tr>
        <td>
            <asp:TextBox ID="Year" runat="server" Text='<%# BindItem.Year %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="År måste anges" ControlToValidate="Year" ValidationGroup="InsertGroup"
                Display="None"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:TextBox ID="Week" runat="server" Text='<%# BindItem.Week %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Vecka måste anges" ControlToValidate="Week" ValidationGroup="InsertGroup"
                Display="None"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:DropDownList ID="PropertyNameDropDownList" runat="server"
                ItemType="Booking.Model.Property"
                SelectMethod="PropertyNameDropDownList_GetData"
                DataTextField="PropertyName"
                DataValueField="PropertyID"
                SelectedValue='<%# BindItem.PropertyID %>'
                CssClass="DropDown">
            </asp:DropDownList>
        </td>
        <td>
            <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ErrorMessage="Pris måste anges" ControlToValidate="Price" ValidationGroup="InsertGroup"
                Display="None"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:DropDownList ID="CustomerNameDropDownList" runat="server"
                ItemType="Booking.Model.Customer"
                SelectMethod="CustomerNameDropDownList_GetData"
                DataTextField="Name"
                DataValueField="CustomerID"
                SelectedValue='<%# BindItem.CustomerID %>'
                CssClass="DropDown">
            </asp:DropDownList>
        </td>
        <td>
            <%-- Kommandoknappar --%>
            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
            <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
        </td>
    </tr>
</InsertItemTemplate>
</asp:ListView>
</asp:Content>
