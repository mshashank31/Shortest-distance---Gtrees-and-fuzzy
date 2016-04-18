<%@ Page Title="Road Networks" Language="C#" MasterPageFile="~/FuzzyControl.master" AutoEventWireup="true" CodeFile="SignUpPage.aspx.cs" Inherits="SignUpPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="h30" style="height: 51px"></td>
            <td class="h30" style="height: 51px; width: 124px">&nbsp;</td>
            <td class="h30" colspan="2" style="height: 51px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Yu Gothic" Font-Size="XX-Large" ForeColor="#3e3a3a" Text="SignUp Here"></asp:Label>
            </td>
            <td class="h30" style="height: 51px"></td>
        </tr>
        <tr>
            <td class="h50" style="height: 49px"></td>
            <td class="auto-style1" style="height: 49px; width: 124px">&nbsp;</td>
            <td class="auto-style1" style="height: 49px; width: 392px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Yu Gothic" Font-Size="Large" ForeColor="#3e3a3a" Text="USERNAME:"></asp:Label>
            </td>
            <td class="h50" style="text-align: left; height: 49px">
                <asp:TextBox ID="TextBox1" runat="server" Height="26px" style="margin-left: 0px" Width="194px"></asp:TextBox>
            </td>
            <td class="h50" style="height: 49px"></td>
        </tr>
        <tr>
            <td class="h40" style="height: 49px"></td>
            <td class="auto-style1" style="height: 49px; width: 124px">&nbsp;</td>
            <td class="auto-style1" style="height: 49px; width: 392px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Yu Gothic" Font-Size="Large" ForeColor="#3e3a3a" Text="PASSWORD:"></asp:Label>
            </td>
            <td class="h40" style="height: 49px; text-align: left">
                <asp:TextBox ID="TextBox2" runat="server" Height="26px" style="margin-left: 0px" TextMode="Password" Width="194px"></asp:TextBox>
            </td>
            <td class="h40" style="height: 49px"></td>
        </tr>
        <tr>
            <td class="h30" style="height: 49px"></td>
            <td class="auto-style1" style="height: 49px; width: 124px">&nbsp;</td>
            <td class="auto-style1" style="height: 49px; width: 392px">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Yu Gothic" Font-Size="Large" ForeColor="#3e3a3a" Text="MAIL ID:"></asp:Label>
            </td>
            <td class="h30" style="height: 49px; text-align: left">
                <asp:TextBox ID="TextBox3" runat="server" Height="26px" style="margin-left: 0px" Width="194px"></asp:TextBox>
            </td>
            <td class="h30" style="height: 49px"></td>
        </tr>
        <tr>
            <td class="h40" style="height: 49px"></td>
            <td class="auto-style1" style="height: 49px; width: 124px">&nbsp;</td>
            <td class="auto-style1" style="height: 49px; width: 392px">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Yu Gothic" Font-Size="Large" ForeColor="#3e3a3a" Text="PHONE NO:"></asp:Label>
            </td>
            <td class="h40" style="height: 49px; text-align: left">
                <asp:TextBox ID="TextBox4" runat="server" Height="26px" style="margin-left: 0px" Width="194px"></asp:TextBox>
            </td>
            <td class="h40" style="height: 49px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="col_w200" style="width: 124px">&nbsp;</td>
            <td class="auto-style1" style="width: 392px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="col_w200" style="width: 124px">&nbsp;</td>
            <td class="auto-style1" style="width: 392px; text-align: center">&nbsp;
                <asp:Button ID="Button1" runat="server" Font-Bold="True" Height="37px" OnClick="Button1_Click" Text="CANCEL" Width="148px" />
            </td>
            <td style="text-align: left">
                <asp:Button ID="Button2" runat="server" Font-Bold="True" Height="37px" OnClick="Button2_Click" Text="SUBMIT" Width="148px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
</asp:Content>

