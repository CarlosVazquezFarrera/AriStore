namespace AriStore.Models
{
    using SQLite;
    using System;

    [Table("Detalle")]
    public partial class Detalle
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int IdTipo { get; set; }
        [NotNull]
        public int IdAdeudo { get; set; }
        [NotNull]
        public float Monto { get; set; }
        [NotNull]
        public string Fecha { get; set; }

    }

}
