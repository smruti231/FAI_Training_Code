<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="BookManagement.Views.ViewBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
        <h2 class="text-center" style="background-color: #FF9900">View Books</h2>
        <div>
            <label for="txtSearchTitle">Search by Title:</label>
            <asp:TextBox ID="txtSearchTitle" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearchTitle" runat="server" Text="Search by Title" OnClick="btnSearchTitle_Click" />
        </div>
        <br />
        <div>
            <label for="ddlSearchAuthor">Search by Author:</label>
            <asp:DropDownList ID="ddlSearchAuthor" runat="server" AppendDataBoundItems="true">
                <asp:ListItem Text="Select Author" Value="" />
            </asp:DropDownList>
            <asp:Button ID="btnSearchAuthor" runat="server" Text="Search by Author" OnClick="btnSearchAuthor_Click" />
        </div>

        <br />
        <asp:Label ID="lblErrorMessage" Text="text" runat="server" ForeColor="Red" Visible="false" />

        <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="644px" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvBooks_PageIndexChanging" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="AuthorName" HeaderText="Author" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkView" runat="server" Text="View" NavigateUrl='<%# Eval("BookID", "ViewBook.aspx?BookID={0}") %>' />
                        &nbsp;|&nbsp;
                    <asp:HyperLink ID="lnkEdit" runat="server" Text="Edit" NavigateUrl='<%# Eval("BookID", "EditBook.aspx?BookID={0}") %>' />
                        &nbsp;|&nbsp;
                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this book?');" OnClick="lnkDelete_Click" CommandArgument='<%# Eval("BookID") %>'/>
                     
                    
                    </ItemTemplate>
                </asp:TemplateField>
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

    </form>
</asp:Content>


