<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="EditNewsPhoto.aspx.cs" Inherits="Yacht.BackEnd.EditNewsPhoto" %>

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
    <style>
        img {
            width: 100%; /* 讓圖片寬度占滿容器寬度 */
            height: auto; /* 高度自動調整，保持比例 */
            max-width: 209px; /* 限制圖片最大寬度 */
            max-height: 148px; /* 限制圖片最大高度 */
            object-fit: cover; /* 確保圖片適應容器，不會被拉伸 */
        }
    </style>
    <div class="container mt-5">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

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
                    <p>CoverPhoto</p>
                    <asp:Image ID="PreviewImage" runat="server" Width="300" Height="200" />
                </div>
                <div class="mb-3 border border-1 border-dark">
                    <asp:RadioButtonList ID="AllImages" CssClass="d-flex flex-wrap gap-2"
                        RepeatLayout="Flow" RepeatDirection="Horizontal"
                        AutoPostBack="true" runat="server" OnSelectedIndexChanged="changePinUp">
                    </asp:RadioButtonList>
                </div>
                <div class="mb-3">
                    <p>Delete Photos</p>
                    <asp:CheckBoxList ID="DeleteImagesList" runat="server" CssClass="d-flex flex-wrap gap-2">
                    </asp:CheckBoxList>
                    <asp:Button ID="DeleteSelectedBtn" runat="server" CssClass="btn btn-danger mt-2"
                        Text="刪除選取的圖片" OnClick="DeleteSelectedImages" />
                </div>

                <div class="mb-3">
                    <label for="FileUpload1" class="form-label">News Photos</label>
                    <asp:Image ID="Image1" runat="server" class="img-fluid" />
                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" CssClass="form-control" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
