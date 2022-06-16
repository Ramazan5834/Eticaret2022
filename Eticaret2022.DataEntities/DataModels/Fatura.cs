namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fatura")]
    public partial class Fatura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string TcKimlik { get; set; }

        [StringLength(50)]
        public string VergiNo { get; set; }

        [StringLength(300)]
        public string VergiDairesi { get; set; }

        [StringLength(200)]
        public string FirmaAdi { get; set; }

        public virtual SatisDetay SatisDetay { get; set; }
    }
}
