using App.Application.Modules.Category.Domain.ValueObjects;
using App.Application.Shared.Exceptions;
using Xunit;

namespace App.UnitTests.Domain.Category.ValueObjects
{
	public class CategoryDescriptionTest
	{
		[Fact(DisplayName = nameof(CreateCategoryDescription_Valid))]
		[Trait("Domain", "ValueObject - CategoryDescription")]
		public void CreateCategoryDescription_Valid()
		{
			// Arrange
			var description = "Valid description";

			// Act
			var result = new CategoryDescription(description);

			// Assert
			Assert.Equal(description, result.Value);
		}

		[Theory(DisplayName = nameof(CreateCategoryDescription_InvalidValue))]
		[Trait("Domain", "ValueObject - CategoryDescription")]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("         ")]
		public void CreateCategoryDescription_InvalidValue(string description)
		{
			// Act
			void act() => new CategoryDescription(description);

			// Assert
			var exception = Assert.Throws<EntityValidationException>(act);
			Assert.Equal("Category description cannot be empty.", exception.Message);
		}

		[Fact(DisplayName = nameof(CreateCategoryDescription_LongValue))]
		[Trait("Domain", "ValueObject - CategoryDescription")]
		public void CreateCategoryDescription_LongValue()
		{
			// Arrange
			string longValue = new string('a', 501);

			// Act
			void act() => new CategoryDescription(longValue);

			// Assert
			var exception = Assert.Throws<EntityValidationException>(act);
			Assert.Equal("Category description cannot have more than 500 characters.", exception.Message);
		}
	}
}
