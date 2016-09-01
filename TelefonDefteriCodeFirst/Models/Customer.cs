using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonDefteriCodeFirst.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(25), Required]
        public string Name { get; set; }

        [StringLength(25), Required]
        public string Surname { get; set; }

        public int? Age { get; set; }

        public bool IsMarried { get; set; }


        public virtual List<Address> Addresses { get; set; }
        public virtual List<Phone> Phones { get; set; }
    }
}