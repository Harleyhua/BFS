namespace BFS
{
    partial class Power_info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Power_info));
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
            this.Voltage_box2 = new System.Windows.Forms.TextBox();
            this.Set_Vol_btn2 = new System.Windows.Forms.Button();
            this.Re_Vol_btn2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Vol_label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Electric2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Ele_label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ON_btn = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
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
            this.groupBox1.Location = new System.Drawing.Point(0, 421);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 98);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志";
            // 
            // InputBox
            // 
            this.InputBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputBox.Location = new System.Drawing.Point(444, 20);
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(286, 71);
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
            this.receivingBox.Location = new System.Drawing.Point(6, 19);
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
            "17072"});
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
            "10.10.106.239"});
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
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // Voltage_box2
            // 
            this.Voltage_box2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Voltage_box2.Location = new System.Drawing.Point(469, 54);
            this.Voltage_box2.Name = "Voltage_box2";
            this.Voltage_box2.Size = new System.Drawing.Size(40, 26);
            this.Voltage_box2.TabIndex = 32;
            // 
            // Set_Vol_btn2
            // 
            this.Set_Vol_btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Set_Vol_btn2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Set_Vol_btn2.Location = new System.Drawing.Point(582, 94);
            this.Set_Vol_btn2.Name = "Set_Vol_btn2";
            this.Set_Vol_btn2.Size = new System.Drawing.Size(56, 34);
            this.Set_Vol_btn2.TabIndex = 31;
            this.Set_Vol_btn2.Text = "设置";
            this.Set_Vol_btn2.UseVisualStyleBackColor = true;
            this.Set_Vol_btn2.Click += new System.EventHandler(this.Set_Vol_btn2_Click);
            // 
            // Re_Vol_btn2
            // 
            this.Re_Vol_btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Re_Vol_btn2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Re_Vol_btn2.Location = new System.Drawing.Point(582, 23);
            this.Re_Vol_btn2.Name = "Re_Vol_btn2";
            this.Re_Vol_btn2.Size = new System.Drawing.Size(56, 33);
            this.Re_Vol_btn2.TabIndex = 30;
            this.Re_Vol_btn2.Text = "读取";
            this.Re_Vol_btn2.UseVisualStyleBackColor = true;
            this.Re_Vol_btn2.Click += new System.EventHandler(this.Re_Vol_btn2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(512, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "V";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(512, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "V";
            // 
            // Vol_label2
            // 
            this.Vol_label2.AutoSize = true;
            this.Vol_label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Vol_label2.Location = new System.Drawing.Point(466, 23);
            this.Vol_label2.Name = "Vol_label2";
            this.Vol_label2.Size = new System.Drawing.Size(44, 20);
            this.Vol_label2.TabIndex = 27;
            this.Vol_label2.Text = "00.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(415, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "电压:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Electric2
            // 
            this.Electric2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Electric2.Location = new System.Drawing.Point(469, 168);
            this.Electric2.Name = "Electric2";
            this.Electric2.Size = new System.Drawing.Size(40, 26);
            this.Electric2.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(512, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "V";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(512, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "V";
            // 
            // Ele_label2
            // 
            this.Ele_label2.AutoSize = true;
            this.Ele_label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ele_label2.Location = new System.Drawing.Point(466, 137);
            this.Ele_label2.Name = "Ele_label2";
            this.Ele_label2.Size = new System.Drawing.Size(44, 20);
            this.Ele_label2.TabIndex = 34;
            this.Ele_label2.Text = "00.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(415, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "电流:";
            // 
            // ON_btn
            // 
            this.ON_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ON_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ON_btn.Location = new System.Drawing.Point(582, 168);
            this.ON_btn.Name = "ON_btn";
            this.ON_btn.Size = new System.Drawing.Size(56, 35);
            this.ON_btn.TabIndex = 38;
            this.ON_btn.Text = "启动";
            this.ON_btn.UseVisualStyleBackColor = true;
            this.ON_btn.Click += new System.EventHandler(this.ON_btn_Click);
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
            // Power_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.Controls.Add(this.ON_btn);
            this.Controls.Add(this.Electric2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Ele_label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Voltage_box2);
            this.Controls.Add(this.Set_Vol_btn2);
            this.Controls.Add(this.Re_Vol_btn2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Vol_label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostPort);
            this.Controls.Add(this.HostAdress);
            this.Controls.Add(this.Connect_Way);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Power_info";
            this.Text = "Power_info";
            this.Load += new System.EventHandler(this.Power_info_Load);
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
        private System.Windows.Forms.TextBox Voltage_box2;
        private System.Windows.Forms.Button Set_Vol_btn2;
        private System.Windows.Forms.Button Re_Vol_btn2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Vol_label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Electric2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Ele_label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ON_btn;
    }
}