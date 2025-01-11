using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shotly.Models
{
    public class CreateViewModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]

        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Parolanız Eşleşmiyor")]
        public string? ConfirmPassword { get; set; }

    }
}