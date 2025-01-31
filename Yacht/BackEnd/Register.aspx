<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Yacht.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Account" HeaderText="Account" SortExpression="Account" />
                    <asp:BoundField DataField="HashPwd" HeaderText="HashPwd" SortExpression="HashPwd" />
                    <asp:BoundField DataField="Salt" HeaderText="Salt" SortExpression="Salt" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnectionString %>" ProviderName="<%$ ConnectionStrings:TestConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Admins]"></asp:SqlDataSource>
            <asp:TextBox ID="Account" runat="server"></asp:TextBox>
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <asp:Button ID="Submit" runat="server" Text="Register" OnClick="addUser" />
            <asp:Label ID="Error" ForeColor="Red" Visible="false" runat="server" Text="Label"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">HyperLink</asp:HyperLink>
        </div>
    </form>
</body>
</html>
