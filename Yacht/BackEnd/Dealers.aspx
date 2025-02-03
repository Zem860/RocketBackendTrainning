<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="Yacht.BackEnd.Dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Countries" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Dealers" runat="server">
    <style>
        img {
            max-width: 200px;
            width: 100%;
            height: auto;
            display: block;
        }

        .operation {
            display: flex;
            flex-direction: column;
            gap: 30px;
        }
    </style>
    <asp:DropDownList 
        
        ID="countrySwitch" 
        runat="server" 
        DataSourceID="SqlDataSource1" 
        DataTextField="CountryName" 
        DataValueField="Id" 
        AppendDataBoundItems="True"      
        OnSelectedIndexChanged="ChangeCategory" AutoPostBack="True">
        <asp:ListItem Text="All" Value="0" Selected="True">All</asp:ListItem>
    </asp:DropDownList>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnectionString2 %>" ProviderName="<%$ ConnectionStrings:TestConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [Countries]"></asp:SqlDataSource>

    <asp:GridView ID="DealersGrid" DataKeyNames="Id" AutoGenerateColumns="false" runat="server" OnRowDeleting="DealersGrid_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Company">
                <ItemTemplate>
                    <p class=" text-info"><%# Eval("CName") %></a></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProfilePhoto">
                <ItemTemplate>
                    <img src="<%# Eval("DPhoto") %>">
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dealer">
                <ItemTemplate>
                    <%# Eval("DName") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Country">
                <ItemTemplate>
                    <p>
                        <%#Eval("CountryName") %>
                    </p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CompanyEmail">
                <ItemTemplate>
                    <p>
                        <%#Eval("CompanyEmail") %>
                    </p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Based City">
                <ItemTemplate>
                    <p>
                        <%#Eval("City") %>
                    </p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telephone">
                <ItemTemplate>
                    <p>
                        <%#Eval("Phone") %>
                    </p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ops">
                <ItemTemplate>
                    <div class="operation">

                        <asp:HyperLink ID="btnEdit" CssClass="btn btn-info" runat="server" NavigateUrl='<%# "EditDealer.aspx?Id=" + Eval("Id") %>' >
                            Edit
                        </asp:HyperLink>

                        <asp:Button ID="btnDelete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete？')" runat="server" Text="Delete" CommandName="Delete" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
