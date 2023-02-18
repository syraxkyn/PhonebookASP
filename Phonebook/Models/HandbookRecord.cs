using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Phonebook.Models
{
    public class HandbookRecord
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression("[A-z]{2,}")]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}