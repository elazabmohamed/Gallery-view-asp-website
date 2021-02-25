using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3DModels.Models
{
    public class Admin
    {
        //[Range(1, 9, ErrorMessage ="")]
        [Required(ErrorMessage = "You need to enter your email adress.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "You need to enter your password.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength=10, ErrorMessage ="Password minimum size is 10 charachters.")]
        public string Password { get; set; }
    }
}