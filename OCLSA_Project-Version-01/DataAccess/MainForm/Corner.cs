namespace OCLSA_Project_Version_01.DataAccess.MainForm
{
    public class Corner
    {
        public double LeftCorner { get; set; }
        public double BackCorner { get; set; }
        public double RightCorner { get; set; }
        public double FrontCorner { get; set; }
        public double Center { get; set; }
        public string TrimTime { get; set; }

        public Corner(double leftCorner, double backCorner, double rightCorner, double frontCorner, double center, string trimTime)
        {
            LeftCorner = leftCorner;
            BackCorner = backCorner;
            RightCorner = rightCorner;
            FrontCorner = frontCorner;
            Center = center;
            TrimTime = trimTime;
        }
    }
}