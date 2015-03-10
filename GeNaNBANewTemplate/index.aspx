<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Assembly="obout_Interface" Namespace="Obout.Interface" TagPrefix="cc1" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
       
        
         <br />
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="GAME_SESSION" DataValueField="GAME_SESSION">
         </asp:DropDownList>
                 <br />
         <br />
         <br />
         <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GeNaNBANewConnectionString %>" SelectCommand="SELECT distinct[GAME_SESSION] FROM [playerWarehouse1]"></asp:SqlDataSource>
         <br />
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="GAME_ID" DataSourceID="SqlDataSource1" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
             <Columns>
                 <asp:CommandField ShowSelectButton="True" />
                 <asp:BoundField DataField="GAME_ID" HeaderText="GAME_ID" SortExpression="GAME_ID" />
                 <asp:DynamicField DataField="GAME_DATE" HeaderText="GAME_DATE" />
                 <asp:DynamicField DataField="GAME_TIME" HeaderText="GAME_TIME" />
             </Columns>
             <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
             <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
             <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
             <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
             <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#594B9C" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#33276A" />
         </asp:GridView>
         <br />
         <br />
        <asp:Label ID="detailsLabel" runat="server" /> 
        <asp:Label ID="detailsLabel1" runat="server" /> 
         <br />
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Field Goals" />
         <br />
         <asp:GridView ID="grid" runat="server">
         </asp:GridView>
        <br />
         <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" CssClass="table-responsive" DataSourceID="SqlDataSource2" GridLines="None">
             <Columns>
                 <asp:BoundField DataField="FGM" HeaderText="FGM" SortExpression="FGM" />
                 <asp:BoundField DataField="FGA" HeaderText="FGA" SortExpression="FGA" />
                 <asp:BoundField DataField="FG_PERCENT" HeaderText="FG_PERCENT" SortExpression="FG_PERCENT" />
                 <asp:BoundField DataField="FGM2" HeaderText="FGM2" SortExpression="FGM2" />
                 <asp:BoundField DataField="FIRST_NAME" HeaderText="FIRST_NAME" SortExpression="FIRST_NAME" />
                 <asp:BoundField DataField="LAST_NAME" HeaderText="LAST_NAME" SortExpression="LAST_NAME" />
                 <asp:BoundField DataField="TEAM_NAME" HeaderText="TEAM_NAME" SortExpression="TEAM_NAME" />
                 <asp:BoundField DataField="FGA2" HeaderText="FGA2" SortExpression="FGA2" />
                 <asp:BoundField DataField="FG2_PERCENT" HeaderText="FG2_PERCENT" SortExpression="FG2_PERCENT" />
                 <asp:BoundField DataField="FG3_PERCENT" HeaderText="FG3_PERCENT" SortExpression="FG3_PERCENT" />
                 <asp:BoundField DataField="FGA3" HeaderText="FGA3" SortExpression="FGA3" />
                 <asp:BoundField DataField="FGM3" HeaderText="FGM3" SortExpression="FGM3" />
             </Columns>
             <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
             <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
             <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
             <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
             <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#594B9C" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#33276A" />
         </asp:GridView>
         <br />
         <br />
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GeNaNBANewConnectionString %>" SelectCommand="SELECT DISTINCT GAME_ID, GAME_DATE, GAME_TIME FROM playerWarehouse1 WHERE (GAME_SESSION = @GAME_SESSION)">
             <SelectParameters>
                 <asp:ControlParameter ControlID="DropDownList1" Name="GAME_SESSION" PropertyName="SelectedValue" />
             </SelectParameters>
         </asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GeNaNBANewConnectionString %>" SelectCommand="SELECT [FGM], [FGA], [FG_PERCENT], [FGM2], [FIRST_NAME], [LAST_NAME], [TEAM_NAME], [FGA2], [FG2_PERCENT], [FG3_PERCENT], [FGA3], [FGM3] FROM [playerWarehouse1] WHERE ([GAME_ID] = @GAME_ID)">
             <SelectParameters>
                 <asp:ControlParameter ControlID="GridView1" Name="GAME_ID" PropertyName="SelectedValue" Type="String" />
             </SelectParameters>
         </asp:SqlDataSource>
</form>
</asp:Content>
