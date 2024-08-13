using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    public partial class lh_room : Form
    {
        public TcpClient client = new TcpClient();
        public NetworkStream networkStream;
        private bool isReceiving = false;
        private ManualResetEvent readCompleteEvent;

        public string received;

        public lh_room()
        {
            InitializeComponent();
            InitializeClient();
        }

        private void InitializeClient()
        {
            readCompleteEvent = new ManualResetEvent(false); // 初始化readCompleteEvent
        }

        private void lh_room_Load(object sender, EventArgs e)
        {
            //连接方式框默认选择第一个
            if (Connect_Way.Items.Count > 0)
            {
                Connect_Way.SelectedIndex = 0;
            }

            //读取配置文件
            HostAdress.Text = Global.sysini.Get_Value("Room_IP");
            hostPort.Text = Global.sysini.Get_Value("Room_Port");

            //连接状态
            if (Global.G_lh.getlh_connected())
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

            if (Global.G_lh.getlh_connected())
            {
                receivingBox.Items.Add("Connect");
                networkStream = client.GetStream();
                connect.Enabled = false;
            }
            else
            {
                connect.Enabled = true;
                //网口通讯：端口号502
                if (Connect_Way.Text == "TCP网络")
                {
                    if (string.IsNullOrEmpty(HostAdress.Text) || string.IsNullOrEmpty(hostPort.Text))
                    {
                        MessageBox.Show("地址或端口不能为空！");
                        return;
                    }

                    try
                    {
                        Global.G_lh.connect_Type();
                        //client.Connect(HostAdress.Text, int.Parse(hostPort.Text));
                        //networkStream = client.GetStream();
                        ////if (networkStream.CanRead)
                        ////{
                        ////    BeginReceive();
                        ////}
                        //connect.Enabled = false;
                        //disconnect.Enabled = true;
                        //Print("连接成功");

                        //触发保存地址(配置文件)
                        Global.sysini.Updata_Value("Room_IP", this.HostAdress.Text);
                        Global.sysini.Updata_Value("Room_Port", this.hostPort.Text);
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

        }

        private void Sent_Click(object sender, EventArgs e)
        {

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

        public static int HexStringToDecimal(string hexString)
        {
            // 验证输入字符串是否只包含有效的十六进制字符（0-9, A-F, a-f）  
            if (!Regex.IsMatch(hexString, "^[0-9A-Fa-f]+$"))
            {
                throw new ArgumentException("输入字符串不是有效的十六进制表示。");
            }

            // 使用Convert.ToInt32函数将十六进制字符串转换为十进制整数  
            // 注意：如果字符串以"0x"或"0X"开头，需要去除前缀  
            if (hexString.StartsWith("0x") || hexString.StartsWith("0X"))
            {
                hexString = hexString.Substring(2); // 去除前缀  
            }

            int decimalValue = Convert.ToInt32(hexString, 16); // 第二个参数指定基数为16，表示十六进制  
            return decimalValue;
        }

        private void Re_temp_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_lh.getlh_connected())
            {
                try
                {
                    // 构造指令，确保使用正确的十六进制值
                    string command = $"000000000006000300020001";
                    Global.G_lh.sendData_TY(command);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送指令失败: " + ex.Message);
                }

                string responseText = string.Empty;
                byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                bool success = Global.G_lh.getResult_TY(ref responseText, ref responseBytes);
                if (success)
                {
                    receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                    //string temp = received.Replace(" ", "");
                    string temp2 = responseText.Substring(18, 4);
                    int decimalValue = HexStringToDecimal(temp2);
                    double result = decimalValue / 100.0;
                    Temp_label.Text = result.ToString("F2");
                    Global.sysini.Updata_Value("Real_Temp", Temp_label.Text);

                    //判断阈值
                    if (result > 50 && result < 0)
                    {
                        MessageBox.Show("温度异常！");
                    }
                }
            }
            else
            {
                MessageBox.Show("网络串口未打开，请先连接串口！");
            }
        }

        private void Set_temp_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_lh.getlh_connected())
            {
                    try
                    {
                        string decimalValueString = temp_Box.Text.Trim();

                    if (decimal.TryParse(decimalValueString, out decimal decimalValue))
                    {
                        if(decimalValue <= 40)
                        {
                            // 将带有两位小数的十进制数乘以100转换为整数  
                            decimal multipliedValue = decimalValue * 100;
                            long integerValue = Convert.ToInt64(multipliedValue);

                            // 将整数转换为十六进制字符串  
                            string hexString = Convert.ToString(integerValue, 16).ToUpperInvariant();

                            // 构造指令，确保使用正确的十六进制值
                            string command = $"000000000006000600000{hexString}";

                            Global.G_lh.sendData_TY(command);
                            receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);

                            //将大写转小写
                            string command2 = $"00000000000600060000{Global.G_lh.ConvertToLowerCaseHex(hexString)}";

                            string responseText = string.Empty;
                            byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                            bool success = Global.G_lh.getResult_TY(ref responseText, ref responseBytes);
                            receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                            if (success)
                            {
                                if (responseText == command2)
                                {
                                    MessageBox.Show("设置成功！");
                                }
                            }
                            else
                            {
                                //输入的不是有效的十进制数  
                                MessageBox.Show("输入错误，请重新输入！");
                            }
                        }
                        else if(decimalValue > 40)
                        {
                            // 将带有两位小数的十进制数乘以100转换为整数  
                            decimal multipliedValue = decimalValue * 100;
                            long integerValue = Convert.ToInt64(multipliedValue);
                            // 将整数转换为十六进制字符串  
                            string hexString = Convert.ToString(integerValue, 16).ToUpperInvariant();
                            // 构造指令，确保使用正确的十六进制值
                            string command = $"00000000000600060000{hexString}";

                            Global.G_lh.sendData_TY(command);
                            receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);

                            //将大写转小写
                            string command2 = $"00000000000600060000{Global.G_lh.ConvertToLowerCaseHex(hexString)}";

                            string responseText = string.Empty;
                            byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                            bool success = Global.G_lh.getResult_TY(ref responseText, ref responseBytes);
                            receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                            if (success)
                            {
                                if (responseText == command2)
                                {
                                    MessageBox.Show("设置成功！");
                                }
                            }
                            else
                            {
                                //输入的不是有效的十进制数  
                                MessageBox.Show("输入错误，请重新输入！");
                            }
                        }
                    }

                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("输入的值不是有效的数值: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
            }
            else
            {
                MessageBox.Show("网络串口未连接或无法写入，请检查连接状态！");
            }
        }
    }
}
