namespace SmartConnect.Web.ViewModels.Admin.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.Mappings;

    public class AdminUserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Joined")]
        public DateTime CreatedOn { get; set; }
    }
}
