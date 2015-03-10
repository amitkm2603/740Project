<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BoxScore.aspx.cs" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <form id="form1" runat="server">
           
          <asp:Button ID="Field_Goals" runat="server" OnClick="Field_Goals_Click" Text="Field Goals" />
         
          <asp:Button ID="FreeThrows" runat="server" OnClick="FreeThrows_Click" Text="FreeThrows" />
           <asp:Button ID="Rebounds" runat="server" OnClick="Rebounds_Click" Text="Rebounds" />
          <asp:Button ID="Assists" runat="server" OnClick="Assists_Click" Text="Assists" />
          <asp:Button ID="Points_3" runat="server" OnClick="Points_3_Click" Text="3-Points" />
         <asp:Button ID="Steals" runat="server" OnClick="Steals_Click" Text="Steals" />
         <asp:Button ID="Turnovers" runat="server" OnClick="Turnovers_Click" Text="Turnovers" /> 

          <table class="nav-justified">
              <tr>
                  <td><asp:GridView ID="gridteam1" runat="server" BackColor="#CCCCCC"  AllowSorting="True" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Width="322px"> 
             <FooterStyle BackColor="#CCCCCC" />
             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
             <RowStyle BackColor="White" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#808080" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#383838" />
         </asp:GridView>
 </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>
                      

<asp:GridView ID="gridteam2" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" HorizontalAlign="Left" ForeColor="Black" Width="325px">
                          <FooterStyle BackColor="#CCCCCC" />
                          <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                          <RowStyle BackColor="White" HorizontalAlign="Center" />
                          <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F1F1F1" />
                          <SortedAscendingHeaderStyle BackColor="#808080" />
                          <SortedDescendingCellStyle BackColor="#CAC9C9" />
                          <SortedDescendingHeaderStyle BackColor="#383838" />
                      </asp:GridView>
         </td>
                  <td>
                  </td>
                  <td>
                     
                  </td>
              </tr>
          </table>
   </form>
</asp:Content>

