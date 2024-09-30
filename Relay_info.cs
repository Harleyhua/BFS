using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    public partial class Relay_info : Form
    {
        public TcpClient client = new TcpClient();
        public NetworkStream networkStream;
        private bool isReceiving = false;
        private ManualResetEvent readCompleteEvent;
        public string received;
        public Relay_info()
        {
            InitializeComponent();
            InitializeClient();
        }

        private void InitializeClient()
        {
            client = new TcpClient();
            networkStream = null;
            readCompleteEvent = new ManualResetEvent(false);
        }

        private void Relay_info_Load(object sender, EventArgs e)
        {
            //连接方式框默认选择第一个
            if (Connect_Way.Items.Count > 0)
            {
                Connect_Way.SelectedIndex = 0;
            }

            //读取配置文件
            HostAdress.Text = Global.sysini.Get_Value("Relay_IP");
            hostPort.Text = Global.sysini.Get_Value("Relay_Port");

            //连接状态
            if (Global.G_Rel.getRelay_connected())
            {
                connect.Enabled = false;
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (!connect.Enabled)
            {
                return;
            }
            connect.Enabled = false;

            // 重置 client 对象
            client = new TcpClient();

            Global.G_Rel.connect_TCP();
            receivingBox.Items.Add($"{DateTime.Now} 继电器已连接！");

            if (Connect_Way.Text == "TCP网络" && HostAdress.Text != "10.10.106.241")
            {
                if (string.IsNullOrEmpty(HostAdress.Text) || string.IsNullOrEmpty(hostPort.Text))
                {
                    MessageBox.Show("地址或端口不能为空！");
                    return;
                }

                try
                {
                    client.Connect(HostAdress.Text, int.Parse(hostPort.Text));
                    networkStream = client.GetStream();
                    connect.Enabled = false;
                    disconnect.Enabled = true;
                    receivingBox.Items.Add($"{DateTime.Now} 继电器已连接！");

                    //触发保存地址(配置文件)
                    Global.sysini.Updata_Value("Relay_IP", this.HostAdress.Text);
                    Global.sysini.Updata_Value("Relay_Port", this.hostPort.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接失败: " + ex.Message);
                }
                
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            if (Global.G_Rel.getRelay_connected())
            {
                Global.G_Rel.Disconnect_Type();
                connect.Enabled = true;
                receivingBox.Items.Add($"{DateTime.Now} 继电器连接已断开!");
            }
        }

        private void Sent_Click(object sender, EventArgs e)
        {
            if (networkStream == null || !client.Connected)
            {
                MessageBox.Show("请先连接到服务器！");
                return;
            }

            try
            {
                string message = InputBox.Text + "\r\n";
                byte[] data = Encoding.GetEncoding("UTF-8").GetBytes(message);
                networkStream.Write(data, 0, data.Length);
                networkStream.Flush();
                Print($"发送数据: {message}");
                BeginReceive();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送消息失败: " + ex.Message);
            }
        }

        private void BeginReceive()
        {
            if (networkStream == null || !client.Connected || isReceiving)
                return;

            try
            {
                isReceiving = true;
                byte[] buffer = new byte[1024];
                readCompleteEvent.Reset();
                networkStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), buffer);
                // 等待数据接收完成或超时
                if (!readCompleteEvent.WaitOne(2000))
                {
                    MessageBox.Show("未接收到数据，继续接收...");
                    isReceiving = false;
                    networkStream.Flush();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("开始接收数据失败: " + ex.Message);
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            if (networkStream == null || !client.Connected)
            {
                return;
            }

            try
            {
                byte[] buffer = (byte[])ar.AsyncState;
                int bytesRead = networkStream.EndRead(ar);
                if (bytesRead > 0)
                {
                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Print($"接收数据: {receivedData}\r\n");
                    received = receivedData;

                    // 循环而不是递归调用BeginReceive
                    while (isReceiving && client.Connected)
                    {
                        byte[] newBuffer = new byte[1024];
                        networkStream.BeginRead(newBuffer, 0, newBuffer.Length, new AsyncCallback(ReadCallback), newBuffer);
                    }

                    // 触发事件，表示接收完成
                    readCompleteEvent.Set();
                }
                else
                {
                    isReceiving = false;
                    Print("连接已关闭或没有更多数据。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("接收数据失败: " + ex.Message);
                isReceiving = false;
            }
        }

        private void Print(string message)
        {
            MethodInvoker mi = () => receivingBox.Items.Add($"{DateTime.Now} {message}\r");
            this.Invoke(mi);
        }

        private void OK_btn1_Click(object sender, EventArgs e)
        {
            if (Global.G_Rel.getRelay_connected())
            {
                // 定义一个字典来映射继电器的状态
                Dictionary<CheckBox, int> relays = new Dictionary<CheckBox, int>
                {
                    { Relay1_check, 1 },
                    { Relay2_check, 2 },
                    { Relay3_check, 3 },
                    { Relay4_check, 4 },
                    { Relay5_check, 5 },
                    { Relay6_check, 6 },
                    { Relay7_check, 7 },
                    { Relay8_check, 8 },
                    { Relay9_check, 9 },
                    { Relay10_check, 10 },
                    { Relay11_check, 11 },
                    { Relay12_check, 12 },
                    { Relay13_check, 13 },
                    { Relay14_check, 14 },
                    { Relay15_check, 15 },
                    { Relay16_check, 16 }
                };
                foreach (var relay in relays)
                {
                    string command = $"AT+STACH{relay.Value}={(relay.Key.Checked ? 1 : 0)}\r\n";
                    Global.G_Rel.sendData_TY(command);
                    string status = relay.Key.Checked ? "打开" : "关闭";
                    receivingBox.Items.Add($"{DateTime.Now} 继电器{relay.Value} {status}: " + command);
                }
            }
        }
    }
}
