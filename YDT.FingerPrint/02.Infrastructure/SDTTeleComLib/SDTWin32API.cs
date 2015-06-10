using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SDTTeleComLib
{
    public class SDTWin32API
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

        [DllImport("WltRS.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetBmp(String Wlt_File, int intf);
        #endregion

        #region Helper
        /// <summary>
        /// Structures to bytes.
        /// </summary>
        /// <param name="structObj">The structure object.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static byte[] StructToBytes(object structObj, int size)
        {
            int num = 2;
            byte[] bytes = new byte[size];
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷贝到byte 数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return bytes;

        }

        /// <summary>
        /// Bytes to structure.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object ByteToStruct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length)
            {
                return null;
            }
            //分配结构体内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷贝到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }
        #endregion
    }
}
