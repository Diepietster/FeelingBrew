﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.AddClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 52px;
        }
        .auto-style2 {
            height: 23px;
            width: 451px;
            text-align: left;
        }
        .auto-style3 {
            height: 23px;
            width: 216px;
        }
        .auto-style4 {
            width: 216px;
        }
        .auto-style5 {
            height: 23px;
            width: 296px;
        }
        .auto-style6 {
            width: 296px;
        }
        .auto-style7 {
            width: 216px;
            height: 25px;
        }
        .auto-style8 {
            width: 296px;
            height: 25px;
        }
        .auto-style9 {
            height: 25px;
            width: 451px;
            text-align: left;
        }
        .auto-style10 {
            width: 920px;
        }
        .auto-style11 {
            width: 920px;
            text-align: left;
        }
        .auto-style12 {
            width: 435px;
            text-align: right;
        }
        .auto-style13 {
            width: 58px;
        }
        .auto-style14 {
            width: 451px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style11">
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="A D D" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="C L I E N T" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        <br />
                                    <asp:Label ID="lblsubHeading" runat="server" Font-Names="Consolas" Text="Enter the client's information:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                <br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="lblClientName" runat="server" Font-Names="Consolas" Text="Name:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="txtCName" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style2">
                                    <asp:RequiredFieldValidator ID="requiredFieldName" runat="server" BorderStyle="None" ControlToValidate="txtCName" ErrorMessage="Please enter a client name." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="lblClientSurname" runat="server" Font-Names="Consolas" Text="Surname:"></asp:Label>
                                </td>
                                <td class="auto-style8">
                                    <asp:TextBox ID="txtCSurname" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style9">
                                    <asp:RequiredFieldValidator ID="requiredFieldSurname" runat="server" ControlToValidate="txtCSurname" ErrorMessage="Please enter a client surname." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="lblCompany" runat="server" Font-Names="Consolas" Text="Company name:"></asp:Label>
                                &nbsp;
                                    <asp:Label ID="lblOptional" runat="server" Font-Names="Consolas" Text="(*optional)" Font-Size="Smaller"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:TextBox ID="txtCompanyName" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style14">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="lblCellNo" runat="server" Font-Names="Consolas" Text="Cellphone number:"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:TextBox ID="txtCCellphone" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style14">
                                    <asp:RequiredFieldValidator ID="requiredFieldCellNo" runat="server" ControlToValidate="txtCSurname" ErrorMessage="Please enter a client cellphone number." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="regExpresionCellNo" runat="server" ControlToValidate="txtCCellphone" ErrorMessage="Please enter valid cellphone number." Font-Names="Consolas" ForeColor="Maroon" ValidationExpression="^([\(]{1}[0-9]{3}[\)]{1}[\.| |\-]{0,1}|^[0-9]{3}[\.|\-| ]?)?[0-9]{3}(\.|\-| )?[0-9]{4}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="lblAddress" runat="server" Font-Names="Consolas" Text="Address:"></asp:Label>
                                </td>
                                <td class="auto-style5">&nbsp;</td>
                                <td class="auto-style2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;&nbsp;
                                    <asp:Label ID="lblProvince" runat="server" Font-Names="Consolas" Text="Province:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:DropDownList ID="ddListProvince" runat="server" Font-Names="Consolas">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Gauteng</asp:ListItem>
                                        <asp:ListItem>North West</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style2">
                                    <asp:RequiredFieldValidator ID="requiredFieldProvince" runat="server" ControlToValidate="ddListProvince" ErrorMessage="Please select a province." Font-Names="Consolas" ForeColor="Maroon" InitialValue="Please Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;&nbsp;
                                    <asp:Label ID="lblStreetNo" runat="server" Font-Names="Consolas" Text="Street number:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="txtCStreetNo" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style2">
                                    <asp:RangeValidator ID="rangeValStreetNo" runat="server" ControlToValidate="txtCStreetNo" ErrorMessage="Please enter valid street number." Font-Names="Consolas" ForeColor="Maroon" MaximumValue="9999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;&nbsp;
                                    <asp:Label ID="lblStreetname" runat="server" Font-Names="Consolas" Text="Streetname:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="txtCStreetName" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style2">
                                    <asp:RequiredFieldValidator ID="requiredFieldStreetname" runat="server" BorderStyle="None" ControlToValidate="txtCStreetName" ErrorMessage="Please enter a streetname." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;&nbsp;
                                    <asp:Label ID="lblCity" runat="server" Font-Names="Consolas" Text="City:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:DropDownList ID="ddListCity" runat="server" Font-Names="Consolas">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Johannesburg</asp:ListItem>
                                        <asp:ListItem>Potchefstroom</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style2">
                                    <asp:RequiredFieldValidator ID="requiredFieldCity" runat="server" ControlToValidate="ddListCity" ErrorMessage="Please select a city." Font-Names="Consolas" ForeColor="Maroon" InitialValue="Please Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <br />
                                    <asp:Label ID="lblClientType" runat="server" Font-Names="Consolas" Text="Client type:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <br />
                                    <asp:DropDownList ID="ddListClientType" runat="server" Font-Names="Consolas">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                        <asp:ListItem>Private</asp:ListItem>
                                        <asp:ListItem>Retailer</asp:ListItem>
                                        <asp:ListItem>Restaurant</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style2">
                                    <asp:RequiredFieldValidator ID="requiredFieldClientType" runat="server" ControlToValidate="ddListClientType" ErrorMessage="Please select a client type." Font-Names="Consolas" ForeColor="Maroon" InitialValue="Please Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style12">
                    <br />
                    <asp:Button ID="btnAddClient" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" OnClick="btnAddClient_Click" Text="Add" Width="141px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" Text="Cancel" Width="141px" CausesValidation="False" OnClick="btnCancel_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style12">
                                    <asp:Label ID="lblMessage" runat="server" Font-Names="Consolas" Text="[Message]"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            </table>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Consolas" NavigateUrl="~/HomePage.aspx">Retrun to home page</asp:HyperLink>
        </p>
    </form>
</body>
</html>
