<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AuthorDetails.aspx.cs" Inherits="BookManagement.Views.AuthorDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <form runat="server">
               <h2 class="text-center" style="background-color: #FF9900">Author Details</h2>
    <div>
        <ul>
            <li><b>
                <asp:Label ID="lblAuthorName" runat="server" style="color: #FF9966; background-color: #FFFFFF;"></asp:Label>
                <br style="color: #FF9966; background-color: #FFFFFF;" />
                <asp:Label ID="lblAuthorAge" runat="server" style="color: #FF9966; background-color: #FFFFFF;"></asp:Label>
                <br style="color: #FF9966; background-color: #FFFFFF;" />
                <asp:Label ID="lblAuthorCountry" runat="server" style="color: #FF9966; background-color: #FFFFFF;"></asp:Label>
                <br style="color: #CC00FF" /></b></li>
            <li style="font-size: medium; color: #FF6666">Books by this Author:</li>
        </ul>
        <asp:GridView ID="GridViewBooks" runat="server" AutoGenerateColumns="False" OnRowDataBound = "GridViewBooks_RowDataBound">
            <Columns>
                <asp:BoundField DataField="BookID" HeaderText="Book ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:TemplateField HeaderText="Book Image">
                    <ItemTemplate>
                        <asp:Image ID="imgBook" runat="server" Width="100" Height="150" />
                        <br />
                        <asp:Literal ID="litImageName" runat="server" Text='<%# Eval("BookImage") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    </form>
</asp:Content>
