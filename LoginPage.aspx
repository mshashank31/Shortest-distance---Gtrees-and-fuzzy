<%@ Page Title="Road Networks" Language="C#" MasterPageFile="~/FuzzyControl.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="h40" style="width: 49px; height: 67px"></td>
            <td class="h60" colspan="2" style="height: 67px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Yu Gothic" Font-Size="X-Large" ForeColor="#3e3a3a" Text="LOGIN PAGE"></asp:Label>
            </td>
            <td class="h60" style="height: 67px"></td>
        </tr>
        <tr>
            <td class="h40" style="width: 49px; height: 56px"></td>
            <td style="width: 428px; text-align: left; height: 56px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Yu Gothic" Font-Size="Large" ForeColor="#3e3a3a" Text="USERNAME:"></asp:Label>
            </td>
            <td style="text-align: left; height: 56px">
                <asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="164px"></asp:TextBox>
            </td>
            <td class="h50" style="height: 56px"></td>
        </tr>
        <tr>
            <td style="width: 49px; height: 52px"></td>
            <td class="auto-style1" style="width: 428px; text-align: left; height: 52px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Yu Gothic" Font-Size="Large" ForeColor="#3e3a3a" Text="PASSWORD:"></asp:Label>
            </td>
            <td style="text-align: left; height: 52px">
                <asp:TextBox ID="TextBox2" runat="server" Height="24px" TextMode="Password" Width="164px"></asp:TextBox>
            </td>
            <td class="h50" style="height: 52px"></td>
        </tr>
        <tr>
            <td style="width: 49px">&nbsp;</td>
            <td class="auto-style1" style="width: 428px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 49px">&nbsp;</td>
            <td class="auto-style1" style="width: 428px; text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Font-Bold="True" Height="33px" OnClick="Button2_Click" Text="Cancel" Width="117px" />
            </td>
            <td style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Font-Bold="True" Height="33px" OnClick="Button1_Click" Text="Login" Width="114px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 49px">&nbsp;</td>
            <td class="auto-style1" style="width: 428px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
</asp:Content>

