<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="BookingListing.aspx.cs" Inherits="Booking.Pages.BookingPages.BookingListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ValidationContentPlaceHolder" runat="server">
<%--Header, Validering och meddelanden --%>
    <div class="list">
            
            <%--Validering --%>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade! Korrigera och försök igen." 
                    CssClass="ValidationSummaryErrors" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Fel inträffade! Korrigera och försök igen."
                    ValidationGroup="InsertGroup" ShowModelStateErrors="false" />
            <%--Meddelanden --%>
            <div class="message">
            <asp:Label ID="MessageLabel" runat="server" Text="Nedan visas bokningsbara veckor för respektive stuga. 
                Enbart hela veckor kan bokas. Bytesdag är alltid lördag. Slutstädning ingår ej i priset." 
                Visible="true" CssClass="UploadLabel"></asp:Label>
            <div class="message" id="BookingInfoDiv">
            <asp:Literal ID="Literal1" runat="server" Visible="true">
                
            </asp:Literal>
            </div>
            </div>
            <%--Validation Summary--%>
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
        <div class="message">
            
        </div>
        <fieldset>
        <div class="editor-label">
            <label for="Name">Namn</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
            <%-- Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Namn måste anges" ControlToValidate="Name" ValidationGroup="InsertGroup"
                        Display="None"></asp:RequiredFieldValidator>
        </div>
        <div class="editor-label">
            <label for="Address">Adress</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
            <%-- Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="Adress måste anges" ControlToValidate="Address" ValidationGroup="InsertGroup"
                        Display="None"></asp:RequiredFieldValidator>
        </div>
        <div class="editor-label">
            <label for="Postal">Postnr</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Postal" runat="server" Text='<%# BindItem.Postal %>' />
            <%-- Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="Postnr måste anges" ControlToValidate="Postal" ValidationGroup="InsertGroup"
                        Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ErrorMessage="Postnumret är ogiltigt" ControlToValidate="Postal" ValidationExpression="^[1-9]\d{2} ?\d{2}"
                        ValidationGroup="InsertGrout" Display="None"></asp:RegularExpressionValidator>
        </div>
        <div class="editor-label">
            <label for="City">Ort</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' />
            <%-- Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ErrorMessage="Ort måste anges" ControlToValidate="City" ValidationGroup="InsertGroup"
                        Display="None"></asp:RequiredFieldValidator>
        </div>
        <div class="editor-label">
            <label for="Phone">Telefon</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Phone" runat="server" Text='<%# BindItem.Phone %>' />
            <%-- Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ErrorMessage="Telefonnr måste anges" ControlToValidate="Phone" ValidationGroup="InsertGroup"
                        Display="None"></asp:RequiredFieldValidator>
        </div>
        <div class="editor-label">
            <label for="Email">Epost</label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="Email" runat="server" Text='<%# BindItem.Email %>' />
            <%-- Validering--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ErrorMessage="Email måste anges" ControlToValidate="Email" ValidationGroup="InsertGroup"
                        Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ErrorMessage="E-mailadressen är ogiltig" ControlToValidate="Email" ValidationExpression="^[1-9]\d{2} ?\d{2}"
                        ValidationGroup="InsertGrout" Display="None"></asp:RegularExpressionValidator>
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
    SelectMethod="Unbooked2ListView_GetData"
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
