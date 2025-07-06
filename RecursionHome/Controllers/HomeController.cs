using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using HtmlAgilityPack;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using System.Xml;
using System.Threading;
using System.Web.DynamicData;
using RecursionHome.Models;
using Newtonsoft.Json;


namespace RecursionHome.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StringBuilder sb = new StringBuilder();
            ViewBag.Nine = Nine(9, 9, sb);
            ViewBag.Factorial = Factorial(5);
            ViewBag.PoliceCount = findSum();
            return View();
        }

        public int Factorial(int n)
        {
            if (n ==0)
            {
                return 1;
            } 
            
            return n * Factorial(n - 1);
            
        }


        public string Nine(int i, int j, StringBuilder sb)
        {
            if (i < 1)
            {

                return null; // 結束時不要提早 return sb.ToString()

            }

            if (j < 1)
            {
                sb.AppendLine();
                return Nine(i - 1, 9, sb);
            }

            else
            {
                Nine(i, j - 1, sb); // 遞迴先呼叫
                if (j == 9 && i != 9)
                {
                    sb.Append($"{i}x{j}={i * j},");
                }
                else
                {

                    sb.Append($"{i}x{j}={i * j} ");
                }

            }

            return sb.ToString();
        }



        public int recurseUnit(XElement node)
        {
            int count = 0;

            // 處理當前節點
            //string targetName = node.Element("中文單位名稱")?.Value ?? "無名稱";
            //本來是用targetName.Contains("派出所")|| targetName.Contains("駐點")
            if (!node.Elements("unit").Any())
            {
                count++;
            }

            // 遞迴所有子 <unit>
            foreach (var child in node.Elements("unit"))
            {
                count += recurseUnit(child);
            }

            return count;
        }

        public int findSum()
        {
            string xmlPath = Server.MapPath($"~/{"Tainan City Police"}.xml");
            XDocument xdoc = XDocument.Load(xmlPath);
            var firstUnit = xdoc.Root.Element("unit");
            return recurseUnit(firstUnit);
        }


        public ActionResult About()
        {
            //test change to get data
            string xmlPath = Server.MapPath($"~/{"Tainan City Police"}.xml");
            XDocument xdoc = XDocument.Load(xmlPath);
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (var unit in xdoc.Root.Elements("unit"))
            {
                BuildTree(unit, sb);
            }
            sb.Append("</ul>");

            ViewBag.PoliceTree = sb.ToString();
            return View();

        }
        private void BuildTree(XElement node, StringBuilder sb)
        {
            string nameZh = node.Element("中文單位名稱")?.Value ?? "無名稱";
            string nameEn = node.Element("英文單位名稱")?.Value ?? "";

            sb.Append($"<li>{nameZh} ({nameEn})");

            var children = node.Elements("unit");
            if (children.Any())
            {
                sb.Append("<ul>");
                foreach (var child in children)
                {
                    BuildTree(child, sb); // 遞迴
                }
                sb.Append("</ul>");
            }
            sb.Append("</li>");
        }




        private void SaveNodeAndChildren(PoliceStations node, Model1 db, int? parentId = null)
        {
            node.ParentId = parentId;

            // 清掉 EF 導航屬性，避免追蹤樹狀資料
            node.Parent = null;
            node.Children = null;

            db.PoliceStations.Add(node);
            db.SaveChanges();

            int currentId = node.Id;

            foreach (var child in node.Children ?? new List<PoliceStations>())
            {
                SaveNodeAndChildren(child, db, currentId);
            }
        }



        public void SaveXmlToDatabase(XElement node, Model1 db, int? parentId = null)
        {
            // 建立單位資料
            var station = new PoliceStations
            {
                NameZh = node.Element("中文單位名稱")?.Value ?? "",
                NameEn = node.Element("英文單位名稱")?.Value ?? "",
                ZipCode = node.Element("郵遞區號")?.Value ?? "",
                Address = node.Element("地址")?.Value ?? "",
                Phone = node.Element("電話")?.Value ?? "",
                PointX = decimal.TryParse(node.Element("POINT_X")?.Value, out var x) ? x : (decimal?)null,
                PointY = decimal.TryParse(node.Element("POINT_Y")?.Value, out var y) ? y : (decimal?)null,
                ParentId = parentId // 設定父層 ID
            };

            db.PoliceStations.Add(station);
            db.SaveChanges(); 

            int currentId = station.Id; // 拿到父層 ID 給子層用

            // 遞迴儲存子節點
            foreach (var child in node.Elements("unit"))
            {
                SaveXmlToDatabase(child, db, currentId);
            }
        }


        public void insertPoliceData()
        {
            string xmlPath = Server.MapPath("~/Tainan City Police.xml");
            XDocument xdoc = XDocument.Load(xmlPath);

            using (var db = new Model1())
            {
                var rootNode = xdoc.Root.Element("unit");
                SaveXmlToDatabase(rootNode, db);
            }

            ViewBag.Message = "已寫入資料並建立父子層級";
        }




        public ActionResult Contact()
        {
            using (var db = new Model1())
            {
                var flatList = db.PoliceStations.ToList();

                // 建立 Id → Node 的對應表
                var lookup = flatList.ToDictionary(s => s.Id);

                // 建立 Children
                foreach (var station in flatList)
                {
                    if (station.ParentId != null && lookup.ContainsKey(station.ParentId.Value))
                    {
                        var parent = lookup[station.ParentId.Value];
                        if (parent.Children == null)
                            parent.Children = new List<PoliceStations>();

                        parent.Children.Add(station);
                    }
                }

                // 只挑選 Root 節點（ParentId 為 NULL）
                var rootNodes = flatList.Where(s => s.ParentId == null).ToList();

                // 用匿名物件移除 Parent 避免循環引用
                var result = rootNodes.Select(r => CleanTree(r)).ToList();

                ViewBag.TreeData = JsonConvert.SerializeObject(result);
            }

            return View();
        }

        // 遞迴建立無 Parent 的資料
        private object CleanTree(PoliceStations node)
        {
            return new
            {
                id = node.Id, // 前端 Tree 套件需要 id
                text = node.NameZh, // 前端 Tree 套件需要 text
                children = node.Children?.Select(c => CleanTree(c)).ToList()
            };
        }




    }
}