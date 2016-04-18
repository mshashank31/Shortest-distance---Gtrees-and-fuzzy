<%@ Page Language="C#" MasterPageFile="~/FuzzyControl.master" AutoEventWireup="true" CodeFile="Path.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 1018px">
        <tr>
            <td style="width: 52px">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666"
                    BorderStyle="Double" BorderWidth="1px" Caption="Top Best Routes" CellPadding="4"
                    CellSpacing="4" Font-Size="0.8em" ForeColor="Red" Height="72px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    ShowFooter="True" Width="1010px">
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 52px; height: 21px">
                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#336666"
                    BorderStyle="Double" BorderWidth="3px" Caption="Driver Preferd Route" CellPadding="4"
                    CellSpacing="4" Font-Size="0.8em" ForeColor="Red" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                    ShowFooter="True" Width="1009px">
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 52px">
            </td>
        </tr>
        <tr>
            <td style="width: 52px">
            </td>
        </tr>
        <tr>
            <td style="width: 52px">
            </td>
        </tr>
        <tr>
            <td style="width: 52px">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:Button ID="Button1" runat="server" Font-Names="@Kozuka Gothic Pro R" OnClick="Button1_Click"
        Text="Get Best Route" />
    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
</asp:Content>

