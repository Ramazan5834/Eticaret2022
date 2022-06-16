namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AltKategori")]
    public partial class AltKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AltKategori()
        {
            Urun = new HashSet<Urun>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Adi { get; set; }

        [Required]
        [StringLength(300)]
        public string Tanimi { get; set; }

        [StringLength(300)]
        public string ResimPath { get; set; }

        public int UstKategoriId { get; set; }

        public bool AktifDurum { get; set; }

        public virtual UstKategori UstKategori { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun> Urun { get; set; }
    }
}
