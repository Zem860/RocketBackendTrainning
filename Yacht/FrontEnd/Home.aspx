<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Yacht.FrontEnd.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Home" runat="server">
    <div class="contain">
        <div class="sub">
            <p><a href="#">Home</a></p>
        </div>

        <!--------------------------------選單開始---------------------------------------------------->
        <div class="menu">
            <ul>
                <li class="menuli01"><a href="Yachts.aspx">Yachts</a></li>
                <li class="menuli02"><a href="#">NEWS</a></li>
                <li class="menuli03"><a href="Company.aspx">COMPANY</a></li>
                <li class="menuli04"><a href="#">DEALERS</a></li>
                <li class="menuli05"><a href="Contact.aspx">CONTACT</a></li>
            </ul>
        </div>
        <!--------------------------------選單開始結束---------------------------------------------------->


        <!--遮罩-->
        <div class="bannermasks">
            <img src="/Tayanahtml/html/tayana/html/images/banner00_masks.png" alt="&quot;&quot;" /></div>
        <!--遮罩結束-->
        <!--------------------------------換圖開始---------------------------------------------------->

        <div id="abgne-block-20110111">

            <div class="bd">


                <div class="banner">

                    <ul>
                        <li class="info on"><a href="#">
                            <img src="/Tayanahtml/html/tayana/html/images/banner001b.jpg" /></a><!--文字開始--><div class="wordtitle">TAYANA <span>48</span><br />
                                <p>SPECIFICATION SHEET</p>
                            </div>
                            <!--文字結束-->
                        </li>
                        <li class="info"><a class="slideshow" href="#">
                            <img src="../Tayanahtml/html/tayana/html/images/banner002b.jpg" /></a><!--文字開始--><div class="wordtitle">TAYANA <span>54</span><br />
                                <p>SPECIFICATION SHEET</p>
                            </div>
                            <!--文字結束-->
                            <!--新船型開始  54型才出現其於隱藏 -->
                            <div class="new">
                                <img src="/Tayanahtml/html/tayana/html/images/new01.png" alt="new" /></div>
                            <!--新船型結束-->
                        </li>
                        <li class="info"><a href="#">
                            <img src="/Tayanahtml/html/tayana/html/images/banner003b.jpg" /></a><!--文字開始--><div class="wordtitle">TAYANA <span>37</span><br />
                                <p>SPECIFICATION SHEET</p>
                            </div>
                            <!--文字結束-->
                        </li>
                        <li class="info"><a href="#">
                            <img src="/Tayanahtml/html/tayana/html/images/banner004b.jpg" /></a><!--文字開始--><div class="wordtitle">TAYANA <span>64</span><br />
                                <p>SPECIFICATION SHEET</p>
                            </div>
                            <!--文字結束-->
                        </li>
                        <li class="info"><a href="#">
                            <img src="/Tayanahtml/html/tayana/html/images/banner005b.jpg" /></a><!--文字開始--><div class="wordtitle">TAYANA <span>58</span><br />
                                <p>SPECIFICATION SHEET</p>
                            </div>
                            <!--文字結束-->
                        </li>
                        <li class="info"><a href="#">
                            <img src="/Tayanahtml/html/tayana/html/images/banner006b.jpg" /></a><!--文字開始--><div class="wordtitle">TAYANA <span>55</span><br />
                                <p>SPECIFICATION SHEET</p>
                            </div>
                            <!--文字結束-->
                        </li>
                    </ul>


                    <!--小圖開始-->
                    <div class="bannerimg title">
                        <ul>
                            <li class="on">
                                <div>
                                    <p class="bannerimg_p">
                                        <img src="/Tayanahtml/html/tayana/html/images/i001.jpg" alt="&quot;&quot;" /></p>
                                </div>
                            </li>
                            <li>
                                <div>
                                    <p class="bannerimg_p">
                                        <img src="/Tayanahtml/html/tayana/html/images/i002.jpg" alt="&quot;&quot;" /></p>
                                </div>
                            </li>
                            <li>
                                <div>
                                    <p class="bannerimg_p">
                                        <img src="/Tayanahtml/html/tayana/html/images/i003.jpg" alt="&quot;&quot;" /></p>
                                </div>
                            </li>
                            <li>
                                <div>
                                    <p class="bannerimg_p">
                                        <img src="/Tayanahtml/html/tayana/html/images/i004.jpg" alt="&quot;&quot;" /></p>
                                </div>
                            </li>
                            <li>
                                <div>
                                    <p class="bannerimg_p">
                                        <img src="/Tayanahtml/html/tayana/html/images/i005.jpg" alt="&quot;&quot;" /></p>
                                </div>
                            </li>
                            <li>
                                <div>
                                    <p class="bannerimg_p">
                                        <img src="/Tayanahtml/html/tayana/html/images/i006.jpg" alt="&quot;&quot;" /></p>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <!--小圖結束-->

                </div>
            </div>
        </div>

        <!--------------------------------換圖結束---------------------------------------------------->


        <!--------------------------------最新消息---------------------------------------------------->
        <div class="news">
            <div class="newstitle">
                <p class="newstitlep1">
                    <img src="/Tayanahtml/html/tayana/html/images/news.gif" alt="news" /></p>
                <p class="newstitlep2"><a href="#">More>></a></p>
            </div>

            <ul>
                <!--TOP第一則最新消息-->
                <li>
                    <div class="newstop">
                        <img src="/Tayanahtml/html/tayana/html/images/new_top01.png" alt="&quot;&quot;" /></div>
                    <div class="news01">
                        <div class="news02p1">
                            <p class="news02p1img">
                                <img src="/Tayanahtml/html/tayana/html/images/pit002.jpg" alt="&quot;&quot;" /></p>
                        </div>
                        <p class="news02p2">
                            <span>Tayana 54 CE Certifica..</span>
                            <a href="#">For Tayana 54 entering the EU, CE Certificates are AVAILABLE to ensure conformity to all applicable European ...</a>
                        </p>
                    </div>
                </li>
                <!--TOP第一則最新消息結束-->

                <!--第二則-->
                <li>
                    <div class="news02">
                        <div class="news02p1">
                            <p class="news02p1img">
                                <img src="/Tayanahtml/html/tayana/html/images/pit001.jpg" alt="&quot;&quot;" width="150" /></p>
                        </div>
                        <p class="news02p2">
                            <span>Tayana 58 CE Certifica..</span>
                            <a href="#">For Tayana 58 entering the EU, CE Certificates are AVAILABLE to ensure conformity to all applicable European ...</a>
                        </p>
                    </div>
                </li>
                <!--第二則結束-->

                <li>
                    <div class="news02">
                        <div class="news02p1">
                            <p class="news02p1img">
                                <img src="/Tayanahtml/html/tayana/html/images/pit001.jpg" alt="&quot;&quot;" /></p>
                        </div>
                        <p class="news02p2">
                            <span>Big Cruiser in a Small ..</span>
                            <a href="#">Tayana 37 is our classical product and full of skilful craftsmanship. We only plan to build TWO units in a year.</a>
                        </p>
                    </div>
                </li>
            </ul>
        </div>
        <!--------------------------------最新消息結束---------------------------------------------------->



        <!--------------------------------落款開始---------------------------------------------------->
        <div class="footer">

            <div class="footerp00">
                <a href="#">
                    <img src="/Tayanahtml/html/tayana/html/images/tog.jpg" alt="&quot;&quot;" /></a>
                <p class="footerp001">© 1973-2011 Tayana Yachts, Inc. All Rights Reserved</p>
            </div>
            <div class="footer01">
                <span>No. 60, Hai Chien Road, Chung Men Li, Lin Yuan District, Kaohsiung City, Taiwan, R.O.C.</span><br />
                <span>TEL：+886(7)641-2721</span> <span>FAX：+886(7)642-3193</span><span><a href="mailto:tayangco@ms15.hinet.net">E-mail：tayangco@ms15.hinet.net</a>.</span>
            </div>
        </div>
        <!--------------------------------落款結束---------------------------------------------------->

    </div>
    <script type="text/javascript" src="/Tayanahtml/html/tayana/html/Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Tayanahtml/html/tayana/html/Scripts/jquery.cycle.all.2.74.js"></script>
    <script type="text/javascript">

        $(function () {
            // 先取得 #abgne-block-20110111 , 必要參數及輪播間隔
            var $block = $('#abgne-block-20110111'),
                timrt, speed = 3000;


            // 幫 #abgne-block-20110111 .title ul li 加上 hover() 事件
            var $li = $('.title ul li', $block).hover(function () {
                // 當滑鼠移上時加上 .over 樣式
                $(this).addClass('over').siblings('.over').removeClass('over');
            }, function () {
                // 當滑鼠移出時移除 .over 樣式
                $(this).removeClass('over');
            }).click(function () {
                // 當滑鼠點擊時, 顯示相對應的 li.info
                // 並加上 .on 樣式
                var $this = $(this);
                $this.add($('.bd li.info', $block).eq($this.index())).addClass('on').siblings('.on').removeClass('on');
            });

            // 幫 $block 加上 hover() 事件
            $block.hover(function () {
                // 當滑鼠移上時停止計時器
                clearTimeout(timer);
            }, function () {
                // 當滑鼠移出時啟動計時器
                timer = setTimeout(move, speed);
            });

            // 控制輪播
            function move() {
                var _index = $('.title ul li.on', $block).index();
                _index = (_index + 1) % $li.length;
                $li.eq(_index).click();
                timer = setTimeout(move, speed);

            }

            // 啟動計時器
            timer = setTimeout(move, speed);
        });



        $(document).ready(function () {
            $('.slideshow').cycle({
                fx: 'fade' // choose your transition type, ex: fade, scrollUp, shuffle, etc...
            });
        });
    </script>
</asp:Content>
