namespace SmartConnect.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Quote : BaseModel<int>
    {
        [Required]
        [MaxLength(60)]
        public string Author { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
