namespace YDT.WinForm.Utlity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.Windows.Forms;

    public class TesoWin32Helper
    {
        #region DLL Import
        /// <summary>
        /// Tcs the create HDL. 
        /// </summary>
        /// <param name="nPort">The n port.</param>
        /// <param name="nProt">The n prot.</param>
        /// <param name="nRidx">The n ridx.</param>
        /// <param name="nSped">The n sped.</param>
        /// <returns></returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcCreateHDL(int nPort, int nProt, int nRidx, int nSped);
        /// <summary>
        /// Tcs the delete HDL.
        /// </summary>
        /// <param name="vHdl">The v HDL.</param>
        /// <returns></returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcDeleteHDL(int vHdl);
        /// <summary>
        /// Tcs the do templet.
        /// </summary>
        /// <param name="vHdl">The v HDL.</param>
        /// <param name="pReg">The p reg.</param>
        /// <returns></returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcDoTemplet(int vHdl, byte[] pReg);
        /// <summary>
        /// Tcs the do feature.
        /// </summary>
        /// <param name="vHdl">The v HDL.</param>
        /// <param name="hFea">The h fea.</param>
        /// <returns></returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcDoFeature(int vHdl, byte[] hFea);
        /// <summary>
        /// Tcs the safe match.
        /// </summary>
        /// <param name="vHdl">The v HDL.</param>
        /// <param name="hFea">The h fea.</param>
        /// <param name="hTpl">The h TPL.</param>
        /// <param name="nLvl">The n level.</param>
        /// <returns></returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcSafeMatch(int vHdl, String hFea, String hTpl, int nLvl);
        /// <summary>
        /// To Detect Device
        /// </summary>
        /// <param name="nBegin"></param>
        /// <param name="nEnd"></param>
        /// <param name="pszBPControl"></param>
        /// <returns></returns>
        [DllImport("TesoLive.dll")]
        public static extern int FPIDevDetect(int nBegin, int nEnd, int pszBPControl);
        /// <summary>
        /// Sound of Beep
        /// </summary>
        /// <param name="vHdl"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcBeepLight(int vHdl, int nMode);
        /// <summary>
        /// Tcs the get img dat.
        /// </summary>
        /// <param name="vHdl">The v HDL.</param>
        /// <param name="nIdx">Index of the n.</param>
        /// <param name="hFpr">The h FPR.</param>
        /// <returns></returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcGetImgDat(int vHdl, int nIdx, byte[] hFpr);
        /// <summary>
        /// Tcs the show image.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hFpr">The h FPR.</param>
        /// <returns></returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcShowImage(int hWnd, byte[] hFpr);
        /// <summary>
        /// Tcs the save as BMP.
        /// </summary>
        /// <param name="chFile">/* chFile		要保存的目标BMP文件，已存在则覆盖			*/</param>
        /// <param name="hFpr">/* hFpr			由TcGetImgDat获取的，将要保存的图像区首指针	*/</param>
        /// <returns>/* 返回值		大于等于0为成功保存的BMP文件字节大小，小于0失败		*/</returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcSaveAsBmp(String chFile, byte[] hFpr);
        /// <summary>
        /// Tcs the load fr BMP.
        /// </summary>
        /// <param name="chFile">/* chFile		要读取的来源BMP文件，须已存在且格式有效		*/</param>
        /// <param name="hFpr">/* hFpr			要写入的目标内存缓存区首指针					*/</param>
        /// <param name="nStyle">/* nStyle		B1＝0为BMP，B1＝1为FPR；B0＝0为B64，B0＝1为BIN	*/</param>
        /// <returns>/* 返回值		>=0为成功写入目标区的实际字节长度，小于0失败*/</returns>
        [DllImport("TesoLive.dll")]
        public static extern int TcLoadFrBmp(String chFile, byte[] hFpr, int nStyle);
        #endregion

    }
}
