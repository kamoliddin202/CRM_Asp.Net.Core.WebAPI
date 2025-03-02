using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.Helpers
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Name is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Name is required")]
        public string Password { get; set; }
    }
}
