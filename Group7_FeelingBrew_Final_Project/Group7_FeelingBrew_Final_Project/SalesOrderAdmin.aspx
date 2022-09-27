<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesOrderAdmin.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.SalesOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

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
        .auto-style1 {
            width: 155px;
            height: 143px;
        }
        .auto-style5 {
            width: 181px;
        }
        .auto-style6 {
            width: 192px;
        }
        .auto-style7 {
            width: 180px;
        }
        .auto-style8 {
            width: 193px;
        }
        .auto-style25 {
            margin-left: 0px;
        }
        .auto-style26 {
            width: 193px;
            text-align: right;
        }
        .auto-style27 {
            width: 262px;
        }
        .auto-style19 {
            width: 256px;
        }
        .auto-style18 {
            text-align: right;
            width: 657px;
        }
        .auto-style29 {
            width: 180px;
            height: 23px;
        }
        .auto-style30 {
            width: 193px;
            height: 23px;
        }
        .auto-style31 {
            width: 262px;
            height: 23px;
        }
        .auto-style32 {
            width: 256px;
            height: 23px;
        }
        .auto-style33 {
            text-align: right;
            width: 657px;
            height: 23px;
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
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="P L A C E" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblHeading1" runat="server" Font-Names="Consolas" Text="S A L E S" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="O R D E R" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">
                                    <asp:Label ID="lblClient" runat="server" Font-Names="Consolas" Text="Select Client:"></asp:Label>
                                </td>
                <td>
                                    <asp:DropDownList ID="ddListClients" runat="server" Font-Names="Consolas">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30">
                                    <asp:Label ID="lblBeer" runat="server" Font-Names="Consolas" Text="Select Beer:"></asp:Label>
                                </td>
                <td class="auto-style30">
                                    <asp:Label ID="lblQty" runat="server" Font-Names="Consolas" Text="Enter Quantity:"></asp:Label>
                                </td>
                <td class="auto-style30">
                                    <asp:Label ID="lblPrice" runat="server" Font-Names="Consolas" Text="Unit Price:"></asp:Label>
                                </td>
                <td class="auto-style31">
                                    <asp:Label ID="lblTotalHeading" runat="server" Font-Names="Consolas" Text="Total:"></asp:Label>
                                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">
                                    <asp:DropDownList ID="ddListBeer" runat="server" Font-Names="Consolas">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                <td class="auto-style8">
                                    <asp:TextBox ID="txtQty" runat="server" Width="126px" Font-Names="Consolas" CssClass="auto-style25"></asp:TextBox>
                                </td>
                <td class="auto-style8">
                                    <asp:Label ID="lblUnitPrice" runat="server" Font-Names="Consolas" Text="[Price]"></asp:Label>
                                </td>
                <td class="auto-style27">
                                    <asp:Label ID="lblTotal" runat="server" Font-Names="Consolas" Text="[Total]"></asp:Label>
                                </td>
                <td>
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtQty" ErrorMessage="Please enter valid quantity." Font-Names="Consolas" ForeColor="Maroon" MaximumValue="999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">
                                    &nbsp;</td>
                <td class="auto-style8">
                                    &nbsp;</td>
                <td class="auto-style8">
                                    <asp:Button ID="btnCheckPrice" runat="server" Height="46px" OnClick="btnCheckPrice_Click" Text="Check Price" Width="162px" />
                                </td>
                <td class="auto-style27">
                                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">
                                    &nbsp;</td>
                <td class="auto-style8">
                                    &nbsp;</td>
                <td class="auto-style8">
                                    &nbsp;</td>
                <td class="auto-style27">
                                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">
                                    &nbsp;</td>
                <td class="auto-style8">
                                    &nbsp;</td>
                <td class="auto-style8">
                                    &nbsp;</td>
                <td class="auto-style27">
                                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style26">
                                    <asp:Label ID="lblTotalHeading0" runat="server" Font-Names="Consolas" Text="Total excl VAT: R"></asp:Label>
                                </td>
                <td class="auto-style27">
                                    <asp:Label ID="lblTotalExclVAT" runat="server" Font-Names="Consolas" Text="[Total Excl VAT]"></asp:Label>
                                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style26">
                                    <asp:Label ID="lblTotalHeading1" runat="server" Font-Names="Consolas" Text="VAT: R"></asp:Label>
                                </td>
                <td class="auto-style27">
                                    <asp:Label ID="lblVAT" runat="server" Font-Names="Consolas" Text="[VAT]"></asp:Label>
                                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style26">
                                    <asp:Label ID="lblTotalHeading2" runat="server" Font-Names="Consolas" Text="Total incl VAT: R"></asp:Label>
                                </td>
                <td class="auto-style27">
                                    <asp:Label ID="lblInclVAT" runat="server" Font-Names="Consolas" Text="[Total Incl VAT]"></asp:Label>
                                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style18">
                    <br />
                    <asp:Button ID="btnPlaceOrder" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" Text="Place Order" Width="141px" OnClick="btnPlaceOrder_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" OnClick="btnCancel_Click" Text="Cancel" Width="141px" CausesValidation="False" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32"></td>
                <td class="auto-style33">
                                    <asp:Label ID="lblMessage" runat="server" Font-Names="Consolas" Text="[Message]"></asp:Label>
                </td>
                <td class="auto-style3"></td>
            </tr>
            </table>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Consolas" NavigateUrl="~/HomePage.aspx">Retrun to home page</asp:HyperLink>
        </p>
    </form>
</body>
</html>
