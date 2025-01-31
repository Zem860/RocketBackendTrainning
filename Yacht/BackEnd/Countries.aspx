<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="Yacht.BackEnd.Countries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Countries" runat="server">
    <div id="addArea">
        <asp:TextBox ID="CountryName" runat="server"></asp:TextBox>
        <asp:Button ID="addButton" runat="server" Text="AddCountry" OnClick="addCountry" />
    </div>


    <asp:GridView ID="CountryList" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowEditing="showPanel" OnRowDeleting="deleteCountry" OnRowUpdating="updateCountry">
        <Columns>
            <asp:TemplateField HeaderText="CountryName">
                <ItemTemplate>
                    <%# Eval("CountryName") %></a>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:TextBox>
                </EditItemTemplate>
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
