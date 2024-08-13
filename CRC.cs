using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    internal class CRC
    {
        // CRC-16-CCITT (XMODEM variant) 校验函数  
        // 预校验内容：byte数组，待校验的数据  
        // 初始CRC值通常设为0xFFFF（高位在前）  
        public static uint CalculateCrc16Ccitt(byte[] data, uint crc = 0xFFFF)
        {
            const ushort polynomial = 0xA001; // 16位生成多项式，低位在前  
            uint temp;
            for (int i = 0; i < data.Length; ++i)
            {
                temp = crc ^ (uint)data[i] << 8; // 假设crc是高位在前，所以需要左移8位  
                for (int j = 0; j < 8; ++j)
                {
                    if ((temp & 0x8000) != 0) // 检查最高位  
                    {
                        temp = (temp << 1) ^ polynomial;
                    }
                    else
                    {
                        temp <<= 1;
                    }
                }
                crc = temp;
            }
            // 注意：根据CRC的应用场景，可能需要在最后对crc进行反转或取反  
            // 这里我们直接返回crc，不进行反转或取反  
            return crc;
        }
    }

    public class Crc16ANSI
    {
        // CRC-16-ANSI (KERMIT) 校验多项式 0x1021 (带初始值 0xFFFF 和最终反转)  
        private const ushort polynomial = 0xA001;
        private const ushort initialValue = 0xFFFF;

        public static ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = initialValue;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return ReverseBytes(crc);
        }

        // CRC查找表  
        private static readonly ushort[] table = new ushort[256];

        // 静态构造函数，用于初始化CRC查找表  
        static Crc16ANSI()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }

        // 反转字节序的函数  
        private static ushort ReverseBytes(ushort value)
        {
            return (ushort)((value >> 8) | (value << 8));
        }
    }
}
