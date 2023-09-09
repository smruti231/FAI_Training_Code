<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddAuthor.aspx.cs" Inherits="BookManagement.Views.AddAuthor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
            <h2 class="text-center" style="background-color: #FF9900">Add Author</h2>
    <div>
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        <br />
        <asp:TextBox ID="txtName" runat="server" placeholder="Author Name" style="color: #996600"></asp:TextBox>
        <br style="color: #996600; background-color: #FFFFFF" />
        <asp:TextBox ID="txtAge" runat="server" placeholder="Age" style="color: #996600"></asp:TextBox>
        <br style="color: #996600; background-color: #FFFFFF" />
        <asp:TextBox ID="txtCountry" runat="server" placeholder="Country" style="color: #996600"></asp:TextBox>
        <br />
        <asp:Button ID="btnAddAuthor" runat="server" Text="Add Author" OnClick="btnAddAuthor_Click" />
        <br />
        <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="Authors.aspx">Back to Authors</asp:HyperLink>
    </div>
    </form>
</asp:Content>
