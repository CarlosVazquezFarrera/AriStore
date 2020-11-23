namespace AriStore.Models
{
    using SQLite;
    using System;

    [Table("Adeudo")]
    public partial class Adeudo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public Guid IdCliente { get; set; }
        [NotNull]
        public float Total { get; set; }
        [NotNull]
        public DateTime Fecha { get; set; }
    }
}
