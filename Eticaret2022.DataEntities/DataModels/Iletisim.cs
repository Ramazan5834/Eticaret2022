namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Iletisim")]
    public partial class Iletisim
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string AdSoyad { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Konu { get; set; }

        [Required]
        public string MesajIcerik { get; set; }

        public bool Okundu { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}
