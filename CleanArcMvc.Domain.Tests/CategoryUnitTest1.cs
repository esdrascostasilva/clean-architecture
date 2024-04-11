using CleanArcMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArcMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should().NotThrow<CleanArcMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Negative ID Value")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "New Category");
        action.Should()
                .Throw<CleanArcMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
    }

    [Fact(DisplayName = "Create Category With Short Name")]
    public void CreateCategory_WithShortName_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Aa");
        action.Should()
                .Throw<CleanArcMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
    }

    [Fact(DisplayName = "Create Category Missing Name")]
    public void CreateCategory_WithoutName_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");
        action.Should()
                .Throw<CleanArcMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
    }

    [Fact(DisplayName = "Create Category Null Name")]
    public void CreateCategory_WithNullNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, null);
        action.Should()
                .Throw<CleanArcMvc.Domain.Validation.DomainExceptionValidation>();
    }
}