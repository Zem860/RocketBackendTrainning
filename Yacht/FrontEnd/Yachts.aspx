<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Yachts.aspx.cs" Inherits="Yacht.FrontEnd.Yachts" %>

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
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Yacht" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="Contact" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="Yachts" runat="server">
    <style>
        .deckImg {
            max-width: 690px;
            width: 100%;
        }

        .left li {
            position: relative;
        }

            .left li a {
                display: block;
                width: 100%;
                height: 100%;
                z-index: 1000;
            }

        /* ✅ 統一大圖區域 (確保 1001x406px) */
        .aspect-ratio-large {
            width: 100%;
            max-width: 1001px;
            height: auto;
            display: flex;
            justify-content: center;
            align-items: center;
            overflow: hidden; /* 防止圖片溢出 */
        }

        /* ✅ 統一縮略圖區域 */
        .ad-thumb-list {
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 5px; /* ✅ 設定縮略圖之間的間距 */
            flex-wrap: nowrap; /* ✅ 防止縮略圖換行 */
            overflow-x: auto; /* ✅ 允許橫向滾動 */
            padding: 10px 0;
        }

        /* ✅ 確保縮略圖大小一致 */
        .aspect-ratio-thumb {
            width: 100px;
            height: 60px;
            object-fit: cover;
            display: block;
            flex-shrink: 0; /* ✅ 防止 flexbox 壓縮圖片 */
            border: 2px solid transparent; /* ✅ 預設邊框 */
            transition: border-color 0.3s ease-in-out;
        }

            /* ✅ 滑鼠懸停時加上邊框效果 */
            .aspect-ratio-thumb:hover {
                border-color: #007bff;
            }
    </style>
    <link href="/Tayanahtml/html/tayana/html/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/Tayanahtml/html/tayana/html/css/reset.css" rel="stylesheet" type="text/css" />
    <%----------------------------------%>
    <link rel="stylesheet" type="text/css" href="/Tayanahtml/html/tayana/html/css/jquery.ad-gallery.css">
    <link href="/Tayanahtml/html/tayana/html/css/homestyle.css" rel="stylesheet" type="text/css" />
    <link href="/Tayanahtml/html/tayana/html/css/reset.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Tayanahtml/html/tayana/html/Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Tayanahtml/html/tayana/html/Scripts/jquery.cycle.all.2.74.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="/Tayanahtml/html/tayana/html/Scripts/jquery.ad-gallery.js"></script>
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
            <img src="/Tayanahtml/html/tayana/html/images/banner01_masks.png" alt="&quot;&quot;" />
        </div>
        <!--遮罩結束-->

        <div class="banner">
            <div id="gallery" class="ad-gallery">
                <div class="ad-image-wrapper">
                </div>
                <div class="ad-controls" style="display: none">
                </div>
                <div class="ad-nav">
                    <div class="ad-thumbs">
                        <ul class="ad-thumb-list">
                            <asp:Repeater ID="ShipImagesRepeater" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href='<%# Eval("Imgs") %>' class="aspect-ratio-large">
                                            <img src='<%# Eval("Imgs") %>' class="aspect-ratio-thumb" />
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="conbg">
            <!--------------------------------左邊選單開始---------------------------------------------------->
            <div class="left">
                <div class="left1">
                    <p><span>YACHTS</span></p>
                    <ul>
                        <asp:Repeater ID="ModelRepeater" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href='<%# "Yachts.aspx?model=" + Eval("Model") + "&pos=overview" %>'>
                                        <%# Eval("Model") %> <%# filterType( Eval("DesignTag")) %>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>
            <!--------------------------------左邊選單結束---------------------------------------------------->

            <!--------------------------------右邊選單開始---------------------------------------------------->
            <div id="crumb">
                <a href="Home.aspx">Home</a> >> <a href="Yachts.aspx">Yachts</a> >><asp:HyperLink ID="breadCrumb" runat="server">
                    <span class="on1">
                        <asp:Label ID="breadCrumbText" runat="server" Text="Label"></asp:Label>
                    </span>
                </asp:HyperLink>
            </div>

            <div class="right">
                <div class="right1">
                    <div class="title">
                        <span>
                            <asp:Label ID="ShipName" runat="server" Text="Label"></asp:Label></span>
                    </div>

                    <!--------------------------------內容開始---------------------------------------------------->

                    <!--次選單-->
                    <div class="menu_y">
                        <ul>
                            <li class="menu_y00">YACHTS</li>
                            <li>
                                <asp:HyperLink ID="btnOverview" runat="server" CssClass="menu_yli01">Overview</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="btnLayout" runat="server" CssClass="menu_yli02">Layout & deck plan</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="btnSpec" runat="server" CssClass="menu_yli03">Specification</asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                    <!--次選單-->
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="Overview" runat="server">
                                    <div class="box1">
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal><br />
                                        <br />

                                    </div>
                                    <div class="box3">
                                        <h4>PRINCIPAL DIMENSION</h4>
                                        <table class="table02">
                                            <tr>
                                                <td class="table02td01">
                                                    <table>
                                                        <asp:Repeater ID="DimensionRepeater" runat="server">
                                                            <ItemTemplate>
                                                                <tr class='<%# (Container.ItemIndex % 2 == 0) ? "tr003" : "" %>'>
                                                                    <th><%# Eval("Key") %></th>
                                                                    <td><%# Eval("Value") %></td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </td>
                                                <td id="imgsection" visible="false" runat="server">
                                                    <asp:Image ID="SailPlanImg" runat="server" CssClass="img-fluid" Width="278px" Height="345px" />
                                                </td>
                                            </tr>
                                        </table>


                                    </div>

                                </asp:View>

                                <asp:View ID="Layout" runat="server">
                                    <div class="title"><span>Layout</span></div>

                                    <div class="box6">
                                        <p>Layout & deck plan</p>
                                        <ul>
                                            <asp:Repeater ID="DeckPlan" runat="server">
                                                <ItemTemplate>
                                                    <li>
                                                        <img class="deckImg" src='<%# Eval("ImgPath") %>' alt="Alternate Text" />
                                                    </li>
                                                </ItemTemplate>

                                            </asp:Repeater>
                                        </ul>
                                    </div>

                                </asp:View>
                                <asp:View ID="Spec" runat="server">
                                    <div class="title"><span>Layout</span></div>

                                    <div class="box5">
                                        <h4>DETAIL SPECIFICATION</h4>

                                        <p>HULL STRUCTURE & DECKS</p>
                                        <ul>
                                            <li>Yanmar 4LHA-HTP 160HP (or equal)</li>
                                            <li>White formica counters in hgalley. Teak veneer ctt</li>
                                            <li>White formica counters in hgalley. Teak veneer c</li>
                                            <li>White formica counters in hgalley. Teak veneer c</li>
                                            <li>WTeak veneer ctte table 0005</li>
                                            <li>WTeak veneer ctte table 0005</li>
                                        </ul>

                                        <p>HULL STRUCTURE & DECKS</p>
                                        <ul>
                                            <li>Yanmar 4LHA-HTP 160HP (or equal)</li>
                                            <li>White formica counters in hgalley. Teak veneer ctt</li>
                                            <li>White formica counters in hgalley. Teak veneer c</li>
                                            <li>White formica counters in hgalley. Teak veneer c</li>
                                            <li>WTeak veneer ctte table 0005</li>
                                            <li>WTeak veneer ctte table 0005</li>
                                        </ul>


                                    </div>
                                </asp:View>
                            </asp:MultiView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <p class="topbuttom">
                        <img src="/Tayanahtml/html/tayana/html/images/top.gif" alt="top" />
                    </p>

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

    <script type="text/javascript">

        $(function () {
            console.log(typeof $.fn.adGallery); // 如果返回 "undefined"，插件未加載

            var galleries = $('.ad-gallery').adGallery();
            galleries[0].settings.effect = 'slide-hori';

        });
    </script>
</asp:Content>
