<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBeer.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.UpdateBeer" %>

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
            text-align: right;
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
        .auto-style27 {
            width: 819px;
            text-align: left;
        }
        .auto-style19 {
            width: 276px;
        }
        .auto-style18 {
            text-align: right;
            width: 408px;
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
                    <td class="auto-style16">
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="U P D A T E" Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="B E E R" Font-Size="XX-Large"></asp:Label>
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
                                    <asp:Label ID="lblsubHeading0" runat="server" Font-Names="Consolas" Text="Beers:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style11">
                                    &nbsp;<asp:GridView ID="gridViewBeers" runat="server" Font-Names="Consolas" Height="127px" Width="389px">
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
                                    <asp:Label ID="lblBeerFilter" runat="server" Font-Names="Consolas" Text="Filter beer according to any field:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFilterBeer" runat="server" Width="230px" Font-Names="Consolas" CssClass="auto-style25"></asp:TextBox>
                                &nbsp;
                    <asp:Button ID="btnSearch" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="30px" OnClick="btnSearch_Click" Text="Search" Width="141px" CausesValidation="False" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style26">
                                    <asp:Label ID="lblBeerEdit" runat="server" Font-Names="Consolas" Text="Select beer to edit:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddListBeer" runat="server" Font-Names="Consolas" AutoPostBack="True" OnSelectedIndexChanged="ddListBeer_SelectedIndexChanged">
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
                                    <asp:Label ID="lblsubHeading" runat="server" Font-Names="Consolas" Text="Change the beer's information:" Font-Bold="True" Font-Size="Large"></asp:Label>
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
                                <td class="auto-style27">
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
                                <td class="auto-style27">
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
                                <td class="auto-style27">
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
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Consolas" NavigateUrl="~/HomePage.aspx">Return to home page</asp:HyperLink>
        </p>
    </form>
</body>
</html>
