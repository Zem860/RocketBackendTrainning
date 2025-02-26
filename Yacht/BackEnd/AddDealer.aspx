<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddDealer.aspx.cs" Inherits="Yacht.BackEnd.AddDealer" %>

<asp:Content ID="Content5" ContentPlaceHolderID="AddDealer" runat="server">
    <div class="container mt-4">
        <div class="card p-4 shadow-sm">
            <h2 class="mb-4">Add Dealer</h2>

            <!-- Country Selection -->
            <div class="mb-3">
                <label class="form-label">Country</label>
                <asp:DropDownList ID="countrySwitch" runat="server" CssClass="form-select"
                    AutoPostBack="True" DataTextField="CountryName"
                    DataValueField="Id" OnSelectedIndexChanged="ChangeCategory">
                </asp:DropDownList>
            </div>

            <!-- City Selection -->
            <div class="mb-3">
                <label class="form-label">City</label>
                <asp:DropDownList ID="citySwitch" runat="server" CssClass="form-select"
                    AutoPostBack="True" DataTextField="City"
                    DataValueField="Id">
                </asp:DropDownList>
            </div>

            <!-- Profile Photo -->
            <div class="mb-3">
                <label class="form-label">Profile Photo</label>
                <div class="d-flex align-items-center">
                    <asp:Image ID="Image1" runat="server" CssClass="img-thumbnail me-3" Width="150" Height="150" ImageUrl="https://placehold.co/150x150" />
                    <div class="d-flex flex-column w-100">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                        <asp:Label ID="PhotoLabel" Visible="false" ForeColor="Red" runat="server" Text="Dealer require a photo"></asp:Label>
                    </div>


                    <asp:Button ID="Button1" runat="server" Text="Preview" CssClass="btn btn-secondary ms-2" OnClick="Preview" />
                </div>
            </div>

            <!-- Dealer Information -->
            <div class="mb-3">
                <label class="form-label">Dealer Name</label>
                <asp:TextBox ID="DealerName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="NameLabel" Visible="false" ForeColor="Red" runat="server" Text="Dealer Name is required!"></asp:Label>
            </div>

            <div class="mb-3">
                <label class="form-label">Dealer Gender</label>
                <asp:RadioButtonList ID="DealerGender" runat="server" CssClass="form-check" RepeatDirection="Horizontal">
                    <asp:ListItem Text="男" Value="1"></asp:ListItem>
                    <asp:ListItem Text="女" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="GenderLabel" runat="server" Visible="false" ForeColor="Red" Text="Gender is required!"></asp:Label>
            </div>

            <div class="mb-3">
                <label class="form-label">Phone</label>
                <asp:TextBox ID="DealerPhone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Fax</label>
                <asp:TextBox ID="DealerFax" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Cell</label>
                <asp:TextBox ID="DealerCell" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Dealer Email</label>
                <asp:TextBox ID="DealerEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Company Name</label>
                <asp:TextBox ID="CompanyName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Address</label>
                <asp:TextBox ID="Address" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Company Link</label>
                <asp:TextBox ID="CompanyLink" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Submit Button -->
            <div class="text-end">
                <asp:Button ID="AddCompanies" runat="server" Text="Add Dealer" CssClass="btn btn-primary" OnClick="addData" />
            </div>
        </div>
    </div>
</asp:Content>
