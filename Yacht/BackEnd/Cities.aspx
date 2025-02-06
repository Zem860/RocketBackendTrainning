<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="Cities.aspx.cs" Inherits="Yacht.BackEnd.Cities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Countries" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Dealers" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="EditDealer" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="AddDealer" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Cities" runat="server">
    <script>
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
    </script>

    <!-- 國家選單 -->
    <p>Country</p>
    <asp:RadioButtonList ID="Countries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Countries_SelectedIndexChanged"></asp:RadioButtonList>
    <p>City</p>
    <div id="addArea">
        <asp:TextBox ID="CityName" runat="server"></asp:TextBox>
        <asp:Button ID="AddBtn" runat="server" Text="Add City" OnClick="addCity" />
    </div>

    <!-- 城市選單 -->
    <asp:GridView ID="CityGridView" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" OnRowEditing="CityGridView_RowEditing" OnRowCancelingEdit="CityGridView_RowCancelingEdit" OnRowUpdating="CityGridView_RowUpdating" OnRowDeleting="CityGridView_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="CityName">
                <ItemTemplate>
                    <%# Eval("City") %></a>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TxtCity" runat="server" Text='<%# Bind("City") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ops">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                    <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure you want to delete？')" runat="server" Text="Delete" CommandName="Delete" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Update" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</asp:Content>
