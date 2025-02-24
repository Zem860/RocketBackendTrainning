<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="Yacht.BackEnd.Dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Countries" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Dealers" runat="server">
    <script>
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
    </script>
    <style>
        .dealerPoto {
            max-width: 200px;
            width: 100%;
            height: 150px;
            display: block;
            object-fit: cover;
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
        DataTextField="CountryName"
        DataValueField="Id"
        OnSelectedIndexChanged="ChangeCategory" AutoPostBack="True">
    </asp:DropDownList>
    <asp:DropDownList ID="citySwitch" runat="server" Visible="false"
        AutoPostBack="True" DataTextField="City"
        DataValueField="Id">
    </asp:DropDownList>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnectionString2 %>" ProviderName="<%$ ConnectionStrings:TestConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [Countries]"></asp:SqlDataSource>

    <asp:GridView ID="DealersGrid" AllowPaging="True" DataKeyNames="Id" AutoGenerateColumns="false" runat="server" OnRowDeleting="DealersGrid_RowDeleting" CssClass="table table-bordered table-striped">
        <Columns>
            <asp:TemplateField HeaderText="Company">
                <ItemTemplate>
                    <p class="text-info"><%# Eval("CName") %></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProfilePhoto">
                <ItemTemplate>
                    <img class="dealerPoto" src="<%# Eval("DPhoto") %>" class="img-fluid" alt="Profile Photo">
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dealer">
                <ItemTemplate>
                    <%# Eval("DName") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Country">
                <ItemTemplate>
                    <p><%#Eval("CountryName") %></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CompanyLink">
                <ItemTemplate>
                    <p><%#Eval("CompanyLink") %></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Based City">
                <ItemTemplate>
                    <p><%#Eval("City") %></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telephone">
                <ItemTemplate>
                    <p><%#Eval("Phone") %></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FAX">
                <ItemTemplate>
                    <p><%#Eval("Fax") %></p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cell">
                <ItemTemplate>
                    <p><%#Eval("Cell") %></p>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Ops">
                <ItemTemplate>
                    <div class="operation">
                        <asp:HyperLink ID="btnEdit" CssClass="btn btn-info btn-sm" runat="server" NavigateUrl='<%# "EditDealer.aspx?Id=" + Eval("Id") %>'>
                        Edit
                        </asp:HyperLink>

                        <asp:Button ID="btnDelete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete？')" runat="server" Text="Delete" CommandName="Delete" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <                               
    <asp:Repeater ID="PageRepeater" runat="server">
        <ItemTemplate>
            <span>
                <asp:HyperLink
                    ID="PageLink"
                    runat="server"
                    NavigateUrl='<%# "Dealers.aspx?page=" + Container.DataItem + "&country=" + countrySwitch.SelectedValue %>'>
                                            <%# Container.DataItem %>
                </asp:HyperLink>
            </span>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

