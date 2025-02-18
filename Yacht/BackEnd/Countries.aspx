<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="Yacht.BackEnd.Countries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Countries" runat="server">
    <script>
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
    </script>

    <!-- 新增國家區塊 -->
    <div id="addArea" class="mb-3">
        <label for="CountryName" class="form-label">Country Name</label>
        <asp:TextBox ID="CountryName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="addButton" runat="server" CssClass="btn btn-success mt-2" Text="Add Country" OnClick="addCountry" />
    </div>

    <!-- 國家列表表格 -->
    <asp:GridView ID="CountryList" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" DataKeyNames="Id" 
        OnRowEditing="showPanel" OnRowDeleting="deleteCountry" OnRowUpdating="updateCountry" OnRowCancelingEdit="cancelEdit">
        <Columns>
            <asp:TemplateField HeaderText="Country Name">
                <ItemTemplate>
                    <%# Eval("CountryName") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control" Text='<%# Bind("CountryName") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Created At">
                <ItemTemplate>
                    <%# Eval("CreatedAt", "{0:yyyy-MM-dd HH:mm:ss}") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Updated At">
                <ItemTemplate>
                    <%# Eval("UpdatedAt", "{0:yyyy-MM-dd HH:mm:ss}") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Operations">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" CommandName="Edit" />
                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?')" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm" Text="Save" CommandName="Update" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary btn-sm" Text="Cancel" CommandName="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnectionString %>" SelectCommand="SELECT * FROM [Countries]"></asp:SqlDataSource>
</asp:Content>
