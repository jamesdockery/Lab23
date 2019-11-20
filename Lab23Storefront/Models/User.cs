using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab23Storefront.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(15)]
        public string Password { get; set; }

        [Required]
        public double Money { get; set; }
    }
}
