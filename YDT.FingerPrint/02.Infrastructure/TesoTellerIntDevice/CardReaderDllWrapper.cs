using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TesoTellerIntDevice
{ 

    internal class CardReaderDllWrapper
    {
        [DllImport("McrcReaderDevice.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ReadCard(int iPort, byte[] readData, int mode);

        [DllImport("McrcReaderDevice.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteCard(int iPort, byte[] writeData, int mode);
         
         
    }
}
