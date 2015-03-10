<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index1.aspx.cs" Inherits="index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <form id="form1" runat="server">
    <p>
        <asp:DropDownList ID="DropDownSeason" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceDropDownSeason" DataTextField="GAME_SESSION" DataValueField="GAME_SESSION">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSourceDropDownSeason" runat="server" ConnectionString="<%$ ConnectionStrings:GeNaNBANewConnectionString %>" SelectCommand="SELECT DISTINCT GAME_SESSION FROM playerWarehouse1"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridGame" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceGridGame" OnSelectedIndexChanged="GridGame_SelectedIndexChanged" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" HorizontalAlign="Center">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="GAME_ID" HeaderText="GAME_ID" SortExpression="GAME_ID" />
                <asp:BoundField DataField="GAME_DATE" HeaderText="GAME_DATE" SortExpression="GAME_DATE" />
                <asp:BoundField DataField="GAME_TIME" HeaderText="GAME_TIME" SortExpression="GAME_TIME" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceGridGame" runat="server" ConnectionString="<%$ ConnectionStrings:GeNaNBANewConnectionString %>" SelectCommand="SELECT DISTINCT GAME_ID, GAME_DATE, GAME_TIME FROM playerWarehouse1 WHERE (GAME_SESSION = @GAME_SESSION)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownSeason" Name="GAME_SESSION" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
</form>

</asp:Content>

