using System.ComponentModel.DataAnnotations;
using WebApplication1.Game;

namespace WebApplication1.ViewModels
{
    public class ProfileViewModel
    {
        [Display(Name = "Nickname")]
        public string Nick { get; }
    }
}