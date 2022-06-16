namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SatisDetay")]
    public partial class SatisDetay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SatisDetay()
        {
            SatilanUrun = new HashSet<SatilanUrun>();
        }

        public int Id { get; set; }

        public double TotalFiyat { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Tarih { get; set; }

        [Required]
        [StringLength(128)]
        public string MusteriId { get; set; }

        public bool OnayDurum { get; set; }

        public bool Okundu { get; set; }

        public long KargoNumarasi { get; set; }

        public int AdresId { get; set; }

        public int OdemeTipId { get; set; }

        public virtual Adres Adres { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Fatura Fatura { get; set; }

        public virtual OdemeTip OdemeTip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatilanUrun> SatilanUrun { get; set; }
    }
}
