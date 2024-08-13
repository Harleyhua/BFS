using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    public partial class config : Form
    {
        //private lh_info parentForm;

        //继电器
        string relay1_status = "OFF";
        string relay2_status = "OFF";
        string relay3_status = "OFF";
        string relay4_status = "OFF";
        string relay5_status = "OFF";
        string relay6_status = "OFF";
        string relay7_status = "OFF";
        string relay8_status = "OFF";
        string relay9_status = "OFF";
        string relay10_status = "OFF";
        string relay11_status = "OFF";
        string relay12_status = "OFF";
        string relay13_status = "OFF";
        string relay14_status = "OFF";
        string relay15_status = "OFF";
        string relay16_status = "OFF";

        public config()
        {
            InitializeComponent();
            // 设置窗体启动位置为屏幕中心
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Load += new EventHandler(config_Load);

            //读取配置文件
            //this.Text = Global.con.Get_Value("windowsTitle");
        }

        private void config_Load(object sender, EventArgs e)
        {
            //// 使用属性来设置TextBox的值  
            //if (!string.IsNullOrEmpty(PowerTextValue))
            //{
            //    power_text.Text = PowerTextValue;
            //}
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //触发保存地址(配置文件)
                //电子负载
                Global.sysini.Updata_Value("Ele_Power",power_text.Text);
                Global.sysini.Updata_Value("Ele_Vol", this.vol_text.Text);
                Global.sysini.Updata_Value("Ele_Ele", this.ele_text.Text);
                Global.sysini.Updata_Value("Ele_Resis", this.resis_text.Text);
                //万瑞达电源
                string pow_status = "OFF";
                if (open_Btn.Checked)
                {
                    pow_status = "ON";
                }
                else if (close_Btn.Checked)
                {
                    pow_status = "OFF";
                }
                Global.sysini.Updata_Value("Power_Status", pow_status);
                Global.sysini.Updata_Value("Power_Vol", this.vol_text2.Text);
                Global.sysini.Updata_Value("Power_Ele", this.ele_text2.Text);
                //老化柜
                string lh_status = "OFF";
                if (lh_open_radio.Checked)
                {
                    lh_status = "ON";
                }
                else if (lh_close_radio.Checked)
                {
                    lh_status = "OFF";
                }
                Global.sysini.Updata_Value("lh_Status", lh_status);
                Global.sysini.Updata_Value("lh_Temp", this.Temp_text.Text);
                ////继电器
                //string relay1_status = "OFF";
                //string relay2_status = "OFF";
                //string relay3_status = "OFF";
                //string relay4_status = "OFF";
                //string relay5_status = "OFF";
                //string relay6_status = "OFF";
                //string relay7_status = "OFF";
                //string relay8_status = "OFF";
                //string relay9_status = "OFF";
                //string relay10_status = "OFF";
                //string relay11_status = "OFF";
                //string relay12_status = "OFF";
                //string relay13_status = "OFF";
                //string relay14_status = "OFF";
                //string relay15_status = "OFF";
                //string relay16_status = "OFF";

                if (buttonCheck1.Checked)
                {
                    relay1_status = "OFF";
                }
                else
                {
                    relay1_status = "ON";
                }
                Global.sysini.Updata_Value("Relay1_Status", relay1_status);
                if (buttonCheck2.Checked)
                {
                    relay2_status = "OFF";
                }
                else
                {
                    relay2_status = "ON";
                }
                Global.sysini.Updata_Value("Relay2_Status", relay2_status);
                if (buttonCheck3.Checked)
                {
                    relay3_status = "OFF";
                }
                else
                {
                    relay3_status = "ON";
                }
                Global.sysini.Updata_Value("Relay3_Status", relay3_status);
                if (buttonCheck4.Checked)
                {
                    relay4_status = "OFF";
                }
                else
                {
                    relay4_status = "ON";
                }
                Global.sysini.Updata_Value("Relay4_Status", relay4_status);
                if (buttonCheck5.Checked)
                {
                    relay5_status = "OFF";
                }
                else
                {
                    relay5_status = "ON";
                }
                Global.sysini.Updata_Value("Relay5_Status", relay5_status);
                if (buttonCheck6.Checked)
                {
                    relay6_status = "OFF";
                }
                else
                {
                    relay6_status = "ON";
                }
                Global.sysini.Updata_Value("Relay6_Status", relay6_status);
                if (buttonCheck_7.Checked)
                {
                    relay7_status = "OFF";
                }
                else
                {
                    relay7_status = "ON";
                }
                Global.sysini.Updata_Value("Relay7_Status", relay7_status);
                if (buttonCheck_8.Checked)
                {
                    relay8_status = "OFF";
                }
                else
                {
                    relay8_status = "ON";
                }
                Global.sysini.Updata_Value("Relay8_Status", relay8_status);
                if (buttonCheck_9.Checked)
                {
                    relay9_status = "OFF";
                }
                else
                {
                    relay9_status = "ON";
                }
                Global.sysini.Updata_Value("Relay9_Status", relay9_status);
                if (buttonCheck_10.Checked)
                {
                    relay10_status = "OFF";
                }
                else
                {
                    relay10_status = "ON";
                }
                Global.sysini.Updata_Value("Relay10_Status", relay10_status);
                if (buttonCheck11.Checked)
                {
                    relay11_status = "OFF";
                }
                else
                {
                    relay11_status = "ON";
                }
                Global.sysini.Updata_Value("Relay11_Status", relay11_status);
                if (buttonCheck12.Checked)
                {
                    relay12_status = "OFF";
                }
                else
                {
                    relay12_status = "ON";
                }
                Global.sysini.Updata_Value("Relay12_Status", relay12_status);
                if (buttonCheck13.Checked)
                {
                    relay13_status = "OFF";
                }
                else
                {
                    relay13_status = "ON";
                }
                Global.sysini.Updata_Value("Relay13_Status", relay13_status);
                if (buttonCheck14.Checked)
                {
                    relay14_status = "OFF";
                }
                else
                {
                    relay14_status = "ON";
                }
                Global.sysini.Updata_Value("Relay14_Status", relay14_status);
                if (buttonCheck15.Checked)
                {
                    relay15_status = "OFF";
                }
                else
                {
                    relay15_status = "ON";
                }
                Global.sysini.Updata_Value("Relay15_Status", relay15_status);
                if (buttonCheck16.Checked)
                {
                    relay16_status = "OFF";
                }
                else
                {
                    relay16_status = "ON";
                }
                Global.sysini.Updata_Value("Relay16_Status", relay16_status);

                MessageBox.Show("数据已成功保存到文件。");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存数据时发生错误: {ex.Message}");
            }
        }

        private void Load_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //读取配置文件
                //电子负载
                power_text.Text = Global.sysini.Get_Value("Ele_Power");
                vol_text.Text = Global.sysini.Get_Value("Ele_Vol");
                ele_text.Text = Global.sysini.Get_Value("Ele_Ele");
                resis_text.Text = Global.sysini.Get_Value("Ele_Resis");
                //万瑞达电源
                string pow_status = Global.sysini.Get_Value("Power_Status");
                if (pow_status == "ON")
                {
                    open_Btn.Checked = true;
                }
                else if (pow_status == "OFF")
                {
                    close_Btn.Checked = true;
                }
                vol_text2.Text = Global.sysini.Get_Value("Power_Vol");
                ele_text2.Text = Global.sysini.Get_Value("Power_Ele");
                //老化柜
                string lh_status = Global.sysini.Get_Value("lh_Status");
                if (lh_status == "ON")
                {
                    open_Btn.Checked = true;
                }
                else if (lh_status == "OFF")
                {
                    close_Btn.Checked = true;
                }
                Temp_text.Text = Global.sysini.Get_Value("lh_Temp");
                //继电器
                string relay1_status = Global.sysini.Get_Value("Relay1_Status");
                if (relay1_status == "ON")
                {
                    buttonCheck1.Checked = false;
                }
                else if (relay1_status == "OFF")
                {
                    buttonCheck1.Checked = true;
                }
                string relay2_status = Global.sysini.Get_Value("Relay2_Status");
                if (relay2_status == "ON")
                {
                    buttonCheck2.Checked = false;
                }
                else if (relay2_status == "OFF")
                {
                    buttonCheck2.Checked = true;
                }
                string relay3_status = Global.sysini.Get_Value("Relay3_Status");
                if (relay3_status == "ON")
                {
                    buttonCheck3.Checked = false;
                }
                else if (relay3_status == "OFF")
                {
                    buttonCheck3.Checked = true;
                }
                string relay4_status = Global.sysini.Get_Value("Relay4_Status");
                if (relay4_status == "ON")
                {
                    buttonCheck4.Checked = false;
                }
                else if (relay4_status == "OFF")
                {
                    buttonCheck4.Checked = true;
                }
                string relay5_status = Global.sysini.Get_Value("Relay5_Status");
                if (relay5_status == "ON")
                {
                    buttonCheck5.Checked = false;
                }
                else if (relay5_status == "OFF")
                {
                    buttonCheck5.Checked = true;
                }
                string relay6_status = Global.sysini.Get_Value("Relay6_Status");
                if (relay6_status == "ON")
                {
                    buttonCheck6.Checked = false;
                }
                else if (relay6_status == "OFF")
                {
                    buttonCheck6.Checked = true;
                }
                string relay7_status = Global.sysini.Get_Value("Relay7_Status");
                if (relay7_status == "ON")
                {
                    buttonCheck_7.Checked = false;
                }
                else if (relay7_status == "OFF")
                {
                    buttonCheck_7.Checked = true;
                }
                string relay8_status = Global.sysini.Get_Value("Relay8_Status");
                if (relay8_status == "ON")
                {
                    buttonCheck_8.Checked = false;
                }
                else if (relay8_status == "OFF")
                {
                    buttonCheck_8.Checked = true;
                }
                string relay9_status = Global.sysini.Get_Value("Relay9_Status");
                if (relay9_status == "ON")
                {
                    buttonCheck_9.Checked = false;
                }
                else if (relay9_status == "OFF")
                {
                    buttonCheck_9.Checked = true;
                }
                string relay10_status = Global.sysini.Get_Value("Relay10_Status");
                if (relay10_status == "ON")
                {
                    buttonCheck_10.Checked = false;
                }
                else if (relay10_status == "OFF")
                {
                    buttonCheck_10.Checked = true;
                }
                string relay11_status = Global.sysini.Get_Value("Relay11_Status");
                if (relay11_status == "ON")
                {
                    buttonCheck11.Checked = false;
                }
                else if (relay11_status == "OFF")
                {
                    buttonCheck11.Checked = true;
                }
                string relay12_status = Global.sysini.Get_Value("Relay12_Status");
                if (relay12_status == "ON")
                {
                    buttonCheck12.Checked = false;
                }
                else if (relay12_status == "OFF")
                {
                    buttonCheck12.Checked = true;
                }
                string relay13_status = Global.sysini.Get_Value("Relay13_Status");
                if (relay13_status == "ON")
                {
                    buttonCheck13.Checked = false;
                }
                else if (relay13_status == "OFF")
                {
                    buttonCheck13.Checked = true;
                }
                string relay14_status = Global.sysini.Get_Value("Relay14_Status");
                if (relay14_status == "ON")
                {
                    buttonCheck14.Checked = false;
                }
                else if (relay14_status == "OFF")
                {
                    buttonCheck14.Checked = true;
                }
                string relay15_status = Global.sysini.Get_Value("Relay15_Status");
                if (relay15_status == "ON")
                {
                    buttonCheck15.Checked = false;
                }
                else if (relay15_status == "OFF")
                {
                    buttonCheck15.Checked = true;
                }
                string relay16_status = Global.sysini.Get_Value("Relay16_Status");
                if (relay16_status == "ON")
                {
                    buttonCheck16.Checked = false;
                }
                else if (relay16_status == "OFF")
                {
                    buttonCheck16.Checked = true;
                }

                MessageBox.Show("数据已成功加载到页面。");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"从文件读取数据时发生错误: {ex.Message}");
            }
        }

        private void beging_btn_Click(object sender, EventArgs e)
        {
            //电子负载
            Global.sysini.Updata_Value1("Ele_Power", power_text.Text);
            Global.sysini.Updata_Value1("Ele_Vol", vol_text.Text);
            Global.sysini.Updata_Value1("Ele_Ele", ele_text.Text);
            Global.sysini.Updata_Value1("Ele_Resis", resis_text.Text);
            //万瑞达电源
            string pow_status = "OFF";
            if (pow_status == "ON")
            {
                Global.sysini.Updata_Value1("Power_Status", pow_status);
                open_Btn.Checked = true;
            }
            else if (pow_status == "OFF")
            {
                close_Btn.Checked = true;
                Global.sysini.Updata_Value1("Power_Status", pow_status);
            }
            Global.sysini.Updata_Value1("Power_Vol", vol_text2.Text);
            Global.sysini.Updata_Value1("Power_Ele", ele_text2.Text);
            //老化柜
            string room_status = "OFF";
            if (room_status == "ON")
            {
                Global.sysini.Updata_Value1("lh_Status", room_status);
                open_Btn.Checked = true;
            }
            else if (room_status == "OFF")
            {
                close_Btn.Checked = true;
                Global.sysini.Updata_Value1("lh_Status", room_status);
            }
            Global.sysini.Updata_Value1("lh_Temp", Temp_text.Text);
            //继电器
            if (buttonCheck1.Checked)
            {
                relay1_status = "OFF";
            }
            else
            {
                relay1_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay1_Status", relay1_status);
            if (buttonCheck2.Checked)
            {
                relay2_status = "OFF";
            }
            else
            {
                relay2_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay2_Status", relay2_status);
            if (buttonCheck3.Checked)
            {
                relay3_status = "OFF";
            }
            else
            {
                relay3_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay3_Status", relay3_status);
            if (buttonCheck4.Checked)
            {
                relay4_status = "OFF";
            }
            else
            {
                relay4_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay4_Status", relay4_status);
            if (buttonCheck5.Checked)
            {
                relay5_status = "OFF";
            }
            else
            {
                relay5_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay5_Status", relay5_status);
            if (buttonCheck6.Checked)
            {
                relay6_status = "OFF";
            }
            else
            {
                relay6_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay6_Status", relay6_status);
            if (buttonCheck_7.Checked)
            {
                relay7_status = "OFF";
            }
            else
            {
                relay7_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay7_Status", relay7_status);
            if (buttonCheck_8.Checked)
            {
                relay8_status = "OFF";
            }
            else
            {
                relay8_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay8_Status", relay8_status);
            if (buttonCheck_9.Checked)
            {
                relay9_status = "OFF";
            }
            else
            {
                relay9_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay9_Status", relay9_status);
            if (buttonCheck_10.Checked)
            {
                relay10_status = "OFF";
            }
            else
            {
                relay10_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay10_Status", relay10_status);
            if (buttonCheck11.Checked)
            {
                relay11_status = "OFF";
            }
            else
            {
                relay11_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay11_Status", relay11_status);
            if (buttonCheck12.Checked)
            {
                relay12_status = "OFF";
            }
            else
            {
                relay12_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay12_Status", relay12_status);
            if (buttonCheck13.Checked)
            {
                relay13_status = "OFF";
            }
            else
            {
                relay13_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay13_Status", relay13_status);
            if (buttonCheck14.Checked)
            {
                relay14_status = "OFF";
            }
            else
            {
                relay14_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay14_Status", relay14_status);
            if (buttonCheck15.Checked)
            {
                relay15_status = "OFF";
            }
            else
            {
                relay15_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay15_Status", relay15_status);
            if (buttonCheck16.Checked)
            {
                relay16_status = "OFF";
            }
            else
            {
                relay16_status = "ON";
            }
            Global.sysini.Updata_Value1("Relay16_Status", relay16_status);


            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
