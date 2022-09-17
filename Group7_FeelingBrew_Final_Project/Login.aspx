<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Group7_FeelingBrew_Final_Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 180px;
            height: 178px;
        }
        .auto-style2 {
            width: 70px;
        }
        .auto-style9 {
            width: 201px;
        }
        .auto-style8 {
            width: 169px;
        }
        .auto-style6 {
            width: 280px;
        }
        .auto-style5 {
            height: 23px;
            width: 169px;
        }
        .auto-style7 {
            height: 23px;
            width: 280px;
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style9">
                        <img class="auto-style1" src="Images/FeelingBrew_Logo.png" /></td>
                    <td>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style8">
                                    <asp:Label ID="lblUsername" runat="server" Font-Names="Consolas" Text="Enter Username:"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <asp:TextBox ID="txtUsername" runat="server" Width="230px" Font-Names="Consolas"></asp:TextBox>
                                </td>
                                <td>
                                    <br />
                                    <asp:RequiredFieldValidator ID="requiredFieldUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter a username." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="lblPassword" runat="server" Font-Names="Consolas" Text="Enter Password:"></asp:Label>
                                </td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="txtPassword" runat="server" Width="230px" Font-Names="Consolas" TextMode="Password"></asp:TextBox>
                                </td>
                                <td class="auto-style3">
                                    <asp:RequiredFieldValidator ID="requiredFieldUsername0" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a password." Font-Names="Consolas" ForeColor="Maroon"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style8">&nbsp;</td>
                                <td class="auto-style6">
                                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnLogin" runat="server" Height="26px" Text="Login" Width="125px" Font-Bold="False" Font-Names="Consolas" Font-Size="Medium" OnClick="btnLogin_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
