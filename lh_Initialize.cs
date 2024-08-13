using BFS.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    internal class lh_Initialize
    {
        int lh_connectType = 0;
        string lh_IP = "10.10.106.242";
        int lh_Port = 502;
        TcpClient lh_client = new TcpClient();
        NetworkStream lh_stream = null;
        bool lh_connected = false;
        bool lh_sending = false;
        bool lh_reading = false;
        int lh_timeOut = 3000;
        int lh_err = 0;

        public void setlh_connected(bool bool1 = false)
        {

            lh_connected = bool1;
        }
        public bool getlh_connected()
        {

            return lh_connected;
        }

        public lh_Initialize() { Console.WriteLine("lh_Initialize"); return; }

        public bool Load(int port, string address = "", int connectType = 0)
        {
            bool a1 = false;

            if (connectType <= 0)
            {
                //默认为TCP客户端通讯 
                lh_connectType = int.Parse(Resources.C_client);
            }
            else
            {
                lh_connectType = connectType;
            }

            if (lh_connectType == int.Parse(Resources.C_client))
            {
                // 创建Socket对象
                lh_client = new TcpClient();
                if (lh_client != null) { a1 = true; }
            }
            else
            {
                lh_err = -1;
            }
            lh_IP = address;
            lh_Port = port;
            if (a1) { lh_err = 0; }
            return a1;
        }

        //超时处理
        public void setTimeOut(int timeOut)
        {
            if (timeOut <= 0) { lh_timeOut = 3000; } else { lh_timeOut = timeOut; }
        }

        //连接类型
        public bool connect_Type()
        {

            bool a1 = false;

            //if (lh_connectType == int.Parse(Resources.C_client))
            //{
                a1 = connect_TCP();
            //}
            //else
            //{
            //    lh_err = -1;
            //}
            lh_connected = a1;
            if (a1) { lh_err = 0; }
            return a1;
        }

        //断开类型
        public bool Disconnect_Type()
        {
            bool a1 = false;
            if (lh_client != null) { a1 = disconnect_TCP(); }
            return a1;
        }

        //连接服务器
        public bool connect_TCP()
        {
            // 连接服务器
            try
            {
                lh_client.Connect(lh_IP, lh_Port);
                setlh_connected(true);
                Console.WriteLine("老化柜连接成功！");
            }
            catch (Exception e)
            {
                lh_err = -21;
                Console.WriteLine(e.ToString());
            }
            try
            {
                lh_stream = lh_client.GetStream();
            }
            catch (Exception e) { Console.WriteLine(e.Message); lh_err = -22; return false; }

            return lh_client.Connected;

        }

        //断开服务器
        public bool disconnect_TCP()
        {
            lh_client.Close();
            return true;
        }

        //发送数据
        public bool sendData_TY(string data_text)
        {
            if (!lh_connected) { lh_err = -2; return false; }

            if (lh_sending)
            {
                lh_err = -32;
                return false;
            }

            //先读一遍清空缓存
            getReport_clear();
            lh_sending = true;

            bool a1 = false;
            //if (Pow_connectType == int.Parse(Resources.C_client))
            //{
            a1 = sendDate_TCP(data_text);
            //}
            //else
            //{
            //    Pow_err = -1;
            //}
            lh_sending = false;
            if (a1) { lh_err = 0; }
            return a1;
        }

        public bool getResult_TY(ref string re_text, ref byte[] re_byte, bool NoWait = false)
        {
            if (lh_reading)
            {
                lh_err = -42;
                return false;
            }

            lh_reading = true;
            bool a1 = false;
            int time2 = 0;

            while (!a1 && time2 < lh_timeOut / 1000)
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

            lh_reading = false;
            if (a1) { lh_err = 0; }
            return a1;
        }

        //读取数据
        private bool getResult_TCP(ref string re_text, ref byte[] re_byte)
        {
            re_byte = new byte[1024 * 5];
            int byteL = 0;
            lh_stream.ReadTimeout = 800;

            try
            {
                byteL = lh_stream.Read(re_byte, 0, re_byte.Length);
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
            lh_err = -41;
            return false;
        }

        private byte[] strTOcode(ref string code)
        {
            byte[] data = null;
            code = code.Replace(" ", "");

            if (code.Length % 2 != 0 || code == "")
            {
                lh_err = -3;
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

        private bool sendDate_TCP(string hexData)
        {
            if (string.IsNullOrWhiteSpace(hexData))
            {
                lh_err = -33;
                return false;
            }

            if (!IsHexString(hexData)) // 添加一个函数来检查字符串是否有效的十六进制  
            {
                lh_err = -34; // 无效的十六进制字符串  
                return false;
            }

            try
            {
                // 假设Pow_client是一个TcpClient对象，并且已经连接  
                lh_stream = lh_client.GetStream();

                // 将十六进制字符串转换为字节数组  
                byte[] byteData = HexStringToByteArray(hexData);

                // 发送数据  
                lh_stream.Write(byteData, 0, byteData.Length);

                // 发送完成后，通常不需要检查Pow_stream的类型，因为它已经在前面获取了  
                lh_err = 0;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                lh_err = -22;
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
        private byte[] HexStringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        //将大写转为小写
        public string ConvertToLowerCaseHex(string input)
        {
            StringBuilder sb = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (c >= 'A' && c <= 'F')
                {
                    sb.Append((char)(c - 'A' + 'a')); // 转换为小写  
                }
                else
                {
                    sb.Append(c); // 保持原样  
                }
            }
            return sb.ToString();
        }

        //清空采集或上报的缓存
        public bool getReport_clear()
        {
            string re1 = "";
            byte[] re2 = null;

            bool a1 = getResult_TY(ref re1, ref re2, true);

            if (a1) { lh_err = 0; }
            return a1;
        }
    }
}
