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
    public class FingerReader : DeviceBase,ITellerIntDevice
    {
        //BP盒转口控制符
        private char bpControlFlag = 'B';
        //设备连接Com口 
        private int nCommPort = 0;
        //设备通信波特率
        public  int nBaudRate = 3;
        //通讯控制句柄
        private int nDevHandle = 0;
        //特征合成
       static  String nRetsString = "";
 
        
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
            this.TimeOut = config["timeOut"];

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

           
        }
          
        public void ExportPhoto(string photoPath)
        {
        }
       

        public string ReadCard(CardTrackMode mode)
        {
            return "";
        }
        public Ast.Client.Device.IdentityInfo ReadCard()
        {
            Ast.Client.Device.IdentityInfo ininfo = new Ast.Client.Device.IdentityInfo();
            return ininfo;
        }

        //关闭通信句柄
         ~FingerReader()
        {
            try
            {
                if (nDevHandle >= 0)
                {
                    FingerReaderDllWrapper.TcCloseComm(nDevHandle);
                    nDevHandle = 0;
                }
            }
            catch (Exception)
            {

            }

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

       
         

        /// <summary>
        /// 获得注册指纹模板
        /// </summary>
        /// <param name="mode">mode：指纹模式，=1，第一次获取指纹模板；=2，第二次获取指纹模板；=3，第三次获取</param>
        /// <remarks>失败抛异常</remarks>
        /// <returns>指纹图片信息，Base64存储为字符串，jpg格式;</returns>
        public string GetTemplate(int nMode)
        {
            //指纹图像base64信息
            String nRetStringbase64 = "";
            //特征合成
            nRetsString = "";
            string nRetString="";
            StringBuilder readData = new StringBuilder(256);
            //句柄
            int objHdl =-1;
            //返回图像
            int nRet = -1;
            //指纹图像特征
            byte[] pReg = new byte[65536];
            
            //特征合成
            int nRets = -1;
            
            byte[] pRegs = new byte[512];

            //图像长度
            int pdwLen = pReg.Length;
            //第三次注册指纹,特征合成
            int pdwLen2 = pRegs.Length;
          //  byte[] CardPUCIIN = new byte[255];
           // byte[] pucManaMsg = new byte[255];
            //byte[] pucCHMsg = new byte[255];
            //byte[] pucPHMsg = new byte[3024];          

            //BP 盒转口控制
            char bpControlFlag = 'A';
            nCommPort = BpController.CommPortToInt(this.PortName,out bpControlFlag);
            BpController.ChangeTo(nCommPort, bpControlFlag, nBaudRate);
             

            try
            {
                objHdl = FingerReaderDllWrapper.TcOpenComm(nCommPort, nBaudRate, 0, 0); 
            }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }             
            if (objHdl == 0)
            {
                throw new DeviceException(this.DeviceId, objHdl.ToString(), "打开句柄失败");                 
            }           
            //返回图像信息。
            int nRetun=14;              
            try
            {
                if (0 <= nMode - 1 && nMode - 1 < 3)
                {                     
                    nRet = FingerReaderDllWrapper.TcSuperRegist(objHdl, nMode - 1, nRetun, pReg, ref pdwLen);
                }               
            }
            catch (Exception e)
            {
                objHdl = FingerReaderDllWrapper.TcCloseComm(objHdl); 
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }
            
            if (nRet!= 0)
            {
                objHdl = FingerReaderDllWrapper.TcCloseComm(objHdl);
                throw new DeviceException(this.DeviceId, nRet.ToString(), "获取指纹图像信息失败");                
            }
            else
            {
                // byte[]转成string 
             //   nRetString = System.Text.Encoding.Default.GetString(pReg);                 
                nRetString = Convert.ToBase64String(pReg, 0, pdwLen);
                  nRetStringbase64 = this.getImageUpdate("",pReg,pdwLen);
                //蜂鸣器
                FingerReaderDllWrapper.TcSubDev(objHdl, 0, 10); 
            }
            try
            {
                if (nMode - 1 == 2)
                {
                    nRets = FingerReaderDllWrapper.TcSuperRegist(objHdl, nMode, 0, pRegs, ref  pdwLen2);
                    if (nRets != 0)
                    {
                        objHdl = FingerReaderDllWrapper.TcCloseComm(objHdl);
                        throw new DeviceException(this.DeviceId, nRets.ToString(), "特征合成失败");
                    }
                    else
                    { 
                        nRetsString = Convert.ToBase64String(pRegs, 0, pdwLen2);
                        //蜂鸣器
                        FingerReaderDllWrapper.TcSubDev(objHdl, 0, 20); 
                    }

                }
            }
            catch (Exception e)
            {
                objHdl = FingerReaderDllWrapper.TcCloseComm(objHdl);
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }
            
            objHdl = FingerReaderDllWrapper.TcCloseComm(objHdl);

            return nRetStringbase64;
             
        }
        

        //特征合成\ 获得指纹特征或模板数据
        public string GetFingerInfo()
        {
            return nRetsString;
        }
        //获得验证指纹特征[验证指纹]
        public string GetFeature() 
        {

            //指纹特征
          //  string nRetString = "";
            String nRetStringbase64 = "";
            int nRets=-1;
            byte[] pRegs = new byte[512];
            //句柄
            int objHdl = -1;
            //返回图像
            int nRet = -1;
            //指纹图像特征
            byte[] pReg = new byte[65536]; 
            //图像长度
            int pdwLen = pReg.Length;           
            //BP 盒转口控制
            char bpControlFlag = 'A';
            nCommPort = BpController.CommPortToInt(this.PortName, out bpControlFlag);
            BpController.ChangeTo(nCommPort, bpControlFlag,nBaudRate);

            try
            {
                objHdl = FingerReaderDllWrapper.TcOpenComm(nCommPort, nBaudRate, 0, 0);
            }
            catch (Exception e)
            {
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }

            if (objHdl == 0)
            {
                throw new DeviceException(this.DeviceId, objHdl.ToString(), "打开句柄失败");

            }
           
            //返回图像信息。
            int nRetun = 14;
            try
            { 
               nRet = FingerReaderDllWrapper.TcLoadrToPimg(objHdl,nRetun, pReg, ref pdwLen);                 
            }
            catch (Exception e)
            {
                objHdl = FingerReaderDllWrapper.TcCloseComm(objHdl);
                throw new DeviceException(this.DeviceId, "-9999", e.Message.ToString());
            }
            if (nRet != 0)
            {
                objHdl = FingerReaderDllWrapper.TcCloseComm(objHdl);
                throw new DeviceException(this.DeviceId, nRet.ToString(), "获取指纹图像失败");
            }
            else
            {
                // byte[]转成string 
                //   nRetString = System.Text.Encoding.Default.GetString(pReg);

              //  nRetString = Convert.ToBase64String(pReg, 0, pdwLen);
                //图像处理
                 /*
                FingerReaderDllWrapper.TcSmotImg(pReg,152,200);
                FingerReaderDllWrapper.SaveTotalImage("D:\\zlz.bmp",pReg, 152, 200);
               // FingerReaderDllWrapper.LoadBinaryFile("D:\\zlz.bmp", pReg, pReg.Length);
                Bitmap image = new Bitmap("D:\\zlz.bmp");
                image.Save("D:\\zlz.jpg ", System.Drawing.Imaging.ImageFormat.Jpeg);
                image.Dispose();
               int pRegLength= FingerReaderDllWrapper.LoadBinaryFile("D:\\zlz.bmp", pReg, pReg.Length);
               nRetStringbase64 = Convert.ToBase64String(pReg, 0, pRegLength);
                 */
                nRetStringbase64 = this.getImageUpdate("",pReg,pdwLen);
                int nIndex = 0;
                int nRetrn = 1;
                nRets = FingerReaderDllWrapper.TcMinutFrPimg(objHdl, nIndex, nRetrn, pRegs, ref pdwLen);
                if (nRets != 0)
                {
                    objHdl = FingerReaderDllWrapper.TcCloseComm(objHdl);
                    throw new DeviceException(this.DeviceId, nRet.ToString(), "获取指纹特征失败");
                }
                else
                {
                    nRetsString = Convert.ToBase64String(pRegs, 0, pdwLen);
                    //蜂鸣器
                    FingerReaderDllWrapper.TcSubDev(objHdl, 0, 10); 
                }
            }            
            objHdl = FingerReaderDllWrapper.TcCloseComm(objHdl);
            return nRetStringbase64;
        }

        //处理图像方法
        public string getImageUpdate(String imagePath, byte[] pReg, int pdwLen) 
        {
             int pRegLength=0;
            if (imagePath == null || imagePath == "")
            {
               // imagePath = "D:\\zlz.bmp";
                imagePath = System.IO.Path.GetTempFileName();
            }
            try
            { 
            
                FingerReaderDllWrapper.TcSmotImg(pReg, 152, 200);
                FingerReaderDllWrapper.SaveTotalImage(imagePath, pReg, 152, 200);
                // FingerReaderDllWrapper.LoadBinaryFile("D:\\zlz.bmp", pReg, pReg.Length);
                Bitmap image = new Bitmap(imagePath);
                image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                image.Dispose();
                pRegLength = FingerReaderDllWrapper.LoadBinaryFile(imagePath, pReg, pReg.Length);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return Convert.ToBase64String(pReg, 0, pRegLength);
             
        }
        /// <summary>
        /// 根据文件名返回临时文件夹中唯一命名的文件的完整路径
        ///   形如：公司文档(1).doc，公司文档(2).doc
        /// </summary>
        public static string GetTempPathFileName(string fileName)
        {
            // 系统临时文件夹
            string tempPath = Path.GetTempPath();
            // 文件的完成路径
            fileName = tempPath + Path.GetFileName(fileName);
            // 文件名
            string fileNameWithoutExt =
                   Path.GetFileNameWithoutExtension(fileName);
            // 扩展名
              
            string fileExt = Path.GetExtension(fileName);
            
            int i = 0;
            while (File.Exists(fileName))
            {
                // 生成类似这样的文件名：公司文档(1).doc，公司文档(2).doc
                fileName = tempPath + fileNameWithoutExt +
                           string.Format("({0})", ++i) + fileExt;
            }
            return fileName;
        }


       // 指纹对比
        public Boolean IsFingerMatch(string pReg, string pVer, int nLevel)
        {
            int nRet = -1;
            nRet = FingerReaderDllWrapper.TcSafeMatch(0, pReg, pVer, nLevel);
            if (nRet >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
