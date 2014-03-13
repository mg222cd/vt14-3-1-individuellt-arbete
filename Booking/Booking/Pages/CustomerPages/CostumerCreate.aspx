<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CostumerCreate.aspx.cs" Inherits="Booking.Pages.CustomerPages.CostumerCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ValidationContentPlaceHolder" runat="server">
    <h2>Ange dina kontaktuppgifter</h2>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:FormView ID="CustomerFormView" runat="server"
        ItemType="Booking.Model.Customer"
        DefaultMode="Insert"
        InsertMethod="CustomerFormView_InsertItem">
        <InsertItemTemplate>
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
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
