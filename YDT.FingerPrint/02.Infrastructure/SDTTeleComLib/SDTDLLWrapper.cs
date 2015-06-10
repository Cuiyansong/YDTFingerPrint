using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDTTeleComLib
{
    public class SDTDLLWrapper : IDisposable
    {
        //变量声明
        private byte[] CardPUCIIN = new byte[255];
        private byte[] pucManaMsg = new byte[255];
        private byte[] pucCHMsg = new byte[255]; // 文字信息
        private byte[] pucPHMsg = new byte[3024];// 图片信息
        private UInt32 puiCHMsgLen = 0;
        private UInt32 puiPHMsgLen = 0;
        private Int32 isOpen = 0;
        private Int32 usbPortNum;
        private int st = 0;

        public string PucCHMsg
        {
            get
            {
                return System.Text.UTF8Encoding.Unicode.GetString(pucCHMsg);
            }
        }

        public IDCard IDCard
        {
            get
            {
                if (pucCHMsg.Length > 0)
                {
                    return (IDCard)SDTWin32API.ByteToStruct(pucCHMsg, typeof(IDCard));
                }
                return new IDCard();
            }
        }

        public byte[] ImageBytes
        {
            get
            {
                return pucPHMsg;
            }
        }

        public SDTDLLWrapper()
        {
            usbPortNum = 1001; // USB port
        }

        public bool ReadIDCard()
        {
            var success = false;

            try
            {
                // 打开USB
                st = SDTWin32API.SDT_OpenPort(usbPortNum);
                if (st == 0x90) success = true;

                // 尝试读卡
                if (success)
                {
                    st = SDTWin32API.SDT_StartFindIDCard(usbPortNum, CardPUCIIN, isOpen);
                    if (st != 0x9f) success = false;
                }

                // 读取卡片
                if (success)
                {
                    st = SDTWin32API.SDT_SelectIDCard(usbPortNum, pucManaMsg, isOpen);
                    if (st != 0x90) success = false;
                }

                // 读取信息
                if (success)
                {
                    st = SDTWin32API.SDT_ReadBaseMsg(usbPortNum, pucCHMsg, ref puiCHMsgLen, pucPHMsg, ref puiPHMsgLen, isOpen);
                    var debugTest = System.Text.UTF8Encoding.Unicode.GetString(pucCHMsg);
                    if (st != 0x90) success = false;
                }

                if (success)
                {
                    st = SDTWin32API.SDT_ClosePort(usbPortNum);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (success)
                    st = SDTWin32API.SDT_ClosePort(usbPortNum);
            }
            return success;
        }


        #region IDisposable
        public void Dispose()
        {

        }
        #endregion

    }
}
