<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePageClient.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.HomePageClient" %>

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
            width: 420px;
            text-align: center;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style1 {
            width: 173px;
        }
        .auto-style5 {
            width: 189px;
        }
        .auto-style6 {
            width: 165px;
        }
        .auto-style7 {
            width: 643px;
        }
        .auto-style8 {
            width: 100%;
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
                    <td>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading" runat="server" Font-Names="Consolas" Text="H O M E  " Font-Size="XX-Large"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblHeading0" runat="server" Font-Names="Consolas" Text="P A G E" Font-Size="XX-Large"></asp:Label>
                                </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
                    </td>
                </tr>
            </table>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style5">
                        <img class="auto-style1" src="Images/FeelingBrew_Logo.png" /></td>
                <td>
                    <table class="auto-style8">
                        <tr>
                            <td class="auto-style6">
                                    <asp:Label ID="lblsubHeading0" runat="server" Font-Names="Consolas" Text="Sales Orders:" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </td>
                            <td class="auto-style7">
                    <asp:Button ID="btnPlaceSO" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="Place Order" Width="160px" OnClick="btnPlaceSO_Click" />
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnViewSO" runat="server" Font-Names="Consolas" Font-Size="Medium" Height="39px" Text="View Orders" Width="160px" OnClick="btnViewSO_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td>Need help?&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="target = '_blank';" Text="Help" />
                &nbsp;&nbsp; </td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
