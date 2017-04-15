using Rules;

namespace ProductImport.Rules
{
    public class ProductMustHaveMinQuantity : IRules<Product>
    {
        public string Message { get; private set; }

        public StatusOfValidation StatusOfValidation { get; private set; } = StatusOfValidation.Success;

        public void Validate(Product entity)
        {
            if (!entity.HasMinQuantity)
            {
                Message = "Product quantity must be greater than 5";
                StatusOfValidation = StatusOfValidation.Error;
            }
        }
    }
}
