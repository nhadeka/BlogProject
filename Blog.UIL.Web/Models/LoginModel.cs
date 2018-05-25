using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.UIL.Web.Models
{
    public class LoginModel
    {
       
        [Required(ErrorMessage = "Username Boş Geçilemez")]
        public string UserName { get; set; }  

        [Required(ErrorMessage = "Parola Boş Geçilemez")]
        [MinLength(6, ErrorMessage = "En az 6 karakter olmalıdır")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}