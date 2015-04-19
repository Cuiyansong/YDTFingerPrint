namespace YDT.WinForm.Common
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using YDT.WinForm.Utlity;
    using System.Runtime.InteropServices;

    internal class TesoDevMgmt : IDisposable
    {
        #region Private Property
        private int objHdl = -1;
        private byte[] pReg = new byte[512];
        private byte[] pVer = new byte[512];
        private int nRet;
        private String strReg = "";
        private String strVer = "";
        private int match;
        private Bitmap curImg;
        private string fingerPath = Application.StartupPath + "\\Temp\\finger.bmp";
        #endregion

        #region Public Property
        /// <summary>
        /// Gets register fingerprint
        /// </summary>
        /// <value>
        /// The get finger.
        /// </value>
        public string Finger
        {
            get { return strReg; }
            set { strReg = value; }
        }
        /// <summary>
        /// Gets varification fingerprint
        /// </summary>
        /// <value>
        /// The get feature.
        /// </value>
        public string Feature
        {
            get { return strVer; }
            set { strVer = value; }
        }
        /// <summary>
        /// Gets the get match.
        /// </summary>
        /// <value>
        /// The get match.
        /// </value>
        public int Match
        {
            get { return match; }
        }
        /// <summary>
        /// Gets the current img.
        /// </summary>
        /// <value>
        /// The current img.
        /// </value>
        public Bitmap CurImg
        {
            get { return curImg; }
            set
            {
                curImg = value;
            }
        }

        #endregion

        #region Constructor

        #endregion

        #region Public Method
        /// <summary>
        /// To get template
        /// </summary>
        /// <returns></returns>
        public bool DoTemplet()
        {
            try
            {
                // Get Hardware Handle
                objHdl = GetDevHDL();
                if (objHdl <= 0)
                {
                    MessageBox.Show(StringConstant.Error_NotFoundHDL);
                    return false;
                }

                // To get fingerprint by four times
                nRet = TesoWin32Helper.TcDoTemplet(objHdl, pReg);
                if (nRet < 0)
                {
                    MessageBox.Show(StringConstant.Error_RegisterTemplate);
                    return false;
                }

                strReg = System.Text.Encoding.UTF8.GetString(pReg);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                var res = TesoWin32Helper.TcDeleteHDL(objHdl);
            }
        }
        /// <summary>
        /// To get feature.
        /// </summary>
        /// <returns></returns>
        public bool DoFeature()
        {
            try
            {
                // Get Hardware Handle
                objHdl = GetDevHDL();
                if (objHdl <= 0)
                {
                    MessageBox.Show(StringConstant.Error_NotFoundHDL);
                    return false;
                }

                // Get single fingerprint
                nRet = TesoWin32Helper.TcDoFeature(objHdl, pVer);
                if (nRet >= 0)
                {
                    strVer = System.Text.Encoding.UTF8.GetString(pVer);
                }
                else
                {
                    MessageBox.Show(StringConstant.Error_VarifyFingerprint);
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                var res = TesoWin32Helper.TcDeleteHDL(objHdl);
            }
        }
        /// <summary>
        /// Do safe match
        /// </summary>
        /// <returns></returns>
        public bool DoSafeMatch()
        {
            try
            {
                // Get Hardware Handle
                objHdl = GetDevHDL();
                if (objHdl <= 0)
                {
                    MessageBox.Show(StringConstant.Error_NotFoundHDL);
                    return false;
                }

                // Compare fingerprint
                nRet = TesoWin32Helper.TcSafeMatch(objHdl, strReg, strVer, 3);
                match = nRet;
                if (nRet < 0)
                {
                    MessageBox.Show(StringConstant.Error_MatchFingerprint);
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                var res = TesoWin32Helper.TcDeleteHDL(objHdl);
            }
        }
        /// <summary>
        /// Get finger image
        /// </summary>
        /// <returns></returns>
        public bool GetFingerImage()
        {
            return this.GetFingerImageByIndex(3); // Default is the last image
        }
        /// <summary>
        /// Gets the image once.
        /// </summary>
        /// <returns></returns>
        public bool GetImageByPressOnce() 
        {
            try
            {
                // Get Hardware Handle
                objHdl = GetDevHDL();
                if (objHdl <= 0)
                {
                    MessageBox.Show(StringConstant.Error_NotFoundHDL);
                    return false;
                }

                // To get fingerprint by tow times  
                TesoWin32Helper.TcBeepLight(objHdl, 2);

                // Get single fingerprint
                nRet = TesoWin32Helper.TcDoFeature(objHdl, pVer);
                if (nRet >= 0)
                {
                    strVer = System.Text.Encoding.UTF8.GetString(pVer);
                }
                else
                {
                    MessageBox.Show(StringConstant.Error_VarifyFingerprint);
                    return false;
                }
                 
                // Get Image
                int imageIndex = 4;
                int imgLength = 0;
                byte[] imagebytes = new byte[1024 * 100];
                imgLength = TesoWin32Helper.TcGetImgDat(objHdl, imageIndex, imagebytes);
                if (imgLength < 0)
                {
                    MessageBox.Show(StringConstant.Error_FingerprintImage);
                    return false;
                }

                // Save Image First and delete temp image 
                TesoWin32Helper.TcSaveAsBmp(fingerPath, imagebytes);
                using (FileStream fs = new FileStream(fingerPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    curImg = new Bitmap(Bitmap.FromStream(fs));
                File.Delete(fingerPath);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                var res = TesoWin32Helper.TcDeleteHDL(objHdl);
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Gets the dev HDL.
        /// </summary>
        /// <returns></returns>
        private int GetDevHDL()
        {
            /*------创建COM设备控制句柄 USB(0,0,0,0) ------*/
            objHdl = TesoWin32Helper.TcCreateHDL(0, 0, 0, 0);
            return objHdl;
        }
        /// <summary>
        /// Get finger image by index
        /// </summary>
        /// <returns></returns>
        private bool GetFingerImageByIndex(int imageIndex)
        {
            try
            {
                // Get Hardware Handle
                objHdl = GetDevHDL();
                if (objHdl <= 0)
                {
                    MessageBox.Show(StringConstant.Error_NotFoundHDL);
                    return false;
                }

                // To get fingerprint by one times  
                TesoWin32Helper.TcBeepLight(objHdl, 0);
                var doFeature = TesoWin32Helper.TcDoTemplet(objHdl, pReg);
                if (doFeature < 0)
                {
                    MessageBox.Show(StringConstant.Error_FingerprintImage);
                    return false;
                }

                // Get Image
                int imgLength = 0;
                byte[] imagebytes = new byte[1024 * 100];
                imgLength = TesoWin32Helper.TcGetImgDat(objHdl, imageIndex, imagebytes);
                if (imgLength < 0)
                {
                    MessageBox.Show(StringConstant.Error_FingerprintImage);
                    return false;
                }

                // Save Image First and delete temp image 
                TesoWin32Helper.TcSaveAsBmp(fingerPath, imagebytes);
                using (FileStream fs = new FileStream(fingerPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    curImg = new Bitmap(Bitmap.FromStream(fs));
                File.Delete(fingerPath);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                var res = TesoWin32Helper.TcDeleteHDL(objHdl);
            }
        }
        #endregion

        #region IDisposable Implment
        private bool disposed = false;
        /// <summary>
        /// 实现IDisposable中的Dispose方法
        /// </summary>
        public void Dispose()
        {
            //必须为true
            Dispose(true);
            //通知垃圾回收机制不再调用终结器（析构器）
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 必须，以备程序员忘记了显式调用Dispose方法
        /// </summary>
        ~TesoDevMgmt()
        {
            //必须为false
            Dispose(false);
        }
        /// <summary>
        /// 非密封类修饰用protected virtual
        /// 密封类修饰用private
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                pReg = new byte[0];
                pVer = new byte[0];
                nRet = -1;
                strReg = string.Empty;
                strVer = string.Empty;
                match = -1;
                if (curImg != null)
                {
                    curImg.Dispose();
                    curImg = null;
                }
            }
            // 清理非托管资源
            //if (nativeResource != IntPtr.Zero)
            //{
            //    Marshal.FreeHGlobal(nativeResource);
            //    nativeResource = IntPtr.Zero;
            //}

            disposed = true;
        }
        #endregion

    }
}
