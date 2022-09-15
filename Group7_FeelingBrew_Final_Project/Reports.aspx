﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.Reports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


        .auto-style2 {
            width: 181px;
            height: 23px;
        }
        .auto-style1 {
            width: 155px;
            height: 143px;
        }
        .auto-style4 {
            height: 23px;
            width: 936px;
            }
        .auto-style3 {
            height: 23px;
        }
        .auto-style29 {
            width: 256px;
            height: 54px;
        }
        .auto-style27 {
            width: 920px;
            text-align: left;
            height: 54px;
        }
        .auto-style28 {
            height: 54px;
        }
        .auto-style11 {
            width: 920px;
            text-align: left;
        }
        .auto-style10 {
            width: 920px;
        }
        .auto-style26 {
            width: 298px;
        }
        .auto-style25 {
            margin-left: 0px;
        }
        .auto-style30 {
            width: 256px;
            height: 143px;
        }
        .auto-style31 {
            width: 278px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
                        <img class="auto-style1" src="Images/FeelingBrew_Logo.png" /></td>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="V I E W" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblHeading1" runat="server" Font-Names="Consolas" Text="R E P O R T S" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
        <div>
        </div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style29">
                                    <asp:Label ID="lblsubHeading1" runat="server" Font-Names="Consolas" Text="Select report to display:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                    <td class="auto-style27">
                        &nbsp;</td>
                    <td class="auto-style28">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style29">&nbsp;</td>
                    <td class="auto-style27">
                    <asp:Button ID="btnTopBeers" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Top Beers" Width="150px"  />
                                &nbsp;&nbsp;
                    <asp:Button ID="btnPO" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Purchase Order" Width="150px"  />
                                &nbsp;&nbsp;
                    <asp:Button ID="btnSO" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Sales Order" Width="150px"  />
                                <br />
                                </td>
                    <td class="auto-style28">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style29"></td>
                    <td class="auto-style27">
                                    <asp:Label ID="lblsubHeading0" runat="server" Font-Names="Consolas" Text="Report:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                    <td class="auto-style28"></td>
                </tr>
                <tr>
                    <td class="auto-style30">&nbsp;</td>
                    <td class="auto-style11">
                                    &nbsp;<asp:GridView ID="gridViewData" runat="server" Font-Names="Consolas" Height="127px" Width="389px">
                                    </asp:GridView>
                                </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style30">&nbsp;</td>
                    <td class="auto-style10">
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style26">
                                    <asp:Label ID="lblFilter" runat="server" Font-Names="Consolas" Text="Filter according to any field:"></asp:Label>
                                </td>
                                <td class="auto-style31">
                                    <asp:TextBox ID="txtFilterPO" runat="server" Width="230px" Font-Names="Consolas" CssClass="auto-style25"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style26">
                                    &nbsp;</td>
                                <td class="auto-style31">
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            </table>
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
