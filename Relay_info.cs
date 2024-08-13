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

            if (Global.G_ELe.getEle_connected())
            {
                receivingBox.Items.Add("Connect");
                networkStream = client.GetStream();
                connect.Enabled = false;
            }
            else
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
                        connect.Enabled = false;
                        disconnect.Enabled = true;
                        Print("连接成功");

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
                if (comboBox1.Text == "通道1" && comboBox2.Text == "分离")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH1=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }

                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("请选择通道或开关!");
                }

                if (comboBox1.Text == "通道2" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH2=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }

                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道3" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH3=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道4" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH4=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }

                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道5" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH5=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }

                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道6" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH6=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }

                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道7" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH7=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }

                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道8" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH8=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道9" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH9=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道10" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH10=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道11" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH11=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道12" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH12=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道13" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH13=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道14" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH14=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道15" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH15=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                if (comboBox1.Text == "通道16" && comboBox2.Text == "分离")
                {
                    try
                    {
                        string command = $"AT+STACH16=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                //通道吸合
                if (comboBox1.Text == "通道1" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH1=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道2" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH2=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道3" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH3=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道4" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH4=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道5" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH5=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道6" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH6=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道7" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH7=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道8" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH8=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道9" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH9=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道10" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH10=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道11" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH11=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道12" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH12=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道13" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH13=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道14" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH14=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道15" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH15=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
                else if (comboBox1.Text == "通道16" && comboBox2.Text == "吸合")
                {
                    try
                    {
                        string command = $"AT+STACH16=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Rel.getResult_TY(ref responseText, ref responseBytes);
                    if (success)
                    {
                        receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    }
                }
            }
        }

    }
}
