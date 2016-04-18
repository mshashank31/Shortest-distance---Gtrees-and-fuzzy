<%@ Page Language="C#" MasterPageFile="~/FuzzyControl.master" AutoEventWireup="true" CodeFile="ControlCenter_Login.aspx.cs" Inherits="Default2" Title="Control Center" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large"
        Width="545px" Font-Italic="True" ForeColor="White"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; 
    <br />
    <br />
    &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<center><asp:Login
        ID="Login1" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4"
        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
        ForeColor="#333333" OnAuthenticate="Login1_Authenticate" TextLayout="TextOnTop" Width="311px" style="text-align: center" Height="218px">
        <TextBoxStyle Font-Size="0.8em" />
        <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
    </asp:Login>
        </center>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Contentplaceholder2">
    &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana"
        Font-Size="0.8em" Width="109px">Administrator</asp:Label></asp:Content>

