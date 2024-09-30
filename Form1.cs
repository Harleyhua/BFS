using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
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

        private System.Windows.Forms.Timer Power_timer;
        private int currentIndex = 1;
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

            //页面实时数据
            RealInfo_timer = new Timer();
            RealInfo_timer.Interval = 5000;
            RealInfo_timer.Tick += RealInfo_Tick;
            RealInfo_timer.Start();

            //功率段设置
            Power_timer = new Timer();
            Power_timer.Interval = 10000; // 设置间隔为 10000 毫秒（10秒）  
            Power_timer.Tick += PowerSegment_Tick; // 绑定 Tick 事件  
            //Power_timer.Start();

            //获取电子负载实时数据
            Ele_timer = new Timer();
            Ele_timer.Interval = 10000; // 设置间隔为 10000 毫秒（10秒）  
            Ele_timer.Tick += EleInfo_Tick; // 绑定 Tick 事件  
            //Ele_timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ele_connection();
            Power_connection();
            lh_connection();
            Relay_connection();
        }

        //****************** 页面刷新 ******************//
        private void flash_form()
        {
            //电子负载
            string ele_pow_staus = Global.sysini.Get_Value("Ele_Power_Status");
            string ele_vol_staus = Global.sysini.Get_Value("Ele_Vol_Status");
            string ele_ele_staus = Global.sysini.Get_Value("Ele_Ele_Status");
            string ele_resis_staus = Global.sysini.Get_Value("Ele_Resis_Status");
            if ( ele_pow_staus == "ON" ) 
            {
                ele_groupBox.Text = "恒功率模式";
                ele_lb1.Text = "恒电压：";
                ele_lb2.Text = "0.0";
                ele_lb3.Text = "V";
                ele_lb4.Text = "恒电流："; 
                ele_lb5.Text = "0.0";
                ele_lb6.Text = "A";
                ele_lb7.Text = "恒功率：";
                ele_lb8.Text = "0.0";
                ele_lb9.Text = "W";
                //ele_lb7.Text = "电阻：";
                //ele_lb8.Text = "0.0";
                //ele_lb9.Text = "Ω";
            }
            if (ele_vol_staus == "ON")
            {
                ele_groupBox.Text = "恒电压模式";
                ele_lb1.Text = "恒电压：";
                ele_lb2.Text = "0.0";
                ele_lb3.Text = "V";
                ele_lb4.Text = "恒电流：";
                ele_lb5.Text = "0.0";
                ele_lb6.Text = "A";
                ele_lb7.Text = "恒功率：";
                ele_lb8.Text = "0.0";
                ele_lb9.Text = "W";
                //ele_lb1.Text = "功率：";
                //ele_lb2.Text = "0.0";
                //ele_lb3.Text = "W";
                //ele_lb4.Text = "电流：";
                //ele_lb5.Text = "0.0";
                //ele_lb6.Text = "A";
                //ele_lb7.Text = "电阻：";
                //ele_lb8.Text = "0.0";
                //ele_lb9.Text = "Ω";
            }
            if (ele_ele_staus == "ON")
            {
                ele_groupBox.Text = "恒电流模式";
                ele_lb1.Text = "恒电压：";
                ele_lb2.Text = "0.0";
                ele_lb3.Text = "V";
                ele_lb4.Text = "恒电流：";
                ele_lb5.Text = "0.0";
                ele_lb6.Text = "A";
                ele_lb7.Text = "恒功率：";
                ele_lb8.Text = "0.0";
                ele_lb9.Text = "W";
                //ele_groupBox.Text = "恒电流模式";
                //ele_lb1.Text = "功率：";
                //ele_lb2.Text = "0.0";
                //ele_lb3.Text = "W";
                //ele_lb4.Text = "电压：";
                //ele_lb5.Text = "0.0";
                //ele_lb6.Text = "V";
                //ele_lb7.Text = "电阻：";
                //ele_lb8.Text = "0.0";
                //ele_lb9.Text = "Ω";
            }
            if (ele_resis_staus == "ON")
            {
                ele_groupBox.Text = "恒电阻模式";
                ele_lb1.Text = "恒电压：";
                ele_lb2.Text = "0.0";
                ele_lb3.Text = "V";
                ele_lb4.Text = "恒电流：";
                ele_lb5.Text = "0.0";
                ele_lb6.Text = "A";
                ele_lb7.Text = "恒功率：";
                ele_lb8.Text = "0.0";
                ele_lb9.Text = "W";
                //ele_groupBox.Text = "恒电阻模式";
                //ele_lb1.Text = "功率";
                //ele_lb2.Text = "0.0";
                //ele_lb3.Text = "W";
                //ele_lb4.Text = "电压";
                //ele_lb5.Text = "0.0";
                //ele_lb6.Text = "V";
                //ele_lb7.Text = "电流";
                //ele_lb8.Text = "0.0";
                //ele_lb9.Text = "A";
            }
            pw_label.Text = Global.sysini.Get_Value("Ele_Power");
            power_1.Text = Global.sysini.Get_Value("Ele_Power_1");
            if (power_1.Text != "0.0")
            {
                power_1.Visible = true;
            }
            else
            {
                power_1.Visible = false;
            }
            power_2.Text = Global.sysini.Get_Value("Ele_Power_2");
            if (power_2.Text != "0.0")
            {
                power_2.Visible = true;
            }
            else
            {
                power_2.Visible = false;
            }
            power_3.Text = Global.sysini.Get_Value("Ele_Power_3");
            if (power_3.Text != "0.0")
            {
                power_3.Visible = true;
            }
            else
            {
                power_3.Visible = false;
            }
            power_4.Text = Global.sysini.Get_Value("Ele_Power_4");
            if (power_4.Text != "0.0")
            {
                power_4.Visible = true;
            }
            else
            {
                power_4.Visible = false;
            }
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
            Label[] relayLabels = new Label[] { relay1_label, relay2_label, relay3_label, relay4_label, relay5_label,
                                                relay6_label, relay7_label, relay8_label, relay9_label, relay10_label,
                                                relay11_label, relay12_label, relay13_label, relay14_label, relay15_label, relay16_label };
            // 循环遍历所有继电器的状态
            for (int i = 1; i <= 16; i++)
            {
                string statusKey = $"Relay{i}_Status";
                string statusValue = Global.sysini.Get_Value(statusKey);

                // 根据继电器的状态更新标签文本
                if (statusValue == "ON")
                {
                    relayLabels[i - 1].Text = "ON";
                }
                else if (statusValue == "OFF")
                {
                    relayLabels[i - 1].Text = "OFF";
                }
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

        //**************************** 初始化连接 ****************************//
        //电子负载
        private void Ele_connection()
        {
            if (Global.G_ELe.getEle_connected())
            {
                Global.G_ELe.Disconnect_Type();
                receivingBox.Items.Add("DisConnect");
            }
            else
            {
                Global.G_ELe.connect_TCP();
                receivingBox.Items.Add($"{DateTime.Now} 电子负载已连接！");
            }
        }

        //万瑞达电源
        private void Power_connection()
        {
            if (Global.G_Power.getPow_connected())
            {
                Global.G_Power.Disconnect_Type();
                receivingBox.Items.Add("DisConnect");
            }
            else
            {
                Global.G_Power.connect_TCP();
                receivingBox.Items.Add($"{DateTime.Now} 万瑞达电源已连接！");
            }
        }

        //老化柜
        private void lh_connection()
        {
            if (Global.G_lh.getlh_connected())
            {
                Global.G_lh.Disconnect_Type();
                receivingBox.Items.Add("DisConnect");
            }
            else
            {
                Global.G_lh.connect_TCP();
                receivingBox.Items.Add($"{DateTime.Now} 老化柜已连接！");
            }
        }

        //继电器
        private void Relay_connection()
        {
            if (Global.G_Rel.getRelay_connected())
            {
                Global.G_Rel.Disconnect_Type();
                receivingBox.Items.Add("DisConnect");
            }
            else
            {
                Global.G_Rel.connect_TCP();
                receivingBox.Items.Add($"{DateTime.Now} 继电器已连接！");
            }
        }

        //************************ 倒计时设置 ********************//
        private void Set_Time_btn_Click(object sender, EventArgs e)
        {
            Time time = new Time();
            // 显示窗体并获取用户设置的时间
            if (time.ShowDialog() == DialogResult.OK)
            {
                countdownTime = time.CountdownTime; // 假设 SelectedTime 返回用户设置的时间
            }
            lh_label.Text = countdownTime.ToString();
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

                    //老化时间结束重置设备
                    Reset_device();
                    //MessageBox.Show("设备重置成功");

                    Global.G_Rel.sendData_TY($"AT+STACH4=1\r\n");
                    DialogResult result = MessageBox.Show("老化结束", "操作确认", MessageBoxButtons.OK);
                    if(result == DialogResult.OK) 
                    {
                        string command = $"AT+STACH4=0\r\n";
                        Global.G_Rel.sendData_TY(command);
                    }
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

        //**************************** 参数设置 ************************//
        //参数设置
        private void Argument_btn_Click(object sender, EventArgs e)
        {
            config con = new config();
            con.Show(this);
        }

        //************************* 开始老化 **************************//
        //开始老化
        private async void beging_lh_btn_Click(object sender, EventArgs e)
        {
            //更新时间
            if (countdownTime == TimeSpan.Zero)
            {
                MessageBox.Show("请先设置时间！");
                return;
            }

            bool result = Relay_lh();
            if (result)
            {
                bool result2 = Power_lh();
                if (result2)
                {
                    await Task.Delay(30000);
                    bool result3 = Ele_lh();
                    if (result3)
                    {

                        bool result4 = Room_lh();
                        if (result4)
                        {
                            MessageBox.Show("启动老化成功！");
                            StartCountdown(countdownTime);
                        }
                        else
                        {
                            MessageBox.Show("老化柜老化启动失败！");
                        }

                    }
                    else
                    {
                        MessageBox.Show("电子负载老化启动失败！");
                    }

                }
                else
                {
                    MessageBox.Show("万瑞达老化启动失败！");
                }

            }
            else
            {
                MessageBox.Show("继电器老化启动失败！");
            }
        }

        //*************************** 老化参数 ***********************//
        //电子负载老化
        private bool Ele_lh()
        {
            bool Ele_success = false;
            if (Global.G_ELe.getEle_connected())
            {
                //开机
                string open = "INPut:STATe ON";
                string ON_data = open + "\r\n";
                Global.G_ELe.sendData_TY(ON_data);

                try
                {
                    if( ele_groupBox.Text == "恒功率模式")
                    {
                        //切换模式
                        string mode_1 = "INPut:FUNCtion CP";
                        string M_data = mode_1 + "\r\n";
                        Global.G_ELe.sendData_TY(M_data);
                        //receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + M_data);

                        //恒功率
                        string power = "STATic:CP:LEVel " + pw_label.Text;
                        string P_data = power + "\r\n";
                        Global.G_ELe.sendData_TY(P_data);
                        //receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + power);

                        //Ele_timer.Start();

                    }
                    else if (ele_groupBox.Text == "恒电压模式")
                    {
                        string mode_2 = "INPut:FUNCtion CV";
                        string M_data = mode_2 + "\r\n";
                        Global.G_ELe.sendData_TY(M_data);

                        //电压
                        string voltage = "STATic:CV:HIGH:LEVel " + vol_label_2.Text;
                        string V_data = voltage + "\r\n";
                        Global.G_ELe.sendData_TY(V_data);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + voltage);

                        //Ele_timer.Start();

                    }
                    else if(ele_groupBox.Text == "恒电流模式") 
                    {
                        string mode_3 = "INPut:FUNCtion CC";
                        string M_data = mode_3 + "\r\n";
                        Global.G_ELe.sendData_TY(M_data);

                        //电流
                        string electric = "STATic:CC:HIGH:LEVel " + ele_label_2.Text;
                        string E_data = electric + "\r\n";
                        Global.G_ELe.sendData_TY(E_data);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + electric);

                        //Ele_timer.Start();
                    }
                    else if(ele_groupBox.Text == "恒电阻模式")
                    {
                        string mode_4 = "INPut:FUNCtion CR";
                        string M_data = mode_4 + "\r\n";
                        Global.G_ELe.sendData_TY(M_data);

                        //电阻
                        string resistan = "STATic:CR:HIGH:LEVel " + resis_label_2.Text;
                        string R_data = resistan + "\r\n";
                        Global.G_ELe.sendData_TY(R_data);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + resistan);

                        //Ele_timer.Start();
                    }
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

        /************************ 其他参数 ******************/
        private void EleInfo_Tick(object sender, EventArgs e)
        {
            Read_E_CV();
            Read_E_CC();
            Read_E_CP();
        }
        private void Read_E_CP() 
        {
            Task.Run(() =>
            {
                string read_cp = "STATic:CP:HIGH:LEVel?\r\n";
                Global.G_ELe.sendData_TY(read_cp);

                this.Invoke((MethodInvoker)delegate
                {
                    string response_cp = string.Empty;
                    byte[] responseBytes_cp = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success_cp = Global.G_ELe.getResult_TY(ref response_cp, ref responseBytes_cp);
                    if (success_cp)
                    {
                        //receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                        string result = response_cp.Substring(0, 5);
                        ele_lb8.Text = result;
                    }
                });
            });
        }
        private void Read_E_CC() 
        {
            //Task.Run(() =>
            //{
                string read_cc = "STATic:CC:HIGH:LEVel?\r\n";
                Global.G_ELe.sendData_TY(read_cc);

                //this.Invoke((MethodInvoker)delegate
                //{
                    string response_cc = string.Empty;
                    byte[] Bytes_cc = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success_cc = Global.G_ELe.getResult_TY(ref response_cc, ref Bytes_cc);
                    if (success_cc)
                    {
                        //receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                        string result_cc = response_cc.Substring(0, 5);
                        ele_lb5.Text = result_cc;
                    }
                //});
            //});
        }
        private void Read_E_CV()
        {
            //Task.Run(() => {
                string read_cv = "STATic:CV:HIGH:LEVel?\r\n";
                Global.G_ELe.sendData_TY(read_cv);

                //this.Invoke((MethodInvoker)delegate
                //{
                    string response_cv = string.Empty;
                    byte[] Bytes_cv = new byte[1024 * 5]; // 根据需要设置合适的大小
                    bool success_cv = Global.G_ELe.getResult_TY(ref response_cv, ref Bytes_cv);
                    if (success_cv)
                    {
                        //receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                        string result_cv = response_cv.Substring(0, 5);
                        ele_lb2.Text = result_cv;
                    }
            //    });
            //});
        }
        private void Read_E_CR()
        {
            string read_cr = "STATic:CR:HIGH:LEVel?\r\n";
            Global.G_ELe.sendData_TY(read_cr);
            string response_cr = string.Empty;
            byte[] Bytes_cr = new byte[1024 * 5]; // 根据需要设置合适的大小
            bool success_cr = Global.G_ELe.getResult_TY(ref response_cr, ref Bytes_cr);
            if (success_cr)
            {
                //receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
                string result_cr = response_cr.Substring(0, 5);
                ele_lb8.Text = result_cr;
            }
        }

        //万瑞达电源老化
        private bool Power_lh()
        {
            bool Power_success = false;
            if (Global.G_Power.getPow_connected())
            {
                try
                {
                    //万瑞达电源状态
                    if (status_label1.Text == "ON")
                    {
                        string command1 = $"01050085FF009DD3";
                        command1 = command1.Replace(" ", "");
                        Global.G_Power.sendData_TY(command1);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command1);
                    }
                    else if (status_label2.Text == "OFF")
                    {
                        string command3 = $"010500850000DC23";
                        command3 = command3.Replace(" ", "");
                        Global.G_Power.sendData_TY(command3);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command3);
                    }
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
            }
            else
            {
                MessageBox.Show("网络串口未打开，请先连接串口！");
            }

            return Power_success;
        }

        //老化柜老化
        private bool Room_lh()
        {
            bool Room_success = false;
            if (Global.G_lh.getlh_connected())
            {
                try
                {
                    //老化柜状态
                    if (status_label2.Text == "ON")
                    {
                        string command1 = $"00000000000600050000FF00";
                        command1 = command1.Replace(" ", "");
                        Global.G_lh.sendData_TY(command1);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command1);
                    }
                    else if (status_label2.Text == "OFF")
                    {
                        string command1 = $"00000000000600050001FF00";
                        command1 = command1.Replace(" ", "");
                        Global.G_lh.sendData_TY(command1);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command1);
                    }

                    string decimalValueString = temp_label_2.Text.Trim();
                    if (decimal.TryParse(decimalValueString, out decimal decimalValue))
                    {
                        if (decimalValue <= 40)
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
                            string command2 = $"000000000006000600000{Global.G_lh.ConvertToLowerCaseHex(hexString)}";

                            string responseText = string.Empty;
                            byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                            bool success = Global.G_lh.getResult_TY(ref responseText, ref responseBytes);
                            receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                            if (success)
                            {
                                if (responseText == command2)
                                {
                                    Console.WriteLine("设置成功！");
                                    Room_success = true;
                                }
                            }
                            else
                            {
                                //输入的不是有效的十进制数  
                                Console.WriteLine("输入错误，请重新输入！");
                            }
                        }
                        else if (decimalValue > 40)
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
                                    Room_success = true;
                                }
                            }
                            else
                            {
                                //输入的不是有效的十进制数  
                                Console.WriteLine("输入错误，请重新输入！");
                            }
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

        //继电器老化
        private bool RelayControl(int relayNumber, bool state)
        {
            try
            {
                string command = $"AT+STACH{relayNumber}={(state ? 1 : 0)}\r\n";
                Global.G_Rel.sendData_TY(command);
                receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"继电器{relayNumber}控制失败: {ex.Message}");
                return false;
            }
            return true;
        }

        private bool Relay_lh()
        {
            bool Relay_success = true;
            var relayStates = new (int, bool)[] {
            (1, relay1_label.Text == "ON"),
            (2, relay2_label.Text == "ON"),
            (3, relay3_label.Text == "ON"),
            (4, relay4_label.Text == "ON"),
            (5, relay5_label.Text == "ON"),
            (6, relay6_label.Text == "ON"),
            (7, relay7_label.Text == "ON"),
            (8, relay8_label.Text == "ON"),
            (9, relay9_label.Text == "ON"),
            (10, relay10_label.Text == "ON"),
            (11, relay11_label.Text == "ON"),
            (12, relay12_label.Text == "ON"),
            (13, relay13_label.Text == "ON"),
            (14, relay14_label.Text == "ON"),
            (15, relay15_label.Text == "ON"),
            (16, relay16_label.Text == "ON")
            };

            foreach (var (relayNumber, state) in relayStates)
            {
                if (!RelayControl(relayNumber, state))
                {
                    Relay_success = false;
                }
            }
            return Relay_success;
        }

        private void Reset_device()
        {
            if (Global.G_ELe.getEle_connected())
            {
                try
                {
                    //关机
                    string close = "INPut:STATe OFF";
                    string OFF_data = close + "\r\n";
                    Global.G_ELe.sendData_TY(OFF_data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("电子负载重置失败: " + ex.Message);
                }
            }
            if (Global.G_Power.getPow_connected())
            {
                try
                {
                    string command3 = $"010500850000DC23";
                    command3 = command3.Replace(" ", "");
                    Global.G_Power.sendData_TY(command3);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("万瑞达重置失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("万瑞达网络串口未打开，请先连接串口！");
            }

            if (Global.G_lh.getlh_connected())
            {
                try
                {
                    string command = $"00000000000600050001FF00";
                    Global.G_lh.sendData_TY(command);
                    //receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("老化柜重置失败 " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("老化柜网络串口未打开，请先连接串口！");

            }

            Reset_Relay();
        }

        /************************** 数据类型转换 ***********************/
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

        //********************* 继电器重置 ************************//
        private void Reset_Relay()
        {
            if (Global.G_Rel.getRelay_connected())
            {
                string prefix = "AT+STACH";
                string suffix = "\r\n";
                int[] relayNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

                foreach (int relayNumber in relayNumbers)
                {
                    try
                    {
                        // 构造指令，确保使用正确的继电器编号
                        string command = $"{prefix}{relayNumber}=0{suffix}";
                        Global.G_Rel.sendData_TY(command);
                        receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        // 记录失败信息，包含继电器编号
                        Console.WriteLine($"继电器{relayNumber}重置失败: " + ex.Message);
                    }
                }
            }
        }

        //**************************** 页面实时数据 ***************************//
        private void RealInfo_Tick(object sender, EventArgs e)
        {
            real_info();
        }
        private void real_info()
        {
            if (Global.G_lh.getlh_connected())
            {
                Task.Run(() =>
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        string command = $"000000000006000300020001";
                        Global.G_lh.sendData_TY(command);
                        //receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("发送指令失败: " + ex.Message);
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        string responseText = string.Empty;
                        byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                        bool success = Global.G_lh.getResult_TY(ref responseText, ref responseBytes);
                        if (success)
                        {
                            //receivingBox.Items.Add($"{DateTime.Now} 接收命令: " + responseText);
                            string temp2 = responseText.Substring(18, 4);
                            int decimalValue = HexStringToDecimal(temp2);
                            double result = decimalValue / 100.0;
                            Temp_label2.Text = result.ToString("F2");

                            //判断阈值
                            if (result > 52 && result < 0)
                            {
                                MessageBox.Show("温度异常！");
                            }
                        }
                    });
                });
            }

            if (Global.G_Power.getPow_connected())
            {
                Task.Run(() =>
                {
                    try
                    {
                        // 构造指令，确保使用正确的十六进制值
                        //00104006400023014
                        string command = $"0104006400023014";
                        Global.G_Power.sendData_TY(command);
                        //receivingBox.Items.Add($"{DateTime.Now} 发送命令: " + command);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("发送指令失败: " + ex.Message);
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        string responseText = string.Empty;
                        byte[] responseBytes = new byte[1024 * 5]; // 根据需要设置合适的大小
                        bool success = Global.G_Power.getResult_TY(ref responseText, ref responseBytes);
                        if (success)
                        {
                            //receivingBox.Items.Add($"{DateTime.Now} 接收指令: " + responseText);
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
                           // Console.WriteLine("数据为：" + Pow_Vol_Result);

                            string Pow_Ele = responseText.Substring(10, 4);
                            int pow_ele = Convert.ToInt32(Pow_Ele, 16);
                            double result2 = pow_ele / 100.0;
                            string Pow_Ele_Result = result2.ToString("F2");
                            Elec_label4.Text = Pow_Ele_Result;
                           // Console.WriteLine("数据为：" + Pow_Ele_Result);
                        }
                    });
                });
            }
        }

        /************************* 分段式功率 *******************/
        private void PowerSegment_Tick(object sender, EventArgs e)
        {
            switch (currentIndex)
            {
                case 1:
                    if (power_1.Text != "0.0") 
                    {
                        PowerSegment_sent1();
                    }
                    break;
                case 2:
                    if (power_1.Text != "0.0")
                    {
                        PowerSegment_sent2();
                    }
                    break;
                case 3:
                    if (power_1.Text != "0.0")
                    {
                        PowerSegment_sent3();
                    }
                    break;
                case 4:
                    if (power_1.Text != "0.0")
                    {
                        PowerSegment_sent4();
                        //currentIndex = 1; 
                    }
                    break;
                default:
                    break;
            }
            Power_timer.Stop();

            // 更新 currentIndex 以准备下一次调用  
            currentIndex++;
            if (currentIndex > 4)
            {
                currentIndex = 1; 
            }
        }

        private void PowerSegment_sent1() 
        {
            string power = "STATic:CP:LEVel " + power_1.Text;
            string P_data = power + "\r\n";
            Global.G_ELe.sendData_TY(P_data);
        }

        private void PowerSegment_sent2()
        {
            string power2 = "STATic:CP:LEVel " + power_2.Text;
            string P_data2 = power2 + "\r\n";
            Global.G_ELe.sendData_TY(P_data2);
        }

        private void PowerSegment_sent3()
        {
            string power3 = "STATic:CP:LEVel " + power_3.Text;
            string P_data3 = power3 + "\r\n";
            Global.G_ELe.sendData_TY(P_data3);
        }

        private void PowerSegment_sent4()
        {
            string power4 = "STATic:CP:LEVel " + power_4.Text;
            string P_data4 = power4 + "\r\n";
            Global.G_ELe.sendData_TY(P_data4);
        }

        private void HeadStop_btn_Click(object sender, EventArgs e)
        {
            Reset_device();
            StopCountdown();
        }

        private void Recon_btn_Click(object sender, EventArgs e)
        {
            Ele_connection();
            Power_connection();
            lh_connection();
            Relay_connection();
        }
    }
}
