namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            SatilanUrun = new HashSet<SatilanUrun>();
            UrunYorum = new HashSet<UrunYorum>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Adi { get; set; }

        [Required]
        public string Aciklama { get; set; }

        public double Fiyat { get; set; }

        public short Stok { get; set; }

        [StringLength(300)]
        public string ResimPath { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime EklenmeTarihi { get; set; }

        public int AltKategoriId { get; set; }

        public bool AktifDurum { get; set; }

        public virtual AltKategori AltKategori { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatilanUrun> SatilanUrun { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunYorum> UrunYorum { get; set; }
    }
}
