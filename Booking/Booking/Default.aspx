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
                <%--Validation Summary--%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade! Korrigera och försök igen." 
                    CssClass="ValidationSummaryErrors" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Fel inträffade! Korrigera och försök igen."
                    ValidationGroup="InsertGroup" ShowModelStateErrors="false" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="Fel inträffade! Korrigera och försök igen." 
                    ValidationGroup="EditGroup" ShowModelStateErrors="false"/>

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
                    <%-- Pager --%>
                    <asp:DataPager ID="DataPager1" runat="server"></asp:DataPager>
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
                                <asp:LinkButton runat="server" CommandName="Delete" Text="Radera" CausesValidation="false" 
                                     OnClientClick='<%# String.Format("return confirm(\"Vill du verkligen ta bort {0} från kontaktlistan?\")", Item.Name) %>'  />
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
                                <%-- Validering Input Name --%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="Namn måste anges" ControlToValidate="Name" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="Adress måste anges" ControlToValidate="Address" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="Postal" runat="server" Text='<%# BindItem.Postal %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="Postnr måste anges" ControlToValidate="Postal" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ErrorMessage="Postnumret är ogiltigt" ControlToValidate="Postal" ValidationExpression="^[1-9]\d{2} ?\d{2}"
                                    ValidationGroup="InsertGrout" Display="None"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="Ort måste anges" ControlToValidate="City" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="Phone" runat="server" Text='<%# BindItem.Phone %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ErrorMessage="Telefonnr måste anges" ControlToValidate="Phone" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server" Text='<%# BindItem.Email %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ErrorMessage="Email måste anges" ControlToValidate="Email" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ErrorMessage="E-mailadressen är ogiltig" ControlToValidate="Email" ValidationExpression="^[1-9]\d{2} ?\d{2}"
                                    ValidationGroup="InsertGrout" Display="None"></asp:RegularExpressionValidator>
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
                                <%-- Validering Input Name --%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="Namn måste anges" ControlToValidate="Name" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="Adress måste anges" ControlToValidate="Address" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="Postal" runat="server" Text='<%# BindItem.Postal %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="Postnr måste anges" ControlToValidate="Postal" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ErrorMessage="Postnumret är ogiltigt" ControlToValidate="Postal" ValidationExpression="^[1-9]\d{2} ?\d{2}"
                                    ValidationGroup="InsertGrout" Display="None"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="Ort måste anges" ControlToValidate="City" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="Phone" runat="server" Text='<%# BindItem.Phone %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ErrorMessage="Telefonnr måste anges" ControlToValidate="Phone" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server" Text='<%# BindItem.Email %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ErrorMessage="Email måste anges" ControlToValidate="Email" ValidationGroup="InsertGroup"
                                    Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ErrorMessage="E-mailadressen är ogiltig" ControlToValidate="Email" ValidationExpression="^[1-9]\d{2} ?\d{2}"
                                    ValidationGroup="InsertGrout" Display="None"></asp:RegularExpressionValidator>
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
