using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TesoTellerIntDevice
{
    internal class FingerReaderDllWrapper
    {
        //蜂鸣器
        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcSubDev(int nComm, int byWho, int byTim);
        //打开句柄
        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcOpenComm(int nPort, int nRate, int nFmt, int hDadWnd);
        //关闭句柄
        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcCloseComm(int hComm);
        //返回图像信息
        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcLoadrToPimg(int hComm, int nStyle, byte[] pImage, ref int pdwLen);
        //返回指纹特征
        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcMinutFrPimg(int hComm, int nIndex,int nRetrn,byte[] pMinut, ref int pdwLen);
        // 指纹对比
        [DllImport("TesoLive.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcSafeMatch(int vHdl, String hFea, String hTpl, int nLvl);

        //图像优化
        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcSmotImg(byte[] pImg, int nWd, int nHi);

        /* 保存的图像的点阵数据为BMP文件(可以存贮非4的整数倍的宽度)  
STD_API(LONG) SaveTotalImage(LPCTSTR chFile,		// 欲存文件名
				const BYTE *pbyImage,				// 图像区指针
				LONG nWide, LONG nHigh);			// 图像区宽高
 
 */
        /* 加载二进制文件，先给定缓存的长度，并返回实际使用长度 
STD_API(LONG) LoadBinaryFile(LPCTSTR chFile, BYTE *pbyBinary,
							LONG nLength);
          */
        //图像优化
        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int SaveTotalImage(String chFile, byte[] pImg, int nWd, int nHi);
        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int LoadBinaryFile(String chFile, byte[] pImg, int nLength);



        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool TcIsCommBusy(int hComm);

        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ReadComm(int hPort, byte[] pBuff, UInt32 dwLen, bool bSplit);

        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritComm(int hPort, byte[] pBuff, UInt32 dwLen, bool bSplit);

        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcGhPort(int hComm);

        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcSuperRegist(int hComm, int nStyle, int nReturn, byte[] pbyBuff,ref int pdwLen);

        [DllImport("Tcsy2008.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int TcVeriMatch(int hComm, int nStyle, byte[] pbyBuff, ref UInt32 pdwLen);

    }

  /* ORD_VERI：按捺一次，在设备内一对多搜索，可选是否要特征 */
//STD_API(LONG) TcVeriMatch(LONG hComm, LONG nStyle, BYTE *pbyBuff,	 DWORD *pdwLen);

    /* 获取内部句柄中所包含的真正的口句柄hPort，用于扩展访问 */
//STD_API(HANDLE) TcGhPort(LONG hComm);


/* ORD_REGT：强化的注册指纹模板接口，可返回模板，图像缩小传出 */
//STD_API(LONG) TcSuperRegist(LONG hComm, LONG nStyle, LONG nRetun,  BYTE *pbyBuff, DWORD *pdwLen);

        /* 更新串口通讯的超时设置，目的：等待操作完成，直至超时 */
//STD_API(BOOL) UpdateCommTimeOut(HANDLE hPort, DWORD dwTmOt);

/* 从串口以阻塞方式读取指定数量的二进制数据，可选拆分方式 */
//STD_API(BOOL) ReadComm(HANDLE hPort, void *pBuff, DWORD dwLen, BOOL bSplit = 0);

/* 将指定数量的二进制数据写入串口，阻塞方式，可选拆分方式 */
//STD_API(BOOL) WritComm(HANDLE hPort, const void *pBuff, DWORD dwLen, BOOL bSplit = 0);

    
/*=///////////////////////////////////////////////////////////////////////=*/
/*= 驱动支持库LIB，对外接口声明，hComm可支持同时打开多个串口              =*/
/*=///////////////////////////////////////////////////////////////////////=*/

/* 获取本DLL模块的软件版本号，检查更新使用 */
//STD_API(void) TcGetVersion(BYTE *pbyHiv, BYTE *pbyLov);

/*===============================================================*/

/* 打开通讯，按指定的串口，和速率，返回关联句柄 */
//STD_API(LONG) TcOpenComm(LONG nComm, LONG nRate, LONG nFmt, HWND hDadWnd);

/* 关闭指定句柄所关联的通讯，释放所用资源 */
//STD_API(LONG) TcCloseComm(LONG hComm);

/* 判断串口通讯是否正在进行中... */
//STD_API(BOOL) TcIsCommBusy(LONG hComm);
}
