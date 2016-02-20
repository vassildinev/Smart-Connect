namespace SmartConnect.Data.Models.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BaseModel<TKey> : IEntity<TKey>, IDeletableEntity, IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DeletedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? ModifiedOn { get; set; }
    }
}
