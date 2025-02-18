<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="YachtsModel.aspx.cs" Inherits="Yacht.BackEnd.YachtsModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Default" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Countries" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Dealers" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="EditDealer" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="AddDealer" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Cities" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="AddNews" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="News" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="EditNews" runat="server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="EditNewsPhoto" runat="server">
</asp:Content>
<asp:Content ID="Content12" ContentPlaceHolderID="EditNewsFile" runat="server">
</asp:Content>
<asp:Content ID="Content13" ContentPlaceHolderID="AddYachtsModel" runat="server">
</asp:Content>
<asp:Content ID="Content14" ContentPlaceHolderID="AddYachtSpec" runat="server">
</asp:Content>
<asp:Content ID="Content15" ContentPlaceHolderID="Specification" runat="server">
</asp:Content>
<asp:Content ID="Content16" ContentPlaceHolderID="YachtsModel" runat="server">
    <p>Yachts Model</p>
    <asp:GridView ID="YachtsGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"

    CssClass="table table-striped table-bordered text-center" OnRowEditing="YachtsGridView_RowEditing" OnRowCancelingEdit="YachtsGridView_RowCancelingEdit" OnRowUpdating="YachtsGridView_RowUpdating">
    <Columns>
<asp:TemplateField HeaderText="SpecDetail">
    <ItemTemplate>
        <asp:Label ID="ModelLabel" runat="server" Text='<%# Eval("Model") %>' CssClass="fw-bold text-info"></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="ModelText" runat="server" Text='<%# Bind("Model") %>' CssClass="form-control"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>

        <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"
                    CommandName="Delete" CommandArgument='<%# Eval("Id") %>' 
                    OnClientClick="return confirm('Are you sure you want to delete this item?');" />
            </ItemTemplate>
        </asp:TemplateField>


            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm"
                        CommandName="Edit" CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" Text="Save" CssClass="btn btn-success btn-sm"
                        CommandName="Update" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary btn-sm"
                        CommandName="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>


    </Columns>
</asp:GridView>
</asp:Content>

