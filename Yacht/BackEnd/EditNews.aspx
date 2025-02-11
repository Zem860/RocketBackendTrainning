﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="EditNews.aspx.cs" Inherits="Yacht.BackEnd.EditNews" %>

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
        <!-- Row: 容納列元素 -->
        <div class="row d-flex justify-content-center border-1 border-dark p-3">
            <!-- Col: 占 12 列中的 6 列，畫面小於768px時會自動換行 -->
            <div class="col-md-6">
                <!-- News Title -->
                <div class="mb-3">
                    <label for="NewsTitle" class="form-label">News Title</label>
                    <asp:TextBox ID="NewsTitle" runat="server" CssClass="form-control" />
                </div>

                <!-- News Photos -->
                <div class="mb-3">
                    <p>CoverPhoto</p>
                    <asp:Image ID="PreviewImage" runat="server" Width="300" Height="200" />
                </div>
                <div class="mb-3">
                    <label for="FileUpload1" class="form-label">News Photos</label>
                    <asp:Image ID="Image1" runat="server" class="img-fluid" />
                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" CssClass="form-control" />
                </div>
                <!-- News Content -->
                <div class="mb-3">
                    <label for="editor" class="form-label">News Content</label>
                    <textarea id="editor" name="editor1" class="form-control w-100 h-75"><asp:Literal ID="Literal1" runat="server"></asp:Literal></textarea>
                </div>
                
                <!-- Submit Button -->
                <div class="mb-3">
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="sendEdit" />
                </div>
            </div>
        </div>
    </div>

    <script>

        ClassicEditor.create(document.querySelector('#editor'), {
            licenseKey: 'GPL',
            ckfinder: {
                uploadUrl: 'https://ckeditor.com/apps/ckfinder/3.5.0/core/connector/php/connector.php?command=QuickUpload&type=Files&responseType=json'
            },
            resize_enabled: true,  // 啟用大小調整功能
        }).catch(error => {
            console.error(error);
        });


    </script>
</asp:Content>
