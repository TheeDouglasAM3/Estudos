using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.IdentityServer.Quickstart.Account
{
    public class RegisterInputModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}