using System.Linq;

namespace OCLSA_Project_Version_01.WorkFlow
{
    public class SpaceRemover
    {
        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}