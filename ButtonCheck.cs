using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    public partial class ButtonCheck : UserControl
    {
        //是否选中
        bool isCheck = true;

        // 文本内容
        private string text = "Check";

        public enum CheckStyle
        {
            style1 = 0,
            style2 = 1,
            style3 = 2

        };
        public ButtonCheck()
        {
            InitializeComponent();

            //设置Style支持透明背景色并且双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;

            this.Cursor = Cursors.Hand;
            this.Size = new Size(87, 27);
        }

        /// 是否选中
        /// </summary>
        public bool Checked
        {
            set { isCheck = value; this.Invalidate(); }
            get { return isCheck; }
        }

        CheckStyle checkStyle = CheckStyle.style1;

        public CheckStyle CheckStyleX
        {
            set { checkStyle = value; this.Invalidate(); }
            get { return checkStyle; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitMapOn = null;
            Bitmap bitMapOff = null;

            if (checkStyle == CheckStyle.style1)
            {
                bitMapOn = Properties.Resources._8;
                bitMapOff = Properties.Resources._6;
            }
            else if(checkStyle == CheckStyle.style2) 
            {
                bitMapOn = Properties.Resources.open;
                bitMapOff = Properties.Resources.close;
            }
            else if (checkStyle == CheckStyle.style3)
            {
                bitMapOn = Properties.Resources.open_2;
                bitMapOff = Properties.Resources.close_2;
            }

            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0, 0, this.Size.Width, this.Size.Height);

            if (isCheck)
            {
                g.DrawImage(bitMapOff, rec);
            }
            else
            {
                g.DrawImage(bitMapOn, rec);
            }
        }

        private void ButtonCheck_Click(object sender, EventArgs e)
        {
            isCheck = !isCheck;
            this.Invalidate();
        }
    }
}
