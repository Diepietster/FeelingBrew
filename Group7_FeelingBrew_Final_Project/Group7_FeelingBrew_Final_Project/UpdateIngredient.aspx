<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateIngredient.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.UpdateIngredient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

                        .auto-style16 {
            width: 819px;
            text-align: center;
        }
        
                            .auto-style16 {
                            width: 813px;
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
        .auto-style26 {
            width: 391px;
        }
        .auto-style25 {
            margin-left: 0px;
        }
        .auto-style21 {
            width: 642px;
            height: 25px;
        }
        .auto-style22 {
            width: 295px;
            height: 25px;
            text-align: left;
        }
        .auto-style23 {
            width: 451px;
            text-align: left;
            height: 25px;
        }
        .auto-style17 {
            width: 642px;
        }
        .auto-style6 {
            width: 295px;
            text-align: left;
        }
        .auto-style14 {
            width: 451px;
            text-align: left;
        }
        .auto-style5 {
            height: 23px;
            width: 295px;
            text-align: left;
        }
        .auto-style2 {
            height: 23px;
            width: 451px;
            text-align: left;
        }
        .auto-style19 {
            width: 256px;
        }
        .auto-style18 {
            text-align: right;
            width: 408px;
        }
        .auto-style28 {
            width: 408px;
        }
        .auto-style29 {
            width: 813px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style16">
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="U P D A T E" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="I N G R E D I E N T" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style11">
                                    <asp:Label ID="lblsubHeading0" runat="server" Font-Names="Consolas" Text="Ingredients:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style11">
                                    &nbsp;<asp:GridView ID="gridViewIngredients" runat="server" Font-Names="Consolas" Height="127px" Width="389px">
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
                                <td class="auto-style26">
                                    <asp:Label ID="lblIngredientFilter" runat="server" Font-Names="Consolas" Text="Filter ingredient according to any field:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFilterIngredient" runat="server" Width="230px" Font-Names="Consolas" CssClass="auto-style25"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style26">
                                    <asp:Label ID="lblIngredientEdit" runat="server" Font-Names="Consolas" Text="Select ingredient to edit:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddListIngredient" runat="server" Font-Names="Consolas">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style26">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        <br />
                                    <asp:Label ID="lblsubHeading" runat="server" Font-Names="Consolas" Text="Change the ingredient's information:" Font-Bold="True" Font-Size="Large"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style21">
                                    <asp:Label ID="lblIngrDesc" runat="server" Font-Names="Consolas" Text="Ingredient description:"></asp:Label>
                                &nbsp;
                                    </td>
                                <td class="auto-style22">
                                    <asp:TextBox ID="txtIngrDesc" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style23">
                                    <asp:RequiredFieldValidator ID="requiredFieldBeerName" runat="server" BorderStyle="None" ControlToValidate="txtIngrDesc" ErrorMessage="Please enter a ingredient description." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    <asp:Label ID="lblIngrCost" runat="server" Font-Names="Consolas" Text="Ingredient latest cost:"></asp:Label>
                                    </td>
                                <td class="auto-style6">
                                    <asp:TextBox ID="txtIngrCost" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td class="auto-style14">
                                    <asp:RequiredFieldValidator ID="requiredFieldBeerDesc" runat="server" BorderStyle="None" ControlToValidate="txtIngrCost" ErrorMessage="Please enter the latest cost." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style29">
                                    <asp:Label ID="lblIngrUnitType" runat="server" Font-Names="Consolas" Text="Ingredient Unit Type:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:DropDownList ID="ddListIngrUnitType" runat="server" Font-Names="Consolas">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style2">
                                    <asp:RequiredFieldValidator ID="requiredFieldBeerDesc0" runat="server" BorderStyle="None" ControlToValidate="ddListIngrUnitType" ErrorMessage="Please select a ingredient unit type." Font-Names="Consolas" ForeColor="Maroon" InitialValue="Please Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style29">
                                    <asp:Label ID="lblSupplier" runat="server" Font-Names="Consolas" Text="Supplier:"></asp:Label>
                                </td>
                                <td class="auto-style5">
                                    <asp:DropDownList ID="ddListSupplier" runat="server" Font-Names="Consolas">
                                        <asp:ListItem>Please Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style2">
                                    <asp:RequiredFieldValidator ID="requiredFieldBeerDesc1" runat="server" BorderStyle="None" ControlToValidate="ddListSupplier" ErrorMessage="Please select a supplier." Font-Names="Consolas" ForeColor="Maroon" InitialValue="Please Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style29">
                                    <asp:Label ID="lblQtyOnHand" runat="server" Font-Names="Consolas" Text="Ingredient quantity on hand:"></asp:Label>
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
        <table style="width:100%;">
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style18">
                    <asp:Button ID="btnUpdate" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" OnClick="btnUpdate_Click" Text="Update" Width="141px" />
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
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Consolas" NavigateUrl="~/HomePage.aspx">Retrun to home page</asp:HyperLink>
        </p>
    </form>
</body>
</html>
