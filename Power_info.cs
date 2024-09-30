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
    public partial class Power_info : Form
    {
        private TcpClient client;
        private NetworkStream networkStream;
        private bool isReceiving = false;
        public string received;
        private ManualResetEvent readCompleteEvent;
        public Power_info()
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

        private void Power_info_Load(object sender, EventArgs e)
        {
            //连接方式框默认选择第一个
            if (Connect_Way.Items.Count > 0)
            {
                Connect_Way.SelectedIndex = 0;
            }

            //读取配置文件
            HostAdress.Text = Global.sysini.Get_Value("Power_IP");
            hostPort.Text = Global.sysini.Get_Value("Power_Port");

            //连接状态
            if (Global.G_Power.getPow_connected())
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
            Global.G_Power.connect_TCP();
            receivingBox.Items.Add($"{DateTime.Now} 万瑞达电源已连接！");

            if (Connect_Way.Text == "TCP网络" && HostAdress.Text != "10.10.106.239")
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
                    //if (networkStream.CanRead)
                    //{
                    //    BeginReceive();
                    //}
                    connect.Enabled = false;
                    disconnect.Enabled = true;
                    receivingBox.Items.Add($"{DateTime.Now} 万瑞达电源已连接！");

                    //触发保存地址(配置文件)
                    Global.sysini.Updata_Value("Power_IP", this.HostAdress.Text);
                    Global.sysini.Updata_Value("Power_Port", this.hostPort.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接失败: " + ex.Message);
                }
                
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            if (Global.G_Power.getPow_connected())
            {
                Global.G_Power.Disconnect_Type();
                connect.Enabled = true;
                receivingBox.Items.Add($"{DateTime.Now} 万瑞达电源连接已断开！");
            }
        }

        private void BeginReceive()
        {
            if (networkStream == null || !client.Connected || isReceiving)
                return;

            try
            {
                //isReceiving = true;
                //byte[] buffer = new byte[1024];
                //networkStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), buffer);

                isReceiving = true;
                byte[] buffer = new byte[1024];
                //重置事件，以便我们可以等待它被设置
                readCompleteEvent.Reset();
                networkStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), buffer);
                // 等待数据接收完成或超时
                if (!readCompleteEvent.WaitOne(2000))
                {
                    MessageBox.Show("未接收到数据，继续接收...");
                    //重置接收标志
                    isReceiving = false;
                    networkStream.Flush();
                    //BeginReceive(); // 继续接收
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
                    //将字节数组转换为十六进制字符串
                    string hexString = BitConverter.ToString(buffer, 0, bytesRead).Replace("-", " ");
                    Print($"接收数据: {hexString}");
                    received = hexString;

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
                string message = InputBox.Text;
                byte[] data = ConvertHexStringToBytes(message);
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

        private byte[] ConvertHexStringToBytes(string hexString)
        {
            int numberChars = hexString.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return bytes;
        }

        //十六进制转成byte
        public static byte[] HexStringToByteArray(string hexString)
        {
            if (hexString == null || hexString.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid hex string");
            }

            byte[] result = new byte[hexString.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                string byteValue = hexString.Substring(i * 2, 2);
                result[i] = Convert.ToByte(byteValue, 16);
            }

            return result;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Re_Vol_btn2_Click(object sender, EventArgs e)
        {
            if (Global.G_Power.getPow_connected())
            {
                try
                {
                    // 构造指令，确保使用正确的十六进制值
                    //00104006400023014
                    string command = $"0104006400023014";
                    Global.G_Power.sendData_TY(command);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送指令失败: " + ex.Message);
                }

                string responseText = string.Empty;
                byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                bool success = Global.G_Power.getResult_TY(ref responseText, ref responseBytes);
                if (success)
                {
                    receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    //索引 7 开始提取 4 个字符长度
                    string Pow_Vol = responseText.Substring(6, 4);
                    //string Pow_Vol1 = Pow_Vol.Replace(" ", ""); // 去掉空格
                                                                //将十六进制字符串 转换为十进制整数
                    int pow_vol = Convert.ToInt32(Pow_Vol, 16);
                    //将十进制数除以 100 并保留两位小数
                    double result = pow_vol / 10.0;
                    //F2 格式化为两位小数
                    string Pow_Vol_Result = result.ToString("F2");

                    // 更新 UI 控件
                    Vol_label2.Text = Pow_Vol_Result;
                    // 打印结果
                    Console.WriteLine("数据为：" + Pow_Vol_Result);

                    string Pow_Ele = responseText.Substring(10, 4);
                    //string Pow_Ele1 = Pow_Ele.Replace(" ", ""); // 去掉空格
                    int pow_ele = Convert.ToInt32(Pow_Ele, 16);
                    double result2 = pow_ele / 100.0;
                    string Pow_Ele_Result = result2.ToString("F2");
                    Ele_label2.Text = Pow_Ele_Result;
                    Console.WriteLine("数据为：" + Pow_Ele_Result);

                    Global.sysini.Updata_Value("Real_Pow_Vol", Vol_label2.Text);
                    Global.sysini.Updata_Value("Real_Pow_Ele", Ele_label2.Text);
                }
            }
            else
            {
                MessageBox.Show("网络串口未打开，请先连接串口！");
            }
        }

        private void Set_Vol_btn2_Click(object sender, EventArgs e)
        {
            if (Global.G_Power.getPow_connected())
            {
                try
                {
                    //电压
                    int Vol_value = int.Parse(Voltage_box2.Text);
                    int Vol_valueTextBox = Vol_value * 10;
                    // 将十进制转换为十六进制字符串，确保为4位数
                    ushort volValueAsUShort = (ushort)(Vol_valueTextBox & 0xFFFF);
                    string volValueHex = volValueAsUShort.ToString("X4");
                    string Vol_hexValue = (Vol_valueTextBox & 0xFFFF).ToString("X4");

                    //电流
                    int Ele_value = int.Parse(Electric2.Text);
                    int Ele_valueTextBox = Ele_value * 100;
                    string Ele_hexValue = Ele_valueTextBox.ToString("X4");

                    //01100095000204 0190 01F4 3B3A 
                    string command = $"01100095000204{Vol_hexValue}{Ele_hexValue}";
                    command = command.Replace(" ", "");
                    byte[] commandBytes = HexStringToByteArray(command);
                    ushort crc = Crc16ANSI.ComputeChecksum(commandBytes);
                    Console.WriteLine("CRC-16-CCITT: " + crc.ToString("X4")); // 输出CRC值，格式化为4位十六进制数
                    string crc1 = crc.ToString("X4");
                    //拼接
                    string command2 = command + crc1;
                    Global.G_Power.sendData_TY(command2);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发送指令失败: " + ex.Message);
                }

                string responseText = string.Empty;
                byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                bool success = Global.G_Power.getResult_TY(ref responseText, ref responseBytes);
                receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                if (success)
                {
                    string command3 = $"01100095000251e4";
                    if (responseText == command3)
                    {
                        MessageBox.Show("设置成功！");
                    }
                }
                else
                {
                    MessageBox.Show("设置失败！");
                }

            }
            else
            {
                MessageBox.Show("网络串口未打开，请先连接串口！");
            }
        }

        private void ON_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_Power.getPow_connected())
            {
                try
                {
                    //01050085FF009DD3
                    string command = $"01050085FF009DD3";
                    Global.G_Power.sendData_TY(command);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);

                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Power.getResult_TY(ref responseText, ref responseBytes);
                    receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                    if (success)
                    {
                        string command2 = $"01050085ff009dd3";
                        if (responseText == command2)
                        {
                            MessageBox.Show("启动设置成功！");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送指令失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("网络串口未打开，请先连接串口！");
            }
        }

        private void OFF_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_Power.getPow_connected())
            {
                try
                {
                    string command = $"010500850000DC23";
                    Global.G_Power.sendData_TY(command);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);

                    string responseText = string.Empty;
                    byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success = Global.G_Power.getResult_TY(ref responseText, ref responseBytes);
                    receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                    if (success)
                    {
                        string command2 = $"01050085ff009dd3";
                        if (responseText == command2)
                        {
                            MessageBox.Show("关闭万瑞达电源成功！");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送指令失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("网络串口未打开，请先连接串口！");
            }
        }
    }
}
