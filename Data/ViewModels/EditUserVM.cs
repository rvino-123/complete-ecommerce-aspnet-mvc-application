using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class EditUserVM
    {
        [Display(Name = "User Id")]
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
