namespace AriStore.Models
{
    using SQLite;
    using System.Collections.Generic;

    [Table("Cliente")]
    public partial class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50), NotNull]
        public string Nombre { get; set; }
        [MaxLength(50), NotNull]
        public string Paterno { get; set; }
        [MaxLength(50)]
        public string Materno { get; set; }

    }
}
