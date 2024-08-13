using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;
using Timer = System.Windows.Forms.Timer;

namespace BFS
{
    public partial class Form1 : Form
    {
        //设备连接状态
        //private Ele_Initialize E_connection;
        //private Power_Initialize P_connection;
        //private lh_Initialize L_connection;
        //private Relay_Initialize R_connection;

        //倒计时
        private TimeSpan countdownTime;
        private TimeSpan initialCountdownTime;

        public Form1()
        {
            InitializeComponent();

            // 设置窗体启动位置为屏幕中心
            this.StartPosition = FormStartPosition.CenterScreen;
            
            //倒计时
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 设置计时器的间隔为1秒
            countdownTimer.Tick += CountdownTimer_Tick;

            //读取配置文件
            this.Text = Global.sysini.Get_Value("windowsTitle");
            this.vol_label4.Text = Global.sysini.Get_Value("Real_Pow_Vol");
            this.Elec_label4.Text = Global.sysini.Get_Value("Real_Pow_Ele");
            this.Temp_label2.Text = Global.sysini.Get_Value("Real_Temp");
            flash_form();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //info = new Info();
            //info.Dock = DockStyle.Fill;
            //OpenFrom(info, this.info_Page);
            //room = new lh_room();
            //room.Dock = DockStyle.Fill;
            //OpenFrom(room, this.room_Page);

            //Ele_connection();
            //Power_connection();
            //lh_connection();
            //Relay_connection();

        }

        private void flash_form()
        {
            //电子负载
            pw_label.Text = Global.sysini.Get_Value("Ele_Power");
            vol_label_2.Text = Global.sysini.Get_Value("Ele_Vol");
            ele_label_2.Text = Global.sysini.Get_Value("Ele_Ele");
            resis_label_2.Text = Global.sysini.Get_Value("Ele_Resis");

            //万瑞达电源
            string pow_status = Global.sysini.Get_Value("Power_Status");
            if (pow_status == "ON")
            {
                status_label1.Text = "ON";
            }
            else if (pow_status == "OFF")
            {
                status_label1.Text = "OFF";
            }
            vol_label_3.Text = Global.sysini.Get_Value("Power_Vol");
            ele_label_3.Text = Global.sysini.Get_Value("Power_Ele");

            //老化柜
            string lh_status = Global.sysini.Get_Value("lh_Status");
            if (lh_status == "ON")
            {
                status_label2.Text = "ON";
            }
            else if (lh_status == "OFF")
            {
                status_label2.Text = "OFF";
            }
            temp_label_2.Text = Global.sysini.Get_Value("lh_Temp");

            //继电器
            string relay1_status = Global.sysini.Get_Value("Relay1_Status");
            if (relay1_status == "ON")
            {
                relay1_label.Text = "ON";
            }
            else if (relay1_status == "OFF")
            {
                relay1_label.Text = "OFF";
            }
            string relay2_status = Global.sysini.Get_Value("Relay2_Status");
            if (relay2_status == "ON")
            {
                relay2_label.Text = "ON";
            }
            else if (relay2_status == "OFF")
            {
                relay2_label.Text = "OFF";
            }
            string relay3_status = Global.sysini.Get_Value("Relay3_Status");
            if (relay3_status == "ON")
            {
                relay3_label.Text = "ON";
            }
            else if (relay3_status == "OFF")
            {
                relay3_label.Text = "OFF";
            }
            string relay4_status = Global.sysini.Get_Value("Relay4_Status");
            if (relay4_status == "ON")
            {
                relay4_label.Text = "ON";
            }
            else if (relay4_status == "OFF")
            {
                relay4_label.Text = "OFF";
            }
            string relay5_status = Global.sysini.Get_Value("Relay5_Status");
            if (relay5_status == "ON")
            {
                relay5_label.Text = "ON";
            }
            else if (relay5_status == "OFF")
            {
                relay5_label.Text = "OFF";
            }
            string relay6_status = Global.sysini.Get_Value("Relay6_Status");
            if (relay6_status == "ON")
            {
                relay6_label.Text = "ON";
            }
            else if (relay6_status == "OFF")
            {
                relay6_label.Text = "OFF";
            }
            string relay7_status = Global.sysini.Get_Value("Relay7_Status");
            if (relay7_status == "ON")
            {
                relay7_label.Text = "ON";
            }
            else if (relay7_status == "OFF")
            {
                relay7_label.Text = "OFF";
            }
            string relay8_status = Global.sysini.Get_Value("Relay8_Status");
            if (relay8_status == "ON")
            {
                relay8_label.Text = "ON";
            }
            else if (relay8_status == "OFF")
            {
                relay8_label.Text = "OFF";
            }
            string relay9_status = Global.sysini.Get_Value("Relay9_Status");
            if (relay9_status == "ON")
            {
                relay9_label.Text = "ON";
            }
            else if (relay9_status == "OFF")
            {
                relay9_label.Text = "OFF";
            }
            string relay10_status = Global.sysini.Get_Value("Relay10_Status");
            if (relay10_status == "ON")
            {
                relay10_label.Text = "ON";
            }
            else if (relay10_status == "OFF")
            {
                relay10_label.Text = "OFF";
            }
            string relay11_status = Global.sysini.Get_Value("Relay11_Status");
            if (relay11_status == "ON")
            {
                relay11_label.Text = "ON";
            }
            else if (relay11_status == "OFF")
            {
                relay11_label.Text = "OFF";
            }
            string relay12_status = Global.sysini.Get_Value("Relay12_Status");
            if (relay12_status == "ON")
            {
                relay12_label.Text = "ON";
            }
            else if (relay12_status == "OFF")
            {
                relay12_label.Text = "OFF";
            }
            string relay13_status = Global.sysini.Get_Value("Relay13_Status");
            if (relay13_status == "ON")
            {
                relay13_label.Text = "ON";
            }
            else if (relay13_status == "OFF")
            {
                relay13_label.Text = "OFF";
            }
            string relay14_status = Global.sysini.Get_Value("Relay14_Status");
            if (relay14_status == "ON")
            {
                relay14_label.Text = "ON";
            }
            else if (relay14_status == "OFF")
            {
                relay14_label.Text = "OFF";
            }
            string relay15_status = Global.sysini.Get_Value("Relay15_Status");
            if (relay15_status == "ON")
            {
                relay15_label.Text = "ON";
            }
            else if (relay15_status == "OFF")
            {
                relay15_label.Text = "OFF";
            }
            string relay16_status = Global.sysini.Get_Value("Relay16_Status");
            if (relay16_status == "ON")
            {
                relay16_label.Text = "ON";
            }
            else if (relay16_status == "OFF")
            {
                relay16_label.Text = "OFF";
            }

        }

