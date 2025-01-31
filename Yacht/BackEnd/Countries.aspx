<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="Yacht.BackEnd.Countries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Countries" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <Columns>

                 <asp:TemplateField HeaderText="CountryName">
                    <ItemTemplate>
                       <%# Eval("CountryName") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CreatedAt">
                    <ItemTemplate>
                         <%# Eval("CreatedAt") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UpdatedAt">
                    <ItemTemplate>
                         <%# Eval("UpdatedAt") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ops">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Update" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnectionString %>" SelectCommand="SELECT * FROM [Countries]"></asp:SqlDataSource>
</asp:Content>
