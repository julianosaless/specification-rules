using System.Collections.Generic;
using Rules;
using SpecificationRulesTest.ProductImport.Rules;
using System.Linq;

namespace SpecificationRulesTest.ProductImport
{
    public class ProductImportRules : RulesBase<Product, RulesResultBase<Product>>
    {
        protected override List<IRules<Product>> Rules => new List<IRules<Product>>
        {
            new ProductMustHaveName(),
            new ProductMustHaveMinQuantity()
        };

        public override List<RulesResultBase<Product>> ApplyRules(List<Product> entites)
        {
            return entites
                     .Select(entity => new RulesResultBase<Product>(entity, ProcessRules(entity))).ToList();
        }
    }
}
