<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="Yacht.BackEnd.Overview" %>

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

    <div class="mb-3">
        <label for="YachtModel" class="form-label fw-bold">Select Yacht Model</label>
        <asp:DropDownList ID="YachtModel" AutoPostBack="true" runat="server" CssClass="form-select" OnSelectedIndexChanged="YachtModel_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <div class="mb-3">

        <label for="YachtModel" class="form-label fw-bold">Fill In Dimensions</label>

        <p>Dimension Details</p>
        <p>Dimension Title</p>
        <asp:TextBox ID="dimensionTitle" runat="server"></asp:TextBox>
        <p>Dimension Content</p>
        <asp:TextBox ID="dimensionContent" runat="server"></asp:TextBox>
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="submitDimension" />
<asp:GridView ID="DimensionGridView" runat="server"
    AutoGenerateColumns="False"
    OnRowEditing="DimensionGridView_RowEditing"
    OnRowUpdating="DimensionGridView_RowUpdating"
    OnRowCancelingEdit="DimensionGridView_RowCancelingEdit"
    OnRowDeleting="DimensionGridView_RowDeleting"
    DataKeyNames="Key"
    ShowFooter="true"
    CssClass="table table-bordered">

    <Columns>
        <asp:TemplateField HeaderText="Key">
            <ItemTemplate>
                <%# Eval("Key") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtKey" runat="server" Text='<%# Bind("Key") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Value">
            <ItemTemplate>
                <%# Eval("Value") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtValue" runat="server" Text='<%# Bind("Value") %>' CssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:CommandField ShowEditButton="True" ShowCancelButton="True" ShowHeader="True" />

        <asp:CommandField ShowDeleteButton="True" ShowHeader="True" />
    </Columns>

</asp:GridView>


    </div>
    <div>
        <label for="editor" class="form-label">Yacht Content</label>
        <textarea id="editor" name="editor1" class="form-control w-100 h-75"><asp:Literal ID="Literal1" runat="server"></asp:Literal></textarea>

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="addOverviewText" />
    </div>

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
                        'exportPDF', 'exportWord', '|',
                        'findAndReplace', 'selectAll', '|',
                        'heading', '|',
                        'bold', 'italic', 'strikethrough', 'underline', 'code', 'subscript', 'superscript', 'removeFormat', '|',
                        'bulletedList', 'numberedList', 'todoList', '|',
                        'outdent', 'indent', '|',
                        'undo', 'redo',
                        '-',
                        'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', 'highlight', '|',
                        'alignment', '|',
                        'link', 'insertImage', 'blockQuote', 'insertTable', 'mediaEmbed', 'codeBlock', 'htmlEmbed', '|',
                        'specialCharacters', 'horizontalLine', 'pageBreak', '|',
                        'textPartLanguage', '|',
                        'sourceEditing' // 修正 'SourceDialog' 為 'sourceEditing'
                    ]
                }
            })
            .catch(error => {
                console.error(error);
            });
    </script>
</asp:Content>
