namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiteHakkinda")]
    public partial class SiteHakkinda
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Adi { get; set; }

        [StringLength(200)]
        public string Adres { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Tel1 { get; set; }

        [StringLength(30)]
        public string Tel2 { get; set; }

        [StringLength(100)]
        public string FacebookUrl { get; set; }

        [StringLength(100)]
        public string TwitterUrl { get; set; }

        [StringLength(100)]
        public string InstagramUrl { get; set; }

        [StringLength(100)]
        public string YoutubeUrl { get; set; }

        [StringLength(100)]
        public string GoogleUrl { get; set; }

        [StringLength(100)]
        public string LogoPath { get; set; }

        [StringLength(100)]
        public string HakkimizdaBaslik { get; set; }

        public string HakkimizdaIcerik { get; set; }

        [StringLength(300)]
        public string HakkimizdaResimPath { get; set; }

        [StringLength(300)]
        public string BannerResimPath { get; set; }
    }
}
