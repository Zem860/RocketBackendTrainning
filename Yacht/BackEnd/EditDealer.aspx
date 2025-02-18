<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd/Dashboard.Master" AutoEventWireup="true" CodeBehind="EditDealer.aspx.cs" Inherits="Yacht.BackEnd.EditDealer" %>

<asp:Content ID="Content4" ContentPlaceHolderID="EditDealer" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="container mt-4">
        <div class="card p-4 shadow-sm">
            <h2 class="mb-4">Edit Dealer</h2>

            <!-- Country Selection -->
            <div class="mb-3">
                <label class="form-label">Country</label>
                <asp:DropDownList ID="CountrySwitch" runat="server" CssClass="form-select"
                    AutoPostBack="True" DataTextField="CountryName"
                    DataValueField="Id" OnSelectedIndexChanged="CountrySwitch_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <!-- City Selection -->
            <div class="mb-3">
                <label class="form-label">City</label>
                <asp:DropDownList ID="CitySwitch" runat="server" CssClass="form-select"
                    DataTextField="City" DataValueField="Id">
                </asp:DropDownList>
            </div>

            <!-- Profile Photo -->
            <div class="mb-3">
                <label class="form-label">Profile Photo</label>
                <div class="d-flex align-items-center">
                    <asp:Image ID="Image1" runat="server" CssClass="img-thumbnail me-3" Width="150" Height="150" ImageUrl="https://placehold.co/150x150" />
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                    <asp:Button ID="Button1" runat="server" Text="Upload Image" CssClass="btn btn-secondary ms-2" />
                </div>
            </div>

            <!-- Dealer Information -->
            <div class="mb-3">
                <label class="form-label">Dealer Name</label>
                <asp:TextBox ID="DealerName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Dealer Gender</label>
                <asp:RadioButtonList ID="Gender" runat="server" CssClass="form-check">
                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="0" Text="Female"></asp:ListItem>
                </asp:RadioButtonList>
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
                <label class="form-label">Email</label>
                <asp:TextBox ID="DealerEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Company Link</label>
                <asp:TextBox ID="CompanyLink" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <!-- Submit Button -->
            <div class="text-end">
                <asp:Button ID="Button2" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="ConfirmEdit" />
            </div>
        </div>
    </div>
</asp:Content>
