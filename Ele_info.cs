using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    public partial class Ele_info : Form
    {
        public TcpClient client = new TcpClient();
        public NetworkStream networkStream;
        private bool isReceiving = false;
        private ManualResetEvent readCompleteEvent;

        public string received;

        //连接状态
        //private Ele_Initialize connection;

        public Ele_info()
        {
            InitializeComponent();
            InitializeClient();
        }

        private void InitializeClient()
        {
            readCompleteEvent = new ManualResetEvent(false); // 初始化readCompleteEvent
        }
        private void Ele_info_Load(object sender, EventArgs e)
        {
            //连接方式框默认选择第一个
            if (Connect_Way.Items.Count > 0)
            {
                Connect_Way.SelectedIndex = 0;
            }

            //读取配置文件
            HostAdress.Text = Global.sysini.Get_Value("Ele_IP");
            hostPort.Text = Global.sysini.Get_Value("Ele_Port");

            //连接状态
            if (Global.G_ELe.getEle_connected())
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
                        //receivingBox.Items.Add("连接成功");
                        Print("连接成功");


                        //触发保存地址(配置文件)
                        Global.sysini.Updata_Value("Ele_IP", this.HostAdress.Text);
                        Global.sysini.Updata_Value("Ele_Port", this.hostPort.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("连接失败: " + ex.Message);
                    }
                }
            }
        }

        private void disconnect_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (networkStream != null)
                    networkStream.Close();
                if (client != null)
                    client.Close();
                MessageBox.Show("串口已断开");
            }
            catch (Exception ex)
            {
                MessageBox.Show("断开连接时出错: " + ex.Message);
            }
            finally
            {
                connect.Enabled = true;
                disconnect.Enabled = false;
                Global.G_ELe.disconnect_TCP();
                //receivingBox.Items.Add("已断开连接");
                Print("已断开连接");
                isReceiving = false;
            }
        }

        private void BeginReceive()
        {
            //if (networkStream == null || !client.Connected || isReceiving)
            //    return;

            try
            {
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
        private void Powcheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                CP_Mode();
                Set_Pow_btn.Enabled = true;
                Vol_check.Enabled = false;
                Curr_check.Enabled = false;
                Resis_check.Enabled = false;
            }
            else
            {
                Set_Pow_btn.Enabled = false;
                Vol_check.Enabled = true;
                Curr_check.Enabled = true;
                Resis_check.Enabled = true;
            }
        }
        private void Sent_Click_1(object sender, EventArgs e)
        {
            if (!Global.G_ELe.getEle_connected())
            {
                MessageBox.Show("请先连接到服务器！");
                return;
            }

            try
            {
                string message = InputBox.Text + "\r\n";
                Global.G_ELe.sendData_TY(message);
                receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + message);
                receivingBox.Items.Add($"发送数据: {message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送消息失败: " + ex.Message);
            }
        }

        private void Re_pw_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    // 命令字符串，包含协议规定的结束符，如\r\n
                    string command = "STATic:CP:LEVel?\r\n";
                    Global.G_ELe.sendData_TY(command);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发送命令失败: " + ex.Message);
                }

                // 调用getResult_TY方法
                string result;
                string responseText = string.Empty;
                byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                bool success = Global.G_ELe.getResult_TY(ref responseText, ref responseBytes);
                if (success)
                {
                    receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    result = responseText.Substring(0, 5);
                    Power_label.Text = result;
                    if (string.IsNullOrEmpty(responseText) || responseText.Length < 5)
                    {
                        MessageBox.Show("接收到的数据不完整。");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("网络串口未连接或无法写入，请检查连接状态！");
            }
        }

        private void Set_Pow_btn_Click(object sender, EventArgs e)
        {
            if (Constant_Power.Text == "")
            {
                MessageBox.Show("请输入需设置的恒功率值!");
                return;
            }
            else if (Constant_Power.Text != "")
            {
                if (Global.G_ELe.getEle_connected())
                {
                    try
                    {
                        string power = "STATic:CP:LEVel " + Constant_Power.Text;
                        string P_data = power + "\r\n";
                        Global.G_ELe.sendData_TY(P_data);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + power);
                        MessageBox.Show("设置成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("设置失败: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("网络串口未连接或无法写入，请检查连接状态！");
                }
            }
        }

        private void Volcheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                CV_Mode();
                Set_Vol_btn.Enabled = true;
                Pow_check.Enabled = false;
                Curr_check.Enabled = false;
                Resis_check.Enabled = false;
            }
            else
            {
                Set_Vol_btn.Enabled = false;
                Pow_check.Enabled = true;
                Curr_check.Enabled = true;
                Resis_check.Enabled = true;

            }
        }

        private void Re_Vol_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    // 命令字符串，包含协议规定的结束符，如\r\n
                    string command = "STATic:CV:HIGH:LEVel?\r\n";
                    Global.G_ELe.sendData_TY(command);
                    receivingBox.Items.Add($"{DateTime.Now} 命令发送成功: " + command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发送命令失败: " + ex.Message);
                }
                // 调用getResult_TY方法
                string result;
                string responseText = string.Empty;
                byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                bool success = Global.G_ELe.getResult_TY(ref responseText, ref responseBytes);
                if (success)
                {
                    receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    result = responseText.Substring(0, 5);
                    Vol_label.Text = result;
                    if (string.IsNullOrEmpty(responseText) || responseText.Length < 5)
                    {
                        MessageBox.Show("接收到的数据不完整。");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("无法写入到网络流！");
            }
        }

        private void Set_Vol_btn_Click(object sender, EventArgs e)
        {
            if (Voltage_box.Text == "")
            {
                MessageBox.Show("请输入需设置的电压值!");
                return;
            }
            else if (Voltage_box.Text != "")
            {
                if (Global.G_ELe.getEle_connected())
                {
                    try
                    {
                        string voltage = "STATic:CV:HIGH:LEVel " + Voltage_box.Text;
                        string V_data = voltage + "\r\n";
                        Global.G_ELe.sendData_TY(V_data);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + voltage);
                        MessageBox.Show("设置成功！");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("设置失败: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("请检查网络连接状态！");
                }
            }
        }

        private void Elecheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                CC_Mode();
                Set_Ele_btn.Enabled = true;
                Pow_check.Enabled = false;
                Vol_check.Enabled = false;
                Resis_check.Enabled = false;

            }
            else
            {
                Set_Ele_btn.Enabled = false;
                Pow_check.Enabled = true;
                Vol_check.Enabled = true;
                Resis_check.Enabled = true;
            }
        }

        private void Re_Ele_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    // 命令字符串，包含协议规定的结束符，如\r\n
                    string command = "STATic:CC:HIGH:LEVel?\r\n";
                    Global.G_ELe.sendData_TY(command);
                    receivingBox.Items.Add($"{DateTime.Now} 命令发送成功: " + command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发送命令失败: " + ex.Message);
                }

                // 调用getResult_TY方法
                string result;
                string responseText = string.Empty;
                byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                bool success = Global.G_ELe.getResult_TY(ref responseText, ref responseBytes);
                if (success)
                {
                    receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    result = responseText.Substring(0, 5);
                    Ele_label.Text = result;
                    if (string.IsNullOrEmpty(responseText) || responseText.Length < 5)
                    {
                        MessageBox.Show("接收到的数据不完整。");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("网络串口未连接或无法写入，请检查连接状态！");
            }
        }

        private void Set_Ele_btn_Click(object sender, EventArgs e)
        {
            if (Electric.Text == "")
            {
                MessageBox.Show("请输入需设置的电流值!");
                return;
            }
            else if (Electric.Text != "")
            {
                if (Global.G_ELe.getEle_connected())
                {
                    try
                    {
                        string electric = "STATic:CC:HIGH:LEVel " + Electric.Text;
                        string E_data = electric + "\r\n";
                        Global.G_ELe.sendData_TY(E_data);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + electric);
                        MessageBox.Show("设置成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("设置失败: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("请检查网络连接状态！");
                }
            }
        }
        private void Resischeck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                CR_Mode();
                Set_Resis_btn.Enabled = true;
                Pow_check.Enabled = false;
                Curr_check.Enabled = false;
                Vol_check.Enabled = false;
            }
            else
            {
                Set_Resis_btn.Enabled = false;
                Pow_check.Enabled = true;
                Curr_check.Enabled = true;
                Vol_check.Enabled = true;
            }
        }

        private void Re_Resis_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    // 命令字符串，包含协议规定的结束符，如\r\n
                    string command = "STATic:CR:HIGH:LEVel?\r\n";
                    Global.G_ELe.sendData_TY(command);
                    receivingBox.Items.Add($"{DateTime.Now} 命令发送成功: " + command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发送命令失败: " + ex.Message);
                }

                // 调用getResult_TY方法
                string result;
                string responseText = string.Empty;
                byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                bool success = Global.G_ELe.getResult_TY(ref responseText, ref responseBytes);
                if (success)
                {
                    receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                    result = responseText.Substring(0, 5);
                    Resistance_label.Text = result;
                    if (string.IsNullOrEmpty(responseText) || responseText.Length < 5)
                    {
                        MessageBox.Show("接收到的数据不完整。");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("无法写入到网络流！");
            }
        }

        private void Set_Resis_btn_Click(object sender, EventArgs e)
        {
            if (Resis_Box.Text == "")
            {
                MessageBox.Show("请输入需设置的电阻值!");
                return;
            }
            else if (Resis_Box.Text != "")
            {
                if (Global.G_ELe.getEle_connected())
                {
                    try
                    {
                        string resistan = "STATic:CR:LOW:LEVel " + Resis_Box.Text;
                        string R_data = resistan + "\r\n";
                        Global.G_ELe.sendData_TY(R_data);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);
                        MessageBox.Show("设置成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("设置失败: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("请检查网络连接状态！");
                }
            }
        }

        private void ON_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    string resistan = "INPut:STATe ON";
                    string R_data = resistan + "\r\n";
                    Global.G_ELe.sendData_TY(R_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);
                    MessageBox.Show("开机成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("开机失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请检查网络连接状态！");
            }
        }

        private void OFF_btn_Click(object sender, EventArgs e)
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    string resistan = "INPut:STATe OFF";
                    string R_data = resistan + "\r\n";
                    Global.G_ELe.sendData_TY(R_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);
                    MessageBox.Show("关机成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("关机失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请检查网络连接状态！");
            }
        }

        /******************模式设置*********************/
        //恒功率模式
        private void CP_Mode()
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    string resistan = "INPut:FUNCtion CP";
                    string R_data = resistan + "\r\n";
                    Global.G_ELe.sendData_TY(R_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);
                    //MessageBox.Show("恒功率模式设置成功！");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("恒功率模式设置失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请检查网络连接状态！");
            }
        }

        private void CV_Mode()
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    string resistan = "INPut:FUNCtion CV";
                    string R_data = resistan + "\r\n";
                    Global.G_ELe.sendData_TY(R_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);
                    //MessageBox.Show("恒功率模式设置成功！");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("恒功率模式设置失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请检查网络连接状态！");
            }
        }

        private void CC_Mode()
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    string resistan = "INPut:FUNCtion CC";
                    string R_data = resistan + "\r\n";
                    Global.G_ELe.sendData_TY(R_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);
                    //MessageBox.Show("恒功率模式设置成功！");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("恒功率模式设置失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请检查网络连接状态！");
            }
        }

        private void CR_Mode()
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    string resistan = "INPut:FUNCtion CR";
                    string R_data = resistan + "\r\n";
                    Global.G_ELe.sendData_TY(R_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);
                    //MessageBox.Show("恒功率模式设置成功！");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("恒功率模式设置失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请检查网络连接状态！");
            }
        }
    }
}
