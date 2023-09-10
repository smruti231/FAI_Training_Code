<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataApp.aspx.cs" Inherits="WebApplication.TEST.DataApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <asp:GridView runat="server" ID="grdProducts" AutoGenerateColumns="False" OnRowCommand="grdProducts_RowCommand" DataKeyNames="ProductId">
                        <Columns>
                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" ReadOnly="True" />
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                            <asp:BoundField DataField="ProductPrice" HeaderText="Product Price" />
                            <asp:BoundField DataField="ProductImage" HeaderText="Product Image" />

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="Delete" CommandName="DeleteProduct" CommandArgument='<%# Eval("ProductId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <p>
                        Enter the Product Name:
                        <asp:TextBox runat="server" ID="txtNewName" />
                    </p>
                    <p>
                        Enter the Product Price:
                        <asp:TextBox runat="server" ID="txtNewCost" TextMode="Number" />
                    </p>
                    <p>
                        Enter the Product Image:
                        <asp:TextBox runat="server" ID="txtNewImage" />
                    </p>
                    <p>
                        <asp:Button Text="Save Changes" ID="btnAdd" runat="server" OnClick="btnAdd_Click" Width="172px" />
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" style="margin-left: 28px" Text="Update Changes" Width="170px" />
                    </p>
                </div>
                <!-- Update section on the right -->
                <div class="col-md-6">
                    <p>
                        Enter the Product ID:
                        <asp:TextBox runat="server" ID="txtId" />
                    </p>
                    <p>
                        Enter the Updated Product Name:
                        <asp:TextBox runat="server" ID="txtUpdatedName" />
                    </p>
                    <p>
                        Enter the Updated Product Price:
                        <asp:TextBox runat="server" ID="txtUpdatedCost" TextMode="Number" />
                    </p>
                    <p>
                        Enter the Updated Product Image:
                        <asp:TextBox runat="server" ID="txtUpdatedImage" />
                    </p>
                    <asp:Label Text="" ForeColor="Red" ID="lblStatus" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>