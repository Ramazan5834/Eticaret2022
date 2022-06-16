namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UstKategori")]
    public partial class UstKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UstKategori()
        {
            AltKategori = new HashSet<AltKategori>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Adi { get; set; }

        [Required]
        [StringLength(500)]
        public string Tanimi { get; set; }

        public bool AktifDurum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AltKategori> AltKategori { get; set; }
    }
}
