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
  <div class="sub"> <p><a href="Default.aspx">Home</a></p></div>
  
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
<div class="bannermasks"><img src="/Tayanahtml/html/tayana/html/images/banner01_masks.png" alt="&quot;&quot;" /></div>
<!--遮罩結束-->

<div class="banner">
<div id="gallery" class="ad-gallery">
      <div class="ad-image-wrapper">
      </div>
      <div class="ad-controls" style="display:none">
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
<li><a href="#">Dynasty 72</a></li>
<li><a href="#">Tayana 64</a></li>
<li><a href="#">Tayana 58</a></li>
<li><a href="#">Tayana 55</a></li>
</ul>



</div>




</div>







<!--------------------------------左邊選單結束----------------------------------------------------> 

<!--------------------------------右邊選單開始----------------------------------------------------> 
<div id="crumb"><a href="#">Home</a> >> <a href="#">Yachts</a> >> <a href="#"><span class="on1">Dynasty 72</span></a></div>
<div class="right"> 
<div class="right1">
  <div class="title"> <span>Dynasty 72</span></div>
  
<!--------------------------------內容開始----------------------------------------------------> 

<!--次選單-->
<div class="menu_y">
<ul>
<li class="menu_y00">YACHTS</li>
<li><a class="menu_yli01" href="#">Interior</a></li>
<li><a class="menu_yli02" href="#">Layout & deck pla</a>n</li>
<li><a class="menu_yli03" href="#">Specification</a></li>
</ul>
</div> 
<!--次選單-->
 
  
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





<p class="topbuttom"><img src="/Tayanahtml/html/tayana/html/images/top.gif" alt="top" /></p>


  
  
  <!--------------------------------內容結束------------------------------------------------------> 
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
</div>


<!--------------------------------落款開始----------------------------------------------------> 
<div class="footer">
<p class="footerp01">© 1973-2011 Tayana Yachts, Inc. All Rights Reserved</p>
<div class="footer01"><span>No. 60, Hai Chien Road, Chung Men Li, Lin Yuan District, Kaohsiung City, Taiwan, R.O.C.</span><br />
<span>TEL：+886(7)641-2721</span> <span>FAX：+886(7)642-3193</span><span><a href="mailto:tayangco@ms15.hinet.net">E-mail：tayangco@ms15.hinet.net</a>.</span></div>
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
