using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}