using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    public partial class Info : Form
    {
        //Global global = new Global();
        //设备类初始化
        //Ele_Initialize ele_load = new Ele_Initialize();
        //设备连接状态
        //bool Ele_connected = false;


        public TcpClient client = new TcpClient();
        public NetworkStream networkStream;
        private bool isReceiving = false;

        public Info()
        {
            InitializeComponent();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            //连接方式框默认选择第一个
            if (Connect_Way.Items.Count > 0)
            {
                Connect_Way.SelectedIndex = 0;
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
                if (Connect_Way.Text == "TCP网络")
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
                        if (networkStream.CanRead)
                        {
                            BeginReceive();
                        }
                        connect.Enabled = false;
                        disconnect.Enabled = true;
                        Print("连接成功");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("连接失败: " + ex.Message);
                    }
                }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (networkStream != null)
                    networkStream.Close();
                if (client != null)
                    client.Close();
                Print("串口已断开");
            }
            catch (Exception ex)
            {
                MessageBox.Show("断开连接时出错: " + ex.Message);
            }
            finally
            {
                connect.Enabled = true;
                disconnect.Enabled = false;
                Print("已断开连接");
                isReceiving = false;
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
                networkStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), buffer);

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

                    // 循环而不是递归调用BeginReceive
                    while (isReceiving && client.Connected)
                    {
                        byte[] newBuffer = new byte[1024];
                        networkStream.BeginRead(newBuffer, 0, newBuffer.Length, new AsyncCallback(ReadCallback), newBuffer);
                    }
                }
                else
                {
                    // 处理连接关闭的情况
                    isReceiving = false;
                    Print("连接已关闭或没有更多数据。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("接收数据失败: " + ex.Message);
                isReceiving = false; // 确保在发生异常时停止接收
            }
        }

        private void Print(string message)
        {
            MethodInvoker mi = () => receivingBox.Items.Add($"{DateTime.Now} {message}\r");
            this.Invoke(mi);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送消息失败: " + ex.Message);
            }
        }
    }
}
