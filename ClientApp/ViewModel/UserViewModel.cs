using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DominosFrontEnd.ViewModel
{
    /// <summary>
    /// This class contains the properties for view model of the account login or registration page
    /// </summary>
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please enter username")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}