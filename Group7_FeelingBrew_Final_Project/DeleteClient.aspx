<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteClient.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.DeleteClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


                            .auto-style16 {
                            width: 813px;
                        }
                        .auto-style16 {
            width: 819px;
            text-align: center;
        }
        .auto-style15 {
            width: 819px;
        }
        .auto-style1 {
            width: 52px;
        }
        .auto-style11 {
            width: 920px;
            text-align: left;
        }
        .auto-style10 {
            width: 920px;
        }
        .auto-style20 {
            width: 361px;
        }
        .auto-style21 {
            width: 459px;
        }
        .auto-style19 {
            width: 256px;
        }
        .auto-style18 {
            text-align: right;
            width: 398px;
        }
        .auto-style22 {
            width: 361px;
            height: 25px;
        }
        .auto-style23 {
            width: 459px;
            height: 25px;
        }
        .auto-style24 {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style16">
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="D E L E T E" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="C L I E N T" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                </table>
        </div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style11">
                                    <asp:Label ID="lblsubHeading0" runat="server" Font-Names="Consolas" Text="Clients:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style11">
                                    &nbsp;<asp:GridView ID="gridViewClient" runat="server" Font-Names="Consolas" Height="127px" Width="389px">
                                    </asp:GridView>
                                </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style22">
                                    <asp:Label ID="lblClientFilter" runat="server" Font-Names="Consolas" Text="Filter clients according to any field:"></asp:Label>
                                </td>
                                <td class="auto-style23">
                                    <asp:TextBox ID="txtFilterClients" runat="server" Width="230px" Font-Names="Consolas" ></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFilter" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" Text="Filter" Width="141px" OnClick="btnFilter_Click" CausesValidation="False"  />
                                </td>
                                <td class="auto-style24"></td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <asp:Label ID="lblClientDlt" runat="server" Font-Names="Consolas" Text="Select client to delete:"></asp:Label>
                                </td>
                                <td class="auto-style21">
                                    <asp:DropDownList ID="ddListClients" runat="server" Font-Names="Consolas">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                    </asp:DropDownList>
                                &nbsp;&nbsp;
                                    <asp:RequiredFieldValidator ID="requiredFieldName" runat="server" BorderStyle="None" ControlToValidate="ddListClients" ErrorMessage="Please select a client to delete." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style20">&nbsp;</td>
                                <td class="auto-style21">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style18">
                    <asp:Button ID="btnDelete" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" Text="Delete" Width="141px" OnClick="btnDelete_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" OnClick="btnCancel_Click" Text="Cancel" Width="141px" CausesValidation="False" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style18">
                                    <asp:Label ID="lblMessage" runat="server" Font-Names="Consolas" Text="[Message]"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            </table>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Consolas" NavigateUrl="~/HomePage.aspx">Return to home page</asp:HyperLink>
        </p>
    </form>
</body>
</html>
