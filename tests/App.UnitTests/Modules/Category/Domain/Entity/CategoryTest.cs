using App.Application.Modules.Category.Domain.Entity;
using CategoryEntity = App.Application.Modules.Category.Domain.Entity.Category;

namespace App.UnitTests.Domain.Category.Entity
{
	public class CategoryTest
	{
		// Fixtures
		private readonly string ValidCategoryName1 = "Category 1";
		private readonly string ValidCategoryDescription1 = "Description 1";
		private readonly string ValidCategoryName2 = "Category 2";
		private readonly string ValidCategoryDescription2 = "Description 2";

		private CategoryInput GetValidCategoryInput() =>
			new() { Name = ValidCategoryName1, Description = ValidCategoryDescription1 };

		// Tests
		[Fact(DisplayName = nameof(CreateCategory))]
		[Trait("Domain", "Entity - Category")]
		public void CreateCategory()
		{
			// Arrange
			var input = GetValidCategoryInput();

			// Act
			var dateTimeBefore = DateTime.Now;
			var category = new CategoryEntity(input);
			var dateTimeAfter = DateTime.Now;

			// Assert
			Assert.Equal(input.Name, category.Name);
			Assert.Equal(input.Description, category.Description);
			Assert.NotEqual(default, category.Id);
			Assert.NotEqual(default, category.CreatedAt);
			Assert.True(category.CreatedAt > DateTime.MinValue);
			Assert.True(category.CreatedAt < DateTime.MaxValue);
			Assert.True(category.CreatedAt >= dateTimeBefore);
			Assert.True(category.CreatedAt <= dateTimeAfter);
			Assert.True(category.IsActive);
		}

		[Fact(DisplayName = nameof(UpdateCategoryName))]
		[Trait("Domain", "Entity - Category")]
		public void UpdateCategoryName()
		{
			// Arrange
			var input = GetValidCategoryInput();
			var category = new CategoryEntity(input);
			var newName = ValidCategoryName2;

			// Act
			category.UpdateName(newName);

			// Assert
			Assert.Equal(newName, category.Name);
		}

		[Fact(DisplayName = nameof(UpdateCategoryDescription))]
		[Trait("Domain", "Entity - Category")]
		public void UpdateCategoryDescription()
		{
			// Arrange
			var input = GetValidCategoryInput();
			var category = new CategoryEntity(input);
			var newDescription = ValidCategoryDescription2;

			// Act
			category.UpdateDescription(newDescription);

			// Assert
			Assert.Equal(newDescription, category.Description);
		}
	}
}
