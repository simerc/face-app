using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaceImage.Api.Models.Registration
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        //[Required]
        //public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Age { get; set; }

    }
}
