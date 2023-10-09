using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LogInSignupProject.Models
{
    public class LogInVeiwModel
    {
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}