<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="Yacht.FrontEnd.Dealers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Dealers</title>
    <link href="/Tayanahtml/html/tayana/html/css/homestyle.css" rel="stylesheet" type="text/css" />
    <link href="/Tayanahtml/html/tayana/html/css/reset.css" rel="stylesheet" type="text/css" />
    <style>
        /* 使圖片保持一致的大小 */
        .list02 img {
            width: 100%; /* 讓圖片寬度占滿容器寬度 */
            height: auto; /* 高度自動調整，保持比例 */
            max-width: 209px; /* 限制圖片最大寬度 */
            max-height: 148px; /* 限制圖片最大高度 */
            object-fit: cover; /* 確保圖片適應容器，不會被拉伸 */
        }
        /* 保證地址不會超出容器寬度並且換行 */
        .list02li {
            max-width: 100%;
            word-wrap: break-word; /* 強制換行 */
            word-break: break-all; /* 長字串自動換行 */
        }

        .list02 li {
            max-width: 326px;
            overflow-wrap: break-word; /* 同樣處理超長文字 */
        }

        .menu li a {
            display: block;
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contain">
            <div class="sub">
                <p><a href="Homepage.aspx">Home</a></p>
            </div>

            <!--------------------------------選單開始---------------------------------------------------->
            <div class="menu">
                <ul>
                    <li class="menuli01"><a href="Yachts.aspx">Yachts</a></li>
                    <li class="menuli02"><a href="News.aspx">NEWS</a></li>
                    <li class="menuli03"><a href="Company.aspx">COMPANY</a></li>
                    <li class="menuli04"><a href="Dealers.aspx">DEALERS</a></li>
                    <li class="menuli05"><a href="Contact.aspx">CONTACT</a></li>
                </ul>
            </div>
            <!--------------------------------選單開始結束---------------------------------------------------->

            <!--遮罩-->
            <div class="bannermasks">
                <img src="/Tayanahtml/html/tayana/html/images/DEALERS.jpg" alt="&quot;&quot;" width="967" height="371" />
            </div>
            <!--遮罩結束-->

            <!--<div id="buttom01"><a href="#"><img src="images/buttom01.gif" alt="next" /></a></div>-->

            <!--小圖開始-->
            <!--<div class="bannerimg">
<ul>
<li> <a href="#"><div class="on"><p class="bannerimg_p"><img  src="images/pit003.jpg" alt="&quot;&quot;" /></p></div></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" width="300" /></p>
</a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>

<ul>
<li> <a class="on" href="#"><p class="bannerimg_p"><img  src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <p class="bannerimg_p"><a href="#"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>


</div>-->
            <!--小圖結束-->


            <!--<div id="buttom02"> <a href="#"><img src="images/buttom02.gif" alt="next" /></a></div>-->

            <!--------------------------------換圖開始---------------------------------------------------->

            <div class="banner">
                <ul>
                    <li>
                        <img src="/Tayanahtml/html/tayana/html/images/newbanner.jpg" alt="Tayana Yachts" /></li>
                </ul>

            </div>
            <!--------------------------------換圖結束---------------------------------------------------->




            <div class="conbg">
                <!--------------------------------左邊選單開始---------------------------------------------------->
                <div class="left">
                    <div class="left1">
                        <p><span>DEALERS</span></p>
                        <ul>
                            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink ID="btnEdit" CssClass="btn btn-info" runat="server" NavigateUrl='<%# "Dealers.aspx?country=" + Eval("CountryName") %>'>
                                                <%# Eval("CountryName") %>
                                        </asp:HyperLink>

                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnectionString %>" SelectCommand="SELECT * FROM [Countries]"></asp:SqlDataSource>
                        </ul>
                    </div>
                </div>







                <!--------------------------------左邊選單結束---------------------------------------------------->

                <!--------------------------------右邊選單開始---------------------------------------------------->
                <div id="crumb"><a href="#">Home</a> >> <a href="#">Dealers </a>>> <a href="#"><span class="on1">Unite States</span></a></div>
                <div class="right">
                    <div class="right1">
                        <div class="title"><span>Unite States</span></div>

                        <!--------------------------------內容開始---------------------------------------------------->
                        <div class="box2_list">
                            <ul>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="list02">
                                                <ul>
                                                    <li class="list02li">
                                                        <div>
                                                            <p>
                                                                <img src="<%# ResolveUrl("../BackEnd/" + Eval("DealerPhoto")) %>" />
                                                            </p>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <span><%# Eval("CityName") %></span><br />
                                                        <%# Eval("CompanyName") %><br />
                                                        Contact：<%# (bool)Eval("DealerGender") ? "Mr." : "Ms." %> <%# Eval("DealerName") %><br />
                                                        Address: <%# Eval("CompanyAddress") %><br />
                                                        TEL：<%# Eval("DealerPhone") %><br />
                                                        E-mail：<%# Eval("DealerEmail") %><br />
                                                        <a href="<%# Eval("CompanyLink") %>" target="_blank"><%# Eval("CompanyLink") %></a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>

                            <div class="pagenumber">
                                <asp:Repeater ID="PageRepeater" runat="server">
                                    <ItemTemplate>
                                        <span>
                                            <asp:HyperLink
                                                ID="PageLink"
                                                runat="server"
                                                NavigateUrl='<%# "Dealers.aspx?page=" + Container.DataItem + "&country=" + Request.QueryString["country"] %>'>
                                            <%# Container.DataItem %>
                                            </asp:HyperLink>
                                        </span>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
                            <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>


                        </div>

                        <!--------------------------------內容結束------------------------------------------------------>
                    </div>
                </div>

                <!--------------------------------右邊選單結束---------------------------------------------------->
            </div>


            <!--------------------------------落款開始---------------------------------------------------->
            <div class="footer">
                <p class="footerp01">© 1973-2011 Tayana Yachts, Inc. All Rights Reserved</p>
                <div class="footer01">
                    <span>No. 60, Hai Chien Road, Chung Men Li, Lin Yuan District, Kaohsiung City, Taiwan, R.O.C.</span><br />
                    <span>TEL：+886(7)641-2721</span> <span>FAX：+886(7)642-3193</span><span><a href="mailto:tayangco@ms15.hinet.net">E-mail：tayangco@ms15.hinet.net</a>.</span>
                </div>
            </div>
            <!--------------------------------落款結束---------------------------------------------------->

        </div>

    </form>
</body>
</html>
