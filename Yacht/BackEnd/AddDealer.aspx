<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddDealer.aspx.cs" Inherits="Yacht.BackEnd.AddDealer" %>

<asp:Content ID="Content5" ContentPlaceHolderID="AddDealer" runat="server">
    <div>
        <!-- 國家選單 -->
        <p>Country</p>
        <asp:DropDownList ID="countrySwitch" runat="server"
            AutoPostBack="True" DataTextField="CountryName"
            DataValueField="Id" OnSelectedIndexChanged="ChangeCategory">
        </asp:DropDownList>
        <p>City</p>
        <!-- 城市選單 -->

        <p>CityName</p>
        <asp:DropDownList ID="citySwitch" runat="server"
            AutoPostBack="True" DataTextField="City"
            DataValueField="Id">
        </asp:DropDownList>
        <div>
            <p>Profile Photo</p>
            <asp:Image ID="Image1" runat="server" ImageUrl="https://placehold.co/150x150" />
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <p>Dealer Name</p>
        <asp:TextBox ID="DealerName" runat="server"></asp:TextBox>
        <p>Dealer Gender</p>
        <p>Dealer Gender</p>
        <asp:RadioButtonList ID="DealerGender" runat="server">
            <asp:ListItem Text="男" Value="1"></asp:ListItem>
            <asp:ListItem Text="女" Value="0"></asp:ListItem>
        </asp:RadioButtonList>

        <p>Dealer Email</p>
        <asp:TextBox ID="DealerEmail" runat="server"></asp:TextBox>
        <p>Company Name</p>
        <asp:TextBox ID="CompanyName" runat="server"></asp:TextBox>
        <p>Country Name</p>

        <p>Address</p>
        <asp:TextBox ID="Address" runat="server"></asp:TextBox>
        <p>Phone</p>
        <asp:TextBox ID="CompanyPhone" runat="server"></asp:TextBox>
        <p>CompanyLink</p>
        <asp:TextBox ID="CompanyLink" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="AddCompanies" runat="server" Text="Button" OnClick="addData" />
</asp:Content>

