2024/10/30今日的重點是字串的處理、正則表達式、C#的命名空間、封裝、private、public、protected、static的概念。\n
2024/11/6今日的重點為日期、檔案處理、random\n
2024/11/13今日準備考試，目前準備到字串的處理，比較有印象的方法大概是Replace(),Reverse(),Join()，Replace是把整個字串想抓的那個全部replace可以chain去改變整個list。reverse會return一個枚舉，一坨東西但是可以用String.Join處理~就顯示出來了。最後join那個辦法似乎可以處理好一微陣列東西。\n
2024/11/15 \n
            //File.ReadAllLines-->回傳一個陣列，會自動偵測\n為分隔符號。
            //File.ReadAllText-- > 回傳一整個文字(可以說是文字形陣列);
            //File.WriteAllLines--->會將一個陣列寫回去。(原則上相反的概念，會自動分行)
            //File.WriteAllText --->會將一個文字(陣列傳回去，想要分行的話要自己家換行和迴車)
            //----若把Write改成Append基本上就是字不會完全刪掉，新的會接在舊的指標後面-------
