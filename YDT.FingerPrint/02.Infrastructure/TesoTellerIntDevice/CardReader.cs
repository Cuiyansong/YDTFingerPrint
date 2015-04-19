using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ast.Client.Device;

namespace TesoTellerIntDevice
{
    public class CardReader : DeviceBase, ITellerIntDevice
    {
        private char bpControlFlag = 'B';
        private int nCommPort = 0;
        //设备通信波特率
        public int nBaudRate = 3;

        public string BaudRate
        {
            get;
            set;
        }

        public string TimeOut
        {
            get;
            set;
        }

        public override void ApplyConfiguration(IDictionary<string, string> config)
        {
            string baud = config["baudRate"];
            //this.BaudRate = config["baudRate"];
            if (baud == "1200")
            {
                this.nBaudRate = 0;
            }
            if (baud == "2400")
            {
                this.nBaudRate = 1;
            }
            if (baud == "4800")
            {
                this.nBaudRate = 2;
            }
            if (baud == "9600")
            {
                this.nBaudRate = 3;
            }
            if (baud == "19200")
            {
                this.nBaudRate = 4;
            }
            if (baud == "38400")
            {
                this.nBaudRate = 5;
            }
            if (baud == "57600")
            {
                this.nBaudRate = 6;
            }
            if (baud == "115200")
            {
                this.nBaudRate = 7;
            }
            this.TimeOut = config["timeOut"];
        }
        public void ExportPhoto(string photoPath)
        {

        }
        
        public Ast.Client.Device.IdentityInfo ReadCard()
        {
            Ast.Client.Device.IdentityInfo ininfo = new Ast.Client.Device.IdentityInfo();
            return ininfo;
        }
        public string GetFeature()
        {
            return "";
        }
        public string GetFingerInfo()
        {
            return "";
        }
        public string GetTemplate(int nMode)
        {
            return "";
        }
        public Boolean IsFingerMatch(string pReg, string pVer, int nLevel)
        {
            return false;
        }
        public void Close()
        {
            throw new DeviceException(this.DeviceId, "-1", "设备不支持此功能");
        }

        public void Open()
        {
            throw new DeviceException(this.DeviceId, "-1", "设备不支持此功能");
        }

        public override DeviceStatus GetDeviceStatus()
        {
            throw new DeviceException(this.DeviceId, "-1", "设备不支持此功能");
        }
        public string ReadCard(CardTrackMode mode)
        {
            int returnCode = 0;
            //BP 盒转口控制
            char bpControlFlag = 'A';
            nCommPort = BpController.CommPortToInt(this.PortName, out bpControlFlag);
            BpController.ChangeTo(nCommPort, bpControlFlag, nBaudRate);
            byte[] readData = new byte[255];
            Array.Clear(readData, 0, readData.Length);
            try
            {
                returnCode = CardReaderDllWrapper.ReadCard(nCommPort, readData, (int)mode);         
             }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }
            if (returnCode >= 1)
            {
              return     System.Text.Encoding.Default.GetString(readData);
               
            }
            else
            {
                switch (returnCode)
                {
                    case -11:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "打开端口失败");
                    case -1:
                        throw new DeviceException(this.DeviceId, "-99", "操作超时");
                    case -2:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "操作失败");
                    case -7:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "参数mode值非法");
                    default:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "失败");
                }
            }
             
        }

        

        public string WaitReadCard(CardTrackMode mode)
        {
            throw new DeviceException(this.DeviceId, "-1", "设备没有一直等待刷卡功能");
        }

        public void WriteCard(CardTrackMode mode, string readData)
        {
            if (readData == null)
            {
                throw new DeviceException(this.DeviceId, "-7", "参数data值非法");
            }

            int returnCode = 0;
            //BP 盒转口控制
            char bpControlFlag = 'A';
            nCommPort = BpController.CommPortToInt(this.PortName, out bpControlFlag);
            BpController.ChangeTo(nCommPort, bpControlFlag, nBaudRate);
            byte[] writeData  = new byte[255];
            byte[] tmpBuf= System.Text.Encoding.Default.GetBytes(readData);
            Array.Clear(writeData, 0, writeData.Length);
            Array.Copy(tmpBuf, writeData, tmpBuf.Length); 
            try
            {
                returnCode = CardReaderDllWrapper.WriteCard(nCommPort, writeData, (int)mode);
            }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }
            if (returnCode >= 1)
            {

                throw new DeviceException(this.DeviceId, "-9999", "009");
            }
            else
            {
                switch (returnCode)
                {
                    case -11:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "打开端口失败");
                    case -1:
                        throw new DeviceException(this.DeviceId, "-99", "操作超时");
                    case -2:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "操作失败");
                    case -7:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "参数mode值非法");
                    default:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "失败");
                }
            }

        }
    }
}
