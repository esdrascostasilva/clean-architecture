using CleanArcMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArcMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact(DisplayName = "Create Product With Valid Values")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product good", 10.00m, 3, "Image.jpg");
        action.Should()
                .NotThrow<CleanArcMvc.Domain.Validation.DomainExceptionValidation>();
    }

     [Fact(DisplayName = "Create Product With Negative ID Value")]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Product good", 10.00m, 3, "Image.jpg");
        action.Should()
                .Throw<CleanArcMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
    }

     [Fact(DisplayName = "Create Product With Short Name")]
    public void CreateProduct_WithShortName_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Pr", "Product good", 10.00m, 3, "Image.jpg");
        action.Should()
                .Throw<CleanArcMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
    }

    [Fact(DisplayName = "Create Product With Long Image Name")]
     public void CreateProduct_WithLongImageName_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Product Name", "Product good", 10.00m, 3, "mnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewqmnbvcxzlkjhgfdsapoiuytrewq");
        action.Should()
                .Throw<CleanArcMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
    }

    [Fact(DisplayName = "Create Product With Null Image Name")]
    public void CreateProduct_WithNullImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product good", 10.00m, 3, null);
        action.Should()
                .NotThrow<CleanArcMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product With Null Image Name Reference Exception")]
    public void CreateProduct_WithNullImageName_NoNullReferenceException()
    {
        Action action = () => new Product(1, "Product Name", "Product good", 10.00m, 3, null);
        action.Should()
                .NotThrow<NullReferenceException>();
    }

    [Fact(DisplayName = "Create Product With Empty Image Name")]
    public void CreateProduct_WithEmptyImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product good", 10.00m, 3, "");
        action.Should()
                .NotThrow<CleanArcMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Prodcut With Price Negative")]
    public void CreateProduct_WithPriceNegativeValue_DomainExceptionInvalidPrice()
    {
        Action action = () => new Product(1, "Product Name", "Product good", -10.00m, 3, "Image.jpg");
        action.Should()
                .Throw<CleanArcMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
    }
    
    [Theory]
    [InlineData(-99)]
    public void CreateProduct_WithStockNegativeValue_DomainExceptionInvalidStock(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product good", 10.00m, value, "Image.jpg");
        action.Should()
                .Throw<CleanArcMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
    }
}
