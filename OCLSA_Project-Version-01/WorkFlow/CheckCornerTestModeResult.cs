using OCLSA_Project_Version_01.Models;

namespace OCLSA_Project_Version_01.WorkFlow
{
    public class CheckCornerTestModeResult
    {
        public LoadCell LoadCell { get; set; }
        public string TestModeInDb { get; set; }
        public bool IsLoadCellNotAvailable { get; set; }
    }
}