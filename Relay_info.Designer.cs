namespace BFS
{
    partial class Relay_info
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
            this.OK_btn1 = new System.Windows.Forms.Button();
            this.Open_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Relay1_check = new System.Windows.Forms.CheckBox();
            this.Relay2_check = new System.Windows.Forms.CheckBox();
            this.Relay4_check = new System.Windows.Forms.CheckBox();
            this.Relay3_check = new System.Windows.Forms.CheckBox();
            this.Relay8_check = new System.Windows.Forms.CheckBox();
            this.Relay7_check = new System.Windows.Forms.CheckBox();
            this.Relay6_check = new System.Windows.Forms.CheckBox();
            this.Relay5_check = new System.Windows.Forms.CheckBox();
            this.Relay16_check = new System.Windows.Forms.CheckBox();
            this.Relay15_check = new System.Windows.Forms.CheckBox();
            this.Relay14_check = new System.Windows.Forms.CheckBox();
            this.Relay13_check = new System.Windows.Forms.CheckBox();
            this.Relay12_check = new System.Windows.Forms.CheckBox();
            this.Relay11_check = new System.Windows.Forms.CheckBox();
            this.Relay10_check = new System.Windows.Forms.CheckBox();
            this.Relay9_check = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.Location = new System.Drawing.Point(0, 413);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 100);
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
            this.Sent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sent.Location = new System.Drawing.Point(736, 41);
            this.Sent.Name = "Sent";
            this.Sent.Size = new System.Drawing.Size(58, 27);
            this.Sent.TabIndex = 2;
            this.Sent.Text = "发送";
            this.Sent.UseVisualStyleBackColor = true;
            this.Sent.Click += new System.EventHandler(this.Sent_Click);
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
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(26, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "端口号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(26, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "IP地址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "连接方式:";
            // 
            // hostPort
            // 
            this.hostPort.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hostPort.FormattingEnabled = true;
            this.hostPort.Items.AddRange(new object[] {
            "17072"});
            this.hostPort.Location = new System.Drawing.Point(105, 136);
            this.hostPort.Name = "hostPort";
            this.hostPort.Size = new System.Drawing.Size(121, 28);
            this.hostPort.TabIndex = 13;
            // 
            // HostAdress
            // 
            this.HostAdress.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HostAdress.FormattingEnabled = true;
            this.HostAdress.Items.AddRange(new object[] {
            "10.10.106.241"});
            this.HostAdress.Location = new System.Drawing.Point(105, 72);
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
            this.Connect_Way.Location = new System.Drawing.Point(105, 17);
            this.Connect_Way.Name = "Connect_Way";
            this.Connect_Way.Size = new System.Drawing.Size(121, 28);
            this.Connect_Way.TabIndex = 11;
            // 
            // disconnect
            // 
            this.disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.disconnect.Location = new System.Drawing.Point(172, 214);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(75, 31);
            this.disconnect.TabIndex = 10;
            this.disconnect.Text = "断开";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // connect
            // 
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.connect.Location = new System.Drawing.Point(15, 214);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 31);
            this.connect.TabIndex = 9;
            this.connect.Text = "连接";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // OK_btn1
            // 
            this.OK_btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_btn1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OK_btn1.Location = new System.Drawing.Point(410, 267);
            this.OK_btn1.Name = "OK_btn1";
            this.OK_btn1.Size = new System.Drawing.Size(75, 31);
            this.OK_btn1.TabIndex = 22;
            this.OK_btn1.Text = "吸合";
            this.OK_btn1.UseVisualStyleBackColor = true;
            this.OK_btn1.Click += new System.EventHandler(this.OK_btn1_Click);
            // 
            // Open_btn
            // 
            this.Open_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Open_btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Open_btn.Location = new System.Drawing.Point(627, 269);
            this.Open_btn.Name = "Open_btn";
            this.Open_btn.Size = new System.Drawing.Size(75, 31);
            this.Open_btn.TabIndex = 23;
            this.Open_btn.Text = "无";
            this.Open_btn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(15, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "连接方式:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(29, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "IP地址:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(29, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "端口号:";
            // 
            // Relay1_check
            // 
            this.Relay1_check.AutoSize = true;
            this.Relay1_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay1_check.Location = new System.Drawing.Point(354, 21);
            this.Relay1_check.Name = "Relay1_check";
            this.Relay1_check.Size = new System.Drawing.Size(86, 25);
            this.Relay1_check.TabIndex = 48;
            this.Relay1_check.Text = "继电器1";
            this.Relay1_check.UseVisualStyleBackColor = true;
            // 
            // Relay2_check
            // 
            this.Relay2_check.AutoSize = true;
            this.Relay2_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay2_check.Location = new System.Drawing.Point(468, 21);
            this.Relay2_check.Name = "Relay2_check";
            this.Relay2_check.Size = new System.Drawing.Size(86, 25);
            this.Relay2_check.TabIndex = 49;
            this.Relay2_check.Text = "继电器2";
            this.Relay2_check.UseVisualStyleBackColor = true;
            // 
            // Relay4_check
            // 
            this.Relay4_check.AutoSize = true;
            this.Relay4_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay4_check.Location = new System.Drawing.Point(706, 20);
            this.Relay4_check.Name = "Relay4_check";
            this.Relay4_check.Size = new System.Drawing.Size(86, 25);
            this.Relay4_check.TabIndex = 51;
            this.Relay4_check.Text = "继电器4";
            this.Relay4_check.UseVisualStyleBackColor = true;
            // 
            // Relay3_check
            // 
            this.Relay3_check.AutoSize = true;
            this.Relay3_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay3_check.Location = new System.Drawing.Point(585, 20);
            this.Relay3_check.Name = "Relay3_check";
            this.Relay3_check.Size = new System.Drawing.Size(86, 25);
            this.Relay3_check.TabIndex = 50;
            this.Relay3_check.Text = "继电器3";
            this.Relay3_check.UseVisualStyleBackColor = true;
            // 
            // Relay8_check
            // 
            this.Relay8_check.AutoSize = true;
            this.Relay8_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay8_check.Location = new System.Drawing.Point(706, 75);
            this.Relay8_check.Name = "Relay8_check";
            this.Relay8_check.Size = new System.Drawing.Size(86, 25);
            this.Relay8_check.TabIndex = 55;
            this.Relay8_check.Text = "继电器8";
            this.Relay8_check.UseVisualStyleBackColor = true;
            // 
            // Relay7_check
            // 
            this.Relay7_check.AutoSize = true;
            this.Relay7_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay7_check.Location = new System.Drawing.Point(585, 75);
            this.Relay7_check.Name = "Relay7_check";
            this.Relay7_check.Size = new System.Drawing.Size(86, 25);
            this.Relay7_check.TabIndex = 54;
            this.Relay7_check.Text = "继电器7";
            this.Relay7_check.UseVisualStyleBackColor = true;
            // 
            // Relay6_check
            // 
            this.Relay6_check.AutoSize = true;
            this.Relay6_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay6_check.Location = new System.Drawing.Point(468, 76);
            this.Relay6_check.Name = "Relay6_check";
            this.Relay6_check.Size = new System.Drawing.Size(86, 25);
            this.Relay6_check.TabIndex = 53;
            this.Relay6_check.Text = "继电器6";
            this.Relay6_check.UseVisualStyleBackColor = true;
            // 
            // Relay5_check
            // 
            this.Relay5_check.AutoSize = true;
            this.Relay5_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay5_check.Location = new System.Drawing.Point(354, 76);
            this.Relay5_check.Name = "Relay5_check";
            this.Relay5_check.Size = new System.Drawing.Size(86, 25);
            this.Relay5_check.TabIndex = 52;
            this.Relay5_check.Text = "继电器5";
            this.Relay5_check.UseVisualStyleBackColor = true;
            // 
            // Relay16_check
            // 
            this.Relay16_check.AutoSize = true;
            this.Relay16_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay16_check.Location = new System.Drawing.Point(706, 187);
            this.Relay16_check.Name = "Relay16_check";
            this.Relay16_check.Size = new System.Drawing.Size(95, 25);
            this.Relay16_check.TabIndex = 63;
            this.Relay16_check.Text = "继电器16";
            this.Relay16_check.UseVisualStyleBackColor = true;
            // 
            // Relay15_check
            // 
            this.Relay15_check.AutoSize = true;
            this.Relay15_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay15_check.Location = new System.Drawing.Point(585, 187);
            this.Relay15_check.Name = "Relay15_check";
            this.Relay15_check.Size = new System.Drawing.Size(95, 25);
            this.Relay15_check.TabIndex = 62;
            this.Relay15_check.Text = "继电器15";
            this.Relay15_check.UseVisualStyleBackColor = true;
            // 
            // Relay14_check
            // 
            this.Relay14_check.AutoSize = true;
            this.Relay14_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay14_check.Location = new System.Drawing.Point(468, 188);
            this.Relay14_check.Name = "Relay14_check";
            this.Relay14_check.Size = new System.Drawing.Size(95, 25);
            this.Relay14_check.TabIndex = 61;
            this.Relay14_check.Text = "继电器14";
            this.Relay14_check.UseVisualStyleBackColor = true;
            // 
            // Relay13_check
            // 
            this.Relay13_check.AutoSize = true;
            this.Relay13_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay13_check.Location = new System.Drawing.Point(354, 188);
            this.Relay13_check.Name = "Relay13_check";
            this.Relay13_check.Size = new System.Drawing.Size(95, 25);
            this.Relay13_check.TabIndex = 60;
            this.Relay13_check.Text = "继电器13";
            this.Relay13_check.UseVisualStyleBackColor = true;
            // 
            // Relay12_check
            // 
            this.Relay12_check.AutoSize = true;
            this.Relay12_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay12_check.Location = new System.Drawing.Point(706, 132);
            this.Relay12_check.Name = "Relay12_check";
            this.Relay12_check.Size = new System.Drawing.Size(95, 25);
            this.Relay12_check.TabIndex = 59;
            this.Relay12_check.Text = "继电器12";
            this.Relay12_check.UseVisualStyleBackColor = true;
            // 
            // Relay11_check
            // 
            this.Relay11_check.AutoSize = true;
            this.Relay11_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay11_check.Location = new System.Drawing.Point(585, 132);
            this.Relay11_check.Name = "Relay11_check";
            this.Relay11_check.Size = new System.Drawing.Size(95, 25);
            this.Relay11_check.TabIndex = 58;
            this.Relay11_check.Text = "继电器11";
            this.Relay11_check.UseVisualStyleBackColor = true;
            // 
            // Relay10_check
            // 
            this.Relay10_check.AutoSize = true;
            this.Relay10_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay10_check.Location = new System.Drawing.Point(468, 133);
            this.Relay10_check.Name = "Relay10_check";
            this.Relay10_check.Size = new System.Drawing.Size(95, 25);
            this.Relay10_check.TabIndex = 57;
            this.Relay10_check.Text = "继电器10";
            this.Relay10_check.UseVisualStyleBackColor = true;
            // 
            // Relay9_check
            // 
            this.Relay9_check.AutoSize = true;
            this.Relay9_check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Relay9_check.Location = new System.Drawing.Point(354, 133);
            this.Relay9_check.Name = "Relay9_check";
            this.Relay9_check.Size = new System.Drawing.Size(86, 25);
            this.Relay9_check.TabIndex = 56;
            this.Relay9_check.Text = "继电器9";
            this.Relay9_check.UseVisualStyleBackColor = true;
            // 
            // Relay_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(816, 513);
            this.Controls.Add(this.Relay16_check);
            this.Controls.Add(this.Relay15_check);
            this.Controls.Add(this.Relay14_check);
            this.Controls.Add(this.Relay13_check);
            this.Controls.Add(this.Relay12_check);
            this.Controls.Add(this.Relay11_check);
            this.Controls.Add(this.Relay10_check);
            this.Controls.Add(this.Relay9_check);
            this.Controls.Add(this.Relay8_check);
            this.Controls.Add(this.Relay7_check);
            this.Controls.Add(this.Relay6_check);
            this.Controls.Add(this.Relay5_check);
            this.Controls.Add(this.Relay4_check);
            this.Controls.Add(this.Relay3_check);
            this.Controls.Add(this.Relay2_check);
            this.Controls.Add(this.Relay1_check);
            this.Controls.Add(this.Open_btn);
            this.Controls.Add(this.OK_btn1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostPort);
            this.Controls.Add(this.HostAdress);
            this.Controls.Add(this.Connect_Way);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Relay_info";
            this.Text = "Relay_info";
            this.Load += new System.EventHandler(this.Relay_info_Load);
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
        private System.Windows.Forms.Button OK_btn1;
        private System.Windows.Forms.Button Open_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox Relay1_check;
        private System.Windows.Forms.CheckBox Relay2_check;
        private System.Windows.Forms.CheckBox Relay4_check;
        private System.Windows.Forms.CheckBox Relay3_check;
        private System.Windows.Forms.CheckBox Relay8_check;
        private System.Windows.Forms.CheckBox Relay7_check;
        private System.Windows.Forms.CheckBox Relay6_check;
        private System.Windows.Forms.CheckBox Relay5_check;
        private System.Windows.Forms.CheckBox Relay16_check;
        private System.Windows.Forms.CheckBox Relay15_check;
        private System.Windows.Forms.CheckBox Relay14_check;
        private System.Windows.Forms.CheckBox Relay13_check;
        private System.Windows.Forms.CheckBox Relay12_check;
        private System.Windows.Forms.CheckBox Relay11_check;
        private System.Windows.Forms.CheckBox Relay10_check;
        private System.Windows.Forms.CheckBox Relay9_check;
    }
}