<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSOAdmin.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.ViewSOAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 155px;
            height: 143px;
        }
        
        .auto-style2 {
            width: 181px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
            width: 936px;
            }
        .auto-style3 {
            height: 23px;
        }
        .auto-style11 {
            width: 920px;
            text-align: left;
        }
        .auto-style10 {
            width: 920px;
        }
        .auto-style26 {
            width: 391px;
        }
        .auto-style25 {
            margin-left: 0px;
        }
        .auto-style27 {
            width: 920px;
            text-align: left;
            height: 54px;
        }
        .auto-style28 {
            height: 54px;
        }
        .auto-style29 {
            width: 155px;
            height: 54px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
                        <img class="auto-style1" src="Images/FeelingBrew_Logo.png" /></td>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="V I E W" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblHeading1" runat="server" Font-Names="Consolas" Text="S A L E S" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="O R D E R S" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
        </div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style29"></td>
                    <td class="auto-style27">
                                    <asp:Label ID="lblsubHeading0" runat="server" Font-Names="Consolas" Text="Sales Orders:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                    <td class="auto-style28"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style11">
                                    &nbsp;<asp:GridView ID="gridViewSO" runat="server" Font-Names="Consolas" Height="127px" Width="389px">
                                    </asp:GridView>
                                </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        &nbsp;<table style="width:100%;">
                            <tr>
                                <td class="auto-style26">
                                    <asp:Label ID="lblIngredientFilter" runat="server" Font-Names="Consolas" Text="Filter sales orders according to any field:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFilterSO" runat="server" Width="230px" Font-Names="Consolas" CssClass="auto-style25"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style26">
                                    &nbsp;</td>
                                <td>
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
