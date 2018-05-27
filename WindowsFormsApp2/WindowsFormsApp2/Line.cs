using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
  public class Line
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public string HtmlColor { get; set; }
        public Line() { }
        public Line(int x1, int y1, int x2, int y2, string cl)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            HtmlColor = cl;
        }
    }
}


