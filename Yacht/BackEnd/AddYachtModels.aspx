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
    <div class="container w-50 mt-4 p-4 border rounded shadow-sm bg-light">
        <h3 class="text-center mb-4">Add Yacht Model</h3>
        <div class="mb-3 row align-items-center">
            <label for="YachtName" class="col-sm-4 col-form-label fw-bold">Yacht Name</label>
            <div class="col-sm-8">
                <asp:TextBox CssClass="form-control" ID="YachtName" runat="server" placeholder="Enter yacht name"></asp:TextBox>
            </div>
        </div>

        <div class="mb-3 row align-items-center">
            <label for="YachtModel" class="col-sm-4 col-form-label fw-bold">Yacht Model</label>
            <div class="col-sm-8">
                <asp:TextBox CssClass="form-control" ID="YachtModel" runat="server" placeholder="Enter yacht model"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3 row align-items-center d-flex">
            <div class="mb-3 row align-items-center d-flex">
                <label for="YachtModel" class="col-sm-4 col-form-label fw-bold">Yacht Design</label>

                <div class="col-sm-8 d-flex flex-row">
                    <asp:RadioButtonList ID="ModelDesign" runat="server"
                        CssClass="d-flex flex-row gap-3"
                        DataSourceID="SqlDataSource1"
                        DataTextField="DesignType"
                        DataValueField="Id"
                        OnSelectedIndexChanged="rblLatestModel_SelectedIndexChanged"
                        RepeatLayout="Flow"
                        RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </div>
            </div>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:TestConnectionString %>"
                SelectCommand="SELECT Id, DesignType FROM YachtsDesign ORDER BY Id"></asp:SqlDataSource>




            <div class="mb-3 row align-items-center">
                <label for="FileUpload1" class="col-sm-4 col-form-label fw-bold">Ship Photos</label>
                <div class="col-sm-8">
                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" CssClass="form-control" />
                </div>
            </div>

            <div class="text-center">
                <asp:Button ID="Submit" runat="server" CssClass="btn btn-primary px-4 py-2" Text="Submit" OnClick="addModel" />
            </div>
        </div>
</div>
</asp:Content>

