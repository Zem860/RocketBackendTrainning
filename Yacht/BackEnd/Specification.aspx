<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="Specification.aspx.cs" Inherits="Yacht.BackEnd.Specification" %>
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
    <script>
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
    </script>

    <div class="container mt-4">
        <!-- 標題區 -->
        <div class="mb-3">
            <h2 class="text-primary">
                <asp:Label ID="YachtTitle" runat="server" CssClass="fw-bold"></asp:Label>
            </h2>
            <h4 class="text-secondary">
                <asp:Label ID="SpecTitle" runat="server" CssClass="fw-semibold"></asp:Label>
            </h4>
        </div>

        <!-- 表單區 -->
        <div class="row g-3">
            <div class="col-md-8">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter specification"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Button ID="Button1" runat="server" Text="Add Spec" CssClass="btn btn-info w-100" OnClick="addSpec" />
            </div>
        </div>

        <!-- 按鈕區 -->
        <div class="mt-3">
            <asp:Button ID="Button2" runat="server" Text="Back to Spec Title" CssClass="btn btn-outline-primary me-2" OnClick="BacktoSpecTitle" />
        </div>

        <!-- 表格區 -->
        <div class="mt-4">
            <asp:GridView ID="SpecGridview" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                OnRowEditing="SpecGridview_RowEditing" 
                OnRowUpdating="SpecGridview_RowUpdating"
                OnRowCancelingEdit="SpecGridview_RowCancelingEdit"
                OnRowDeleting="SpecGridview_RowDeleting"
                CssClass="table table-striped table-bordered text-center">
                <Columns>
                    <asp:TemplateField HeaderText="Spec Detail">
                        <ItemTemplate>
                            <asp:Label ID="lblSpecDetail" runat="server" Text='<%# Eval("SpecDetail") %>' CssClass="fw-bold"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditSpecDetail" runat="server" Text='<%# Bind("SpecDetail") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm"
                                CommandName="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-sm"
                                CommandName="Update" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary btn-sm"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"
                                CommandName="Delete" CommandArgument='<%# Eval("Id") %>' 
                                OnClientClick="return confirm('Are you sure you want to delete this item?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

