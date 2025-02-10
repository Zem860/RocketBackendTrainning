<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Yacht.BackEnd.News" %>

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
    <style>
        img {
            width: 100%; /* 讓圖片寬度占滿容器寬度 */
            height: auto; /* 高度自動調整，保持比例 */
            max-width: 209px; /* 限制圖片最大寬度 */
            max-height: 148px; /* 限制圖片最大高度 */
            object-fit: cover; /* 確保圖片適應容器，不會被拉伸 */
        }
    </style>
    <div class="container-fluid d-flex justify-content-center">
        <asp:GridView ID="NewsGridView" DataKeyNames="Id" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <p class=" text-info"><%# Eval("NewsTitle") %></a></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProfilePhoto">
                    <ItemTemplate>
                        <img src="<%# Eval("PinUpImg") %>">
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dealer">
                    <ItemTemplate>
                        <%# Eval("NewsContent") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dealer">
                    <ItemTemplate>
                        <%# Eval("CreatedAt") %></a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ops">
                    <ItemTemplate>
                        <div class="operation">

                            <asp:HyperLink ID="btnEdit" CssClass="btn btn-info" runat="server" NavigateUrl='<%# "EditNews.aspx?Id=" + Eval("Id") %>'>
                     Edit
                            </asp:HyperLink>

                            <asp:Button ID="btnDelete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete？')" runat="server" Text="Delete" CommandName="Delete" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
