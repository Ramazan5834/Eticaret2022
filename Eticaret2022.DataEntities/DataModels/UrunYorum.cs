namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UrunYorum")]
    public partial class UrunYorum
    {
        public int Id { get; set; }

        [Required]
        [StringLength(800)]
        public string Icerik { get; set; }

        public int UrunId { get; set; }

        public bool OnayDurum { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
