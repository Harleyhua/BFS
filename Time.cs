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
    public partial class Time : Form
    {
        public TimeSpan CountdownTime { get; private set; }
        public Time()
        {
            InitializeComponent();
            InitializeControls();
            // 设置窗体启动位置为屏幕中心
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeControls()
        {
            // 初始化控件属性
            // 例如设置 NumericUpDown 的最小值、最大值等
            numericUpDownHours.Minimum = 0;
            numericUpDownHours.Maximum = 24 - 1; // 24小时制，所以最大值是23

            numericUpDownMinutes.Minimum = 0;
            numericUpDownMinutes.Maximum = 59;

            numericUpDownSeconds.Minimum = 0;
            numericUpDownSeconds.Maximum = 59;
        }
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            // 用户点击确定时，获取设置的时间并关闭窗体
            CountdownTime = new TimeSpan(
                (int)numericUpDownHours.Value,
                (int)numericUpDownMinutes.Value,
                (int)numericUpDownSeconds.Value
            );
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
