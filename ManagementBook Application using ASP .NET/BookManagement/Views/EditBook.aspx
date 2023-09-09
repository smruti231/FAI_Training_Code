<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="EditBook.aspx.cs" Inherits="BookManagement.Views.EditBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
        <h2 class="text-center" style="background-color: #FF9900">Edit Book</h2>
    <div>
        <table style="width: 568px; height: 323px; background-color: #9966FF">
            <tr>
                <td>Book Title:</td>
                <td><asp:TextBox ID="txtTitle" runat="server" /></td>
            </tr>
            <tr>
                <td>Book Price:</td>
                <td><asp:TextBox ID="txtPrice" runat="server" /></td>
            </tr>
            <tr>
                <td>Book Image:</td>
                <td><asp:FileUpload ID="fileBookImage" runat="server" /></td>
            </tr>
            <tr>
                <td>Author:</td>
                <td>
                    <asp:DropDownList ID="ddlAuthors" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="Select an Author" Value="" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnUpdateBook" runat="server" Text="Update Book" OnClick="btnUpdateBook_Click" style="color: #66FF33" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lblErrorMessage" Text="text" runat="server" ForeColor="Red" Visible="false" /></td>
            </tr>
        </table>
    </div>
        </form>
</asp:Content>