using System;

namespace AriStore.Helpers
{
    public class Converter
    {
        /// <summary>
        /// Convierto un valor de tipo string en Booleano
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool StringToBool(string value)
        {
            value = string.IsNullOrEmpty(value)?"False":value;
            return Convert.ToBoolean(value);
        }
    }
}
