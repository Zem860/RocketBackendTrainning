﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/HomeMaster.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Yacht.FrontEnd.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Home" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Company" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HomeDealers" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="News" runat="server">
    <link href="/Tayanahtml/html/tayana/html/css/homestyle.css" rel="stylesheet" type="text/css" />
    <link href="/Tayanahtml/html/tayana/html/css/reset.css" rel="stylesheet" type="text/css" />
    <div class="contain">
        <div class="sub">
            <p><a href="#">Home</a></p>
        </div>

        <!--------------------------------選單開始---------------------------------------------------->
        <div class="menu">
            <ul>
                <li class="menuli01"><a href="#">Yachts</a></li>
                <li class="menuli02"><a href="#">NEWS</a></li>
                <li class="menuli03"><a href="#">COMPANY</a></li>
                <li class="menuli04"><a href="#">DEALERS</a></li>
                <li class="menuli05"><a href="#">CONTACT</a></li>
            </ul>
        </div>
        <!--------------------------------選單開始結束---------------------------------------------------->

        <!--遮罩-->
        <div class="bannermasks">
            <img src="/Tayanahtml/html/tayana/html/images/banner02_masks.png" alt="&quot;&quot;" />
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
                    <p><span>NEWS</span></p>
                    <ul>
                        <li><a href="#">News & Events</a></li>

                    </ul>



                </div>




            </div>







            <!--------------------------------左邊選單結束---------------------------------------------------->

            <!--------------------------------右邊選單開始---------------------------------------------------->
            <div id="crumb"><a href="#">Home</a> >> <a href="#">News </a>>> <a href="#"><span class="on1">News & Events</span></a></div>
            <div class="right">
                <div class="right1">
                    <div class="title"><span>News & Events</span></div>

                    <!--------------------------------內容開始---------------------------------------------------->

                    <div class="box2_list">
                        <ul>


                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>

                                    <li>
                                        <div class="list01">
                                            <ul>
                                                <li>
                                                    <div>
                                                        <p>
                                                            <img src=<%# Eval("NewsImg") %>  alt="&quot;&quot;" />
                                                        </p>
                                                    </div>
                                                </li>
                                                <li><span><%# Eval("CreatedAt") %></span><br />
                                                    <%# Eval("Title") %></li>
                                                <li><%# Eval("NewsContent") %></li>
                                            </ul>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>







                            <li>
                                <div class="list01">
                                    <ul>
                                        <li>
                                            <div>
                                                <p>
                                                    <img src="/Tayanahtml/html/tayana/html/images/pit006.jpg" alt="&quot;&quot;" width="300" />
                                                </p>
                                            </div>
                                        </li>
                                        <li><span>2012-01-28</span><br />
                                            Tayana 58 CE Certificates are available</li>
                                    </ul>
                                </div>
                            </li>
                        </ul>

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
</asp:Content>
