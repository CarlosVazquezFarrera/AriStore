namespace AriStore.Helpers
{
    using AriStore.Enumeration;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    public class CacheHelper
    {
        /// <summary>
        /// Define el valor de un dato que se desea almacenar en la memoria del teléfono
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public async static void SetValue(CacheEnumerations key, string value)
        {
            switch (key)
            {
                case CacheEnumerations.DataBaseCreate:
                    await SecureStorage.SetAsync(key.ToString(), value);
                    break;
            }

        }

        /// <summary>
        /// Obtene el valor de un dato en concreto que se encuenta almacenado dentro de la memmoria del telefono
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async static Task<string> GetValue(CacheEnumerations key)
        {
            string value = string.Empty;
            try
            {
                switch (key)
                {
                    case CacheEnumerations.DataBaseCreate:
                        value = await SecureStorage.GetAsync(key.ToString());
                    break;
                }
            }
            catch (System.Exception)
            {

            }

            return value;
        }
        
    }
}
