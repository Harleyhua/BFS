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
    public partial class Door : Form
    {
        public Door()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (Global.G_lh.getlh_connected())
            {
                try
                {
                    string command = $"00000000000600050008FF00";
                    Global.G_lh.sendData_TY(command);
                    //receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("开门指令发送失败: " + ex.Message);
                }

                string responseText = string.Empty;
                byte[] responseBytes = new byte[1024 * 5];
                bool success = Global.G_lh.getResult_TY(ref responseText, ref responseBytes);
                if (success)
                {
                    //receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                    MessageBox.Show("老化柜门已打开！");
                }
            }
            else
            {
                //MessageBox.Show("网络串口未打开，请先连接串口！");

            }
        }
    }
}
