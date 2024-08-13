using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace BFS
{
    public struct Pair
    {
        public string key;
        public string value;
        public Pair(string key1, string value1)
        {
            key = key1;
            value = value1;
        }
    }
    internal class Sysini
    {
        public static List<Pair> sysini = new List<Pair>();
        public Sysini() {
            Pair pairT1 = new Pair();
            pairT1.key = "windowsTitle";
            pairT1.value = "关断器老化监控系统";
            sysini.Add(pairT1);
            //电子负载
            pairT1.key = "Ele_IP";
            pairT1.value = "10.10.106.240";
            sysini.Add(pairT1);
            pairT1.key = "Ele_Port";
            pairT1.value = "7000";
            sysini.Add(pairT1);
            //万瑞达电源
            pairT1.key = "Power_IP";
            pairT1.value = "10.10.106.239";
            sysini.Add(pairT1);
            pairT1.key = "Power_Port";
            pairT1.value = "17072";
            sysini.Add(pairT1);
            //老化柜
            pairT1.key = "Room_IP";
            pairT1.value = "10.10.106.242";
            sysini.Add(pairT1);
            pairT1.key = "Room_Port";
            pairT1.value = "502";
            sysini.Add(pairT1);
            //继电器
            pairT1.key = "Relay_IP";
            pairT1.value = "10.10.106.241";
            sysini.Add(pairT1);
            pairT1.key = "Relay_Port";
            pairT1.value = "17072";
            sysini.Add(pairT1);

            pairT1.key = "Ele_Power";
            pairT1.value = "0.0";
            sysini.Add(pairT1);
            pairT1.key = "Ele_Vol";
            pairT1.value = "0.0";
            sysini.Add(pairT1);
            pairT1.key = "Ele_Ele";
            pairT1.value = "0.0";
            sysini.Add(pairT1);
            pairT1.key = "Ele_Resis";
            pairT1.value = "0.0";
            sysini.Add(pairT1);

            pairT1.key = "Power_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Power_Vol";
            pairT1.value = "0.0";
            sysini.Add(pairT1);
            pairT1.key = "Power_Ele";
            pairT1.value = "0.0";
            sysini.Add(pairT1);

            pairT1.key = "lh_Status";
            pairT1.value = "0.0";
            sysini.Add(pairT1);
            pairT1.key = "lh_Temp";
            pairT1.value = "25.0";
            sysini.Add(pairT1);

            pairT1.key = "Relay1_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay2_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay3_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay4_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay5_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay6_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay7_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay8_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay9_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay10_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay11_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay12_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay13_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay14_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay15_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);
            pairT1.key = "Relay16_Status";
            pairT1.value = "OFF";
            sysini.Add(pairT1);

            pairT1.key = "Real_Pow_Vol";
            pairT1.value = "0.0";
            sysini.Add(pairT1);
            pairT1.key = "Real_Pow_Ele";
            pairT1.value = "0.0";
            sysini.Add(pairT1);
            pairT1.key = "Real_Temp";
            pairT1.value = "25.0";
            sysini.Add(pairT1);

            Get_Sysini();
        }

        public void Get_Sysini() {

            using (StreamReader sr = new StreamReader(Global.G_sysconfig))
            {
                string line;
                bool a1 = false;

                while ((line = sr.ReadLine()) != null)
                {

                    //line = new TranscodeToUTF8(ref line).getResult();
                    //line = line.Replace(" ","");

                    // 忽略空行和注释行
                    if (line == "" || line.Trim().StartsWith(";") || line.Trim().StartsWith("="))
                    {
                        continue;
                    }

                    // 分割键值对
                    string[] keyValuePair = line.Split('=');
                    Pair pairTemp1 = new Pair();

                    if (keyValuePair.Length > 2)
                    {
                        // 获取键和值
                        pairTemp1.key = keyValuePair[0].Trim();
                        pairTemp1.value = line.Replace(keyValuePair[0].Trim() + "=", "");
                        a1 = true;
                    }
                    else if (keyValuePair.Length == 2)
                    {
                        // 获取键和值
                        pairTemp1.key = keyValuePair[0].Trim();
                        pairTemp1.value = keyValuePair[1].Trim();
                        a1 = true;
                    }
                    else
                    {

                        pairTemp1.key = line.Replace("=", "");
                        pairTemp1.value = "";

                    }

                    // 处理键值对
                    if (a1)
                    {
                        a1 = false;
                        for (int i = 0; i < sysini.Count; i++)
                        {

                            if (pairTemp1.key.ToUpper() == sysini[i].key.ToUpper())
                            {
                                sysini[i] = new Pair(pairTemp1.key, pairTemp1.value);
                                a1 = true;
                            }

                        }

                        //加入数组
                        if (!a1)
                        {
                            sysini.Add(pairTemp1);
                        }
                    }

                }
            }
        }

        public void Set_Sysini()
        {

        }

        public string Get_Value(string key, string def = "")
        {
            if (key.Replace(" ", "") == "") { return ""; };

            for (int i = 0; i < sysini.Count; i++)
            {
                if (key.ToUpper() == sysini[i].key.ToUpper())
                {
                    return sysini[i].value;
                }
            }

            if (def == "")
            {
                return key;
            }
            else
            {
                return def;
            }
        }

        public bool Updata_Value(string key, string value = "")
        {
            bool a1 = false;
            key = key.Replace(" ", "");

            for (int i = 0; i < sysini.Count; i++)
            {
                if (key.ToUpper() == sysini[i].key.ToUpper())
                {
                    sysini[i] = new Pair(key, value);
                    a1 = true;
                }
            }
            if (!a1)
            {
                sysini.Add(new Pair(key, value));
            }

            //更新配置文件
            using (StreamWriter sw = new StreamWriter(Global.G_sysconfig))
            {
                // 写入键值对
                for (int i = 0; i < sysini.Count; i++)
                {
                    sw.WriteLine($"{sysini[i].key}={sysini[i].value}");
                }
            }
            return true;
        }
        public bool Updata_Value1(string key, string value = "", bool notSave = false)
        {
            bool a1 = false;
            key = key.Replace(" ", "");

            for (int i = 0; i < sysini.Count; i++)
            {
                if (key.ToUpper() == sysini[i].key.ToUpper())
                {
                    sysini[i] = new Pair(key, value);
                    a1 = true;
                }
            }
            if (!a1)
            {
                sysini.Add(new Pair(key, value));
            }

            if (!notSave)
            {
                ////更新配置文件
                //using (StreamWriter sw = new StreamWriter(Global.G_sysconfig))
                //{
                //    // 写入键值对
                //    for (int i = 0; i < sysini.Count; i++)
                //    {
                //        sw.WriteLine($"{sysini[i].key}={sysini[i].value}");
                //    }
                //}
            }
            return true;
        }
    }
}