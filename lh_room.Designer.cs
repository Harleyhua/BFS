namespace BFS
{
    partial class lh_room
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
            this.components = new System.ComponentModel.Container();
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
            this.temp_Box = new System.Windows.Forms.TextBox();
            this.Set_temp_btn = new System.Windows.Forms.Button();
            this.Re_temp_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Temp_label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.left_open = new System.Windows.Forms.Button();
            this.open_clear = new System.Windows.Forms.Button();
            this.left_close = new System.Windows.Forms.Button();
            this.close_clear = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.temp_star_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
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
            this.groupBox1.Location = new System.Drawing.Point(0, 426);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 100);
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
            "502"});
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
            "10.10.106.242"});
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
            this.Connect_Way.Location = new System.Drawing.Point(107, 14);
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
            // temp_Box
            // 
            this.temp_Box.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.temp_Box.Location = new System.Drawing.Point(473, 73);
            this.temp_Box.Name = "temp_Box";
            this.temp_Box.Size = new System.Drawing.Size(40, 29);
            this.temp_Box.TabIndex = 39;
            // 
            // Set_temp_btn
            // 
            this.Set_temp_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Set_temp_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Set_temp_btn.Location = new System.Drawing.Point(581, 71);
            this.Set_temp_btn.Name = "Set_temp_btn";
            this.Set_temp_btn.Size = new System.Drawing.Size(58, 28);
            this.Set_temp_btn.TabIndex = 38;
            this.Set_temp_btn.Text = "设置";
            this.Set_temp_btn.UseVisualStyleBackColor = true;
            this.Set_temp_btn.Click += new System.EventHandler(this.Set_temp_btn_Click);
            // 
            // Re_temp_btn
            // 
            this.Re_temp_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Re_temp_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Re_temp_btn.Location = new System.Drawing.Point(581, 12);
            this.Re_temp_btn.Name = "Re_temp_btn";
            this.Re_temp_btn.Size = new System.Drawing.Size(58, 30);
            this.Re_temp_btn.TabIndex = 37;
            this.Re_temp_btn.Text = "读取";
            this.Re_temp_btn.UseVisualStyleBackColor = true;
            this.Re_temp_btn.Click += new System.EventHandler(this.Re_temp_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(517, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 21);
            this.label5.TabIndex = 36;
            this.label5.Text = "℃";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(516, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 21);
            this.label8.TabIndex = 35;
            this.label8.Text = "℃";
            // 
            // Temp_label
            // 
            this.Temp_label.AutoSize = true;
            this.Temp_label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Temp_label.Location = new System.Drawing.Point(469, 21);
            this.Temp_label.Name = "Temp_label";
            this.Temp_label.Size = new System.Drawing.Size(50, 21);
            this.Temp_label.TabIndex = 34;
            this.Temp_label.Text = "00.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(403, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 21);
            this.label10.TabIndex = 33;
            this.label10.Text = "温度:";
            // 
            // left_open
            // 
            this.left_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.left_open.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.left_open.Location = new System.Drawing.Point(462, 199);
            this.left_open.Name = "left_open";
            this.left_open.Size = new System.Drawing.Size(75, 31);
            this.left_open.TabIndex = 40;
            this.left_open.Text = "开门";
            this.left_open.UseVisualStyleBackColor = true;
            this.left_open.Click += new System.EventHandler(this.left_open_Click);
            // 
            // open_clear
            // 
            this.open_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_clear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.open_clear.Location = new System.Drawing.Point(664, 199);
            this.open_clear.Name = "open_clear";
            this.open_clear.Size = new System.Drawing.Size(89, 31);
            this.open_clear.TabIndex = 41;
            this.open_clear.Text = "开门清除";
            this.open_clear.UseVisualStyleBackColor = true;
            this.open_clear.Click += new System.EventHandler(this.open_clear_Click);
            // 
            // left_close
            // 
            this.left_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.left_close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.left_close.Location = new System.Drawing.Point(462, 280);
            this.left_close.Name = "left_close";
            this.left_close.Size = new System.Drawing.Size(75, 31);
            this.left_close.TabIndex = 42;
            this.left_close.Text = "关门";
            this.left_close.UseVisualStyleBackColor = true;
            this.left_close.Click += new System.EventHandler(this.left_close_Click);
            // 
            // close_clear
            // 
            this.close_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_clear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.close_clear.Location = new System.Drawing.Point(664, 280);
            this.close_clear.Name = "close_clear";
            this.close_clear.Size = new System.Drawing.Size(89, 31);
            this.close_clear.TabIndex = 43;
            this.close_clear.Text = "关门清除";
            this.close_clear.UseVisualStyleBackColor = true;
            this.close_clear.Click += new System.EventHandler(this.close_clear_Click);
            // 
            // temp_star_btn
            // 
            this.temp_star_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.temp_star_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.temp_star_btn.Location = new System.Drawing.Point(695, 12);
            this.temp_star_btn.Name = "temp_star_btn";
            this.temp_star_btn.Size = new System.Drawing.Size(58, 28);
            this.temp_star_btn.TabIndex = 44;
            this.temp_star_btn.Text = "启动";
            this.temp_star_btn.UseVisualStyleBackColor = true;
            this.temp_star_btn.Click += new System.EventHandler(this.temp_star_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stop_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stop_btn.Location = new System.Drawing.Point(695, 74);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(58, 28);
            this.stop_btn.TabIndex = 45;
            this.stop_btn.Text = "停止";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // lh_room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(814, 526);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.temp_star_btn);
            this.Controls.Add(this.close_clear);
            this.Controls.Add(this.left_close);
            this.Controls.Add(this.open_clear);
            this.Controls.Add(this.left_open);
            this.Controls.Add(this.temp_Box);
            this.Controls.Add(this.Set_temp_btn);
            this.Controls.Add(this.Re_temp_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Temp_label);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostPort);
            this.Controls.Add(this.HostAdress);
            this.Controls.Add(this.Connect_Way);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "lh_room";
            this.Text = "lh_room";
            this.Load += new System.EventHandler(this.lh_room_Load);
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
        private System.Windows.Forms.TextBox temp_Box;
        private System.Windows.Forms.Button Set_temp_btn;
        private System.Windows.Forms.Button Re_temp_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Temp_label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button left_open;
        private System.Windows.Forms.Button open_clear;
        private System.Windows.Forms.Button left_close;
        private System.Windows.Forms.Button close_clear;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button temp_star_btn;
        private System.Windows.Forms.Button stop_btn;
    }
}