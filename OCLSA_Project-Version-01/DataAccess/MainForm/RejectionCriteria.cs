using System.ComponentModel;

namespace OCLSA_Project_Version_01.DataAccess.MainForm
{
    public enum RejectionCriteria
    {
        [Description("High Balance")]
        HighBalance,

        [Description("High FSO")]
        HighFso,

        [Description("Low FSO")]
        LowFso,

        [Description("Excessive Corners")]
        ExcessiveCorners,

        [Description("Unstable")]
        Unstable,

        [Description("High Zero")]
        HighZero,

        [Description("No Complete")]
        NoComplete,

        [Description("No")]
        No
    }
}