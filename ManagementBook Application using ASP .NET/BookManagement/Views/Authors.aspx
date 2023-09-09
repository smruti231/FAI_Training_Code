<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="BookManagement.Views.Authors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
        <h2 class="text-center" style="background-color: #FF9900">Author Management</h2>
    <div>
        <!-- Display a list of authors -->
        <asp:GridView ID="GridViewAuthors" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewAuthors_RowEditing" OnRowCancelingEdit="GridViewAuthors_RowCancelingEdit" OnRowUpdating="GridViewAuthors_RowUpdating" OnRowDeleting="GridViewAuthors_RowDeleting" DataKeyNames="AuthorID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="AuthorID" HeaderText="Author ID" ReadOnly="true"/>
                <asp:TemplateField HeaderText="Author Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblAuthorName" Text='<%# Bind("Name") %>'></asp:Label>
                        <asp:TextBox runat="server" ID="txtEditName" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblAuthorAge" Text='<%# Bind("Age") %>'></asp:Label>
                        <asp:TextBox runat="server" ID="txtEditAge" Text='<%# Bind("Age") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblAuthorCountry" Text='<%# Bind("Country") %>'></asp:Label>
                        <asp:TextBox runat="server" ID="txtEditCountry" Text='<%# Bind("Country") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
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
        <br />
        <asp:Button ID="btnAddAuthor" runat="server" Text="Add Author" OnClick="btnAddAuthor_Click" style="color: #66FF33" />
    </div>

    </form>
</asp:Content>
