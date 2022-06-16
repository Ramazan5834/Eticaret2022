namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SistemHata")]
    public partial class SistemHata
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Veri { get; set; }

        public long Kod { get; set; }

        [Required]
        [StringLength(1000)]
        public string Mesaj { get; set; }

        [Required]
        [StringLength(1000)]
        public string Kaynak { get; set; }

        [Required]
        public string YiginIzi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}
