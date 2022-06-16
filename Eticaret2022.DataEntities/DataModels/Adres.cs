namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adres
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adres()
        {
            SatisDetay = new HashSet<SatisDetay>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(50)]
        public string Sehir { get; set; }

        [Required]
        [StringLength(50)]
        public string Ilce { get; set; }

        public int PostaKodu { get; set; }

        [Required]
        [StringLength(500)]
        public string AcikAdres { get; set; }

        [Required]
        [StringLength(128)]
        public string MusteriId { get; set; }

        public bool AktifDurum { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisDetay> SatisDetay { get; set; }
    }
}
