<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/HomeMaster.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="Yacht.FrontEnd.NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Home" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Company" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HomeDealers" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="News" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsDetail" runat="server">
    <link href="/Tayanahtml/html/tayana/html/css/homestyle.css" rel="stylesheet" type="text/css" />
    <link href="/Tayanahtml/html/tayana/html/css/reset.css" rel="stylesheet" type="text/css" />
    <style>
        .image-style-side {
            float: right; /* 讓它靠右對齊 */
            margin-left: 20px; /* 增加左邊距離，避免貼太近 */
            max-width: 300px; /* 限制最大寬度 */
        }

        .news-content p {
            word-wrap: break-word; /* 讓長字串換行 */
            overflow-wrap: break-word; /* 讓長字串換行（現代瀏覽器） */
            word-break: break-all; /* 如果字串太長，則強制斷行 */
            white-space: normal; /* 確保內容不會被 `nowrap` 鎖住 */
            border: none;
        }

        .news-content img {
            max-width: 300px;
            width: 100%;
            max-height: 200px;
            height: 100%;
            object-fit: cover;
        }

        .news-content p:empty {
            display: none;
        }
    </style>
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
                    <div class="box3">
                        <h4>
                            <asp:Label ID="NewsTitle" runat="server" Text="Label"></asp:Label>

                        </h4>

                        <asp:Literal ID="News" runat="server"></asp:Literal>
                        <div>
                            <asp:Repeater ID="ImgRepeater" runat="server">
                                <ItemTemplate>

                                    <li style="display:inline">
                                        <asp:HyperLink ID="lnkViewImage"
                                            runat="server"
                                            NavigateUrl='<%# Eval("ImagePath") %>'
                                            Target="_blank">
                                            <img style="max-width:300px; width:100%; object-fit:cover; height:200px;" src="<%# Eval("ImagePath") %>" alt="Click to View" />
                                        </asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>

                    <!--下載開始-->
                    <div class="downloads" id="fileBox" runat="server">
                        <p>
                            <img src="/Tayanahtml/html/tayana/html/images/downloads.gif" alt="&quot;&quot;" />
                        </p>
                        <ul>
                            <asp:Repeater ID="FileRepeater" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink ID="lnkDownload"
                                            runat="server"
                                            NavigateUrl='<%# ResolveUrl("~/NewsFiles/") + Eval("FileName") %>'
                                            Text='<%# Eval("FileName") %>'
                                            Download='<%# Eval("FileName") %>'>
                                        </asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <!--下載結束-->

                    <div class="buttom001">
                        <a href="News.aspx">
                            <img src="/Tayanahtml/html/tayana/html/images/back.gif" alt="&quot;&quot;" width="55" height="28" /></a>
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
