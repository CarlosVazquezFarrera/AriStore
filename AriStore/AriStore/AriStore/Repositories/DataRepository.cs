namespace AriStore.Repositories
{
    using AriStore.Enumeration;
    using AriStore.Helpers;
    using AriStore.Models;
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DataRepository
    {
        SQLiteAsyncConnection conn;

        #region Constrcutor
        public DataRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            var isDataBaseCreated = CacheHelper.GetValue(CacheEnumerations.DataBaseCreate).GetAwaiter().GetResult();
            if (!Converter.StringToBool(isDataBaseCreated))
            {
                conn.CreateTablesAsync<Cliente, Tipo, Adeudo, Detalle>().Wait();
                CacheHelper.SetValue(CacheEnumerations.DataBaseCreate, "True");
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Ejecuta un Query, el cual debe ser escrito manualmente y enviado como un parametro String
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryAsync<T>(string query, params object[] parameters) where T : new() 
        {
            try
            {
                return await conn.QueryAsync<T>(query, parameters);
            }
            catch (Exception)
            {

                return new List<T>();
            }
        }

        /// <summary>
        /// Inserta un objeto en la tabla especificada
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Número 1 o 2</returns>
        public async Task<int> Insertar<T>(T enttidad)
        {
            try
            {
                return await conn.InsertAsync(enttidad);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Actualiza una entidad especificada
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public async Task<int> Actualizar<T>(T entidad)
        {
            try
            {
                return await conn.UpdateAsync(entidad);
            }
            catch (Exception)
            {

                return 0;
            }
        }

        /// <summary>
        /// Elimina una entidad de una table específica 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public async Task<int> Borrar<T>(T entidad)
        {
            try
            {
                return await conn.DeleteAsync(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene un listado entero de la tabla especificada
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<List<T>> ObtenerTodo<T>() where T : new()
        {
            try
            {
                return await conn.Table<T>().ToListAsync();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }
        #endregion
    }
}
