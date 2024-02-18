namespace CleanArchitectureUdemyCourse.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; set; }

        public Product(int id, string name, string description, decimal price, int stock, string? image, int categoryId)
        {
            Validate(name, description, price, stock, image);

            Validation.DomainExceptoinValidation.When(Id <= 0, "Invalid Id.");

            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }        
        
        public Product(string name, string description, decimal price, int stock, string? image, int categoryId)
        {
            Validate(name, description, price, stock, image);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        public void Validate(string name, string description, decimal price, int stock, string? image)
        {
            Validation.DomainExceptoinValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");

            Validation.DomainExceptoinValidation.When(name?.Length < 3, "Name is too short. Minimun length is 3.");

            Validation.DomainExceptoinValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required.");

            Validation.DomainExceptoinValidation.When(description?.Length < 5, "Description is too short. Minimun length is 5.");

            Validation.DomainExceptoinValidation.When(price < 0, "Invalid price. Price is required.");

            Validation.DomainExceptoinValidation.When(stock < 0, "Invalid stock. Stock is required.");


            Validation.DomainExceptoinValidation.When(image?.Length > 255, "Image name is too long. Maximun length is 255.");
        }
    }
}
