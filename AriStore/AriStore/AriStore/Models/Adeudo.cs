namespace AriStore.Models
{
    using SQLite;
    using System.Collections.Generic;

    [Table("Adeudo")]
    public partial class Adeudo
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int IdCliente { get; set; }
        [NotNull]
        public decimal Total { get; set; }
    }
}
