namespace SmartConnect.Data.Models
{
    using Contracts;

    public class Requirement : BaseModel<string>
    {
        public string Name { get; set; }

        public bool IsFulfilled { get; set; }

        public RequirementPriority Priority { get; set; }
    }
}