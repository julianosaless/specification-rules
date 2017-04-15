using Rules;

namespace SpecificationRulesTest.ProductImport.Rules
{
    public class ProductMustHaveName : IRules<Product>
    {
        public string Message { get; private set; }

        public StatusOfValidation StatusOfValidation { get; private set; } = StatusOfValidation.Success;

        public void Validate(Product entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                Message = "Name of product required";
                StatusOfValidation = StatusOfValidation.Error;
            }
        }
    }
}
