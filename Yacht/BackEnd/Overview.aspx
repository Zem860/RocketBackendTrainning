<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" MaintainScrollPositionOnPostBack="true" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="Yacht.BackEnd.Overview" %>

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
    <script>
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
    </script>
    <!-- 遊艇選擇區 -->
    <div class="mb-3">
        <label for="YachtModel" class="form-label fw-bold">Select Yacht Model</label>
        <asp:DropDownList ID="YachtModel" AutoPostBack="true" runat="server" CssClass="form-select" OnSelectedIndexChanged="YachtModel_SelectedIndexChanged"></asp:DropDownList>
    </div>

      <!-- Content（內容）區塊 -->
  <div class="card mb-4">
      <div class="card-header fw-bold">Yacht Content</div>
      <div class="card-body">
          <textarea id="editor" name="editor1" class="form-control w-100" rows="6">
              <asp:Literal ID="Literal1" runat="server"></asp:Literal>
          </textarea>
      </div>
      <div class="card-footer text-end">
          <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary" Text="Save Content" OnClick="addOverviewText" />
      </div>
  </div>
    <!-- 圖片區塊 -->
    <div class="card mb-4">
        <div class="card-header fw-bold">Sail Plan Img</div>
        <div class="card-body text-center">
            <div>
                <asp:Image ID="Image1" runat="server" class="img-fluid rounded mb-3" Width="278px" Height="345px" />
                <asp:Image ID="TempImg" runat="server" class="img-thumbnail mt-2" Visible="false" Width="278px" Height="345px" />

            </div>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control mb-2" />


            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="ReplacePhoto" runat="server" Visible="false" CssClass="btn btn-warning me-2" Text="Show Replace Img" OnClick="Replace" />
                <asp:Button ID="UploadBtn" runat="server" CssClass="btn btn-success" Text="Confirm" OnClick="UploadImgs" />
                <asp:Button ID="DeleteBtn" runat="server" CssClass="btn btn-danger"
                    Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?')" OnClick="DeleteImg" />

            </div>
        </div>
    </div>

    <!-- 檔案區塊 -->
    <div class="card mb-4">
        <div class="card-header fw-bold">Related Files</div>
        <div class="card-body">
            <asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="True" CssClass="form-control mb-3" />
            <asp:Button ID="UploadFileBtn" runat="server" CssClass="btn btn-primary" Text="Upload Files" OnClick="AddFiles" />
        </div>

            <!-- Overview（概覽）區塊 -->
    <div class="card mb-4">
        <div class="card-header fw-bold">Fill In Dimensions</div>
        <div class="card-body">
            <p>Dimension Details</p>
            <p>Dimension Title</p>
            <asp:TextBox ID="dimensionTitle" runat="server" CssClass="form-control mb-2"></asp:TextBox>
            <p>Dimension Content</p>
            <asp:TextBox ID="dimensionContent" runat="server" CssClass="form-control mb-3"></asp:TextBox>

            <asp:Button ID="Submit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="submitDimension" />
        </div>

        <!-- GridView 顯示維度資料 -->
        <div class="card-footer">
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
                    <asp:TemplateField HeaderText="Actions">
                        <HeaderTemplate>
                            <strong>Actions</strong>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-warning">Edit</asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-danger ms-2" OnClientClick="return confirm('Are you sure you want to delete this item?');">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" CssClass="btn btn-sm btn-success">Save</asp:LinkButton>
                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" CssClass="btn btn-sm btn-secondary ms-2">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

        </div>
    </div>

        <!-- 檔案列表區 -->
        <div class="card-footer">
            <asp:GridView ID="FileGridView" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-bordered"  DataKeyNames="FileID" OnRowDeleting="FileGridView_RowDeleting1" >

                <Columns>
                    <asp:TemplateField HeaderText="File Name">
                        <ItemTemplate>
                            <asp:HyperLink ID="FileLink" runat="server" NavigateUrl='<%# Eval("FilePath") %>' Text='<%# Eval("FileName") %>' Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDeleteFile" runat="server" CommandName="Delete"
                                CommandArgument='<%# Eval("FileID") %>' CssClass="btn btn-sm btn-danger"
                                OnClientClick="return confirm('Are you sure you want to delete this file?');">
                            Delete
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
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
                        'sourceEditing'
                    ]
                }
            })
            .catch(error => {
                console.error(error);
            });
    </script>

</asp:Content>
