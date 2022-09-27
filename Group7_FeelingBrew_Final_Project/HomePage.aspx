<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 173px;
        }
        .auto-style2 {
            width: 181px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
            width: 409px;
            text-align: center;
        }
        .auto-style10 {
            width: 180px;
        }
        .auto-style11 {
            width: 834px;
        }
        .auto-style13 {
            width: 636px;
        }
        .auto-style14 {
            width: 218px;
            height: 43px;
        }
        .auto-style15 {
            width: 636px;
            height: 43px;
        }
        .auto-style16 {
            height: 43px;
        }
        .auto-style17 {
            width: 100%;
        }
        .auto-style18 {
            width: 218px;
        }
        .auto-style19 {
            width: 178px;
        }
        .auto-style20 {
            width: 178px;
            height: 47px;
        }
        .auto-style21 {
            width: 218px;
            height: 47px;
        }
        .auto-style22 {
            height: 47px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>  
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
    </div> 
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="H O M E  " Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="P A G E" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style10">
                        <img class="auto-style1" src="Images/FeelingBrew_Logo.png" /></td>
                <td class="auto-style11">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style3">
                                <br />
                                    <asp:Label ID="lblsubHeading" runat="server" Font-Names="Consolas" Text="Select entity to be maintained:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table class="auto-style17">
                        <tr>
                            <td class="auto-style14">
                                    <asp:Label ID="lblClients" runat="server" Font-Names="Consolas" Text="Maintain Clients"></asp:Label>
                                </td>
                            <td class="auto-style15">
                                <asp:Button ID="btnAddClient" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Add" Width="110px" OnClick="btnAddClient_Click" />
&nbsp;&nbsp;
                                <asp:Button ID="btnUpdateClient" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Update" Width="146px" OnClick="btnUpdateClient_Click" />
&nbsp;&nbsp;
                                <asp:Button ID="btnDeleteClient" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Delete" Width="110px" OnClick="btnDeleteClient_Click" />
                            </td>
                            <td class="auto-style16">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style18">
                                    <asp:Label ID="lblSuppliers" runat="server" Font-Names="Consolas" Text="Maintain Suppliers"></asp:Label>
                                </td>
                            <td class="auto-style13">
                                <asp:Button ID="btnAddSupplier" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Add" Width="110px" OnClick="btnAddSupplier_Click" />
&nbsp;&nbsp;
                                <asp:Button ID="btnUpdateSupplier" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Update" Width="144px" OnClick="btnUpdateSupplier_Click" />
&nbsp;&nbsp;
                                <asp:Button ID="btnDeleteSupplier" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Delete" Width="110px" OnClick="btnDeleteSupplier_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style18">
                                    <asp:Label ID="lblBeers" runat="server" Font-Names="Consolas" Text="Maintain Beers"></asp:Label>
                                </td>
                            <td class="auto-style13">
                                <asp:Button ID="btnAddBeer" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Add" Width="110px" OnClick="btnAddBeer_Click" />
&nbsp;&nbsp;
                                <asp:Button ID="btnUpdateBeer" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Update" Width="143px" OnClick="btnUpdateBeer_Click" />
&nbsp;&nbsp;
                                <asp:Button ID="btnDeleteBeer" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Delete" Width="110px" OnClick="btnDeleteBeer_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style18">
                                    <asp:Label ID="lblIngredients" runat="server" Font-Names="Consolas" Text="Maintain Ingredients"></asp:Label>
                                </td>
                            <td class="auto-style13">
                                <asp:Button ID="btnAddIngredient" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Add" Width="110px" OnClick="btnAddIngredient_Click" />
&nbsp;&nbsp;
                                <asp:Button ID="btnUpdateIngredient" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Update" Width="141px" OnClick="btnUpdateIngredient_Click" />
&nbsp;&nbsp;
                                <asp:Button ID="btnDeleteIngredient" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Delete" Width="110px" OnClick="btnDeleteIngredient_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style18">
                                    <asp:Label ID="lblsubHeading0" runat="server" Font-Names="Consolas" Text="Sales Orders:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                <td>
                    <asp:Button ID="btnPlaceSO" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Place Order" Width="165px" OnClick="btnPlaceSO_Click" />
&nbsp;&nbsp;
                    <asp:Button ID="btnViewSO" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="View Orders" Width="172px" OnClick="btnViewSO_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style20"></td>
                <td class="auto-style21">
                                    <asp:Label ID="lblsubHeading1" runat="server" Font-Names="Consolas" Text="Purchase Orders:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                <td class="auto-style22">
                    <asp:Button ID="btnPlacePO" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Place Order" Width="165px" OnClick="btnPlacePO_Click" />
&nbsp;&nbsp;
                    <asp:Button ID="btnViewPO" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="View Orders" Width="171px" OnClick="btnViewPO_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style18">
                                    <asp:Label ID="lblsubHeading2" runat="server" Font-Names="Consolas" Text="Reports:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                <td>
                    <asp:Button ID="btnCustom" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Custom" Width="110px" OnClick="btnCustom_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style18">
                                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style18">
                                    Need help?</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="target = '_blank';" Text="Help" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
