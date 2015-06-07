using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDTTeleComLib
{
    public class Uitl
    {
        /// <summary>
        /// Number to the nation.
        /// </summary>
        /// <param name="nation">The nation.</param>
        /// <returns></returns>
        public static string ToNation(string nation)
        {
            var nationStr = "";

            switch (nation)
            {
                case "01": nationStr = "汉族"; break;
                case "02": nationStr = "蒙古族"; break;
                case "03": nationStr = "回族"; break;
                case "04": nationStr = "藏族"; break;
                case "05": nationStr = "维吾尔族"; break;
                case "06": nationStr = "苗族"; break;
                case "07": nationStr = "彝族"; break;
                case "08": nationStr = "壮族"; break;
                case "09": nationStr = "布依族"; break;

                case "10": nationStr = "朝鲜族"; break;
                case "11": nationStr = "满族"; break;
                case "12": nationStr = "侗族"; break;
                case "13": nationStr = "瑶族"; break;
                case "14": nationStr = "白族"; break;
                case "15": nationStr = "土家族"; break;
                case "16": nationStr = "哈尼族"; break;
                case "17": nationStr = "哈萨克族"; break;
                case "18": nationStr = "傣族"; break;
                case "19": nationStr = "黎族"; break;

                case "20": nationStr = "傈僳族"; break;
                case "21": nationStr = "佤族"; break;
                case "22": nationStr = "畲族"; break;
                case "23": nationStr = "高山族"; break;
                case "24": nationStr = "拉祜族"; break;
                case "25": nationStr = "水族"; break;
                case "26": nationStr = "东乡族"; break;
                case "27": nationStr = "纳西族"; break;
                case "28": nationStr = "景颇族"; break;
                case "29": nationStr = "柯尔克孜族"; break;

                case "30": nationStr = "土族"; break;
                case "31": nationStr = "达斡尔族"; break;
                case "32": nationStr = "仫佬族"; break;
                case "33": nationStr = "羌族"; break;
                case "34": nationStr = "布朗族"; break;
                case "35": nationStr = "撒拉族"; break;
                case "36": nationStr = "毛南族"; break;
                case "37": nationStr = "仡佬族"; break;
                case "38": nationStr = "锡伯族"; break;
                case "39": nationStr = "阿昌族"; break;

                case "40": nationStr = "普米族"; break;
                case "41": nationStr = "塔吉克族"; break;
                case "42": nationStr = "怒族"; break;
                case "43": nationStr = "乌孜别克族 "; break;
                case "44": nationStr = "俄罗斯族"; break;
                case "45": nationStr = "鄂温克族"; break;
                case "46": nationStr = "德昂族"; break;
                case "47": nationStr = "保安族"; break;
                case "48": nationStr = "裕固族"; break;
                case "49": nationStr = "京族"; break;

                case "50": nationStr = "塔塔尔族"; break;
                case "51": nationStr = "独龙族"; break;
                case "52": nationStr = "鄂伦春族"; break;
                case "53": nationStr = "赫哲族 "; break;
                case "54": nationStr = "门巴族"; break;
                case "55": nationStr = "珞巴族"; break;
                case "56": nationStr = "基诺族"; break;
                case "57": nationStr = "其他"; break;
                case "58": nationStr = "外国血统"; break;

                default: nationStr = "其他"; break;
            }

            return nationStr;
        }

        /// <summary>
        /// To the sex.
        /// </summary>
        /// <param name="sex">The sex.</param>
        /// <returns></returns>
        public static string ToSex(string sex)
        {
            var sexStr = "";
            try
            {
                int sexNum = int.Parse(sex);
                if (sexNum % 2 > 0)
                    sexStr = "男";
                else
                    sexStr = "女";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sexStr;
        }

        /// <summary>
        /// To the age.
        /// </summary>
        /// <param name="age">The age.</param>
        /// <returns></returns>
        public static string ToAge(string age) 
        {
            DateTime birth = new DateTime();

            // DateTime.Now
            return "";
        }
    }
}
