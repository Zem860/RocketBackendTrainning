<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestRecipe._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:MultiView ID="RecipeMultiView" runat="server">
        <asp:View ID="Recipe" runat="server">
            <main>
                <ul>
                    <asp:Repeater ID="RecipeRepeater" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href='Default.aspx?id=<%#Eval("Id") %>'><%#Eval("RecipeName") %></a>
                               </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </main>
        </asp:View>
        <asp:View ID="RecipeDetail" runat="server">
            <main>
                <h2>
                   
                    <asp:Label ID="RecipeName" runat="server" Text=''></asp:Label>
                </h2>
                <asp:Image ID="Cover" runat="server" />
                <h3>簡介</h3>
                <p>
                    <asp:Label ID="Intro" runat="server" Text="Label"></asp:Label></p>
                <p>烹調時間</p>
                <p>
                    <asp:Label ID="CookingTime" runat="server" Text="Label"></asp:Label></p>
                <p>份量</p>
                <p>
                    <asp:Label ID="Portion" runat="server" Text="Label"></asp:Label></p>
                <p>教學影片</p>
                <asp:Literal ID="WholeVideo" runat="server"></asp:Literal>
            <asp:HiddenField ID="StartTimeHidden" runat="server" />
        <asp:HiddenField ID="EndTimeHidden" runat="server" />
    </main>

 <script>
     var player;
     var startTime = parseInt(document.getElementById('<%= StartTimeHidden.ClientID %>').value) || 10;
        var endTime = parseInt(document.getElementById('<%= EndTimeHidden.ClientID %>').value) || 20;

     // ✅ 透過 YouTube API 控制播放
     function onYouTubeIframeAPIReady() {
         player = new YT.Player('youtubePlayer', {
             events: {
                 'onReady': onPlayerReady,
                 'onStateChange': onPlayerStateChange
             }
         });
     }

     // ✅ 當播放器準備好時，靜音並強制播放
     function onPlayerReady(event) {
         player.mute(); // 🚀 先靜音，讓 autoplay 生效，瀏覽器會限制如果有聲音不能autoplay
         player.seekTo(startTime, true);
         player.playVideo();
     }

     // ✅ 監聽播放狀態，確保影片在 `startTime - endTime` 內循環
     function onPlayerStateChange(event) {
         if (event.data == YT.PlayerState.PLAYING) {
             checkTime();
         }
     }

     function checkTime() {
         if (player.getCurrentTime() >= endTime) {
             player.seekTo(startTime, true); // ✅ 當影片播放到 `endTime`，強制跳回 `startTime`
         }
         setTimeout(checkTime, 500); // ✅ 每 0.5 秒檢查一次
     }

     // ✅ 載入 YouTube API
     var tag = document.createElement('script');
     tag.src = "https://www.youtube.com/iframe_api";
     var firstScriptTag = document.getElementsByTagName('script')[0];
     firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
    </script>
      
        </asp:View>
    </asp:MultiView>


</asp:Content>
