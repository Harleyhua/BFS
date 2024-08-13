using BFS.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    internal class Power_Initialize
    {
        int Pow_connectType = 0;
        string Pow_IP = "10.10.106.239";
        int Pow_Port = 17072;
        TcpClient Pow_client = new TcpClient();
        NetworkStream Pow_stream = null;
        private bool Pow_connected = false;
        public bool Pow_sending = false;
        bool Pow_reading = false;
        int Pow_timeOut = 3000;
        int Pow_err = 0;

        //public bool Ele_connected { get; set; }


        public void setPow_connected(bool bool1 = false)
        {

            Pow_connected = bool1;
        }
        public bool getPow_connected()
        {

            return Pow_connected;
        }

        public Power_Initialize()
        {
            Console.WriteLine("Power_Initialize"); return;
        }

        //初始化
        public bool Load(int port, string address = "", int connectType = 0)
        {

            bool a1 = false;

            if (connectType <= 0)
            {
                //默认为TCP客户端通讯 
                Pow_connectType = int.Parse(Resources.C_client);
            }
            else
            {
                Pow_connectType = connectType;
            }

            if (Pow_connectType == int.Parse(Resources.C_client))
            {
                // 创建Socket对象
                Pow_client = new TcpClient();
                if (Pow_client != null) { a1 = true; }
            }
            else
            {
                Pow_err = -1;
            }
            Pow_IP = address;
            Pow_Port = port;
            if (a1) { Pow_err = 0; }
            return a1;
        }

        //超时处理
        public void setTimeOut(int timeOut)
        {
            if (timeOut <= 0) { Pow_timeOut = 3000; } else { Pow_timeOut = timeOut; }
        }

        //连接类型
        public bool connect_Type()
        {

            bool a1 = false;

            if (Pow_connectType == int.Parse(Resources.C_client))
            {
                a1 = connect_TCP();
            }
            else
            {
                Pow_err = -1;
            }
            //Ele_connected = a1;
            if (a1) { Pow_err = 0; }
            return a1;
        }

        //断开类型
        public bool Disconnect_Type()
        {
            bool a1 = false;
            //Ele_connected = false;
            if (Pow_client != null) { a1 = disconnect_TCP(); }
            return a1;
        }

        //连接服务器
        public bool connect_TCP()
        {
            // 连接服务器
            try
            {
                Pow_client.Connect(Pow_IP, Pow_Port);
                setPow_connected(true);
                Console.WriteLine("万瑞达电源连接成功！");
            }
            catch (Exception e)
            {
                Pow_err = -21;
                Console.WriteLine(e.ToString());
            }
            try
            {
                Pow_stream = Pow_client.GetStream();
            }
            catch (Exception e) { Console.WriteLine(e.Message); Pow_err = -22; return false; }

            return Pow_client.Connected;

        }

        //断开服务器
        public bool disconnect_TCP()
        {
            Pow_client.Close();
            return true;
        }

        //发送数据
        public bool sendData_TY(string data_text)
        {
            if (!Pow_connected) { Pow_err = -2; return false; }

            if (Pow_sending)
            {
                Pow_err = -32;
                return false;
            }

            //先读一遍清空缓存
            getReport_clear();
            Pow_sending = true;

            bool a1 = false;
            //if (Pow_connectType == int.Parse(Resources.C_client))
            //{
                a1 = sendDate_TCP(data_text);
            //}
            //else
            //{
            //    Pow_err = -1;
            //}
            Pow_sending = false;
            if (a1) { Pow_err = 0; }
            return a1;
        }

        public bool getResult_TY(ref string re_text, ref byte[] re_byte, bool NoWait = false)
        {
            if (Pow_reading)
            {
                Pow_err = -42;
                return false;
            }

            Pow_reading = true;
            bool a1 = false;
            int time2 = 0;

            while (!a1 && time2 < Pow_timeOut / 1000)
            {
                //if (Pow_connectType == int.Parse(Resources.C_client))
                //{
                    a1 = getResult_TCP(ref re_text, ref re_byte);
                //}
                //else
                //{
                //    Pow_err = -1;
                //}

                //快速执行只执行一次，可以直接跳出；
                if (NoWait) { break; }

                time2++;
                //Application.DoEvents();
                Task.Delay(200).Wait();
            }

            Pow_reading = false;
            if (a1) { Pow_err = 0; }
            return a1;
        }

        //读取数据
        private bool getResult_TCP(ref string re_text, ref byte[] re_byte)
        {
            re_byte = new byte[1024 * 5];
            int byteL = 0;
            Pow_stream.ReadTimeout = 800;

            try
            {
                byteL = Pow_stream.Read(re_byte, 0, re_byte.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            if (byteL > 0)
            {
                re_byte = re_byte.Skip(0).Take(byteL).ToArray();
                //将字节集转为字符串
                re_text = codeTOstr(ref re_byte, 0, byteL);
                return true;
            }
            Pow_err = -41;
            return false;
        }

        private byte[] strTOcode(ref string code)
        {
            byte[] data = null;
            code = code.Replace(" ", "");

            if (code.Length % 2 != 0 || code == "")
            {
                Pow_err = -3;
                return null;
            }

            data = new byte[code.Length / 2];

            for (int i = 0; i < code.Length / 2; i++)
            {

                data[i] = (byte)Convert.ToInt32(code.Substring(i * 2, 2), 16);

            }
            Console.WriteLine("send=" + code);
            return data;
        }

        //将字节集转为字符串
        private string codeTOstr(ref byte[] data, int st1 = 0, int end2 = 0)
        {
            string str1 = "";
            string temp1 = "";

            if (data.Length <= 0)
            {
                return "";
            }
            if (end2 <= 0) { end2 = data.Length; }

            for (int i = 0; i < data.Length; i++)
            {
                if (i < st1) { continue; }
                if (i >= st1 + end2) { break; }
                temp1 = ("00" + Convert.ToString(data[i], 16));
                str1 = str1 + temp1.Substring(temp1.Length - 2);
            }
            Console.WriteLine("reply=" + str1);
            return str1;
        }

        //发送数据
        //private bool sendDate_TCP(string dataText)
        //{

        //    if (dataText == "" || dataText is null)
        //    {
        //        Pow_err = -33;
        //        return false;
        //    }
        //    try
        //    {
        //        Pow_stream = Pow_client.GetStream();
        //    }
        //    catch
        //    {
        //        Pow_err = -22;
        //        return false;
        //    }
        //    // 发送数据
        //    Pow_stream.Write(strTOcode(ref dataText), 0, dataText.Length / 2);

        //    if (Pow_stream is NetworkStream)
        //    {
        //        Pow_err = 0;
        //        return true;
        //    }
        //    else
        //    {
        //        Pow_err = -31;
        //        return false;
        //    }
        //}

        private bool sendDate_TCP(string hexData)
        {
            if (string.IsNullOrWhiteSpace(hexData))
            {
                Pow_err = -33;
                return false;
            }

            if (!IsHexString(hexData)) // 添加一个函数来检查字符串是否有效的十六进制  
            {
                Pow_err = -34; // 无效的十六进制字符串  
                return false;
            }

            try
            {
                // 假设Pow_client是一个TcpClient对象，并且已经连接  
                Pow_stream = Pow_client.GetStream();

                // 将十六进制字符串转换为字节数组  
                byte[] byteData = HexStringToByteArray(hexData);

                // 发送数据  
                Pow_stream.Write(byteData, 0, byteData.Length);

                // 发送完成后，通常不需要检查Pow_stream的类型，因为它已经在前面获取了  
                Pow_err = 0;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Pow_err = -22;
                return false;
            }
        }

        // 检查字符串是否为有效的十六进制  
        private bool IsHexString(string hex)
        {
            for (int i = 0; i < hex.Length; i++)
            {
                char c = hex[i];
                if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
                {
                    return false;
                }
            }
            return true;
        }

        // 将十六进制字符串转换为字节数组  
        public byte[] HexStringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }


        //清空采集或上报的缓存
        public bool getReport_clear()
        {
            string re1 = "";
            byte[] re2 = null;

            bool a1 = getResult_TY(ref re1, ref re2, true);

            if (a1) { Pow_err = 0; }
            return a1;
        }
    }
}
