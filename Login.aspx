<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td><asp:Label ID="lbl1" runat="server" Text="USERNAME"></asp:Label></td>
    <td><asp:TextBox ID="txt1" runat="server"></asp:TextBox></td>
    </tr>
    
    <tr>
    <td><asp:Label ID="lbl2" runat="server" Text="PASSWORD"></asp:Label></td>
    <td><asp:TextBox ID="txt2" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    
    <tr>
    <td><asp:Button ID="btn1" runat="server" Text="LOGIN" onclick="btn1_Click" style="height: 26px" /></td>
    <td><asp:Button ID="btn2" runat="server" Text="CANCEL" onclick="btn2_Click" /></td>
    <td><asp:Button ID="btn3" runat="server" Text="NEWUSER" onclick="btn3_Click" /></td>
    </tr>
    
    
    
    </table>
    </div>
    </form>
</body>
</html>
