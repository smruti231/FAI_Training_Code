
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DeleteBook.aspx.cs" Inherits="BookManagement.Views.DeleteBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
            <h2>Delete Book</h2>
    <div>
        <p>Are you sure you want to delete this book?</p>
      <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this book?');" NavigateUrl='<%# Eval("BookID", "DeleteBook.aspx?BookID={0}") %>' OnClick="lnkDelete_Click" />

        <td><asp:Label ID="lblErrorMessage" Text="text" runat="server" ForeColor="Red" Visible="false" /></td>

    </div>

    </form>
</asp:Content>
