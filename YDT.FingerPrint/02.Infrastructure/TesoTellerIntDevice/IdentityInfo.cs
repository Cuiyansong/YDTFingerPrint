
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesoTellerIntDevice
{
    public   struct  IdentityInfo

    {
        //姓名
        public string Name;
        //性别
        public string Sex;
        //民族
        public string Nation;
        //生日
        public string Birthday;
        //地址
        public string Address;
        //身份证号
        public string ID;
        //发证机关
        public string Department;
        //起始日期
        public string StartDate;
        // 终止日期
        public string EndDate;
        // 预留信息
        public string Reserve;
        //预留地址
        public string AppAddress1;
        // 照片信息，Base64存储为字符串，jpg格式
        public string PhotoData;

    }
}