        //将当前程序的某一窗口程序 显示到指定容器控件上
        private void OpenFrom(Form objFrm, object objParent)
        {
            //将当前子窗体设置成非顶级控件
            objFrm.TopLevel = false;
            //设置窗体最大化
            objFrm.WindowState = FormWindowState.Maximized;
            //去掉窗体边框
            objFrm.FormBorderStyle = FormBorderStyle.None;
            //指定当前子窗体显示的容器
            objFrm.Parent = (Control)objParent;
            //显示窗体
            objFrm.Show();
        }

        //信息调试
        //Info info = null;
        //老化详细界面
        //lh_info lh = null;
        //电子负载
        Ele_info ele = null;
        //万瑞达电源
        Power_info power = null;
        //老化柜
        lh_room room = null;
        //继电器
        Relay_info relay = null;

        private void tabPage_IndexChange(object sender, EventArgs e)
        {
            //通过 tabControl 控件 下标 区分打开的是那个窗体
            switch (this.info_Control.SelectedIndex)
            {
                case 0:
                    ////判断是否是第一次打开当前 tabPage 页 
                    ////如果是 第一次 那么就创建窗体
                    ////如果不是 那么 这个窗体已经存在了，不可重复在当前父控件多次创建子窗体
                    //if (info == null)
                    //{
                    //    //创建窗口
                    //    info = new Info();
                    //    //设置将子窗口 与 父控件 撑满 （子窗口各边缘 停靠在父控件各边缘）
                    //    info.Dock = DockStyle.Fill;
                    //    //调用方法将 指定窗口 显示在指定控件内
                    //    OpenFrom(info, this.info_Page);
                    //}
                    flash_form();
                    break;
                case 1:
                    if (ele == null)
                    {
                        ele = new Ele_info();
                        ele.Dock = DockStyle.Fill;
                        OpenFrom(ele, this.ele_Page);
                    }
                    break;
                case 2:
                    if (power == null)
                    {
                        power = new Power_info();
                        power.Dock = DockStyle.Fill;
                        OpenFrom(power, this.power_Page);
                    }
                    break;
                case 3:
                    if (room == null)
                    {
                        room = new lh_room();
                        room.Dock = DockStyle.Fill;
                        OpenFrom(room, this.room_Page);
                    }
                    break;
                case 4:
                    if (relay == null)
                    {
                        relay = new Relay_info();
                        relay.Dock = DockStyle.Fill;
                        OpenFrom(relay, this.relay_Page);
                    }
                    break;
            }
        }

