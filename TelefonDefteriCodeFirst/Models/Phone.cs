using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonDefteriCodeFirst.Models
{
    [Table("Phones")]
    public class Phone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(15), Required, DisplayName("Telefon Numarası")]
        public string Number { get; set; }

        [DisplayName("Ülke Kodu")]
        public int? CountryCode { get; set; }

        [DisplayName("Varsayılan")]
        public bool IsDefault { get; set; }

        [DisplayName("Müşteri")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}