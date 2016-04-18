<%@ Page Language="C#" MasterPageFile="~/FuzzyControl.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" Title="Road Networks" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="TABLE1" border="4"  style="width: 1037px">
        <caption>
            <span style="font-family: 'Yu Gothic'; font-size: 25px; text-transform: uppercase; font-weight: 900;  color: #3e3a3a;">Select Source and Destination Route<br />
            <br />
            <br />
            </span></caption>
        <tr>
            <th style="width: 100px; height: 26px; background-color: #7f8284">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label1" runat="server" Font-Names="@Kozuka Gothic Pro R" Text=""
                                Width="99px"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="@Kozuka Gothic Pro R"
                                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Style="left: 1px;
                                top: 10px" Width="145px" AutoPostBack="False">
                            </asp:DropDownList></td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 142px">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 142px; height: 26px;">
                            <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="@Kozuka Gothic Pro R"
                                 OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Style="left: 1px;
                                top: 10px" Width="145px" AutoPostBack="False">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 142px">
                            <br />
                            <asp:Button ID="Button1" runat="server" Font-Names="@Kozuka Gothic Pro R" OnClick="Button1_Click"
                                Text="Find Route" /></td>
                    </tr>
                </table>
            </th>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <table style="width: 1040px">
        <tr>
            <td style="width: 958px; text-align: center;">
                <asp:Label ID="Label3" runat="server" Font-Names="Yu Gothic" Text="POSSIBLE ROUTES"
                    Width="362px" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" ForeColor="#333333"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="border-style: ridge; border-color: inherit; border-width: thin; width: 958px; height: 21px; background-color: #7f8284">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" BorderColor="Silver" BorderStyle="Groove"
                    BorderWidth="2px" CellPadding="2" CellSpacing="2" Font-Bold="False" Font-Names="Yu Gothic"
                    Font-Overline="False" Font-Size="Large" ForeColor="White" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                    Width="1028px" Font-Italic="False" style="text-align: left">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td style="width: 958px; height: 27px">
                
              <asp:Button ID="Button2" runat="server" Font-Names="@Kozuka Gothic Pro R" OnClick="Button2_Click"
                    Text="Submit" />
<asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
    <ContentTemplate>
        <asp:Label ID="Label4" runat="server" ForeColor="Black"/>
    </ContentTemplate>

    <Triggers>
        <asp:AsyncPostBackTrigger controlid="CheckBoxList1" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
               
                
            </td>
        </tr>
    </table>
    
</asp:Content>

