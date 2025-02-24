<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/HomeMaster.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Yacht.FrontEnd.News" %>

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

    <style>
        .newsImg {
            max-width: 100%;
            height: auto;
            object-fit: cover
        }

        .newsContent {
            max-width: 100%;
            word-wrap: break-word; /* 強制換行 */
            word-break: break-all;
            width: 100%;
            max-height: 1em; /* 設定顯示區域的最大高度，根據需要調整 */
            overflow: hidden; /* 隱藏超出部分 */
            text-overflow: ellipsis; /* 超出部分顯示省略號 */
        }
    </style>
    <div class="contain">
        <div class="sub">
            <p><a href="Home.aspx">Home</a></p>
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
                                                            <asp:HyperLink ID="btnNewsDetail"
                                                                runat="server"
                                                                NavigateUrl='<%# "NewsDetail.aspx?pos=" + Eval("Id") %>'>
                                    <img class="newsImg"  src='<%# Eval("NewsImg") %>' alt="&quot;&quot;" />
                                </asp:HyperLink>

                                                        </p>
                                                    </div>
                                                </li>
                                                <li>
                                                    <span><%# Eval("CreatedAt") %></span>
                                                    <br />
                                                    <li class="newsContent"><%# FilterContent(Eval("NewsContent").ToString()) %></li>
                                            </ul>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                        <asp:Repeater ID="PageRepeater" runat="server">
                            <ItemTemplate>
                                <asp:HyperLink ID="PageLink" runat="server"
                                    NavigateUrl='<%# "News.aspx?page=" + Eval("PageNumber") %>'
                                    Text='<%# Eval("PageNumber") %>'
                                    CssClass="btn btn-outline-primary">
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:Repeater>

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
