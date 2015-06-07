using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SDTTeleComLib
{
    internal class SDTWin32API
    {
        #region API声明
        [DllImport("sdtapi.dll", CallingConvention = CallingConvention.StdCall)]
       internal static extern int SDT_OpenPort(int iPort);

        [DllImport("sdtapi.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern int SDT_ClosePort(int iPort);

        [DllImport("sdtapi.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern int SDT_StartFindIDCard(int iPort, byte[] pucManaInfo, int iIfOpen);

        [DllImport("sdtapi.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern int SDT_SelectIDCard(int iPort, byte[] pucManaMsg, int iIfOpen);

        [DllImport("sdtapi.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern int SDT_ReadBaseMsg(int iPort, byte[] pucCHMsg, ref UInt32 puiCHMsgLen, byte[] pucPHMsg, ref UInt32 puiPHMsgLen, int iIfOpen);

        #endregion
    }
}
