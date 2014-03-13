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
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
