<%@ Page Language="C#" MasterPageFile="~/FuzzyControl.master" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2">
        <tr><td style="font-family: 'Times New Roman', Times, serif; font-size: x-large; text-transform: uppercase; font-weight: bold; font-style: italic; color: #FFFFFF; text-align: center;">SELECT DISTRICT HERE FOR UPLOAD ROAD CONDITIONS<br />
            <br />
            </td></tr>
        <tr>
            <td style="width : 998px; height:500px; background-color: #586b29">
                            &nbsp;<asp:ImageMap ID="ImageMap1" runat="server" Height="583px" HotSpotMode="Navigate"
                                OnClick="ImageMap1_Click1" ImageUrl="~/Images/Untitled-5 copy.jpg"
                                Width="573px">
                            </asp:ImageMap></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
</asp:Content>

