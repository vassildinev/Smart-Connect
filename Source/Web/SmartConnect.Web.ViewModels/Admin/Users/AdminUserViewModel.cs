namespace SmartConnect.Web.ViewModels.Admin.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.Mappings;
    using Admin;

    public class AdminUserViewModel : BaseAdministrationViewModel<User, string>, IMapFrom<User>
    {
        [Display(Name = "First name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Joined")]
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
