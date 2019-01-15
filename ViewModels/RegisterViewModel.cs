using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string HeroType { get; set; }
        
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password", ErrorMessage = "Password are not equal")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}