using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace GeneralProjectLibrary.Logs
{
    /// <summary>
    /// Method to create a Log, that writes to the serverlog.txt file
    /// Care: This class does no exception handling, all is left to the user.
    /// </summary>
    public class ServerLog : Log
    {
        /// <summary>
        /// Creates an serverlog.txt file where programms .exe file is
        /// </summary>
        public ServerLog() : base("serverlog.txt")
        {

        }

        /// <summary>
        /// Creates the serverlog.txt at the designated folder directy.
        /// If the folder parameter is missing  the \ at the end, my programm inserts it
        /// </summary>
        /// <param name="folder">the folder where the serverlog.txt shall be placed</param>
        public ServerLog(string folder) : base(((folder.EndsWith(@"\")) ? folder : (folder + @"\") + "serverlog.txt"))
        {                                       //basically checks if it ennds with a backsloah, if not it adds the backslash

        }
    }
}