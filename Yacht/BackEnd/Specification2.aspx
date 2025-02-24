<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="Specification2.aspx.cs" Inherits="Yacht.BackEnd.Specification2" %>

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
</asp:Content>
<asp:Content ID="Content19" ContentPlaceHolderID="TestCk" runat="server">
</asp:Content>
<asp:Content ID="Content20" ContentPlaceHolderID="Overview" runat="server">
</asp:Content>
<asp:Content ID="Content21" ContentPlaceHolderID="SpecChoice" runat="server">
</asp:Content>
<asp:Content ID="Content22" ContentPlaceHolderID="Specification2" runat="server">
    <div class="container py-4">
        <div class="row justify-content-center">
            <div class="col-lg-8 col-md-10">
                <div class="card shadow-sm p-4">
                    <h4 class="mb-3 text-center">Add Yacht Specification</h4>

                    <!-- Yacht Selection -->
                    <div class="mb-3">
                        <label for="YachtDropDown" class="form-label">Yacht Model</label>
<%--                        <asp:DropDownList ID="YachtDropDown" runat="server" DataSourceID="SqlDataSource1"
                            DataTextField="Model" DataValueField="Id" AutoPostBack="true"
                            OnTextChanged="YachtDropDown_TextChanged" CssClass="form-select">
                        </asp:DropDownList>--%>
<%--                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:TestConnectionString %>"
                            SelectCommand="SELECT Id, Model FROM YachtsModel"></asp:SqlDataSource>--%>
                        <asp:DropDownList ID="YachtDropDown" runat="server" AutoPostBack="true" OnTextChanged="YachtDropDown_TextChanged"></asp:DropDownList>
                    </div>

                    <!-- News Content Editor -->
                    <div class="mb-3">
                        <label for="editor" class="form-label">News Content</label>
                        <textarea id="editor" name="editor1" class="form-control" rows="10"><asp:Literal ID="Literal1" runat="server"></asp:Literal></textarea>
                    </div>

                    <!-- Submit Button -->
                    <div class="text-center">
                        <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="sendEdit" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- CKEditor Script -->
    <script>
        ClassicEditor
            .create(document.querySelector('#editor'), {
                licenseKey: 'GPL',
                ckfinder: {
                    uploadUrl: 'https://ckeditor.com/apps/ckfinder/3.5.0/core/connector/php/connector.php?command=QuickUpload&type=Files&responseType=json'
                },
                toolbar: {
                    items: [
                        'ckfinder', '|',
                        'bold', 'italic', 'underline', 'removeFormat', '|',
                        'bulletedList', 'numberedList', '|',
                        'outdent', 'indent', '|',
                        'link', 'insertImage', 'blockQuote', 'insertTable', 'mediaEmbed', '|',
                        'sourceEditing'
                    ]
                }
            })
            .catch(error => {
                console.error(error);
            });
    </script>
</asp:Content>
