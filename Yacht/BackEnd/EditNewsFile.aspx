<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="EditNewsFile.aspx.cs" Inherits="Yacht.BackEnd.EditNewsFile" %>

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
            <script>
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
                }
            </script>
    <div class="container mt-5">
        <!-- Row: 容納列元素 -->
        <div class="row d-flex justify-content-center border-1 border-dark p-3">
            <!-- Col: 占 12 列中的 6 列，畫面小於768px時會自動換行 -->
            <div class="col-md-6">
                <!-- News Title -->
                <div class="mb-3">
                    <label for="NewsTitle" class="form-label">News Title</label>
                    <asp:TextBox ID="NewsTitle" Enabled="false" runat="server" CssClass="form-control" />
                </div>
                <!-- News Photos -->
                <div class="mb-3">
                    <p>FileNames</p>
                    <asp:GridView AutoGenerateColumns="false" DataKeyNames="FileId" ID="FileGridView" runat="server" OnRowDeleting="Delete">
                        <Columns>
                            <asp:TemplateField HeaderText="FileName">
                                <ItemTemplate>
                                    <p class=" text-info"><%# Eval("FileName") %></a></p>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete？')" runat="server" Text="Delete" CommandName="Delete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
                    <div class="mb-3">
                        <label for="FileUpload2" class="form-label">Related Files</label>
                        <asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="True" CssClass="form-control" />
                    </div>
                <!-- Submit Button -->
                <div class="mb-3">
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="AddFiles" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
