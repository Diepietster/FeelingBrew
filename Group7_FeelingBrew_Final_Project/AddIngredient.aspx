<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddIngredient.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.AddIngredient" %>

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
        .auto-style16 {
            height: 23px;
            width: 642px;
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
        .auto-style24 {
            width: 79px;
        }
        .auto-style25 {
            text-align: right;
            width: 556px;
        }
        .auto-style26 {
            margin-right: 0px;
        }
        .auto-style27 {
            width: 556px;
        }
    </style>
</head>
<body>
    <div id="google_translate_element"></div>  
       <script type="text/javascript">  
                                   function googleTranslateElementInit() {  
                                   new google.translate.TranslateElement  
                                   ({ pageLanguage: 'en',   
                                   layout: google.translate.TranslateElement.InlineLayout.SIMPLE },   
                                   'google_translate_element');  
                               }  
       </script><script type="text/javascript"   
    src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit">  
    </script> 
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style11">
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="A D D" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="I N G R E D I E N T" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style10">
                        <br />
                                    <asp:Label ID="lblsubHeading" runat="server" Font-Names="Consolas" Text="Enter the ingredient's information:" Font-Bold="True" Font-Size="Large"></asp:Label>
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
                                <td class="auto-style16">
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
                                <td class="auto-style16">
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
                                <td class="auto-style16">
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
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style24">&nbsp;</td>
                <td class="auto-style25">
                    <asp:Button ID="btnAdd" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" OnClick="btnAdd_Click" Text="Add" Width="141px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="auto-style26" Font-Names="Consolas" Font-Size="Medium" Height="30px" OnClick="btnCancel_Click" Text="Cancel" Width="141px" CausesValidation="False" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24">&nbsp;</td>
                <td class="auto-style25">
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
