namespace AriStore.Models
{
    using SQLite;
    using System.Collections.Generic;
    [Table("Tipo")]
    public partial class Tipo
    {
        [PrimaryKey, NotNull, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(10), NotNull]
        public string Nombre { get; set; }
    }
}
