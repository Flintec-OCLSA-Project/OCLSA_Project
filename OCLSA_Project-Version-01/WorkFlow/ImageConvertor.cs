using System.Drawing;
using System.IO;

namespace OCLSA_Project_Version_01.WorkFlow
{
    public class ImageConvertor
    {
        public ImageConvertor()
        {
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var stream = new MemoryStream(byteArrayIn))
            {
                var returnImage = Image.FromStream(stream, false, true);

                return returnImage;
            }
        }
    }
}