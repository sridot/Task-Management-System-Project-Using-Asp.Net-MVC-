using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TaskManagementSystem.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Please Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage ="Password Mismatch")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Please Email Address")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string ErrorMessage { get; set; }
    }
}