using System.ComponentModel;
using OCLSA_Project_Version_01.DataAccess.MainForm;

namespace OCLSA_Project_Version_01.Common
{
    public class EnumStringFormatter
    {
        public static string ToDescriptionString(RejectionCriteria value)
        {
            var attributes = (DescriptionAttribute[])value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}