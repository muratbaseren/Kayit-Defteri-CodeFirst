using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonDefteriCodeFirst.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(300), Required, DisplayName("Adres Tanım")]
        public string Description { get; set; }

        [StringLength(30), DisplayName("Şehir")]
        public string City { get; set; }

        [StringLength(30), DisplayName("Ülke")]
        public string Country { get; set; }

        [DisplayName("Müşteri")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}