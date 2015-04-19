using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ast.Client.Device;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Data;

namespace TesoTellerIntDevice
{
    public class BpController
    {
        //bp盒控制指令工作模式 0 = 标准模式(Esc%B)  1=三合一专用模式(~%B)
        private static int bpWorkStyle2=0;

        public static int ChangeTo(int nCommPort, char chPort, int nBaudRate)
        {
            int nBPHandle = 0;
            int nHdlPort = 0;
            byte[] pBPCtrl = new byte[32];
            //BP 盒控制命令 ~%A
            if (bpWorkStyle2 == 1)
                pBPCtrl[0] = 0x7E;
            else
                pBPCtrl[0] = 0x1B;
            pBPCtrl[1] = 0x25;
            pBPCtrl[2] = (byte)chPort;
            pBPCtrl[3] = 0xFF;
            pBPCtrl[4] = 0xFF;
            pBPCtrl[5] = 0xFF;
	    
            try
            {
                //注意 第二个参数 波特率 选项
               // nBPHandle = FingerReaderDllWrapper.TcOpenComm(nCommPort, 3, 0, 0);
                //二代证  7
                nBPHandle = FingerReaderDllWrapper.TcOpenComm(nCommPort, nBaudRate, 0, 0);
                if (nBPHandle <= 0)
                {
                    return nBPHandle;
                }
                nHdlPort = FingerReaderDllWrapper.TcGhPort(nBPHandle);
                FingerReaderDllWrapper.WritComm(nHdlPort, pBPCtrl, 6, false);
            } catch (Exception) {
                return -1;
            }
            finally
            {
                if (nBPHandle > 0)
                    FingerReaderDllWrapper.TcCloseComm(nBPHandle);
            }
            return 0;
        }

        //解析PortName字符串 支持格式： Com1,Com2 Com1:A  Com2:B
        // 暂时不理会转口指令
        public static int CommPortToInt(String StrPortName, out char bpControlFlag)
        {
            bpControlFlag = 'O';
            int nTmpPort=0;
            String StrTmp = StrPortName;
            StrTmp = System.Text.RegularExpressions.Regex.Replace(StrTmp, @"[^\d]", "");
            nTmpPort = int.Parse(StrTmp);
            return nTmpPort;
        } 

    }
}
