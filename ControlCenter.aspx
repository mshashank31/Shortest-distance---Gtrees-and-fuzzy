<%@ Page Language="C#" MasterPageFile="~/FuzzyControl.master" AutoEventWireup="true" CodeFile="ControlCenter.aspx.cs" Inherits="Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: 'Times New Roman', Times, serif; font-size: x-large; text-transform: uppercase; font-weight: bold; font-style: italic; color: #FFFFFF;">UPDATE ROAD CONDITIONS HERE<br />
                <br />
                <br />
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td> <table>
            <tr>
                <td style="width: 125px; height: 21px">
                    <asp:Label ID="Label3" runat="server" Font-Names="Times New Roman" Text="Route"
                        Width="98px" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>
                    <br />
                    <br />
                    <br />
                </td>
                <td style="width: 142px; height: 21px"><asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" CausesValidation="True" Font-Names="@Kozuka Gothic Pro R" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Width="142px" Height="20px">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="Label4" runat="server" Text="Distance" Font-Names="Times New Roman" Width="98px" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Height="22px"></asp:Label>
                    <br />
                    <br />
                    <br />
                </td>
                <td style="width: 142px">
                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" Font-Names="@Kozuka Gothic Pro R" Width="142px" Height="19px">
                    <asp:ListItem>Select Value</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px; height: 24px;">
                    <asp:Label ID="Label1" runat="server" Text="Road Condition:-" Font-Names="Times New Roman" Width="215px" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>
                    <br />
                    <br />
                    <br />
                </td>
                <td style="width: 142px; height: 24px;">
                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="@Kozuka Gothic Pro R" Width="143px" Height="17px">
                        <asp:ListItem Value="0">Good</asp:ListItem>
                        <asp:ListItem Value="5">Satisfied</asp:ListItem>
                        <asp:ListItem Value="1">Bad</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="Label2" runat="server" Text="Traffic Condition:-" Width="220px" Font-Names="Times New Roman" Font-Bold="True" Font-Size="X-Large" ForeColor="White"></asp:Label>
                    <br />
                    <br />
                    <br />
                </td>
                <td style="width: 142px">
                    <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="@Kozuka Gothic Pro R" Width="142px" Height="16px">
                        <asp:ListItem Value="0">Good</asp:ListItem>
                        <asp:ListItem Value="5">Satisfied</asp:ListItem>
                        <asp:ListItem Value="1">Bad</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 125px; height: 27px; text-align: right;">
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" Font-Names="@Kozuka Gothic Pro L"
                        OnClick="Button1_Click" Text="Submit" UseSubmitBehavior="False" />
                    <br />
                    <br />
                </td>
                <td colspan="4" style="height: 27px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px; text-align: center;">
                    <asp:Button ID="Button2" runat="server" CausesValidation="False" Font-Names="@Kozuka Gothic Pro L"
                        OnClick="Button2_Click" Text="Update Fuzzy Value" UseSubmitBehavior="False" /></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
        </table></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    &nbsp;
    <div style="z-index: 101; left: 2px; width: 323px; position: absolute; top: 41px;
        height: 118px">
       <%-- <table>
            <tr>
                <td style="width: 125px; height: 21px">
                    <asp:Label ID="Label3" runat="server" Font-Names="@Kozuka Gothic Pro R" Text="Route"
                        Width="98px"></asp:Label></td>
                <td style="width: 142px; height: 21px"><asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" CausesValidation="True" Font-Names="@Kozuka Gothic Pro R" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Width="108px">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="Label4" runat="server" Text="Distance" Font-Names="@Kozuka Gothic Pro R" Width="98px"></asp:Label></td>
                <td style="width: 142px">
                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" Font-Names="@Kozuka Gothic Pro R" Width="108px">
                    <asp:ListItem>Select Value</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px; height: 24px;">
                    <asp:Label ID="Label1" runat="server" Text="Road Condition:-" Font-Names="@Kozuka Gothic Pro R" Width="130px"></asp:Label></td>
                <td style="width: 142px; height: 24px;">
                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="@Kozuka Gothic Pro R" Width="107px">
                        <asp:ListItem Value="0">Good</asp:ListItem>
                        <asp:ListItem Value="5">Satisfied</asp:ListItem>
                        <asp:ListItem Value="1">Bad</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="Label2" runat="server" Text="Traffic Condition:-" Width="181px" Font-Names="@Kozuka Gothic Pro R"></asp:Label></td>
                <td style="width: 142px">
                    <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="@Kozuka Gothic Pro R" Width="107px">
                        <asp:ListItem Value="0">Good</asp:ListItem>
                        <asp:ListItem Value="5">Satisfied</asp:ListItem>
                        <asp:ListItem Value="1">Bad</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 125px; height: 27px">
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" Font-Names="@Kozuka Gothic Pro L"
                        OnClick="Button1_Click" Text="Submit" UseSubmitBehavior="False" /></td>
                <td colspan="4" style="height: 27px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px">
                    <asp:Button ID="Button2" runat="server" CausesValidation="False" Font-Names="@Kozuka Gothic Pro L"
                        OnClick="Button2_Click" Text="Update Fuzzy Value" UseSubmitBehavior="False" /></td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
        </table>--%>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

