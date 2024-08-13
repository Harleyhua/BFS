using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    internal class Global
    {
        //设备对象
        public static Ele_Initialize G_ELe = new Ele_Initialize();
        public static Power_Initialize G_Power = new Power_Initialize();
        public static lh_Initialize G_lh = new lh_Initialize();
        public static Relay_Initialize G_Rel = new Relay_Initialize();

        //网络连接
        public static string T1 = Environment.CurrentDirectory;
        public static string G_sysconfig = T1 + "\\sysinfo.tl";
        public static Sysini sysini  = new Sysini();

        public Global()
        {
            if (System.IO.File.Exists(G_sysconfig))
            {
                // 文件已存在
            }
            else
            {
                // 文件不存在，尝试创建
                try
                {
                    System.IO.File.Create(G_sysconfig).Dispose();
                }
                catch (IOException ex)
                {
                    // 创建失败（例如，由于权限问题），返回false
                    MessageBox.Show("system configuring can't load...\r\n" + ex.Message, "ERR:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
        }
    }
}
