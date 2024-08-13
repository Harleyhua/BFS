using BFS.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BFS
{
    internal class Relay_Initialize
    {
        int Relay_connectType = 0;
        string Relay_IP = "10.10.106.241";
        int Relay_Port = 17072;
        TcpClient Relay_client = new TcpClient();
        NetworkStream Relay_stream = null;
        private bool Relay_connected1 = false;
        public bool Relay_sending = false;
        bool Relay_reading = false;
        int Relay_timeOut = 3000;
        int Relay_err = 0;
        public void setRelay_connected(bool bool1 = false)
        {
            Relay_connected1 = bool1;
        }
        public bool getRelay_connected()
        {
            return Relay_connected1;
        }

        public Relay_Initialize()
        {
            Console.WriteLine("Relay_Initialize"); return;
        }

        public bool Relay_Load(int port, string address = "", int connectType = 0) {

            bool a1 = false;
            if (connectType <= 0)
            {
                //默认为TCP客户端通讯 
                Relay_connectType = int.Parse(Resources.C_client);
            }
            else
            {
                Relay_connectType = connectType;
            }

            if (Relay_connectType == int.Parse(Resources.C_client))
            {
                // 创建Socket对象
                Relay_client = new TcpClient();
                if (Relay_client != null) { a1 = true; }
            }
            else
            {
                Relay_err = -1;
            }
            Relay_IP = address;
            Relay_Port = port;
            if (a1) { Relay_err = 0; }
            return a1;
        }
        //超时处理
        public void setTimeOut(int timeOut)
        {
            if (timeOut <= 0) { Relay_timeOut = 3000; } else { Relay_timeOut = timeOut; }
        }

        //连接类型
        public bool connect_Type()
        {

            bool a1 = false;

            if (Relay_connectType == int.Parse(Resources.C_client))
            {
                a1 = connect_TCP();
            }
            else
            {
                Relay_err = -1;
            }
            //Ele_connected = a1;
            if (a1) { Relay_err = 0; }
            return a1;
        }

        //断开类型
        public bool Disconnect_Type()
        {
            bool a1 = false;
            //Ele_connected = false;
            if (Relay_client != null) { a1 = disconnect_TCP(); }
            return a1;
        }

        //连接服务器
        public bool connect_TCP()
        {
            // 连接服务器
            try
            {
                Relay_client.Connect(Relay_IP, Relay_Port);
                setRelay_connected(true);
                Console.WriteLine("继电器连接成功！");
            }
            catch (Exception e)
            {
                Relay_err = -21;
                Console.WriteLine(e.ToString());
            }
            try
            {
                Relay_stream = Relay_client.GetStream();
            }
            catch (Exception e) { Console.WriteLine(e.Message); Relay_err = -22; return false; }

            return Relay_client.Connected;

        }

        //断开服务器
        public bool disconnect_TCP()
        {
            Relay_client.Close();
            return true;
        }

        //发送数据
        public bool sendData_TY(string data_text)
        {
            if (!getRelay_connected()) { Relay_err = -2; return false; }

            if (Relay_sending)
            {
                Relay_err = -32;
                return false;
            }

            //先读一遍清空缓存
            getReport_clear();
            Relay_sending = true;

            bool a1 = false;
            //if (Ele_connectType == int.Parse(Resources.C_client))
            //{
            a1 = sendDate_TCP(data_text);
            //}
            //else
            //{
            //Ele_err = -1;
            //}
            Relay_sending = false;
            if (a1) { Relay_err = 0; }
            return a1;
        }

        public bool getResult_TY(ref string re_text, ref byte[] re_byte, bool NoWait = false)
        {
            if (Relay_reading)
            {
                Relay_err = -42;
                return false;
            }

            Relay_reading = true;
            bool a1 = false;
            int time2 = 0;

            while (!a1 && time2 < Relay_timeOut / 1000)
            {
                a1 = getResult_TCP(ref re_text, ref re_byte);

                //快速执行只执行一次，可以直接跳出；
                if (NoWait) { break; }

                time2++;
                //Application.DoEvents();
                Task.Delay(200).Wait();
            }

            Relay_reading = false;
            if (a1) { Relay_err = 0; }
            return a1;
        }

        //读取数据
        private bool getResult_TCP(ref string re_text, ref byte[] re_byte)
        {
            // 定义缓冲区大小
            int bufferSize = 1024 * 5;
            re_byte = new byte[bufferSize];
            int byteL = 0;
            Relay_stream.ReadTimeout = 800; // 设置读取超时时间

            try
            {
                byteL = Relay_stream.Read(re_byte, 0, bufferSize); // 从流中读取数据
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            if (byteL > 0)
            {
                // 截取实际读取的数据长度
                Array.Resize(ref re_byte, byteL);

                // 将字节集转为字符串，这里假设使用UTF-8编码
                re_text = Encoding.UTF8.GetString(re_byte);

                // 返回成功
                return true;
            }

            // 如果没有读取到数据，设置错误码并返回失败
            Relay_err = -41;
            return false;
        }

        //发送数据
        private bool sendDate_TCP(string dataText)
        {

            if (dataText == "" || dataText is null)
            {
                Relay_err = -33;
                return false;
            }
            try
            {
                Relay_stream = Relay_client.GetStream();
            }
            catch
            {
                Relay_err = -22;
                return false;
            }
            Encoding encoding = Encoding.UTF8;
            // 将字符串转换为字节数组
            byte[] dataBytes = encoding.GetBytes(dataText);
            Relay_stream.Write(dataBytes, 0, dataBytes.Length);



            if (Relay_stream is NetworkStream)
            {
                Relay_err = 0;
                return true;
            }
            else
            {
                Relay_err = -31;
                return false;
            }
        }

        //清空采集或上报的缓存
        public bool getReport_clear()
        {
            string re1 = "";
            byte[] re2 = null;

            bool a1 = getResult_TY(ref re1, ref re2, true);

            if (a1) { Relay_err = 0; }
            return a1;
        }
    }
}
