using App.Application.Modules.Category.Domain.ValueObjects;
using App.Application.Shared.Exceptions;

namespace App.UnitTests.Domain.Category.ValueObjects
{
	public class CategoryNameTest
	{
		[Fact(DisplayName = nameof(CreateCategoryName_Valid))]
		[Trait("Domain", "ValueObject - CategoryName")]
		public void CreateCategoryName_Valid()
		{
			// Arrange
			var value = "Category 1";

			// Act
			var categoryName = new CategoryName(value);

			// Assert
			Assert.Equal(value, categoryName.Value);
		}

		[Theory(DisplayName = nameof(CreateCategoryName_InvalidValue))]
		[Trait("Domain", "ValueObject - CategoryName")]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("         ")]
		public void CreateCategoryName_InvalidValue(string value)
		{
			void act() => new CategoryName(value);
			var exception = Assert.Throws<EntityValidationException>(act);
			Assert.Equal("Category name cannot be empty.", exception.Message);
		}

		[Theory(DisplayName = nameof(CreateCategoryName_ShortValue))]
		[Trait("Domain", "ValueObject - CategoryName")]
		[InlineData("ab")]
		[InlineData("a")]
		public void CreateCategoryName_ShortValue(string value)
		{
			void act() => new CategoryName(value);
			var exception = Assert.Throws<EntityValidationException>(act);
			Assert.Equal("Category name cannot have less than 3 characters.", exception.Message);
		}

		[Fact(DisplayName = nameof(CreateCategoryName_LongValue))]
		[Trait("Domain", "ValueObject - CategoryName")]
		public void CreateCategoryName_LongValue()
		{
			string longValue = new string('a', 101);
			void act() => new CategoryName(longValue);
			var exception = Assert.Throws<EntityValidationException>(act);
			Assert.Equal("Category name cannot have more than 100 characters.", exception.Message);
		}
	}
}
