<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="BookManagement.Views.Author" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
            <h2 class="text-center" style="background-color: #FF9900">Author List</h2>
    <div>
        <!-- Display a list of authors -->
        <asp:GridView ID="GridViewAuthors" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="245px" Width="664px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="AuthorID" HeaderText="Author ID" />
                <asp:BoundField DataField="Name" HeaderText="Author Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:HyperLinkField DataTextField="Name" HeaderText="Details" DataNavigateUrlFormatString="AuthorDetails.aspx?AuthorID={0}" DataNavigateUrlFields="AuthorID" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
    </form>
</asp:Content>
