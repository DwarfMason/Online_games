using System.ComponentModel.DataAnnotations;
using AdministratorProject.Game;

namespace WebApplication1.ViewModels
{
    public class ProfileViewModel
    {
        [Display(Name = "Nickname")]
        public string Nick { get; }
    }
}