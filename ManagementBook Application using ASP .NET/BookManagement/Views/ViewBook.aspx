<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ViewBook.aspx.cs" Inherits="BookManagement.Views.ViewBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
    <h2 class="text-center" style="background-color: #FF9900">Book Details</h2>
        <div>
        <asp:Image ID="imgBook" runat="server" Width="260px" Height="310px" />
            <ul>
                <li><span style="color: #FF5050; background-color: #FFFFFF; font-size: medium;">Title: </span>
                    <asp:Label ID="lblTitle" runat="server" style="color: #FF5050; background-color: #FFFFFF; font-size: medium;"></asp:Label>
                </li>
                <li><span style="color: #FF5050; background-color: #FFFFFF; font-size: medium;">Price: </span>
                    <asp:Label ID="lblPrice" runat="server" style="color: #FF5050; background-color: #FFFFFF; font-size: medium;"></asp:Label>
                </li>
                <li><span style="color: #FF5050; background-color: #FFFFFF; font-size: medium;">Author: </span>
                    <asp:Label ID="lblAuthor" runat="server" style="color: #FF5050; background-color: #FFFFFF; font-size: medium;"></asp:Label>
                </li>
            </ul>
    </div>
    <br />
    <div>
        <asp:HyperLink ID="lnkEdit" runat="server" Text="Edit" style="color: #66FFFF; background-color: #FFFFFF; font-size: large;" />
        &nbsp;|&nbsp;
        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this book?');" OnClick="lnkDelete_Click" style="color: #FF0000; background-color: #FFFFFF; font-size: large;" />
        <asp:Label ID="lblErrorMessage" Text="text" runat="server" ForeColor="Red" Visible="false" />
    </div>
        </form>
</asp:Content>

