<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BookingListing.aspx.cs" Inherits="Booking.Pages.BookingPages.BookingListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ValidationContentPlaceHolder" runat="server">

<div id="information">
    <p>
    Nedan visas bokningsbara veckor för respektive stuga. Enbart hela veckor kan bokas. Bytesdag är alltid lördag.
    Slutstädning ingår ej i priset.
    </p>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<%--FORMVIEW--%>
<asp:FormView ID="CustomerFormView" runat="server"
    ItemType="Booking.Model.Customer"
    DefaultMode="Insert"
    InsertMethod="CustomerFormView_InsertItem"
    Visible="false">
    <InsertItemTemplate>
        <%--Informationstext--%>
        <asp:Literal ID="BookingLiteral" runat="server">
            <div id="bookingLiteralDiv">
            <p class="bookingLiteralText">Bokning av {0} vecka {1} {2}. Pris {3}.</p> 
            <p class="bookingLiteralTextLast">Var god fyll i dina kontaktuppgifter nedan.</p>
            </div>
        </asp:Literal>
        <fieldset>
        <div class="editor-label">
            <label for="Name">Namn</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
        </div>
        <div class="editor-label">
            <label for="Address">Adress</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
        </div>
        <div class="editor-label">
            <label for="Postal">Postnr</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Postal" runat="server" Text='<%# BindItem.Postal %>' />
        </div>
        <div class="editor-label">
            <label for="City">Ort</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' />
        </div>
        <div class="editor-label">
            <label for="Phone">Telefon</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Phone" runat="server" Text='<%# BindItem.Phone %>' />
        </div>
        <div class="editor-label">
            <label for="Email">Epost</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Email" runat="server" Text='<%# BindItem.Email %>' />
        </div>
        <div id="buttons">
        <asp:Button ID="CommitButton" runat="server" Text="Bekräfta" CommandName="Insert" />
        <asp:Button ID="BreakButton" runat="server" Text="Avbryt"
            OnClientClick='<%# String.Format("return confirm(\"Vill du verkligen avbryta bokningen?\")") %>' />
        </div>
        </fieldset>
    </InsertItemTemplate>
</asp:FormView>

<%--LISTVIEW--%>
<asp:ListView ID="Unbooked1ListView" runat="server"
    ItemType="Booking.Model.Booking"
    SelectMethod="Unbooked1ListView_GetData"
    DataKeyNames="BookingID" 
    Visible="true">
    <LayoutTemplate>
        <table class="maintable">
            <tr><th class="th_header">Stuga 1 - Lillstugan</th></tr>
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
                <asp:LinkButton runat="server" Text="Boka" OnCommand="booking_Command" CommandArgument='<%#: Item.BookingID %>' />
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
    SelectMethod="Unbooked1ListView_GetData"
    DataKeyNames="BookingID"
    Visible="true" >
    <LayoutTemplate>
        <table class="maintable">
            <tr><th class="th_header">Stuga 2 - Huset</th></tr>
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
                <asp:LinkButton runat="server" Text="Boka" OnCommand="booking_Command" CommandArgument='<%#: Item.BookingID %>' />
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
