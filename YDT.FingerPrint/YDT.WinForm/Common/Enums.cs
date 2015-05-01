using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDT.WinForm.Common
{
    /// <summary>
    /// RangeAttachData Enum
    /// </summary>
    public enum RangeAttachData
    {
        Text,
        Image,
        ID,
    }

    /// <summary>
    /// Finger Enum
    /// </summary>
    public enum Finger : int
    {
        [FingerDescription(RangeAttachData.Text, "未知手指")]
        UnknownThumb = 0,

        [FingerDescription(RangeAttachData.Text, "左手-拇指")]
        LeftThumb = 1,

        [FingerDescription(RangeAttachData.Text, "左手-食指")]
        LeftForeFinger = 2,

        [FingerDescription(RangeAttachData.Text, "左手-中指")]
        LeftMiddleFinger = 3,

        [FingerDescription(RangeAttachData.Text, "左手-无名指")]
        LeftRingFinger = 4,

        [FingerDescription(RangeAttachData.Text, "左手-小指")]
        LeftLittleFinger = 5,


        [FingerDescription(RangeAttachData.Text, "右手-拇指")]
        RightThumb =6,

        [FingerDescription(RangeAttachData.Text, "右手-食指")]
        RightForeFinger = 7,

        [FingerDescription(RangeAttachData.Text, "右手-中指")]
        RightMiddleFinger = 8,

        [FingerDescription(RangeAttachData.Text, "右手-无名指")]
        RightRingFinger = 9,

        [FingerDescription(RangeAttachData.Text, "右手-小指")]
        RightLittleFinger = 10,
    }

}
