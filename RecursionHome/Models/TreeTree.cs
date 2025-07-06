using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RecursionHome.Models
{
    public class TreeTree
    {
        public int id { get; set; }
        public string text { get; set; }
        public List<TreeNode> children { get; set; }
    }
}