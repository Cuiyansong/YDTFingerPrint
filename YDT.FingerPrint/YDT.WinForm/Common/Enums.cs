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
        [FingerDescription(RangeAttachData.Text, "左手-拇指")]
        LeftThumb = 0,

        [FingerDescription(RangeAttachData.Text, "左手-食指")]
        LeftForeFinger = 1,

        [FingerDescription(RangeAttachData.Text, "左手-中指")]
        LeftMiddleFinger = 2,

        [FingerDescription(RangeAttachData.Text, "左手-无名指")]
        LeftRingFinger = 3,

        [FingerDescription(RangeAttachData.Text, "左手-小指")]
        LeftLittleFinger = 4,


        [FingerDescription(RangeAttachData.Text, "右手-拇指")]
        RightThumb = 5,

        [FingerDescription(RangeAttachData.Text, "右手-食指")]
        RightForeFinger = 6,

        [FingerDescription(RangeAttachData.Text, "右手-中指")]
        RightMiddleFinger = 7,

        [FingerDescription(RangeAttachData.Text, "右手-无名指")]
        RightRingFinger = 8,

        [FingerDescription(RangeAttachData.Text, "右手-小指")]
        RightLittleFinger = 9,
    }

}