        //电子负载
        private void Ele_connection()
        {
            if (Global.G_ELe.getEle_connected())
            {
                Global.G_ELe.Disconnect_Type();
                receivingBox.Items.Add("Connect");
            }
            else
            {
                {
                    Global.G_ELe.connect_TCP();
                    receivingBox.Items.Add($"{DateTime.Now} 电子负载已连接！");
                }
            }
        }

        //万瑞达电源
        private void Power_connection()
        {
            if (Global.G_Power.getPow_connected())
            {
                Global.G_Power.Disconnect_Type();
                receivingBox.Items.Add("Connect");

            }
            else
            {
                {
                    Global.G_Power.connect_TCP();
                    receivingBox.Items.Add($"{DateTime.Now} 万瑞达电源已连接！");
                }
            }
        }

        //老化柜
        private void lh_connection()
        {
            if (Global.G_lh.getlh_connected())
            {
                Global.G_lh.Disconnect_Type();
                receivingBox.Items.Add("Connect");
            }
            else
            {
                {
                    Global.G_lh.connect_TCP();
                    receivingBox.Items.Add($"{DateTime.Now} 老化柜已连接！");
                }
            }
        }

        //继电器
        private void Relay_connection()
        {
            if (Global.G_Rel.getRelay_connected())
            {
                Global.G_Rel.Disconnect_Type();
                receivingBox.Items.Add("Connect");
            }
            else
            {
                {
                    Global.G_Rel.connect_TCP();
                    receivingBox.Items.Add($"{DateTime.Now} 继电器已连接！");
                }
            }
        }

        private void Set_Time_btn_Click(object sender, EventArgs e)
        {
            Time time = new Time();
            // 显示窗体并获取用户设置的时间
            if (time.ShowDialog() == DialogResult.OK)
            {
                countdownTime = time.CountdownTime; // 假设 SelectedTime 返回用户设置的时间
            }
        }
        private void StartCountdown(TimeSpan time)
        {
            if (!countdownTimer.Enabled)
            {
                countdownTime = time; // 设置倒计时的初始时间
                initialCountdownTime = time;
                countdownTimer.Start();
                UpdateCountdownDisplay(time);
                progressBar_time.Value = 0; // 进度条从0开始
            }
        }

        //暂停倒计时
        private void PauseCountdown()
        {
            if (countdownTimer.Enabled)
            {
                countdownTimer.Stop();
                UpdateCountdownDisplay(countdownTime);
            }
        }

        //结束倒计时
        private void StopCountdown()
        {
            if (countdownTimer.Enabled)
            {
                countdownTimer.Stop();
                progressBar_time.Value = 0;
                countdownTime = TimeSpan.Zero; // 重置倒计时时间
                UpdateCountdownDisplay(countdownTime); // 更新UI显示停止状态
            }
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (countdownTime.TotalSeconds > 0)
            {
                // 倒计时减少一秒
                countdownTime = countdownTime.Subtract(new TimeSpan(0, 0, 1));
                UpdateCountdownDisplay(countdownTime);

                // 计算当前的进度百分比 = (初始时间 - 倒计时时间) / 初始时间
                double progressPercentage = (initialCountdownTime.TotalSeconds - countdownTime.TotalSeconds) / initialCountdownTime.TotalSeconds;

                // 确保进度百分比不超过1
                progressPercentage = Math.Min(1, progressPercentage);

                // 计算进度条的值，并确保它不超过最大值
                int progressBarValue = (int)(progressPercentage * progressBar_time.Maximum);
                progressBar_time.Value = progressBarValue;


                // 当倒计时结束时
                if (countdownTime.TotalSeconds <= 0)
                {
                    countdownTimer.Stop();
                    UpdateCountdownDisplay(TimeSpan.Zero);
                    progressBar_time.Value = progressBar_time.Maximum; // 进度条达到最大值
                    MessageBox.Show("老化结束！");
                    //老化时间结束重置设备
                    Reset_device();
                    MessageBox.Show("设备重置成功");

                    //打开门的操作
                    //DialogResult result = MessageBox.Show("是否打开门？", "操作确认", MessageBoxButtons.YesNo);
                    //if (result == DialogResult.Yes)
                    //{
                    //    // 用户点击了"Yes"
                    //    //Door door1 = new Door();
                    //    //door1.Show();
                    //}
                    //else
                    //{
                    //    // 用户点击了"No"，执行不打开门的操作
                    //}
                }
            }
            else
            {
                // 如果倒计时时间为0，可能需要处理错误情况或重置倒计时
            }
        }

