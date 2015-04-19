using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TesoTellerIntDevice
{
    internal class IdentityCardReaderDllWrapper
    {
         
        [DllImport("sdtapi.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int SDT_StartFindIDCard(int iPort, byte[] pucManaInfo, int iIfOpen);

        [DllImport("sdtapi.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int SDT_SelectIDCard(int iPort, byte[] pucManaMsg, int iIfOpen);

        [DllImport("sdtapi.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int SDT_ReadBaseMsg(int iPort, byte[] pucCHMsg, ref UInt32 puiCHMsgLen, byte[] pucPHMsg, ref UInt32 puiPHMsgLen, int iIfOpen);

        [DllImport("WltRS.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetBmp(String pucPHMsg, int intf);
    }
}
