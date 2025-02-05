<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="EditDealer.aspx.cs" Inherits="Yacht.BackEnd.EditDealer" %>

<asp:Content ID="Content4" ContentPlaceHolderID="EditDealer" runat="server">
    <asp:ScriptManager runat="server" />

<!-- 國家選單 -->
    <p>Country</p>
<asp:DropDownList ID="CountrySwitch" runat="server"
    AutoPostBack="True"  DataTextField="CountryName"
    DataValueField="Id" OnSelectedIndexChanged="CountrySwitch_SelectedIndexChanged">
</asp:DropDownList>
    <p>City</p>
<!-- 城市選單 -->
<asp:DropDownList DataTextField="City"
    DataValueField="Id" ID="CitySwitch" runat="server"></asp:DropDownList>
    <div>
        <p>Profile Photo</p>
        <asp:Image ID="Image1" runat="server" ImageUrl="https://placehold.co/150x150" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="上傳圖片" />
    </div>
    <p>Dealer Name</p>
    <asp:TextBox ID="DealerName" runat="server"></asp:TextBox>
    <p>Company Name</p>
    <asp:TextBox ID="CompanyName" runat="server"></asp:TextBox>
    <p>Address</p>
    <asp:TextBox ID="Address" runat="server"></asp:TextBox>
    <p>Phone</p>
    <asp:TextBox ID="DealerPhone" runat="server"></asp:TextBox>
    <p>Fax</p>
    <asp:TextBox ID="DealerFax" runat="server"></asp:TextBox>
    <p>Cell</p>
    <asp:TextBox ID="DealerCell" runat="server"></asp:TextBox>
    <p>Email</p>
    <asp:TextBox ID="DealerEmail" runat="server"></asp:TextBox>
    <p>CompanyLink</p>
    <asp:TextBox ID="CompanyLink" runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="ConfirmEdit" />
</asp:Content>
