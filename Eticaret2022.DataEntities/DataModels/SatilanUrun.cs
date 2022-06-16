namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SatilanUrun")]
    public partial class SatilanUrun
    {
        public int Id { get; set; }

        public int UrunId { get; set; }

        public int Adet { get; set; }

        public int SatisDetayId { get; set; }

        public double UrunAnlikFiyat { get; set; }

        public virtual SatisDetay SatisDetay { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
