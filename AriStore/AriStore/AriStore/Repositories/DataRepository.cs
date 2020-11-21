namespace AriStore.Repositories
{
    using AriStore.Enumeration;
    using AriStore.Helpers;
    using AriStore.Models;
    using SQLite;
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
                conn.CreateTablesAsync<Cliente, Tipo, Adeudo, Detalle>();
                CacheHelper.SetValue(CacheEnumerations.DataBaseCreate, "True");
            }
        } 
        #endregion

    }
}
