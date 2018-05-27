using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int x1 = -1;
        private int y1 = -1;
        private int y2 = -1;
        private int x2 = -1;
        private Pen pen;
        private bool isSaved = false;
        private List<Line> lines = new List<Line>();

        public Form1()
        {
            
            InitializeComponent();
            graphics = panel1.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen = new Pen(Color.Black, 4);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Blue, 4);
        }

        private void Draw(object sender, PaintEventArgs e)
        {

        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
            lines.Add(new Line(x1, y1, x2, y2, ColorTranslator.ToHtml(pen.Color)));
            panel1.Cursor = Cursors.Default;
            isSaved &= false;
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            //TODO: nice drawings      
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Yellow, 4);
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Red, 4);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Green, 4);
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
             pen = new Pen(Color.Black, 4);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSaved) {
                var resultAnswer = MessageBox.Show("Do you want to save?", "Message", MessageBoxButtons.YesNo);
                if (resultAnswer == DialogResult.Yes)
                {
                    onFileSaved_Click(sender, e);
                }
            }
            panel1.Invalidate();
        }

        private void onFileSaved_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "Lines",
                DefaultExt = "xml"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                Serialization.Serialize(saveFileDialog.FileName, lines);
                isSaved = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog {
                FileName = "Lines",
                DefaultExt = "xml"
            };
            if (openFile.ShowDialog() == DialogResult.OK) {
                panel1.Refresh();
                lines.Clear();
                lines = Serialization.Deserialize(openFile.FileName);
                foreach (var item in lines)
                {
                    pen.Color = ColorTranslator.FromHtml(item.HtmlColor);
                    graphics.DrawLine(pen, new Point(item.X1, item.Y1), new Point(item.X2, item.Y2));

                }
            }
        }
    }
}
