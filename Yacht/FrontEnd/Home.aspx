<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Yacht.FrontEnd.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Home" runat="server">
    <style>
        p {
            word-wrap: break-word; /* 確保長單字自動換行 */
            overflow-wrap: break-word; /* 適用於較新瀏覽器 */
        }
        /* 確保 .bannerimg img 小圖顯示完整 */
        .bannerimg img {
            object-fit: contain; /* 避免裁切 */
            width: 100px;
        }

        .newsImg {
            max-width: 100%;
            height: 100%;
            object-fit: cover
        }
        /*

        .banner img {
            object-fit:cover;
            width:100%;
            height:100%;
        }
    </style>
    <div class="contain">
        <div class="sub">
            <p><a href="#">Home</a></p>
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
            <img src="/Tayanahtml/html/tayana/html/images/banner00_masks.png" alt="&quot;&quot;" />
        </div>
        <!--遮罩結束-->
        <!--------------------------------換圖開始---------------------------------------------------->

        <div id="abgne-block-20110111">

            <div class="bd">

                <div class="banner">

                    <ul>
                        <asp:Repeater ID="rptBoats" runat="server">
                            <ItemTemplate>
                                <li class="info <%# Container.ItemIndex == 0 ? "on" : "" %>">
                                    <a href="#">
                                        <img src='<%# Eval("ImageUrl") %>' />
                                    </a>
                                    <div class="wordtitle">
                                        <%# Eval("YachtName") %> <span><%# Eval("Model") %></span><br />
                                        <p>SPECIFICATION SHEET</p>
                                    </div>
                                    <%# 
    Convert.ToInt32(Eval("DesignId")) == 2 
        ? "<div class='new'><img src='/Tayanahtml/html/tayana/html/images/new02.png' alt='new' /></div>" 
        : Convert.ToInt32(Eval("DesignId")) == 3 
            ? "<div class='new'><img src='/Tayanahtml/html/tayana/html/images/new01.png' alt='new' /></div>" 
            : ""
                                    %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>


                    <!--小圖開始-->
                    <div class="bannerimg title">
                        <ul>
                            <asp:Repeater ID="rptThumbnails" runat="server">
                                <ItemTemplate>
                                    <li class='<%# Container.ItemIndex == 0 ? "on" : "" %>'>
                                        <div>
                                            <p class="bannerimg_p">
                                                <img src='<%# Eval("ImageUrl") %>' alt="&quot;&quot;" />
                                            </p>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
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
                    <img src="/Tayanahtml/html/tayana/html/images/news.gif" alt="news" />
                </p>
                <p class="newstitlep2"><a href="News.aspx">More>></a></p>
            </div>

            <ul>
                <!--TOP第一則最新消息-->

                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li>

                            <div class="news01">
                                <div class="newstop" style="display: <%# Convert.ToBoolean(Eval("NewsPinUp")) ? "block" : "none" %>;">
                                    <img src="/Tayanahtml/html/tayana/html/images/new_top01.png" alt="" />
                                </div>


                                <div class="news02p1">
                                    <p class="news02p1img">
                                        <img class="newsImg" src='<%# Eval("PinUpImg") %>' alt="&quot;&quot;" />
                                    </p>
                                </div>
                                <p class="news02p2">
                                    <span><%# Eval("CreatedAt") %></span>
                                    <a href='<%# "NewsDetail.aspx?pos=" + Eval("Id") %>'><%# FilterContent(Eval("NewsContent")) %></a>
                                </p>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>

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
