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

</asp:Content>
