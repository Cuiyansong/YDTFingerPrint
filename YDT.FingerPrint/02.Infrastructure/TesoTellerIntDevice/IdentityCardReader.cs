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
    public class IdentityCardReader : DeviceBase, IIdentityCard
    {
        private char bpControlFlag = 'S';
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
            this.BaudRate = config["baudRate"];
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
            return "";
        }
        public IdentityInfo WaitReadCard()
        {
            return new IdentityInfo();
        }

        public IdentityInfo ReadCard()
        {
            StringBuilder readData = new StringBuilder(256);
            int returnCode = 0;
            int returnConde2 = 0;
            int returnConde3 = 0;
            byte[] CardPUCIIN = new byte[255];
            byte[] pucManaMsg = new byte[255];
            byte[] pucCHMsg = new byte[255];
            byte[] pucPHMsg = new byte[3024];
            UInt32 puiCHMsgLen = 0;
            UInt32 puiPHMsgLen = 0;

            //BP 盒转口控制
            nCommPort = BpIdentity.CommPortToInt(this.PortName);
            BpIdentity.ChangeTo(nCommPort, bpControlFlag, nBaudRate);

            try
            {
                //开始找卡
                returnCode = IdentityCardReaderDllWrapper.SDT_StartFindIDCard(nCommPort, CardPUCIIN, 1);
            }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }
            if (returnCode != 0x9f)
            {
                switch (returnCode)
                {
                    case 128:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "寻找证/卡失败");
                    case 1:
                        throw new DeviceException(this.DeviceId, "-2", "端口打开失败");

                    default:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "失败");
                }
            }
            try
            {
                //选卡
                returnConde2 = IdentityCardReaderDllWrapper.SDT_SelectIDCard(nCommPort, pucManaMsg, 1);
            }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }
            if (returnConde2 != 0x90)
            {
                switch (returnConde2)
                {
                    case 128:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "寻找证/卡失败");
                    case 1:
                        throw new DeviceException(this.DeviceId, "-2", "端口打开失败");

                    default:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "失败");
                }

            }

            try
            {
                //读取固定信息
                returnConde3 = IdentityCardReaderDllWrapper.SDT_ReadBaseMsg(nCommPort, pucCHMsg, ref puiCHMsgLen, pucPHMsg, ref puiPHMsgLen, 1);

            }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }
            if (returnConde3 != 0x90)
            {
                switch (returnConde3)
                {
                    case 128:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "寻找证/卡失败");
                    case 1:
                        throw new DeviceException(this.DeviceId, "-2", "端口打开失败");

                    default:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "失败");
                }

            }

            return getIdentityInfo(pucCHMsg);
        }

        public void ExportPhoto(string photoPath)
        {
            StringBuilder readData = new StringBuilder(256);
            int returnCode = 0;
            int returnConde2 = 0;
            int returnConde3 = 0;
            byte[] CardPUCIIN = new byte[255];
            byte[] pucManaMsg = new byte[255];
            byte[] pucCHMsg = new byte[255];
            byte[] pucPHMsg = new byte[3024];
            UInt32 puiCHMsgLen = 0;
            UInt32 puiPHMsgLen = 0;

            //BP 盒转口控制
            char bpControlFlag = 'A';
            nCommPort = BpController.CommPortToInt(this.PortName,out bpControlFlag);
            BpController.ChangeTo(nCommPort, bpControlFlag, nBaudRate);

            try
            {
                //开始找卡
                returnCode = IdentityCardReaderDllWrapper.SDT_StartFindIDCard(nCommPort, CardPUCIIN, 1);
            }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", "寻卡"+e.Message.ToString());
            }
            if (returnCode != 0x9f)
            {
                switch (returnCode)
                {
                    case 128:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "寻找证/卡失败");
                    case 1:
                        throw new DeviceException(this.DeviceId, "-2", "端口打开失败");

                    default:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "失败");
                }
            }
            try
            {
                //选卡
                returnConde2 = IdentityCardReaderDllWrapper.SDT_SelectIDCard(nCommPort, pucManaMsg, 1);
            }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", "选卡"+e.Message.ToString());
            }
            if (returnConde2 != 0x90)
            {
                switch (returnConde2)
                {
                    case 128:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "寻找证/卡失败");
                    case 1:
                        throw new DeviceException(this.DeviceId, "-2", "端口打开失败");

                    default:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "失败");
                }

            }

            try
            {
                //读取固定信息
                returnConde3 = IdentityCardReaderDllWrapper.SDT_ReadBaseMsg(nCommPort, pucCHMsg, ref puiCHMsgLen, pucPHMsg, ref puiPHMsgLen, 1);

            }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", "读取"+ e.Message.ToString());
            }
            if (returnConde3 != 0x90)
            {
                switch (returnConde3)
                {
                    case 128:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "寻找证/卡失败");
                    case 1:
                        throw new DeviceException(this.DeviceId, "-2", "端口打开失败");

                    default:
                        throw new DeviceException(this.DeviceId, returnCode.ToString(), "失败");
                }

            }

            //处理图像信息。
            //string path = "C:\\zlz.wlt";
            string path = photoPath + ".wlt";

            File.Delete(path);
            FileStream fs = File.Open(path, FileMode.Append);
            fs.Write(pucPHMsg, 0, pucPHMsg.Length);
            fs.Close();

            int wlt = IdentityCardReaderDllWrapper.GetBmp(path, 2);

            if (wlt == 1)
            {
                // Bitmap image = new Bitmap("C:\\zlz.bmp"); 
                Bitmap image = new Bitmap(photoPath + ".bmp");
                image.Save(photoPath + ".jpg ", System.Drawing.Imaging.ImageFormat.Jpeg);
                image.Dispose();
            }


        }

        //按照字节截取
        public IdentityInfo getIdentityInfo(byte[] bytes)
        {
            IdentityInfo obj = new IdentityInfo();

            String s = System.Text.Encoding.Unicode.GetString(bytes, 0, 30);

            obj.Name = s;
            String s2 = System.Text.Encoding.Unicode.GetString(bytes, 30, 2);
            if (s2 == "1")
            {
                obj.Sex = "男";
            }
            if (s2 == "2")
            {
                obj.Sex = "女";
            }
            String s3 = System.Text.Encoding.Unicode.GetString(bytes, 32, 4);

            if (s3 != null)
            {
                switch (s3)
                {
                    case "01":
                        obj.Nation = "汉";
                        break;
                    case "02":
                        obj.Nation = "蒙古";
                        break;
                    case "03":
                        obj.Nation = "回";
                        break;
                    case "04":
                        obj.Nation = "藏";
                        break;
                    case "05":
                        obj.Nation = "维吾尔";
                        break;
                    case "06":
                        obj.Nation = "苗";
                        break;
                    case "07":
                        obj.Nation = "彝";
                        break;
                    case "08":
                        obj.Nation = "壮";
                        break;
                    case "09":
                        obj.Nation = "布依";
                        break;
                    case "10":
                        obj.Nation = "朝鲜";
                        break;
                    case "11":
                        obj.Nation = "满";
                        break;
                    case "12":
                        obj.Nation = "侗";
                        break;
                    case "13":
                        obj.Nation = "瑶";
                        break;
                    case "14":
                        obj.Nation = "白";
                        break;
                    case "15":
                        obj.Nation = "土家";
                        break;
                    case "16":
                        obj.Nation = "哈尼";
                        break;
                    case "17":
                        obj.Nation = "哈萨克";
                        break;
                    case "18":
                        obj.Nation = "傣";
                        break;
                    case "19":
                        obj.Nation = "黎";
                        break;
                    case "20":
                        obj.Nation = "傈僳";
                        break;
                    case "21":
                        obj.Nation = "佤";
                        break;
                    case "22":
                        obj.Nation = "畲";
                        break;
                    case "23":
                        obj.Nation = "高山";
                        break;
                    case "24":
                        obj.Nation = "拉祜";
                        break;
                    case "25":
                        obj.Nation = "水";
                        break;
                    case "26":
                        obj.Nation = "东乡";
                        break;
                    case "27":
                        obj.Nation = "纳西";
                        break;
                    case "28":
                        obj.Nation = "景颇";
                        break;
                    case "29":
                        obj.Nation = "柯尔克孜";
                        break;
                    case "30":
                        obj.Nation = "土";
                        break;
                    case "31":
                        obj.Nation = "达斡尔";
                        break;
                    case "32":
                        obj.Nation = "仫佬";
                        break;
                    case "33":
                        obj.Nation = "羌";
                        break;
                    case "34":
                        obj.Nation = "布朗";
                        break;
                    case "35":
                        obj.Nation = "撒拉";
                        break;
                    case "36":
                        obj.Nation = "毛南";
                        break;
                    case "37":
                        obj.Nation = "仡佬";
                        break;
                    case "38":
                        obj.Nation = "锡伯";
                        break;
                    case "39":
                        obj.Nation = "阿昌";
                        break;
                    case "40":
                        obj.Nation = "普米";
                        break;
                    case "41":
                        obj.Nation = "塔吉克";
                        break;
                    case "42":
                        obj.Nation = "怒";
                        break;
                    case "43":
                        obj.Nation = "乌孜别克";
                        break;
                    case "44":
                        obj.Nation = "俄罗斯";
                        break;
                    case "45":
                        obj.Nation = "鄂温克";
                        break;
                    case "46":
                        obj.Nation = "德昂";
                        break;
                    case "47":
                        obj.Nation = "保安";
                        break;
                    case "48":
                        obj.Nation = "裕固";
                        break;
                    case "49":
                        obj.Nation = "京";
                        break;

                    case "50":
                        obj.Nation = "塔塔尔";
                        break;
                    case "51":
                        obj.Nation = "独龙";
                        break;
                    case "52":
                        obj.Nation = "鄂伦春";
                        break;
                    case "53":
                        obj.Nation = "赫哲";
                        break;
                    case "54":
                        obj.Nation = "门巴";
                        break;
                    case "55":
                        obj.Nation = "珞巴";
                        break;
                    case "56":
                        obj.Nation = "基诺";
                        break;

                    default:

                        break;

                }

            }
            String s4 = System.Text.Encoding.Unicode.GetString(bytes, 36, 16);

            obj.Birthday = s4;


            String s5 = System.Text.Encoding.Unicode.GetString(bytes, 52, 70);

            obj.Address = s5;

            String s6 = System.Text.Encoding.Unicode.GetString(bytes, 122, 36);
            ;
            obj.ID = s6;

            String s7 = System.Text.Encoding.Unicode.GetString(bytes, 158, 30);

            obj.Department = s7;

            String s8 = System.Text.Encoding.Unicode.GetString(bytes, 188, 16);

            obj.StartDate = s8;

            String s9 = System.Text.Encoding.Unicode.GetString(bytes, 204, 16);

            obj.EndDate = s9;

            return obj;
        }


        public string WaitReadCard(CardTrackMode mode)
        {
            throw new DeviceException(this.DeviceId, "-1", "设备没有一直等待刷卡功能");
        }

        public void WriteCard(CardTrackMode mode, string data)
        {
        }

    }
}
