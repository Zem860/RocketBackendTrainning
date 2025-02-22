<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddYachtSpec.aspx.cs" Inherits="Yacht.BackEnd.AddYachtSpec" %>

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
        <script>
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
        </script>
    <div class="container py-4">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-sm p-4">
                    <h4 class="mb-3 text-center">Add Yacht Specification</h4>

                    <!-- Yacht Selection -->
                    <div class="mb-3">
                        <label for="YachtDropDown" class="form-label">Yacht:</label>
                        <asp:DropDownList ID="YachtDropDown" runat="server" DataSourceID="SqlDataSource1"
                            DataTextField="Model" DataValueField="Id" AutoPostBack="true"
                            OnTextChanged="YachtDropDown_TextChanged" CssClass="form-select">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:TestConnectionString %>"
                            SelectCommand="SELECT Id, Model FROM YachtsModel"></asp:SqlDataSource>
                    </div>

                    <!-- Add SpecType -->
                    <div class="mb-3 d-flex align-items-center gap-2">
                        <label for="SpecType" class="form-label">Add SpecType:</label>
                        <asp:TextBox ID="SpecType" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="AddSpecType" runat="server" Text="Add" OnClick="addSpecType" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>

        <!-- SpecType List -->
        <div class="row justify-content-center mt-4">
            <div class="col-md-8">
                <div class="card shadow-sm p-4">
                    <h5 class="mb-3 text-center">Specification List</h5>
                    <asp:GridView ID="SpecHeadGridView" AutoGenerateColumns="false" DataKeyNames="Id" runat="server"
                        OnRowCancelingEdit="SpecHeadGridView_RowCancelingEdit"
                        OnRowDeleting="SpecHeadGridView_RowDeleting"
                        OnRowEditing="SpecHeadGridView_RowEditing"
                        OnRowUpdating="SpecHeadGridView_RowUpdating"
                        CssClass="table table-striped table-bordered text-center">
                        <Columns>



                            <asp:TemplateField HeaderText="SpecType">
                                <ItemTemplate>
                                    <span class="text-info fw-bold">
                                        <asp:HyperLink ID="HyperLink1" runat="server"
                                            NavigateUrl='<%# "Specification.aspx?yactypeId=" + YachtDropDown.SelectedValue + "&specId=" + Eval("Id") %>'>
                                             <%# Eval("SpecType") %>
                                        </asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSpecType" runat="server" Text='<%# Bind("SpecType") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Operations">
                                <ItemTemplate>
                                    <div class="d-flex justify-content-center gap-2">
                                        <asp:Button ID="btnEdit" CssClass="btn btn-warning btn-sm" runat="server"
                                            CommandName="Edit" Text="Edit" />
                                        <asp:Button ID="btnDelete" CssClass="btn btn-danger btn-sm" runat="server"
                                            CommandName="Delete" Text="Delete"
                                            OnClientClick="return confirm('Are you sure you want to delete?');" />
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="d-flex justify-content-center gap-2">
                                        <asp:Button ID="btnUpdate" CssClass="btn btn-success btn-sm" runat="server"
                                            CommandName="Update" Text="Save" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-secondary btn-sm" runat="server"
                                            CommandName="Cancel" Text="Cancel" />
                                    </div>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

