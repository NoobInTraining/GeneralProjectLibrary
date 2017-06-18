using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeneralProjectLibrary
{
    static class MathFunctions
    {
        /// <summary>
        /// Tries to pass an input string to an integer value using regex. Returns 0 if the resulting Regex is an empty string.
        /// </summary>
        /// <param name="value">The string to be converted</param>
        /// <returns>The integer value of the input</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="OverflowException">If the input value is over the size of an integer.</exception>
        static public int StringToInt(string value)
        {
            //check if null
            if (value == null)
                throw new ArgumentNullException("The input value is not allowed to be null-");

            try
            {
                return int.Parse(value);
            }
            catch (FormatException)
            {
                //replace all non-numbers and check if it's an empty string
                var number = Regex.Replace(value, "\\D+", "");
                return int.Parse((number == "")? "0":number);
            }
        }
    }
}
