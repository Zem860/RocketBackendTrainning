<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddYachtModels.aspx.cs" Inherits="Yacht.BackEnd.YachtModels" %>

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
    <div class="container w-75 d-flex justify-content-center flex-column p-2">
        <div class="d-flex gap-5 justify-content-center align-items-center">
            <p>Yacht Model</p>
            <asp:TextBox CssClass="w-25" ID="YachtModel" runat="server"></asp:TextBox>
        </div>

        <div class="d-flex gap-5 justify-content-center align-items-center">
            <p>Latest Yacht Model</p>
            <asp:CheckBox ID="IsNewModel" runat="server" />
        </div>

        <div class="d-flex gap-5 justify-content-center align-items-center">
            <p>Ship Photos</p>
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
        </div>

        <asp:Button ID="Submit" runat="server" Width="100" CssClass="btn btn-primary rounded-2 align-content-lg-center"
            Text="Submit" OnClick="addModel" />
    </div>
</asp:Content>

