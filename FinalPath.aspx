<%@ Page Language="C#" MasterPageFile="~/FuzzyControl.master" AutoEventWireup="true" CodeFile="FinalPath.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 100px">
                <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#336666"
                    BorderStyle="Double" BorderWidth="3px" Caption="Best Optimal Route" CellPadding="4"
                    CellSpacing="4" Font-Size="0.8em" ForeColor="Red" OnSelectedIndexChanged="GridView4_SelectedIndexChanged"
                    ShowFooter="True" Width="549px">
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#336666"
                    BorderStyle="Double" BorderWidth="3px" Caption="Best Preferd Route" CellPadding="4"
                    CellSpacing="4" Font-Size="0.8em" ForeColor="Red" OnSelectedIndexChanged="GridView3_SelectedIndexChanged"
                    ShowFooter="True" Width="546px">
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Click Here To Another Route" Height="31px" Width="251px" />
    </asp:Content>

