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
            <p><a href="Default.aspx">Home</a></p>
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
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test1.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
                            <li>
                                <a href="/Tayanahtml/html/tayana/html/images/test002.jpg">
                                    <img src="/Tayanahtml/html/tayana/html/images/pit003.jpg">
                                </a>
                            </li>
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
                                    <a href='<%# "Yachts.aspx?model=" + Eval("Model") + "&pos=overview" %>'> <%#Eval("Model")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!--------------------------------左邊選單結束---------------------------------------------------->

            <!--------------------------------右邊選單開始---------------------------------------------------->
            <div id="crumb"><a href="#">Home</a> >> <a href="#">Yachts</a> >> <a href="#"><span class="on1">Dynasty 72</span></a></div>
            <div class="right">
                <div class="right1">
                    <div class="title"><span>Dynasty 72</span></div>

                    <!--------------------------------內容開始---------------------------------------------------->

                    <!--次選單-->
                    <div class="menu_y">
                        <ul>
                            <li class="menu_y00">YACHTS</li>
                            <li>
                                <asp:HyperLink ID="btnOverview" runat="server" CssClass="menu_yli01">Overview</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="btnLayout" runat="server" CssClass="menu_yli02" >Layout & deck plan</asp:HyperLink></li>
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
                                        With the world renowned pedigree combination of Ta Yang Yacht Builders, Andrew Winch Designs, and Bill Dixon Naval Architects, the Tayana Dynasty 72 ranks as an exceptional high performance cruising yacht. Space abounds in the Dynasty 72, with two spacious cockpits and a sunbathing area on the deck. The central cockpit houses twin steering positions with outdoor dining for eight and access forward into the pilothouse. All control and command equipment is readily available for minimal crew handling. The aft cockpit is accessed from the large owner's cabin and provides a pleasant seating area which opens out through a drop-down transom to the bathing platform. The Dynasty is very much a semi-custom yacht. The interior styling, furniture, and fabrics will reflect the owner's ideals and will blend with an extensive range of high quality fittings and equipment. The technical specification of the yacht will be to a very high standard. Three interior styles have been developed by Andrew Winch. Two owner versions each have four staterooms but different positions for the galley; a charter version has six double cabins with en suite heads. All versions have separate crew quarters, and all versions have the magnificent split level pilot house connecting the forward and aft lower accommodation levels. Custom interiors are available to fit the needs of you and your crew. Ta Yang has been constructing first class yachts for many years. The reputation of Chinese craftsmen over thousands of years is renowned, and it is the combination of their skills with modern design and naval architecture that has created the Tayana Dynasty 72.<br />
                                        <br />

                                    </div>
                                    <div class="box3">
                                        <h4>PRINCIPAL DIMENSION</h4>
                                        <table class="table02">
                                            <tr>
                                                <td class="table02td01">
                                                    <table>
                                                        <tr>
                                                            <th>L.O.A.</th>
                                                            <td>72’-0”</td>
                                                        </tr>
                                                        <tr class="tr003">
                                                            <th>L.W.L.</th>
                                                            <td>60’-10”</td>
                                                        </tr>
                                                        <tr>
                                                            <th>Beam</th>
                                                            <td>20’-0”</td>
                                                        </tr>
                                                        <tr class="tr003">
                                                            <th>Draft (Fin Keel)</th>
                                                            <td>8’-6”</td>
                                                        </tr>
                                                        <tr>
                                                            <th>Displacement</th>
                                                            <td>96100lbs</td>
                                                        </tr>
                                                        <tr class="tr003">
                                                            <th>Ballast (Fin Keel)</th>
                                                            <td>24850lbs</td>
                                                        </tr>
                                                        <tr>
                                                            <th>Sail Area (Main + 150% Triangle)<br />
                                                                Main (9.0 oz)<br />
                                                                Stays (9.0 oz)<br />
                                                                No. 1 Genoa (7.2 oz)<br />
                                                                Genoa (150%) (7.2 oz)<br />
                                                                I :<br />
                                                                J :<br />
                                                                P :<br />
                                                                E :</th>
                                                            <td>2748 sq.
                                                                <br />
                                                                ft996 sq. ft<br />
                                                                386 sq. ft<br />
                                                                1167 sq. ft<br />
                                                                1782 sq. ft<br />
                                                                87’-0”<br />
                                                                27’-1.75”<br />
                                                                75’-4”<br />
                                                                26’-0”<br />
                                                            </td>
                                                        </tr>
                                                        <tr class="tr003">
                                                            <th>D/L=191.47Ballast/Displacement</th>
                                                            <td>28.10%</td>
                                                        </tr>
                                                        <tr>
                                                            <th>Exterior Style, Interior Designer</th>
                                                            <td>Andrew Winch</td>
                                                        </tr>
                                                        <tr class="tr003">
                                                            <th>Naval Architect Designer</th>
                                                            <td>Bill Dixon</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <img src="images/ya01.jpg" alt="&quot;&quot;" width="278" height="345" /></td>
                                            </tr>
                                        </table>


                                    </div>

                                </asp:View>

                                <asp:View ID="Layout" runat="server">
                                    <div class="title"><span>Layout</span></div>

                                    <div class="box6">
                                        <p>Layout & deck plan</p>
                                        <ul>
                                            <li>
                                                <img src="/Tayanahtml/html/tayana/html/images/deckplan01.jpg" alt="&quot;&quot;" /></li>
                                            <li>
                                                <img src="/Tayanahtml/html/tayana/html/images/deckplan01.jpg" alt="&quot;&quot;" /></li>
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
