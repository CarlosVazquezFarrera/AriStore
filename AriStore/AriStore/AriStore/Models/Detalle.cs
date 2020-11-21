namespace AriStore.Models
{
    using SQLite;

    [Table("Detalle")]
    public partial class Detalle
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        [NotNull]
        public int IdTipo { get; set; }
        [NotNull]
        public int IdAdeudo { get; set; }
        [NotNull]
        public decimal Monto { get; set; }

    }

}
