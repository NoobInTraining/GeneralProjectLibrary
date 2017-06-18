using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeneralProjectLibrary.Logs
{
    /// <summary>
    /// Class that represents an errorlog.txt for easy 
    /// writing of said log
    /// If the log exists, it will just add your line to the [bla]
    /// Care: This class does no exception handling, all is left to the user.
    /// </summary>
    public class ErrorLog : Log
    {
        /// <summary>
        /// Creates an errorlog.txt file where programms .exe file is
        /// </summary>
        public ErrorLog() : base("errorlog.txt")
        {

        }

        /// <summary>
        /// Creates the erorlog.txt at the designated folder directy.
        /// If the folder parameter is missing  the \ at the end, my programm inserts it
        /// </summary>
        /// <param name="folder">the folder where the eerorlog.txt shall be placed</param>
        public ErrorLog(string folder) : base(((folder.EndsWith(@"\")) ? folder : (folder + @"\") + "errorlog.txt"))
        {                                       //basically checks if it ennds with a backsloah, if not it adds the backslash

        }

        /// <summary>
        /// Funktion to write the log
        /// Works like this: Log.WriteLog()
        /// but adds the compilerMsg and Stacktrace
        /// </summary>
        /// <param name="msg">The message to be written</param>
        /// <param name="compilerMsg">The default message that the error passes </param>
        /// <param name="stacktrace">The default stacktrace that the error passes</param>
        /// <param name="coding">Using specific encoding</param>
        public void writeLog(string msg, string compilerMsg, string stacktrace)
        {
            //set the streamwriter
            using (StreamWriter swLog = new StreamWriter(sFile, true))
            {
                //split the msg by the newline (windows)
                string[] aMsg = Regex.Split(msg, Environment.NewLine);
                string[] aCompMsg = Regex.Split(compilerMsg, Environment.NewLine);
                string[] aStacktrace = Regex.Split(stacktrace, Environment.NewLine);

                //get the date
                string sDate = DateTime.Now.ToString() + ":\t";

                //add the date to firstline
                aMsg[0] = sDate + aMsg[0];

                //and bad the rest by the date
                for (int i = 1; i < aMsg.Length; i++)
                    aMsg[i] = "\t\t\t\t\t\t" + aMsg[i];
                for (int i = 0; i < aCompMsg.Length; i++)
                    aCompMsg[i] = "\t\t\t\t\t\t" + aCompMsg[i];
                for (int i = 0; i < aStacktrace.Length; i++)
                    aStacktrace[i] = "\t\t\t\t\t\t" + aStacktrace[i];

                //now write the the message back again
                foreach (string s in aMsg)
                    swLog.WriteLine(s);
                foreach (string s in aCompMsg)
                    swLog.WriteLine(s);
                foreach (string s in aStacktrace)
                    swLog.WriteLine(s);

                //close and flush the log
                swLog.Flush();
                swLog.Close();

                //drop the arrasy-references again
                aMsg = null;
                aCompMsg = null;
                aStacktrace = null;
            }
        }

        /// <summary>
        /// Funktion to write the log
        /// Works like this: Log.WriteLog()
        /// but adds the compilerMsg and Stacktrace
        /// </summary>
        /// <param name="msg">The message to be written</param>
        /// <param name="compilerMsg">The default message that the error passes </param>
        /// <param name="stacktrace">The default stacktrace that the error passes</param>
        /// <param name="coding">Using specific encoding</param>
        public void writeLog(string msg, string compilerMsg, string stacktrace, Encoding coding)
        {
            //set the streamwriter
            using (StreamWriter swLog = new StreamWriter(sFile, true, coding))
            {
                //split the msg by the newline (windows)
                string[] aMsg = Regex.Split(msg, Environment.NewLine);
                string[] aCompMsg = Regex.Split(compilerMsg, Environment.NewLine);
                string[] aStacktrace = Regex.Split(stacktrace, Environment.NewLine);

                //get the date
                string sDate = DateTime.Now.ToString() + ":\t";

                //add the date to firstline
                aMsg[0] = sDate + aMsg[0];

                //and bad the rest by the date
                for (int i = 1; i < aMsg.Length; i++)
                    aMsg[i] = "\t\t\t\t\t\t" + aMsg[i];
                for (int i = 0; i < aCompMsg.Length; i++)
                    aCompMsg[i] = "\t\t\t\t\t\t" + aCompMsg[i];
                for (int i = 0; i < aStacktrace.Length; i++)
                    aStacktrace[i] = "\t\t\t\t\t\t" + aStacktrace[i];

                //now write the the message back again
                foreach (string s in aMsg)
                    swLog.WriteLine(s);
                foreach (string s in aCompMsg)
                    swLog.WriteLine(s);
                foreach (string s in aStacktrace)
                    swLog.WriteLine(s);

                //close and flush the log
                swLog.Flush();
                swLog.Close();

                //drop the arrasy-references again
                aMsg = null;
                aCompMsg = null;
                aStacktrace = null;
            }
        }
    }
}
