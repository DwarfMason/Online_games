using System.ComponentModel.DataAnnotations;
 
namespace WebApplication1.ViewModels
{
    public class ProfileViewModel
    {
        [Display(Name = "Nickname")]
        public string Nick { get; }
         
    }
}