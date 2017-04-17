
# Specification-Rules

![Image of pull specification-rules](https://dl.dropboxusercontent.com/s/uv3ys3bkd1wa0iw//specification-rules.jpg)


# How to use


#### 1 - Define your Rules

```
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
```
```
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
```
#### 2 - Define your RulesBase
```
  public class ProductImportRules : RulesBase<Product, RulesResultBase<Product>>
  {
      protected override List<IRules<Product>> Rules => new List<IRules<Product>>
      {
          new ProductMustHaveName(),
          new ProductMustHaveMinQuantity()
      };
  }
```
*******
# Usage
```
    var products = new List<Product>
    {
        new Product
        {
            Id = 1,
            Name = "Foo",
            Quantity = 6
        },
        new Product
        {
            Id = 2,
            Name = string.Empty,
            Quantity = 6
        }
    };
    
    var productRulesResult = new ProductImportRules().ApplyRules(products);
    
    //Verifying if all rules be right
    productRulesResult.All(x => x.Rules.All(r => r.StatusOfValidation == StatusOfValidation.Success))
```