        // 更新倒计时显示
        private void UpdateCountdownDisplay(TimeSpan time)
        {
            count_down.Text = time.ToString(@"hh\:mm\:ss");
        }

        //参数设置
        private void Argument_btn_Click(object sender, EventArgs e)
        {
            config con = new config();
            con.Show(this);
        }

        //开始老化
        private void beging_lh_btn_Click(object sender, EventArgs e)
        {
            //更新时间
            if (countdownTime == TimeSpan.Zero)
            {
                MessageBox.Show("请先设置时间！");
                return;
            }

            //bool result = Ele_lh();
            //if (result)
            //{
            //    bool result2 = Power_lh();
            //    if (result2)
            //    {
            //            bool result4 = Relay_lh();
            //            if (result4)
            //            {
            //                MessageBox.Show("启动老化成功！");
            //                StartCountdown(countdownTime);
            //            }
            //            else
            //            {
            //                MessageBox.Show("继电器老化设置失败！");
            //            }
            //    }
            //    else
            //    {
            //        MessageBox.Show("万瑞达老化设置失败！");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("电子负载老化失败！");
            //}

            bool result = Ele_lh();
            if (result)
            {
                bool result2 = Power_lh();
                if (result2)
                {
                    bool result3 = Room_lh();
                    if (result3)
                    {
                        bool result4 = Relay_lh();
                        if (result4)
                        {
                            MessageBox.Show("启动老化成功！");
                            StartCountdown(countdownTime);
                        }
                        else
                        {
                            MessageBox.Show("继电器老化设置失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("老化柜老化设置失败！");
                    }
                }
                else
                {
                    MessageBox.Show("万瑞达老化设置失败！");
                }
            }
            else
            {
                MessageBox.Show("电子负载老化失败！");
            }
            //StartCountdown(countdownTime);
        }

        private bool Ele_lh()
        {
            bool Ele_success = false;
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    //恒功率
                    string power = "STATic:CP:LEVel " + pw_label.Text;
                    string P_data = power + "\r\n";
                    Global.G_ELe.sendData_TY(P_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + power);
                    //电压
                    string voltage = "STATic:CV:HIGH:LEVel " + vol_label_2.Text;
                    string V_data = voltage + "\r\n";
                    Global.G_ELe.sendData_TY(V_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + voltage);
                    //电流
                    string electric = "STATic:CC:HIGH:LEVel " + ele_label_2.Text;
                    string E_data = electric + "\r\n";
                    Global.G_ELe.sendData_TY(E_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + electric);
                    //电阻
                    string resistan = "STATic:CR:LOW:LEVel " + resis_label_2.Text;
                    string R_data = resistan + "\r\n";
                    Global.G_ELe.sendData_TY(R_data);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);

                    Ele_success = true;
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
            return Ele_success;
        }

        private bool Power_lh()
        {
            bool Power_success = false;
            if (Global.G_Power.getPow_connected())
            {
                try
                {
                    //万瑞达电源状态
                    //if(status_label1.Text == "ON")
                    //{
                    //    string command1 = $"01050085FF009DD3";
                    //    command1 = command1.Replace(" ", "");
                    //    Global.G_Power.sendData_TY(command1);
                    //    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command1);
                    //}else if(status_label2.Text == "OFF")
                    //{
                    //    string command1 = $"010500850000DC23";
                    //    command1 = command1.Replace(" ", "");
                    //    Global.G_Power.sendData_TY(command1);
                    //    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command1);
                    //}
                    //电压
                    int Vol_value = int.Parse(vol_label_3.Text);
                    int Vol_valueTextBox = Vol_value * 10;
                    // 将十进制转换为十六进制字符串，确保为4位数
                    ushort volValueAsUShort = (ushort)(Vol_valueTextBox & 0xFFFF);
                    string volValueHex = volValueAsUShort.ToString("X4");
                    string Vol_hexValue = (Vol_valueTextBox & 0xFFFF).ToString("X4");

                    //电流
                    int Ele_value = int.Parse(ele_label_3.Text);
                    int Ele_valueTextBox = Ele_value * 100;
                    string Ele_hexValue = Ele_valueTextBox.ToString("X4");

                    //01100095000204 0190 01F4 3B3A 
                    string command = $"01100095000204{Vol_hexValue}{Ele_hexValue}";
                    command = command.Replace(" ", "");
                    byte[] commandBytes = Global.G_Power.HexStringToByteArray(command);
                    ushort crc = Crc16ANSI.ComputeChecksum(commandBytes);
                    Console.WriteLine("CRC-16-CCITT: " + crc.ToString("X4")); // 输出CRC值，格式化为4位十六进制数
                    string crc1 = crc.ToString("X4");
                    //拼接
                    string command2 = command + crc1;
                    Global.G_Power.sendData_TY(command2);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command2);
                    Power_success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送指令失败: " + ex.Message);
                }

                //string responseText = string.Empty;
                //byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                //bool success = Global.G_Power.getResult_TY(ref responseText, ref responseBytes);
                //receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                //if (success)
                //{
                //    string command3 = $"01100095000251e4";
                //    if (responseText == command3)
                //    {
                //        receivingBox.Items.Add("设置成功！");
                //    }
                //}
                //else
                //{
                //    receivingBox.Items.Add("设置失败！");
                //}
            }
            else
            {
                MessageBox.Show("网络串口未打开，请先连接串口！");
            }

            return Power_success;
        }

