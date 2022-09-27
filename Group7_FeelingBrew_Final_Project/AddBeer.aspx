<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBeer.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.AddBeer" %>

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
        }
        .auto-style10 {
            width: 920px;
        }
        .auto-style6 {
            width: 295px;
            text-align: right;
        }
        .auto-style14 {
            width: 451px;
            text-align: left;
        }
        .auto-style5 {
            height: 23px;
            width: 295px;
            text-align: right;
        }
        .auto-style2 {
            height: 23px;
            width: 451px;
            text-align: left;
        }
        .auto-style16 {
            height: 23px;
            width: 642px;
        }
        .auto-style17 {
            width: 642px;
        }
        .auto-style18 {
            text-align: right;
            width: 385px;
        }
        .auto-style19 {
            width: 276px;
        }
        .auto-style20 {
            width: 385px;
        }
        .auto-style21 {
            width: 642px;
            height: 25px;
        }
        .auto-style22 {
            width: 295px;
            height: 25px;
            text-align: right;
        }
        .auto-style23 {
            width: 451px;
            text-align: left;
            height: 25px;
        }
        .auto-style24 {
            width: 276px;
            text-align: center;
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
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="B E E R" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        <br />
                                    <asp:Label ID="lblsubHeading" runat="server" Font-Names="Consolas" Text="Enter the beer's information:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                <br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style21">
                                    <asp:Label ID="lblBeerName" runat="server" Font-Names="Consolas" Text="Beer name:"></asp:Label>
                                &nbsp;
                                    </td>
                                <td class="auto-style22">
                                    <asp:TextBox ID="txtBeerName" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style23">
                                    <asp:RequiredFieldValidator ID="requiredFieldBeerName" runat="server" BorderStyle="None" ControlToValidate="txtBeerName" ErrorMessage="Please enter a beer name." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    <asp:Label ID="lblBeerDesc" runat="server" Font-Names="Consolas" Text="Beer description:"></asp:Label>
                                    </td>
                                <td class="auto-style6">
                                    <asp:TextBox ID="txtBeerDesc" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style14">
                                    <asp:RequiredFieldValidator ID="requiredFieldBeerDesc" runat="server" BorderStyle="None" ControlToValidate="txtBeerDesc" ErrorMessage="Please enter a beer description." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style16">
                                    <asp:Label ID="lblPrice" runat="server" Font-Names="Consolas" Text="Beer unit price (per bottle):"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="txtBeerPrice" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style2">
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtBeerPrice" ErrorMessage="Please enter valid price." Font-Names="Consolas" ForeColor="Maroon" MaximumValue="999999" MinimumValue="0"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style16">
                                    <asp:Label ID="lblSize" runat="server" Font-Names="Consolas" Text="Beer bottle size:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="txtBottleSize" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style2">
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtBottleSize" ErrorMessage="Please enter valid bottle size." Font-Names="Consolas" ForeColor="Maroon" MaximumValue="999999" MinimumValue="0"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style16">
                                    <asp:Label ID="lblQuantity" runat="server" Font-Names="Consolas" Text="Beer quantity on hand:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="txtQtyOnHand" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style2">
                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtQtyOnHand" ErrorMessage="Please enter valid quantity." Font-Names="Consolas" ForeColor="Maroon" MaximumValue="999999" MinimumValue="0"></asp:RangeValidator>
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
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style18">
                    <asp:Button ID="btnAdd" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" OnClick="btnAdd_Click" Text="Add" Width="141px" />
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
