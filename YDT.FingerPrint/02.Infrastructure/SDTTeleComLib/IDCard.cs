using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SDTTeleComLib
{
    [StructLayout(LayoutKind.Sequential)]  
    public struct IDCard
    { 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public byte[] Name;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Sex;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Nation;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Birth;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
        public byte[] Address;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
        public byte[] ID;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public byte[] Issue;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Exper;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Exper2;
    }
}