        private bool Room_lh()
        {
            bool Room_success = false;
            if (Global.G_lh.getlh_connected())
            {
                try
                {
                    //老化柜状态
                    //if (status_label2.Text == "ON")
                    //{
                    //    string command1 = $"后续补充";
                    //    command1 = command1.Replace(" ", "");
                    //    Global.G_lh.sendData_TY(command1);
                    //    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command1);
                    //}
                    //else if (status_label2.Text == "OFF")
                    //{
                    //    string command1 = $"后续补充";
                    //    command1 = command1.Replace(" ", "");
                    //    Global.G_lh.sendData_TY(command1);
                    //    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command1);
                    //}

                    string decimalValueString = temp_label_2.Text.Trim();

                    if (decimal.TryParse(decimalValueString, out decimal decimalValue))
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
                                    Console.WriteLine("设置成功！");
                                }
                            }
                            else
                            {
                                //输入的不是有效的十进制数  
                                Console.WriteLine("输入错误，请重新输入！");
                            }
                            Room_success = true;
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
            return Room_success;
        }

        private bool Relay_lh()
        {
            bool Relay_success = false;
            if (Global.G_Rel.getRelay_connected())
            {
                if (relay1_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH1=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay1_label.Text == "OFF")
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
                }
                if (relay2_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH2=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay2_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH2=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay3_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH3=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay3_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH3=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay4_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH4=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay4_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH4=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay5_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH5=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay5_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH5=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay6_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH6=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay6_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH6=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay7_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH7=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay7_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH7=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay8_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH8=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay8_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH8=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay9_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH9=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay9_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH9=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay10_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH10=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay10_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH10=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay11_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH11=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay11_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH11=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay12_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH12=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay12_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH12=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay13_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH13=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay13_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH13=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay14_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH14=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay14_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH14=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay15_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH15=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay15_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH15=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                if (relay16_label.Text == "ON")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH16=1\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                else if (relay16_label.Text == "OFF")
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"AT+STACH16=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送指令失败: " + ex.Message);
                    }
                }
                Relay_success = true;
            }
            return Relay_success;
        }

        //老化暂停
        private void Paused_btn_Click(object sender, EventArgs e)
        {
            PauseCountdown();
            MessageBox.Show("已停止老化！");
        }

        //设备重置
        private void Reset_device()
        {
            if (Global.G_ELe.getEle_connected())
            {
                //恒功率
                string power = "STATic:CP:LEVel 0";
                string P_data = power + "\r\n";
                Global.G_ELe.sendData_TY(P_data);
                receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + power);
                //电压
                string voltage = "STATic:CV:HIGH:LEVel 0";
                string V_data = voltage + "\r\n";
                Global.G_ELe.sendData_TY(V_data);
                receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + voltage);
                //电流
                string electric = "STATic:CC:HIGH:LEVel 0";
                string E_data = electric + "\r\n";
                Global.G_ELe.sendData_TY(E_data);
                receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + electric);
                //电阻
                string resistan = "STATic:CR:LOW:LEVel 0";
                string R_data = resistan + "\r\n";
                Global.G_ELe.sendData_TY(R_data);
                receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);
            }
            if (Global.G_Power.getPow_connected())
            {
                try
                {
                    //万瑞达电源状态
                    //if(status_label1.Text == "ON")
                    //{
                    //    string command1 = $"01050085FF009DD3";
                    //    command1 = command1.Replace(" ", "");
                    //    Global.G_Power.sendData_TY(command1);
                    //    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command1);
                    //}else if(status_label2.Text == "OFF")
                    //{
                    //    string command1 = $"010500850000DC23";
                    //    command1 = command1.Replace(" ", "");
                    //    Global.G_Power.sendData_TY(command1);
                    //    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command1);
                    //}
                    string command = $"0110009500020400000000";
                    command = command.Replace(" ", "");
                    byte[] commandBytes = Global.G_Power.HexStringToByteArray(command);
                    ushort crc = Crc16ANSI.ComputeChecksum(commandBytes);
                    Console.WriteLine("CRC-16-CCITT: " + crc.ToString("X4")); // 输出CRC值，格式化为4位十六进制数
                    string crc1 = crc.ToString("X4");
                    string command2 = command + crc1;
                    Global.G_Power.sendData_TY(command2);
                    receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command2);

                    if (Global.G_lh.getlh_connected())
                    {
                        string lh_command = $"000000000006000600000000";
                        Global.G_lh.sendData_TY(lh_command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + lh_command);
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

            Reset_Relay();

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

        //继电器重置
        private void Reset_Relay()
        {
            if (Global.G_Rel.getRelay_connected())
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
                        Console.WriteLine("继电器1重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH2=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器2重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH3=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器3重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH4=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器4重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH5=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器5重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH6=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器6重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH7=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器7重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH8=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器8重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH9=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器9重置失败: " + ex.Message);
                    }


                    try
                    {
                        string command = $"AT+STACH10=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器10重置失败: " + ex.Message);
                    }

  
                    try
                    {
                        string command = $"AT+STACH11=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器11重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH12=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器12重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH13=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器13重置失败: " + ex.Message);
                    }
      
                    try
                    {
                        string command = $"AT+STACH14=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器14重置失败: " + ex.Message);
                    }
    
                    try
                    {
                        string command = $"AT+STACH15=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("继电器15重置失败: " + ex.Message);
                    }

                    try
                    {
                        string command = $"AT+STACH16=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                       Console.WriteLine("继电器16重置失败: " + ex.Message);
                    }
            }
        }

        private void real_info()
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
                    string temp2 = responseText.Substring(18, 4);
                    int decimalValue = HexStringToDecimal(temp2);
                    double result = decimalValue / 100.0;
                    Temp_label2.Text = result.ToString("F2");

                    //判断阈值
                    if (result > 50 && result < 0)
                    {
                        MessageBox.Show("温度异常！");
                    }
                }
            }

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
                    //将十六进制字符串 转换为十进制整数
                    int pow_vol = Convert.ToInt32(Pow_Vol, 16);
                    //将十进制数除以 100 并保留两位小数
                    double result = pow_vol / 10.0;
                    //F2 格式化为两位小数
                    string Pow_Vol_Result = result.ToString("F2");

                    // 更新 UI 控件
                    vol_label4.Text = Pow_Vol_Result;
                    // 打印结果
                    Console.WriteLine("数据为：" + Pow_Vol_Result);

                    string Pow_Ele = responseText.Substring(10, 4);
                    int pow_ele = Convert.ToInt32(Pow_Ele, 16);
                    double result2 = pow_ele / 100.0;
                    string Pow_Ele_Result = result2.ToString("F2");
                    Elec_label4.Text = Pow_Ele_Result;
                    Console.WriteLine("数据为：" + Pow_Ele_Result);
                }
            }
        }
    }
}
