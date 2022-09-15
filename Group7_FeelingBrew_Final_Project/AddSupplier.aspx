﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSupplier.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.AddSupplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 52px;
        }
        .auto-style11 {
            width: 920px;
            text-align: left;
            height: 41px;
        }
        .auto-style10 {
            width: 920px;
        }
        .auto-style3 {
            height: 23px;
            width: 216px;
        }
        .auto-style5 {
            height: 23px;
            width: 296px;
        }
        .auto-style2 {
            height: 23px;
            width: 451px;
            text-align: left;
        }
        .auto-style4 {
            width: 216px;
        }
        .auto-style6 {
            width: 296px;
        }
        .auto-style14 {
            width: 451px;
            text-align: left;
        }
        .auto-style13 {
            width: 253px;
        }
        .auto-style12 {
            width: 303px;
            text-align: right;
        }
        .auto-style15 {
            width: 303px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style20">
                <tr>
                    <td class="auto-style18"></td>
                    <td class="auto-style11">
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="A D D" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="S U P P L I E R" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        <br />
                                    <asp:Label ID="lblsubHeading" runat="server" Font-Names="Consolas" Text="Enter the supplier's information:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                <br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="lblCompany" runat="server" Font-Names="Consolas" Text="Company name:"></asp:Label>
                                &nbsp;
                                    </td>
                                <td class="auto-style6">
                                    <asp:TextBox ID="txtCompanyNameS" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style14">
                                    <asp:RequiredFieldValidator ID="requiredFieldStreetname0" runat="server" BorderStyle="None" ControlToValidate="txtCompanyNameS" ErrorMessage="Please enter a company name." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
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
                                    <asp:TextBox ID="txtSStreetNo" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style2">
                                    <asp:RangeValidator ID="rangeValStreetNo" runat="server" ControlToValidate="txtSStreetNo" ErrorMessage="Please enter valid street number." Font-Names="Consolas" ForeColor="Maroon" MaximumValue="9999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;&nbsp;
                                    <asp:Label ID="lblStreetname" runat="server" Font-Names="Consolas" Text="Streetname:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="txtSStreetName" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style2">
                                    <asp:RequiredFieldValidator ID="requiredFieldStreetname" runat="server" BorderStyle="None" ControlToValidate="txtSStreetName" ErrorMessage="Please enter a streetname." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
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
                                    <asp:Label ID="lblAgreement" runat="server" Font-Names="Consolas" Text="Agreement Details:" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    &nbsp;</td>
                                <td class="auto-style2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style13">
                                    &nbsp;</td>
                <td class="auto-style15">
                                    <asp:Label ID="lblAgreement0" runat="server" Font-Names="Consolas" Text="Select agreement start date"></asp:Label>
                    <br />
                </td>
                <td>
                                    <asp:Label ID="lblAgreement1" runat="server" Font-Names="Consolas" Text="Select agreement end date"></asp:Label>
                                </td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style12">
                    <asp:Calendar ID="calStartDate" runat="server" DayNameFormat="FirstLetter" FirstDayOfWeek="Monday" Font-Names="Consolas" Height="184px" Width="249px" OnSelectionChanged="calStartDate_SelectionChanged">
                        <DayStyle Font-Underline="False" />

                    </asp:Calendar>
                    <style type="text/css">
                            a{
                             text-decoration: none;
                             }
                            .auto-style16 {
                            width: 813px;
                        }
                        .auto-style17 {
                            width: 813px;
                            text-align: right;
                        }
                            .auto-style18 {
                            width: 52px;
                            height: 41px;
                        }
                        .auto-style19 {
                            height: 41px;
                        }
                        .auto-style20 {
                            width: 100%;
                        }
                            .auto-style21 {
                            width: 813px;
                            height: 23px;
                        }
                        .auto-style22 {
                            height: 23px;
                        }
                            </style>
                </td>
                <td>
                    <asp:Calendar ID="calEndDate" runat="server" DayNameFormat="FirstLetter" FirstDayOfWeek="Monday" Font-Names="Consolas" Height="184px" Width="249px" OnSelectionChanged="calEndDate_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style15">
                    <asp:Label ID="lblErrorStartDate" runat="server" Font-Names="Consolas" ForeColor="Maroon" Text="[Error]"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblErrorEndDate" runat="server" Font-Names="Consolas" ForeColor="Maroon" Text="[Error]"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style17">
                    <asp:Button ID="btnAddSupplier" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" Text="Add" Width="141px" OnClick="btnAddSupplier_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" Text="Cancel" Width="141px" CausesValidation="False" OnClick="btnCancel_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">
                                    <asp:Label ID="lblMessage" runat="server" Font-Names="Consolas" Text="[Message]"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Consolas" NavigateUrl="~/HomePage.aspx">Retrun to home page</asp:HyperLink>
        </p>
    </form>
</body>
</html>
