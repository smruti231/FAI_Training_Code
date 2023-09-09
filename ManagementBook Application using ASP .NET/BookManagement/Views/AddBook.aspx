<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="BookManagement.Views.AddBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="text-center" style="background-color: #FF9900">Add a New Book</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <div>
        <form runat="server">
        <table style="width: 648px; height: 292px">
            <tr>
                <td style="background-color: #9999FF">Book Title:</td>
                <td style="background-color: #9999FF"><asp:TextBox ID="txtTitle" runat="server" /></td>
            </tr>
            <tr>
                <td style="background-color: #9999FF">Book Price:</td>
                <td style="background-color: #9999FF"><asp:TextBox ID="txtPrice" runat="server" /></td>
            </tr>
            <tr>
                <td style="background-color: #9999FF">Book Image:</td>
                <td style="background-color: #9999FF"><asp:FileUpload ID="fileBookImage" runat="server" /></td>
            </tr>
            <tr>
                <td style="background-color: #9999FF">Author:</td>
                <td style="background-color: #9999FF">
                    <asp:DropDownList ID="ddlAuthors" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="Select an Author" Value=""/>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="background-color: #9999FF"></td>
                <td style="background-color: #9999FF"><asp:Button ID="btnAddBook" runat="server" Text="Add Book" OnClick="btnAddBook_Click" style="color: #000000; background-color: #CCFF99" /></td>
            </tr>
        </table>
            </form>
    </div>
</asp:Content>

