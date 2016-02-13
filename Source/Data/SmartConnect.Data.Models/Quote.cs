namespace SmartConnect.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Quote : BaseModel<string>
    {
        [Required]
        [MinLength(60)]
        public string Author { get; set; }

        [Required]
        [MinLength(500)]
        public string Content { get; set; }
    }
}
