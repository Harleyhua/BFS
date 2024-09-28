namespace BFS
{
    partial class Ele_info
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.Sent = new System.Windows.Forms.Button();
            this.receivingBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hostPort = new System.Windows.Forms.ComboBox();
            this.HostAdress = new System.Windows.Forms.ComboBox();
            this.Connect_Way = new System.Windows.Forms.ComboBox();
            this.disconnect = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.Power_label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Re_pw_btn = new System.Windows.Forms.Button();
            this.Set_Pow_btn = new System.Windows.Forms.Button();
            this.Constant_Power = new System.Windows.Forms.TextBox();
            this.Electric = new System.Windows.Forms.TextBox();
            this.Set_Ele_btn = new System.Windows.Forms.Button();
            this.Re_Ele_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Ele_label = new System.Windows.Forms.Label();
            this.Voltage_box = new System.Windows.Forms.TextBox();
            this.Set_Vol_btn = new System.Windows.Forms.Button();
            this.Re_Vol_btn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Vol_label = new System.Windows.Forms.Label();
            this.Resis_Box = new System.Windows.Forms.TextBox();
            this.Set_Resis_btn = new System.Windows.Forms.Button();
            this.Re_Resis_btn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Resistance_label = new System.Windows.Forms.Label();
            this.Pow_check = new System.Windows.Forms.CheckBox();
            this.Vol_check = new System.Windows.Forms.CheckBox();
            this.Curr_check = new System.Windows.Forms.CheckBox();
            this.Resis_check = new System.Windows.Forms.CheckBox();
            this.ON_btn = new System.Windows.Forms.Button();
            this.OFF_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InputBox);
            this.groupBox1.Controls.Add(this.Sent);
            this.groupBox1.Controls.Add(this.receivingBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 429);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志";
            // 
            // InputBox
            // 
            this.InputBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputBox.Location = new System.Drawing.Point(444, 18);
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(286, 72);
            this.InputBox.TabIndex = 3;
            // 
            // Sent
            // 
            this.Sent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sent.Location = new System.Drawing.Point(736, 41);
            this.Sent.Name = "Sent";
            this.Sent.Size = new System.Drawing.Size(57, 33);
            this.Sent.TabIndex = 2;
            this.Sent.Text = "发送";
            this.Sent.UseVisualStyleBackColor = true;
            this.Sent.Click += new System.EventHandler(this.Sent_Click_1);
            // 
            // receivingBox
            // 
            this.receivingBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.receivingBox.FormattingEnabled = true;
            this.receivingBox.ItemHeight = 17;
            this.receivingBox.Location = new System.Drawing.Point(6, 18);
            this.receivingBox.Name = "receivingBox";
            this.receivingBox.Size = new System.Drawing.Size(432, 72);
            this.receivingBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "端口号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(31, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "IP地址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "连接方式:";
            // 
            // hostPort
            // 
            this.hostPort.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hostPort.FormattingEnabled = true;
            this.hostPort.Items.AddRange(new object[] {
            "7000"});
            this.hostPort.Location = new System.Drawing.Point(107, 137);
            this.hostPort.Name = "hostPort";
            this.hostPort.Size = new System.Drawing.Size(121, 28);
            this.hostPort.TabIndex = 13;
            // 
            // HostAdress
            // 
            this.HostAdress.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HostAdress.FormattingEnabled = true;
            this.HostAdress.Items.AddRange(new object[] {
            "10.10.106.240"});
            this.HostAdress.Location = new System.Drawing.Point(107, 73);
            this.HostAdress.Name = "HostAdress";
            this.HostAdress.Size = new System.Drawing.Size(121, 28);
            this.HostAdress.TabIndex = 12;
            // 
            // Connect_Way
            // 
            this.Connect_Way.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Connect_Way.FormattingEnabled = true;
            this.Connect_Way.Items.AddRange(new object[] {
            "TCP网络",
            "串口调试"});
            this.Connect_Way.Location = new System.Drawing.Point(107, 15);
            this.Connect_Way.Name = "Connect_Way";
            this.Connect_Way.Size = new System.Drawing.Size(121, 28);
            this.Connect_Way.TabIndex = 11;
            // 
            // disconnect
            // 
            this.disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.disconnect.Location = new System.Drawing.Point(181, 214);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(75, 31);
            this.disconnect.TabIndex = 10;
            this.disconnect.Text = "断开";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click_1);
            // 
            // connect
            // 
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.connect.Location = new System.Drawing.Point(24, 214);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 31);
            this.connect.TabIndex = 9;
            this.connect.Text = "连接";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // Power_label
            // 
            this.Power_label.AutoSize = true;
            this.Power_label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Power_label.Location = new System.Drawing.Point(396, 23);
            this.Power_label.Name = "Power_label";
            this.Power_label.Size = new System.Drawing.Size(50, 21);
            this.Power_label.TabIndex = 19;
            this.Power_label.Text = "00.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(442, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 21);
            this.label6.TabIndex = 20;
            this.label6.Text = "W";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(442, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 21);
            this.label7.TabIndex = 22;
            this.label7.Text = "W";
            // 
            // Re_pw_btn
            // 
            this.Re_pw_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Re_pw_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Re_pw_btn.Location = new System.Drawing.Point(488, 21);
            this.Re_pw_btn.Name = "Re_pw_btn";
            this.Re_pw_btn.Size = new System.Drawing.Size(56, 27);
            this.Re_pw_btn.TabIndex = 23;
            this.Re_pw_btn.Text = "读取";
            this.Re_pw_btn.UseVisualStyleBackColor = true;
            this.Re_pw_btn.Click += new System.EventHandler(this.Re_pw_btn_Click);
            // 
            // Set_Pow_btn
            // 
            this.Set_Pow_btn.Enabled = false;
            this.Set_Pow_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Set_Pow_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Set_Pow_btn.Location = new System.Drawing.Point(488, 76);
            this.Set_Pow_btn.Name = "Set_Pow_btn";
            this.Set_Pow_btn.Size = new System.Drawing.Size(56, 27);
            this.Set_Pow_btn.TabIndex = 24;
            this.Set_Pow_btn.Text = "设置";
            this.Set_Pow_btn.UseVisualStyleBackColor = true;
            this.Set_Pow_btn.Click += new System.EventHandler(this.Set_Pow_btn_Click);
            // 
            // Constant_Power
            // 
            this.Constant_Power.Location = new System.Drawing.Point(400, 78);
            this.Constant_Power.Name = "Constant_Power";
            this.Constant_Power.Size = new System.Drawing.Size(40, 21);
            this.Constant_Power.TabIndex = 25;
            // 
            // Electric
            // 
            this.Electric.Location = new System.Drawing.Point(396, 225);
            this.Electric.Name = "Electric";
            this.Electric.Size = new System.Drawing.Size(44, 21);
            this.Electric.TabIndex = 32;
            // 
            // Set_Ele_btn
            // 
            this.Set_Ele_btn.Enabled = false;
            this.Set_Ele_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Set_Ele_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Set_Ele_btn.Location = new System.Drawing.Point(488, 219);
            this.Set_Ele_btn.Name = "Set_Ele_btn";
            this.Set_Ele_btn.Size = new System.Drawing.Size(56, 27);
            this.Set_Ele_btn.TabIndex = 31;
            this.Set_Ele_btn.Text = "设置";
            this.Set_Ele_btn.UseVisualStyleBackColor = true;
            this.Set_Ele_btn.Click += new System.EventHandler(this.Set_Ele_btn_Click);
            // 
            // Re_Ele_btn
            // 
            this.Re_Ele_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Re_Ele_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Re_Ele_btn.Location = new System.Drawing.Point(488, 163);
            this.Re_Ele_btn.Name = "Re_Ele_btn";
            this.Re_Ele_btn.Size = new System.Drawing.Size(56, 29);
            this.Re_Ele_btn.TabIndex = 30;
            this.Re_Ele_btn.Text = "读取";
            this.Re_Ele_btn.UseVisualStyleBackColor = true;
            this.Re_Ele_btn.Click += new System.EventHandler(this.Re_Ele_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(442, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 21);
            this.label5.TabIndex = 29;
            this.label5.Text = "A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(442, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 21);
            this.label8.TabIndex = 28;
            this.label8.Text = "A";
            // 
            // Ele_label
            // 
            this.Ele_label.AutoSize = true;
            this.Ele_label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ele_label.Location = new System.Drawing.Point(396, 171);
            this.Ele_label.Name = "Ele_label";
            this.Ele_label.Size = new System.Drawing.Size(50, 21);
            this.Ele_label.TabIndex = 27;
            this.Ele_label.Text = "00.00";
            // 
            // Voltage_box
            // 
            this.Voltage_box.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Voltage_box.Location = new System.Drawing.Point(642, 78);
            this.Voltage_box.Name = "Voltage_box";
            this.Voltage_box.Size = new System.Drawing.Size(45, 21);
            this.Voltage_box.TabIndex = 39;
            // 
            // Set_Vol_btn
            // 
            this.Set_Vol_btn.Enabled = false;
            this.Set_Vol_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Set_Vol_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Set_Vol_btn.Location = new System.Drawing.Point(736, 78);
            this.Set_Vol_btn.Name = "Set_Vol_btn";
            this.Set_Vol_btn.Size = new System.Drawing.Size(57, 27);
            this.Set_Vol_btn.TabIndex = 38;
            this.Set_Vol_btn.Text = "设置";
            this.Set_Vol_btn.UseVisualStyleBackColor = true;
            this.Set_Vol_btn.Click += new System.EventHandler(this.Set_Vol_btn_Click);
            // 
            // Re_Vol_btn
            // 
            this.Re_Vol_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Re_Vol_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Re_Vol_btn.Location = new System.Drawing.Point(736, 25);
            this.Re_Vol_btn.Name = "Re_Vol_btn";
            this.Re_Vol_btn.Size = new System.Drawing.Size(57, 27);
            this.Re_Vol_btn.TabIndex = 37;
            this.Re_Vol_btn.Text = "读取";
            this.Re_Vol_btn.UseVisualStyleBackColor = true;
            this.Re_Vol_btn.Click += new System.EventHandler(this.Re_Vol_btn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(691, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 21);
            this.label11.TabIndex = 36;
            this.label11.Text = "V";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(691, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 21);
            this.label12.TabIndex = 35;
            this.label12.Text = "V";
            // 
            // Vol_label
            // 
            this.Vol_label.AutoSize = true;
            this.Vol_label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Vol_label.Location = new System.Drawing.Point(644, 22);
            this.Vol_label.Name = "Vol_label";
            this.Vol_label.Size = new System.Drawing.Size(50, 21);
            this.Vol_label.TabIndex = 34;
            this.Vol_label.Text = "00.00";
            // 
            // Resis_Box
            // 
            this.Resis_Box.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Resis_Box.Location = new System.Drawing.Point(642, 224);
            this.Resis_Box.Name = "Resis_Box";
            this.Resis_Box.Size = new System.Drawing.Size(45, 21);
            this.Resis_Box.TabIndex = 46;
            // 
            // Set_Resis_btn
            // 
            this.Set_Resis_btn.Enabled = false;
            this.Set_Resis_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Set_Resis_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Set_Resis_btn.Location = new System.Drawing.Point(736, 219);
            this.Set_Resis_btn.Name = "Set_Resis_btn";
            this.Set_Resis_btn.Size = new System.Drawing.Size(57, 27);
            this.Set_Resis_btn.TabIndex = 45;
            this.Set_Resis_btn.Text = "设置";
            this.Set_Resis_btn.UseVisualStyleBackColor = true;
            this.Set_Resis_btn.Click += new System.EventHandler(this.Set_Resis_btn_Click);
            // 
            // Re_Resis_btn
            // 
            this.Re_Resis_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Re_Resis_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Re_Resis_btn.Location = new System.Drawing.Point(736, 163);
            this.Re_Resis_btn.Name = "Re_Resis_btn";
            this.Re_Resis_btn.Size = new System.Drawing.Size(57, 27);
            this.Re_Resis_btn.TabIndex = 44;
            this.Re_Resis_btn.Text = "读取";
            this.Re_Resis_btn.UseVisualStyleBackColor = true;
            this.Re_Resis_btn.Click += new System.EventHandler(this.Re_Resis_btn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(690, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 21);
            this.label15.TabIndex = 43;
            this.label15.Text = "Ω";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(690, 171);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 21);
            this.label16.TabIndex = 42;
            this.label16.Text = "Ω";
            // 
            // Resistance_label
            // 
            this.Resistance_label.AutoSize = true;
            this.Resistance_label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Resistance_label.Location = new System.Drawing.Point(644, 171);
            this.Resistance_label.Name = "Resistance_label";
            this.Resistance_label.Size = new System.Drawing.Size(50, 21);
            this.Resistance_label.TabIndex = 41;
            this.Resistance_label.Text = "00.00";
            // 
            // Pow_check
            // 
            this.Pow_check.AutoSize = true;
            this.Pow_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pow_check.Location = new System.Drawing.Point(308, 22);
            this.Pow_check.Name = "Pow_check";
            this.Pow_check.Size = new System.Drawing.Size(93, 25);
            this.Pow_check.TabIndex = 47;
            this.Pow_check.Text = "恒功率：";
            this.Pow_check.UseVisualStyleBackColor = true;
            this.Pow_check.CheckedChanged += new System.EventHandler(this.Powcheck_CheckedChanged);
            // 
            // Vol_check
            // 
            this.Vol_check.AutoSize = true;
            this.Vol_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Vol_check.Location = new System.Drawing.Point(571, 21);
            this.Vol_check.Name = "Vol_check";
            this.Vol_check.Size = new System.Drawing.Size(77, 25);
            this.Vol_check.TabIndex = 48;
            this.Vol_check.Text = "电压：";
            this.Vol_check.UseVisualStyleBackColor = true;
            this.Vol_check.CheckedChanged += new System.EventHandler(this.Volcheck_CheckedChanged);
            // 
            // Curr_check
            // 
            this.Curr_check.AutoSize = true;
            this.Curr_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Curr_check.Location = new System.Drawing.Point(324, 170);
            this.Curr_check.Name = "Curr_check";
            this.Curr_check.Size = new System.Drawing.Size(77, 25);
            this.Curr_check.TabIndex = 49;
            this.Curr_check.Text = "电流：";
            this.Curr_check.UseVisualStyleBackColor = true;
            this.Curr_check.CheckedChanged += new System.EventHandler(this.Elecheck_CheckedChanged);
            // 
            // Resis_check
            // 
            this.Resis_check.AutoSize = true;
            this.Resis_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Resis_check.Location = new System.Drawing.Point(571, 167);
            this.Resis_check.Name = "Resis_check";
            this.Resis_check.Size = new System.Drawing.Size(77, 25);
            this.Resis_check.TabIndex = 50;
            this.Resis_check.Text = "电阻：";
            this.Resis_check.UseVisualStyleBackColor = true;
            this.Resis_check.CheckedChanged += new System.EventHandler(this.Resischeck_CheckedChanged);
            // 
            // ON_btn
            // 
            this.ON_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ON_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ON_btn.Location = new System.Drawing.Point(413, 305);
            this.ON_btn.Name = "ON_btn";
            this.ON_btn.Size = new System.Drawing.Size(73, 29);
            this.ON_btn.TabIndex = 51;
            this.ON_btn.Text = "启动";
            this.ON_btn.UseVisualStyleBackColor = true;
            this.ON_btn.Click += new System.EventHandler(this.ON_btn_Click);
            // 
            // OFF_btn
            // 
            this.OFF_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OFF_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OFF_btn.Location = new System.Drawing.Point(667, 305);
            this.OFF_btn.Name = "OFF_btn";
            this.OFF_btn.Size = new System.Drawing.Size(72, 29);
            this.OFF_btn.TabIndex = 52;
            this.OFF_btn.Text = "停止";
            this.OFF_btn.UseVisualStyleBackColor = true;
            this.OFF_btn.Click += new System.EventHandler(this.OFF_btn_Click);
            // 
            // Ele_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 529);
            this.Controls.Add(this.OFF_btn);
            this.Controls.Add(this.ON_btn);
            this.Controls.Add(this.Resis_check);
            this.Controls.Add(this.Curr_check);
            this.Controls.Add(this.Vol_check);
            this.Controls.Add(this.Pow_check);
            this.Controls.Add(this.Resis_Box);
            this.Controls.Add(this.Set_Resis_btn);
            this.Controls.Add(this.Re_Resis_btn);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.Resistance_label);
            this.Controls.Add(this.Voltage_box);
            this.Controls.Add(this.Set_Vol_btn);
            this.Controls.Add(this.Re_Vol_btn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Vol_label);
            this.Controls.Add(this.Electric);
            this.Controls.Add(this.Set_Ele_btn);
            this.Controls.Add(this.Re_Ele_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Ele_label);
            this.Controls.Add(this.Constant_Power);
            this.Controls.Add(this.Set_Pow_btn);
            this.Controls.Add(this.Re_pw_btn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Power_label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostPort);
            this.Controls.Add(this.HostAdress);
            this.Controls.Add(this.Connect_Way);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Name = "Ele_info";
            this.Text = "Ele_info";
            this.Load += new System.EventHandler(this.Ele_info_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button Sent;
        private System.Windows.Forms.ListBox receivingBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox hostPort;
        private System.Windows.Forms.ComboBox HostAdress;
        private System.Windows.Forms.ComboBox Connect_Way;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label Power_label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Re_pw_btn;
        private System.Windows.Forms.Button Set_Pow_btn;
        private System.Windows.Forms.TextBox Constant_Power;
        private System.Windows.Forms.TextBox Electric;
        private System.Windows.Forms.Button Set_Ele_btn;
        private System.Windows.Forms.Button Re_Ele_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Ele_label;
        private System.Windows.Forms.TextBox Voltage_box;
        private System.Windows.Forms.Button Set_Vol_btn;
        private System.Windows.Forms.Button Re_Vol_btn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label Vol_label;
        private System.Windows.Forms.TextBox Resis_Box;
        private System.Windows.Forms.Button Set_Resis_btn;
        private System.Windows.Forms.Button Re_Resis_btn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label Resistance_label;
        private System.Windows.Forms.CheckBox Pow_check;
        private System.Windows.Forms.CheckBox Vol_check;
        private System.Windows.Forms.CheckBox Curr_check;
        private System.Windows.Forms.CheckBox Resis_check;
        private System.Windows.Forms.Button ON_btn;
        private System.Windows.Forms.Button OFF_btn;
    }
}