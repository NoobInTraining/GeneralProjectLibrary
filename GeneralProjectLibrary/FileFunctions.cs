using System.IO;
using System.Text;

namespace GeneralProjectLibrary
{
    /// <summary>
    /// Function concerning File Operations
    /// </summary>
    public static class FileFunctions
    {
        /// <summary>
        /// -------------------------------------
        /// Taken from a Stack Overflow Answer : http://stackoverflow.com/a/19283954/5757162
        /// -------------------------------------
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// 
        /// Not all error that might be thrown are documented here
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        /// <exception cref="FileNotFoundException">If the specified can't be found.</exception>"
        public static Encoding GetEncoding(string filename)
        {
            //added by me
            if (!File.Exists(filename))
                throw new FileNotFoundException();

            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.Default;
        }
    }
}
