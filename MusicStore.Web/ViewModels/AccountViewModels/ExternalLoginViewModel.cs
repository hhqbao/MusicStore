using System.ComponentModel.DataAnnotations;

namespace MusicStore.Web.ViewModels.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
