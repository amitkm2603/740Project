<%@ Page Title="" Language="C#" MasterPageFile="~/Masterform.master" AutoEventWireup="true" CodeFile="GameDataUpload.aspx.cs" Inherits="form1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form122" runat="server">
    <div>
    
    </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="URL:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Width="318px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" style="margin-left: 166px" Text="Scrape" class="btn btn-success mws-login-button" />
        </p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="SEASON_1">SEASON 1</asp:ListItem>
                <asp:ListItem Value="SEASON_2">SEASON 2</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Height="120px" Width="436px" TextMode="multiline" ReadOnly="true"></asp:TextBox>
       </p>
    </form>

</asp:Content>

