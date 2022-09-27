<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteBeer.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.DeleteBeer" %>

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
        .auto-style19 {
            width: 256px;
        }
        .auto-style18 {
            text-align: right;
            width: 398px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
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
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style16">
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="D E L E T E" Font-Size="XX-Large"></asp:Label>
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
                                    <asp:Label ID="lblBeerEdit" runat="server" Font-Names="Consolas" Text="Select beer to delete:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddListBeer" runat="server" Font-Names="Consolas">
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
