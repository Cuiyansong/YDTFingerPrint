using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDT.WinForm.Common
{
    class StringConstant
    {
        internal static string Info_Retry = "请重试";

        internal static string Error_NotFoundHDL = string.Format("读取指纹仪设备失败，{0}！", Info_Retry);

        internal static string Error_RegisterTemplate = string.Format("获取指纹模板失败，{0}！", Info_Retry);

        internal static string Error_VarifyFingerprint = string.Format("采集验证指纹失败，{0}！", Info_Retry);

        internal static string Error_MatchFingerprint = string.Format("对比指纹失败，{0}！", Info_Retry);

        internal static string Error_FingerprintImage = string.Format("获取指纹图像失败，{0}！", Info_Retry);
    }
}
