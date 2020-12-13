namespace AriStore.Models
{
    using SQLite;
    using System;

    [Table("Cliente")]
    public partial class Cliente
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        [MaxLength(50), NotNull]
        public string Nombre { get; set; }
        [MaxLength(50), NotNull]
        public string Paterno { get; set; }
        [MaxLength(50)]
        public string Materno { get; set; }

    }
}
