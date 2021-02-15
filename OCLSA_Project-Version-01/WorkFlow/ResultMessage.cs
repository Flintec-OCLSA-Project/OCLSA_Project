using System.Windows.Forms;

namespace OCLSA_Project_Version_01.WorkFlow
{
    public class ResultMessage
    {
        public static DialogResult Result(string message, string title)
        {
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show(message, title, buttons);
            return result;
        }
    }
}