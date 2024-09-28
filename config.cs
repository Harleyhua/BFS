using System;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace BFS
{
    public partial class config : Form
    {
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

        /*****************************************电子负载****************************/
        private void ele_pow_checkBox_changed(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                power_text.Enabled = true;
                number_text.Enabled = true;
                Segment_btn.Enabled = true;
                vol_text.Enabled = false;
                ele_text.Enabled = false;
                resis_text.Enabled = false;

                ele_vol_check.Enabled = false;
                ele_Ele_check.Enabled = false;
                ele_resis_check.Enabled = false;
            }
            else
            {
                power_text.Enabled = false;
                number_text.Enabled = false;
                Segment_btn.Enabled = false;

                ele_vol_check.Enabled = true;
                ele_Ele_check.Enabled = true;
                ele_resis_check.Enabled = true;
            }
        }

        private void ele_vol_checkBox_changed(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                power_text.Enabled = false;
                vol_text.Enabled = true;
                ele_text.Enabled = false;
                resis_text.Enabled = false;

                ele_pow_check.Enabled = false;
                ele_Ele_check.Enabled = false;
                ele_resis_check.Enabled = false;
            }
            else
            {
                vol_text.Enabled = false;

                ele_pow_check.Enabled = true;
                ele_Ele_check.Enabled = true;
                ele_resis_check.Enabled = true;
            }
        }

        private void ele_Ele_checkBox_changed(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                power_text.Enabled = false;
                vol_text.Enabled = false;
                ele_text.Enabled = true;
                resis_text.Enabled = false;

                ele_pow_check.Enabled = false;
                ele_vol_check.Enabled = false;
                ele_resis_check.Enabled = false;
            }
            else
            {
                ele_text.Enabled = false;

                ele_pow_check.Enabled = true;
                ele_vol_check.Enabled = true;
                ele_resis_check.Enabled = true;
            }
        }

        private void ele_resis_checkBox_changed(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                power_text.Enabled = false;
                vol_text.Enabled = false;
                ele_text.Enabled = false;
                resis_text.Enabled = true;

                ele_pow_check.Enabled = false;
                ele_vol_check.Enabled = false;
                ele_Ele_check.Enabled = false;
            }
            else
            {
                resis_text.Enabled = false;
                ele_pow_check.Enabled = true;
                ele_vol_check.Enabled = true;
                ele_Ele_check.Enabled = true;
            }
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDataSend = new SaveFileDialog();
                saveDataSend.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // 获取文件路径
                saveDataSend.Filter = "*.txt|txt file"; 
                saveDataSend.DefaultExt = ".txt";
                saveDataSend.FileName = "Data.txt";
                if (saveDataSend.ShowDialog() == DialogResult.OK)  
                {
                    string fName = saveDataSend.FileName;
                    using (StreamWriter writer = new StreamWriter(fName, false))
                    {
                        bool isChecked_pow = ele_pow_check.Checked;
                        bool isCheced_vol = ele_vol_check.Checked;
                        bool isCheced_ele = ele_Ele_check.Checked;
                        bool isCheced_resis = ele_resis_check.Checked;

                        Control Segment_box1 = groupBox1.Controls["Segment1"];
                        Control Segment_box2 = groupBox1.Controls["Segment2"];
                        Control Segment_box3 = groupBox1.Controls["Segment3"];

                        if (isChecked_pow)
                        {
                            writer.WriteLine($"Ele_Power_Status={(isChecked_pow ? "ON" : "OFF")}");

                            if(Segment_box1 != null)
                            {
                                string text = groupBox1.Controls["Segment1"].Text;
                                writer.WriteLine($"Ele_Power_1={text}");
                            }
                            if(Segment_box2 != null)
                            {
                                string text2 = groupBox1.Controls["Segment2"].Text;
                                writer.WriteLine($"Ele_Power_2={text2}");
                            }
                            if(Segment_box3 != null)
                            {
                                string text3 = groupBox1.Controls["Segment3"].Text;
                                writer.WriteLine($"Ele_Power_3={text3}");
                            }
                        }
                        if (isCheced_vol)
                        {
                            writer.WriteLine($"Ele_Vol_Status={(isCheced_vol ? "ON" : "OFF")}");
                        }
                        if (isCheced_ele)
                        {
                            writer.WriteLine($"Ele_Ele_Status={(isCheced_ele ? "ON" : "OFF")}");
                        }
                        if (isCheced_resis)
                        {
                            writer.WriteLine($"Ele_Resis_Status={(isCheced_resis ? "ON" : "OFF")}");
                        }
                        writer.WriteLine($"Ele_Power={this.power_text.Text}");
                        writer.WriteLine($"Ele_Vol={this.vol_text.Text}");
                        writer.WriteLine($"Ele_Ele={this.ele_text.Text}");
                        writer.WriteLine($"Ele_Resis={this.resis_text.Text}");

                        writer.WriteLine($"Power_Status={(open_Btn.Checked ? "ON" : "OFF")}");
                        writer.WriteLine($"Power_Vol={this.vol_text2.Text}");
                        writer.WriteLine($"Power_Ele={this.ele_text2.Text}");

                        writer.WriteLine($"Room_Status={(lh_open_radio.Checked ? "ON" : "OFF")}");
                        writer.WriteLine($"Room_Temp={this.Temp_text.Text}");

                        if (buttonCheck1.Checked)
                        {
                            writer.WriteLine($"Relay1_Status={"OFF"}");
                        }
                        else 
                        {
                            writer.WriteLine($"Relay1_Status={"ON"}");
                        }
                        if (buttonCheck2.Checked)
                        {
                            writer.WriteLine($"Relay2_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay2_Status={"ON"}");
                        }
                        if (buttonCheck3.Checked)
                        {
                            writer.WriteLine($"Relay3_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay3_Status={"ON"}");
                        }
                        if (buttonCheck4.Checked)
                        {
                            writer.WriteLine($"Relay4_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay4_Status={"ON"}");
                        }
                        if (buttonCheck5.Checked)
                        {
                            writer.WriteLine($"Relay5_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay5_Status={"ON"}");
                        }
                        if (buttonCheck6.Checked)
                        {
                            writer.WriteLine($"Relay6_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay6_Status={"ON"}");
                        }
                        if (buttonCheck_7.Checked)
                        {
                            writer.WriteLine($"Relay7_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay7_Status={"ON"}");
                        }
                        if (buttonCheck_8.Checked)
                        {
                            writer.WriteLine($"Relay8_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay8_Status={"ON"}");
                        }
                        if (buttonCheck_9.Checked)
                        {
                            writer.WriteLine($"Relay9_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay9_Status={"ON"}");
                        }
                        if (buttonCheck_10.Checked)
                        {
                            writer.WriteLine($"Relay10_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay10_Status={"ON"}");
                        }
                        if (buttonCheck11.Checked)
                        {
                            writer.WriteLine($"Relay11_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay11_Status={"ON"}");
                        }
                        if (buttonCheck12.Checked)
                        {
                            writer.WriteLine($"Relay12_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay12_Status={"ON"}");
                        }
                        if (buttonCheck13.Checked)
                        {
                            writer.WriteLine($"Relay13_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay13_Status={"ON"}");
                        }
                        if (buttonCheck14.Checked)
                        {
                            writer.WriteLine($"Relay14_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay14_Status={"ON"}");
                        }
                        if (buttonCheck15.Checked)
                        {
                            writer.WriteLine($"Relay15_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay15_Status={"ON"}");
                        }
                        if (buttonCheck16.Checked)
                        {
                            writer.WriteLine($"Relay16_Status={"OFF"}");
                        }
                        else
                        {
                            writer.WriteLine($"Relay16_Status={"ON"}");
                        }
                    }
                }
                MessageBox.Show("数据已保存到文件");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存数据时发生错误: {ex.Message}");
            }
        }

        private void Load_btn_Click(object sender, EventArgs e)
        {
            string ele_pow_status = null;
            string ele_vol_status = null;
            string ele_ele_status = null;
            string ele_resis_status = null;

            string power_status = null;
            string room_status = null;

            string relay1_status = null;
            string relay2_status = null;
            string relay3_status = null;
            string relay4_status = null;
            string relay5_status = null;
            string relay6_status = null;
            string relay7_status = null;
            string relay8_status = null;
            string relay9_status = null;
            string relay10_status = null;
            string relay11_status = null;
            string relay12_status = null;
            string relay13_status = null;
            string relay14_status = null;
            string relay15_status = null;
            string relay16_status = null;

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                dialog.Title = "请选择文件夹";
                dialog.Filter = "所有文件(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.StartsWith("Ele_Power_Status="))
                            {
                                ele_pow_status = line.Split('=')[1].Trim();   
                            }
                            else if (line.StartsWith("Ele_Vol_Status="))
                            {
                                ele_vol_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Ele_Ele_Status="))
                            {
                                ele_ele_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Ele_Resis_Status="))
                            {
                                ele_resis_status = line.Split('=')[1].Trim();
                            }
                            //数值
                            else if (line.StartsWith("Ele_Power="))
                            {
                                power_text.Text = line.Substring("Ele_Power=".Length);
                            }
                            else if (line.StartsWith("Ele_Power_1="))
                            {
                                string power1 = line.Substring("Ele_Power_1=".Length);
                                if(power1 != null)
                                {
                                    power_1.Text = power1;
                                    power_1.Visible = true;
                                }
                            }
                            else if (line.StartsWith("Ele_Power_2="))
                            {
                                string power2 = line.Substring("Ele_Power_2=".Length);
                                if (power2 != null)
                                {
                                    power_2.Text = power2;
                                    power_2.Visible = true;
                                }
                            }
                            else if (line.StartsWith("Ele_Power_3="))
                            {
                                string power3 = line.Substring("Ele_Power_3=".Length);
                                if (power3 != null)
                                {
                                    power_3.Text = power3;
                                    power_3.Visible = true;
                                }
                            }
                            else if (line.StartsWith("Ele_Vol="))
                            {
                                vol_text.Text = line.Substring("Ele_Vol=".Length);
                            }
                            else if (line.StartsWith("Ele_Ele="))
                            {
                                ele_text.Text = line.Substring("Ele_Ele=".Length);
                            }
                            else if (line.StartsWith("Ele_Resis="))
                            {
                                resis_text.Text = line.Substring("Ele_Resis=".Length);
                            }
                            else if (line.StartsWith("Power_Status="))
                            {
                                power_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Power_Vol="))
                            {
                                vol_text2.Text = line.Substring("Power_Vol=".Length);
                            }
                            else if (line.StartsWith("Power_Ele="))
                            {
                                ele_text2.Text = line.Substring("Power_Ele=".Length);
                            }
                            else if (line.StartsWith("Room_Status="))
                            {
                                room_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Room_Temp="))
                            {
                                Temp_text.Text = line.Substring("Room_Temp=".Length);
                            }
                            else if (line.StartsWith("Relay1_Status="))
                            {
                                relay1_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay2_Status="))
                            {
                                relay2_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay3_Status="))
                            {
                                relay3_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay4_Status="))
                            {
                                relay4_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay5_Status="))
                            {
                                relay5_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay6_Status="))
                            {
                                relay6_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay7_Status="))
                            {
                                relay7_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay8_Status="))
                            {
                                relay8_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay9_Status="))
                            {
                                relay9_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay10_Status="))
                            {
                                relay10_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay11_Status="))
                            {
                                relay11_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay12_Status="))
                            {
                                relay12_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay13_Status="))
                            {
                                relay13_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay14_Status="))
                            {
                                relay14_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay15_Status="))
                            {
                                relay15_status = line.Split('=')[1].Trim();
                            }
                            else if (line.StartsWith("Relay16_Status="))
                            {
                                relay16_status = line.Split('=')[1].Trim();
                            }
                        }
                    }
                }
                if (ele_pow_status == "ON")
                {
                    ele_pow_check.Checked = true;
                }
                else 
                {
                    ele_pow_check.Checked = false;
                }
                if (ele_vol_status == "ON" )
                {
                    ele_vol_check.Checked = true;
                }
                else
                {
                    ele_vol_check.Checked = false;
                }
                if (ele_ele_status == "ON")
                {
                    ele_Ele_check.Checked = true;
                }
                else
                {
                    ele_Ele_check.Checked = false;
                }
                if (ele_resis_status == "ON")
                {
                    ele_resis_check.Checked = true;
                }
                else
                {
                    ele_resis_check.Checked = false;
                }
                if (power_status == "ON")
                {
                    open_Btn.Checked = true;
                }
                else
                {
                    close_Btn.Checked = true;
                }
                if (room_status == "ON")
                {
                    lh_open_radio.Checked = true;
                }
                else
                {
                    lh_close_radio.Checked = true;
                }

                if (relay1_status == "ON")
                {
                    buttonCheck1.Checked = false;
                }
                else if (relay1_status == "OFF")
                {
                    buttonCheck1.Checked = true;
                }
                if (relay2_status == "ON")
                {
                    buttonCheck2.Checked = false;
                }
                else if (relay2_status == "OFF")
                {
                    buttonCheck2.Checked = true;
                }
                if (relay3_status == "ON")
                {
                    buttonCheck3.Checked = false;
                }
                else if (relay3_status == "OFF")
                {
                    buttonCheck3.Checked = true;
                }
                if (relay4_status == "ON")
                {
                    buttonCheck4.Checked = false;
                }
                else if (relay4_status == "OFF")
                {
                    buttonCheck4.Checked = true;
                }
                if (relay5_status == "ON")
                {
                    buttonCheck5.Checked = false;
                }
                else if (relay5_status == "OFF")
                {
                    buttonCheck5.Checked = true;
                }
                if (relay6_status == "ON")
                {
                    buttonCheck6.Checked = false;
                }
                else if (relay6_status == "OFF")
                {
                    buttonCheck6.Checked = true;
                }
                if (relay7_status == "ON")
                {
                    buttonCheck_7.Checked = false;
                }
                else if (relay7_status == "OFF")
                {
                    buttonCheck_7.Checked = true;
                }
                if (relay8_status == "ON")
                {
                    buttonCheck_8.Checked = false;
                }
                else if (relay8_status == "OFF")
                {
                    buttonCheck_8.Checked = true;
                }
                if (relay9_status == "ON")
                {
                    buttonCheck_9.Checked = false;
                }
                else if (relay9_status == "OFF")
                {
                    buttonCheck_9.Checked = true;
                }
                if (relay10_status == "ON")
                {
                    buttonCheck_10.Checked = false;
                }
                else if (relay10_status == "OFF")
                {
                    buttonCheck_10.Checked = true;
                }
                if (relay11_status == "ON")
                {
                    buttonCheck11.Checked = false;
                }
                else if (relay11_status == "OFF")
                {
                    buttonCheck11.Checked = true;
                }
                if (relay12_status == "ON")
                {
                    buttonCheck12.Checked = false;
                }
                else if (relay12_status == "OFF")
                {
                    buttonCheck12.Checked = true;
                }
                if (relay13_status == "ON")
                {
                    buttonCheck13.Checked = false;
                }
                else if (relay13_status == "OFF")
                {
                    buttonCheck13.Checked = true;
                }
                if (relay14_status == "ON")
                {
                    buttonCheck14.Checked = false;
                }
                else if (relay14_status == "OFF")
                {
                    buttonCheck14.Checked = true;
                }
                if (relay15_status == "ON")
                {
                    buttonCheck15.Checked = false;
                }
                else if (relay15_status == "OFF")
                {
                    buttonCheck15.Checked = true;
                }
                if (relay16_status == "ON")
                {
                    buttonCheck16.Checked = false;
                }
                else if (relay16_status == "OFF")
                {
                    buttonCheck16.Checked = true;
                }

                MessageBox.Show($"脚本加载成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"从文件读取数据时发生错误: {ex.Message}");
            }
        }

        private void beging_btn_Click(object sender, EventArgs e)
        {
            //电子负载
            bool isChecked_pow = ele_pow_check.Checked;
            bool isCheced_vol = ele_vol_check.Checked;
            bool isCheced_ele = ele_Ele_check.Checked;
            bool isCheced_resis = ele_resis_check.Checked;

            if (isChecked_pow)
            {
                Global.sysini.Updata_Value("Ele_Power_Status", "ON");
            }
            else
            {
                Global.sysini.Updata_Value("Ele_Power_Status", "OFF");
            }

            if (isCheced_vol)
            {
                Global.sysini.Updata_Value("Ele_Vol_Status", "ON");
            }
            else
            {
                Global.sysini.Updata_Value("Ele_Vol_Status", "OFF");
            }
            if (isCheced_ele)
            {
                Global.sysini.Updata_Value("Ele_Ele_Status", "ON");
            }
            else
            {
                Global.sysini.Updata_Value("Ele_Ele_Status", "OFF");
            }
            if (isCheced_resis)
            {
                Global.sysini.Updata_Value("Ele_Resis_Status", "ON");
            }
            else
            {
                Global.sysini.Updata_Value("Ele_Resis_Status", "OFF");
            }

            Global.sysini.Updata_Value1("Ele_Power", power_text.Text);


            Control segmentControl = groupBox1.Controls["Segment1"];
            if (segmentControl != null)
            {
                string text = groupBox1.Controls["Segment1"].Text;
                Global.sysini.Updata_Value("Ele_Power_1", text);
                string text2 = groupBox1.Controls["Segment2"].Text;
                Global.sysini.Updata_Value("Ele_Power_2", text2);
                string text3 = groupBox1.Controls["Segment3"].Text;
                Global.sysini.Updata_Value("Ele_Power_3", text3);
            }
            else
            {
                Global.sysini.Updata_Value1("Ele_Power_1", power_1.Text);
                Global.sysini.Updata_Value1("Ele_Power_2", power_2.Text);
                Global.sysini.Updata_Value1("Ele_Power_3", power_3.Text);
            }
            Global.sysini.Updata_Value1("Ele_Vol", vol_text.Text);
            Global.sysini.Updata_Value1("Ele_Ele", ele_text.Text);
            Global.sysini.Updata_Value1("Ele_Resis", resis_text.Text);


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
            Global.sysini.Updata_Value1("Power_Status", pow_status);
            Global.sysini.Updata_Value1("Power_Vol", vol_text2.Text);
            Global.sysini.Updata_Value1("Power_Ele", ele_text2.Text);


            //老化柜
            string room_status = "OFF";
            if (lh_open_radio.Checked)
            {
                room_status = "ON";
            }
            else if (lh_close_radio.Checked)
            {
                room_status = "OFF";

            }
            Global.sysini.Updata_Value1("lh_Status", room_status);
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

        private void Segment_btn_Click(object sender, EventArgs e)
        {
            string str = number_text.Text;
            int numbers = Convert.ToInt32(str);
            Create_Box(numbers);
        }

        private void Create_Box(int number)
        {
            int currentButtonX = 30; // 初始Y坐标
            for (int i = 0; i < number; i++)
            {
                TextBox newBox = new TextBox();
                newBox.Name = $"Segment{i + 1}";
                newBox.Location = new Point(currentButtonX, 290);
                newBox.Size = new Size(53, 23);
                groupBox1.Controls.Add(newBox);
                currentButtonX += 80; 
            }
        }
    }
}
