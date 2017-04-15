using System.Collections.Generic;
using Rules;
using Xunit;
using System.Linq;
using FluentAssertions;
using SpecificationRulesTest.ProductImport;

namespace SpecificationRulesTest
{
    public class ProductImportTest
    {
        [Fact]
        public void ShouldValidateProductName()
        {
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
            var productImportRules = new ProductImportRules().ApplyRules(products);
            productImportRules.All(x => x.Rules.All(r => r.StatusOfValidation == StatusOfValidation.Success)).Should().BeFalse();

            var rule = productImportRules.FirstOrDefault(x => x.Rules.Any(r => r.StatusOfValidation == StatusOfValidation.Error));
            rule.Entity.Id.Should().Be(2);
        }

        [Fact]
        public void ShouldValidateProductMinQuantity()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Foo",
                    Quantity = 2
                }
            };
            var productImportRules = new ProductImportRules().ApplyRules(products);
            productImportRules.All(x => x.Rules.All(r => r.StatusOfValidation == StatusOfValidation.Success)).Should().BeFalse();

            var rule = productImportRules.FirstOrDefault(x => x.Rules.Any(r => r.StatusOfValidation == StatusOfValidation.Error));
            rule.Entity.Id.Should().Be(1);

            rule.Rules.FirstOrDefault(f => f.StatusOfValidation == StatusOfValidation.Error).Message.Should().NotBeNullOrEmpty();
        }
    }
}
