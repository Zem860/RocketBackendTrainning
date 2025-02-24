<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="DeckPlan.aspx.cs" Inherits="Yacht.BackEnd.DeckPlan" %>
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
</asp:Content>
<asp:Content ID="Content17" ContentPlaceHolderID="EditShipPhotos" runat="server">
</asp:Content>
<asp:Content ID="Content18" ContentPlaceHolderID="DeckPlan" runat="server">
    <div class="container mt-4">
        <div class="mb-3">
            <label for="YachtModel" class="form-label fw-bold">Select Yacht Model</label>
            <asp:DropDownList ID="YachtModel" AutoPostBack="true" runat="server" CssClass="form-select" OnSelectedIndexChanged="YachtModel_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="card shadow-sm p-4">
            <h5 class="mb-3">Upload Related Files</h5>
            <div class="mb-3">
                <asp:FileUpload ID="ImgUpload" runat="server" AllowMultiple="True" CssClass="form-control" />
            </div>
            <div class="d-flex justify-content-end">
                <asp:Button ID="Submit" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="addImg" />
            </div>
        </div>

        <!-- 已上傳圖片列表 -->
        <div class="card mt-4 shadow-sm">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0">Uploaded Files</h5>
            </div>
            <div class="card-body">
                <asp:GridView AutoGenerateColumns="false" DataKeyNames="Id" ID="DeckGridView" runat="server"
                    CssClass="table table-bordered table-hover text-center">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" CssClass="form-check-input" />
                             <asp:HiddenField ID="hiddenId" runat="server" Value='<%# Eval("Id") %>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="File Name">
                            <ItemTemplate>
                                <img class="img-fluid rounded shadow-sm" style="max-width: 250px;" src="<%# Eval("ImgPath") %>" alt="Image" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- 刪除按鈕 -->
        <div class="d-flex justify-content-end mt-3">
            <asp:Button ID="btnDeleteSelected" runat="server" CssClass="btn btn-danger" 
                Text="Delete Selected" OnClick="btnDeleteSelected_Click" 
                OnClientClick="return confirm('Are you sure you want to delete selected items?')" />
        </div>
    </div>
</asp:Content>

