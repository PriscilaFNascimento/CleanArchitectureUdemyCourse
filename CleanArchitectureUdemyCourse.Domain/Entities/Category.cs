namespace CleanArchitectureUdemyCourse.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }
        public Category(int id, string name)
        {
            Validate(name);
            Validation.DomainExceptoinValidation.When(Id <= 0, "Invalid Id.");

            Id = id;
            Name = name;
        }        
        
        public Category(string name)
        {
            Validate(name);

            Name = name;
        }

        public void Validate(string name)
        {
            Validation.DomainExceptoinValidation.When(string.IsNullOrEmpty(Name), "Invalid name. Name is required.");
            Validation.DomainExceptoinValidation.When(Name?.Length < 3, "Name is too short. Minimun length is 3.");
        }
    }
}
