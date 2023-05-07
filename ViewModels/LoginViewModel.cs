using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace VendaLanches.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
