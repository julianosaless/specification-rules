using System;
using System.Collections.Generic;
using Rules;
using ProductImport.Rules;

namespace ProductImport
{
    public class ProductImportRules : RulesBase<Product>
    {
        protected override List<IRules<Product>> Rules => new List<IRules<Product>>
        {
            new ProductMustHaveName(),
            new ProductMustHaveMinQuantity()
        };
    }
}
