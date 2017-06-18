using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace GeneralProjectLibrary.Logs
{
    /// <summary>
    /// Class that can be used to create
    /// an individual log.
    /// Care: This class does no exception handling, all is left to the user.
    /// </summary>
    public class Log : IDisposable
    {
        protected string sFile;

        /// <summary>
        /// Initilize a Log with the name or Path ending with name
        /// </summary>
        /// <param name="nameORpath">
        /// Name of the log file e.g. serverlog.txt
        /// can alsp be the path
        /// e.g. c:programms\goodprogramm\serverlog.txt
        /// </param>
        public Log(string nameORpath)
        {
            this.sFile = nameORpath;
        }

        /// <summary>
        /// Konstroktur that creates the directory if neccesary (...\subfolder)
        /// And create the textfile Log at that specified area.
        /// </summary>
        /// <param name="name">The name + ending of the file</param>
        /// <param name="subFolder">The Subfolder in which it shall be (starting from where the .exe of this Programm lies)
        /// --> eg. awesomeProgramm\logs\serverLog. </param>
        public Log(string name, string subFolder)
        {
            //replace the \ at the end of subfolder
            while ((subFolder.EndsWith(@"\")))
                subFolder = subFolder.Substring(0, subFolder.Length - 1);

            //check if the subfolder starts with a \, if so repcle them all
            while ((subFolder.StartsWith(@"\")))
                subFolder = subFolder.Remove(0, 1);

            //check if directory exists, if it doesnt then create it
            subFolder = AppDomain.CurrentDomain.BaseDirectory + subFolder;
            if (!Directory.Exists(subFolder))
                Directory.CreateDirectory(subFolder);

            //now set the streamwriter
            this.sFile = subFolder + @"\" + name;
        }


        /// <summary>
        /// Funktion to write the log
        /// Works like this: msg = Hello \r\n World\r\nYeahy!
        ///                     \r\n in code is represented by Environmen.Newline
        /// DATE TIME: Hello
        ///            World
        ///            Yeahy!
        /// ~6 Tab stops~
        /// This of course only works on specific fonts.
        /// </summary>
        /// <param name="msg">The message to be written</param>
        public virtual void writeLog(string msg)
        {
            //set the streamwriter
            using (StreamWriter swLog = new StreamWriter(sFile, true))
            {
                //split the msg by the newline (windows)
                string[] aMsg = Regex.Split(msg, Environment.NewLine);

                //get the date
                string sDate = DateTime.Now.ToString() + ":\t";

                //add the date to firstline
                aMsg[0] = sDate + aMsg[0];

                //and bad the rest by the date
                for (int i = 1; i < aMsg.Length; i++)
                    aMsg[i] = "\t\t\t\t\t\t" + aMsg[i];

                //now write the the message back again
                foreach (string s in aMsg)
                    swLog.WriteLine(s);

                //finally close and flush the log
                swLog.Flush();
                swLog.Close();
            }
        }

        /// <summary>
        /// Funktion to write the log
        /// Works like this: msg = Hello \r\n World\r\nYeahy!
        ///                     \r\n in code is represented by Environmen.Newline
        /// DATE TIME: Hello
        ///            World
        ///            Yeahy!
        /// ~6 Tab stops~
        /// This of course only works on specific fonts.
        /// </summary>
        /// <param name="msg">The message to be written</param>
        /// <param name="coding">Using specific encoding</param>
        public virtual void writeLog(string msg, Encoding coding)
        {
            //set the streamwriter
            using (StreamWriter swLog = new StreamWriter(sFile, true, coding))
            {
                //split the msg by the newline (windows)
                string[] aMsg = Regex.Split(msg, Environment.NewLine);

                //get the date
                string sDate = DateTime.Now.ToString() + ":\t";

                //add the date to firstline
                aMsg[0] = sDate + aMsg[0];

                //and bad the rest by the date
                for (int i = 1; i < aMsg.Length; i++)
                    aMsg[i] = "\t\t\t\t\t\t" + aMsg[i];

                //now write the the message back again
                foreach (string s in aMsg)
                    swLog.WriteLine(s);

                //finally close and flush the log
                swLog.Flush();
                swLog.Close();
            }
        }

        /// <summary>
        /// Method that tires to delete the log that was creted
        /// More specific, it deletes the to which it would be writing to
        /// </summary>
        public void deleteLog()
        {
            File.Delete(sFile);
        }




        //Funktions for the iDispoabel Interface

        private IntPtr nativeResource = Marshal.AllocHGlobal(100);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources

                /*
                 *basically, itterate through all of our things to check if they are disposed yet and se evrything to 0
                if (managedResource != null)
                {
                    managedResource.Dispose();
                    managedResource = null;
                }
                */
                sFile = null;

                // free native resources if there are any.
                if (nativeResource != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(nativeResource);
                    nativeResource = IntPtr.Zero;
                }
            }
        }
    }
}
