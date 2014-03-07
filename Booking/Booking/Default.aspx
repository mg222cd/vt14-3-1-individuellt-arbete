<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Booking.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Booking</title>
    <link href="~/Content/reset.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="header">
            <h1>bokning.</h1>
        </div><%--#header--%>
    <div id="wrapper">
        <div id="content">
            <nav>
                <div id="menu">
                    <ul>
                        <li><a href="#">bokning</a></li>
                        <li><a href="#">administrera bokningar</a></li>
                        <li><a href="#">administrera kunder</a></li>
                        <li><a href="#">administrera stugor</a></li>
                    </ul>
                </div><%--#menu--%>
            </nav>
            <div class="list">
            <h2>kunder</h2>
                <%--LISTVIEW--%>
                <asp:ListView ID="CustomerListView" runat="server"
                    ItemType="Booking.Model.Customer"
                    SelectMethod="CustomerListView_GetData"
                    InsertMethod="CustomerListView_InsertItem"
                    UpdateMethod="CustomerListView_UpdateItem"
                    DeleteMethod="CustomerListView_DeleteItem"
                    DataKeyNames="CustomerId"
                    InsertItemPosition="FirstItem">
                    <LayoutTemplate>
                        <table class="grid">
                            <tr>
                                <th>Namn</th>
                                <th>Adress</th>
                                <th>Postnummer</th>
                                <th>Ort</th>
                                <th>Telefon</th>
                                <th>E-mail</th>
                                <th></th>
                            </tr>
                            <%--Platshållare för nya rader --%>
                            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <%--Mall för nya rader--%>
                        <tr>
                            <td>
                                <asp:Label ID="NameLabel" runat="server" Text='<%#: Item.Name %>' ></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="AddressLabel" runat="server" Text='<%#: Item.Address %>' ></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="PostalLabel" runat="server" Text='<%#: Item.Postal %>' ></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="CityLabel" runat="server" Text='<%#: Item.City %>' ></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="PhoneLabel" runat="server" Text='<%#: Item.Phone %>' ></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="EmailLabel" runat="server" Text='<%#: Item.Email %>' ></asp:Label>
                            </td>
                            <td class="command">
                                <asp:LinkButton runat="server" CommandName="Edit" Text="Ändra" CausesValidation="false" />
                                <asp:LinkButton runat="server" CommandName="Delete" Text="Radera" CausesValidation="false" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                    <%-- Detta visas då kunduppgifter saknas i databasen. --%>
                    <table class="grid">
                        <tr>
                            <td>
                                Kunduppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr>
                            <td>
                                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="Postal" runat="server" Text='<%# BindItem.Postal %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="Phone" runat="server" Text='<%# BindItem.Phone %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server" Text='<%# BindItem.Email %>' />
                            </td>
                            <td>
                                <%-- Kommandoknappar --%>
                                <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                                <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <EditItemTemplate>
                         <tr>
                            <td>
                                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="Postal" runat="server" Text='<%# BindItem.Postal %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="Phone" runat="server" Text='<%# BindItem.Phone %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server" Text='<%# BindItem.Email %>' />
                            </td>
                            <td>
                                <%-- Kommandoknappar --%>
                                <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                                <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                            </td>
                        </tr>
                    </EditItemTemplate>

                </asp:ListView>

            </div><%--#customers--%>
        </div><%--#content--%>
    </div><%--#wrapper--%>
    </div><%--#container--%>
    </form>
</body>
</html>
