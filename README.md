# 學習筆記

## 2024/10/30
今日的重點是字串的處理、正則表達式、C#的命名空間、封裝、private、public、protected、static的概念。

## 2024/11/6
今日的重點為日期、檔案處理、random。

## 2024/11/13
今日準備考試，目前準備到字串的處理，比較有印象的方法大概是 `Replace()`、`Reverse()`、`Join()`。

- `Replace()` 是把整個字串想抓的那個全部替換，可以連鎖（chain）去改變整個 list。
- `Reverse()` 會回傳一個枚舉，一坨東西，但可以用 `String.Join` 處理，並將結果顯示出來。
- `Join()` 似乎可以處理好一個微陣列的東西。

## 2024/11/15
### 檔案處理
`這個適合處理檔案不大，可以做一次性的讀取`
- `File.ReadAllLines()` --> 會回傳一個陣列，會自動偵測換行符號。
- `File.ReadAllText()` --> 會回傳一整個文字（可以說是文字形陣列）。
- `File.WriteAllLines()` --> 會將一個陣列寫回去，原則上是相反的概念，會自動分行。
- `File.WriteAllText()` --> 會將一個文字（陣列傳回去），想要分行的話要自己加入換行符號和回車符號。

### 檔案寫入附加模式
如果將 `Write` 改成 `Append`，基本上字串不會完全刪掉，新的內容會接在舊的內容之後。

### StreamReader和StreamWriter
`這個適合處理檔案大，需批次作業的狀況`

- 記得在reader讀取一個文件時，writer不能使用同一個路徑。
- StreamReader使用的概念是開一條讀取一條關起來再開下一條(以\n作為分割)，所以會跑回圈while((r = reader.Readline)!=null){...} 這個就是跑一條直到最後面沒東西
- StreamWriter基本上就和你Console.WriteLine或Console.Write的做法一樣，using(StreamWriter writer = File.CreateText(path)){"這裡直接寫正常想要Console.WriteLine的東西，想跑回圈就跑回圈"} [用起來應該算是會比較直覺]。


