namespace Eticaret2022.DataEntities.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BankaBilgi")]
    public partial class BankaBilgi
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Adi { get; set; }

        [Required]
        [StringLength(100)]
        public string Iban { get; set; }

        [StringLength(300)]
        public string ResimPath { get; set; }
    }
}
