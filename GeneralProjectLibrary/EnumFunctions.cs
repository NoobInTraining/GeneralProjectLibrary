using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralProjectLibrary
{
    /// <summary>
    /// Functions concerning Enum Operations
    /// </summary>
    public static class EnumFunctions<T>
    {
        /// <summary>
        /// Method that Uses the Paramater T to get all the Names of the Enum values
        /// </summary>
        /// <returns></returns>
        public static string[] GetEnumStrings()
        {
            return Enum.GetNames(typeof(T));
        }

        /// <summary>
        /// Returens all the Enum Values of the Enum Passed.
        /// You can thereafter itterate through them all.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }




        #region Dev Area
        private static void ItterateThorughEnumValues()
        {

        }

        /// <summary>
        /// **Untested**
        /// Itterates thourgh all Enums of specivied enum actions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void ItterateThorughEnumValues(Action<T> action)
        {

        }
        #endregion
    }

}
