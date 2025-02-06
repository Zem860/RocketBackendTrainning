<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Yacht.BackEnd.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui" />
    <title>Login Page</title>
    <!-- [Favicon] icon -->
    <link rel="icon" href="../assets/images/favicon.svg" type="image/x-icon" />
    <!-- [Google Font] Family -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap" id="main-font-link" />
    <!-- [phosphor Icons] https://phosphoricons.com/ -->
    <link rel="stylesheet" href="../assets/fonts/phosphor/duotone/style.css" />
    <!-- [Tabler Icons] https://tablericons.com -->
    <link rel="stylesheet" href="../assets/fonts/tabler-icons.min.css" />
    <!-- [Feather Icons] https://feathericons.com -->
    <link rel="stylesheet" href="../assets/fonts/feather.css" />
    <!-- [Font Awesome Icons] https://fontawesome.com/icons -->
    <link rel="stylesheet" href="../assets/fonts/fontawesome.css" />
    <!-- [Material Icons] https://fonts.google.com/icons -->
    <link rel="stylesheet" href="../assets/fonts/material.css" />
    <!-- [Template CSS Files] -->
    <link rel="stylesheet" href="../assets/css/style.css" id="main-style-link" />
    <link rel="stylesheet" href="../assets/css/style-preset.css" />
</head>

<body>
    <form id="form1" runat="server">
        <!-- [ Pre-loader ] start -->
        <div class="loader-bg">
            <div class="loader-track">
                <div class="loader-fill"></div>
            </div>
        </div>
        <!-- [ Pre-loader ] End -->

        <div class="auth-main">
            <div class="auth-wrapper v3">
                <div class="auth-form">
                    <div class="card my-5">
                        <div class="card-body">
                            <a href="#" class="d-flex justify-content-center">
                                <img src="/assets/images/yachtLogin.svg" alt="image" class="img-fluid w-25 h-25" />
                            </a>
                            <div class="row">
                                <div class="d-flex justify-content-center">
                                    <div class="auth-header">
                                        <h2 class="text-secondary mt-5"><b>Hi, Welcome Back</b></h2>
                                    </div>
                                </div>
                            </div>
                            <h5 class="my-4 d-flex justify-content-center">Sing in With Account And Password</h5>
                            <div class="form-floating mb-3">
                                <asp:TextBox CssClass="form-control" ID="Account" runat="server"></asp:TextBox>
                                <label for="floatingInput">User Account</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox CssClass="form-control" ID="Password" runat="server"></asp:TextBox>
                                <label for="floatingInput1">Password</label>
                            </div>
                            <div class="d-flex mt-1 justify-content-between">
                                <div class="form-check">
                                    <input class="form-check-input input-primary" type="checkbox" id="customCheckc1" checked="" />
                                    <label class="form-check-label text-muted" for="customCheckc1">Remember me</label>
                                </div>
                                <h5 class="text-secondary">Forgot Password?</h5>
                            </div>
                            <div class="d-grid mt-4">
                                <asp:Button ID="Signin" CssClass="btn btn-secondary" runat="server" Text="Sign In" OnClick="CheckLogin" />
                            </div>
                            <hr />
                            <h5 class="d-flex justify-content-center">Don't have an account?</h5>
                            <div class="d-grid mt-4">
                                <asp:HyperLink ID="HyperLink1"  CssClass="btn btn-secondary"  runat="server" NavigateUrl="Register.aspx">Go Register</asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ Main Content ] end -->
        <!-- Required Js -->
        <script src="../assets/js/plugins/popper.min.js"></script>
        <script src="../assets/js/plugins/simplebar.min.js"></script>
        <script src="../assets/js/plugins/bootstrap.min.js"></script>
        <script src="../assets/js/fonts/custom-font.js"></script>
        <script src="../assets/js/script.js"></script>
        <script src="../assets/js/theme.js"></script>
        <script src="../assets/js/plugins/feather.min.js"></script>
        <script>
            layout_change('light');
        </script>

        <script>
            font_change('Roboto');
        </script>

        <script>
            change_box_container('false');
        </script>

        <script>
            layout_caption_change('true');
        </script>

        <script>
            layout_rtl_change('false');
        </script>

        <script>
            preset_change('preset-1');
        </script>
    </form>

</body>
</html>
