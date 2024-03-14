using App.Application.Shared.Exceptions;
using ApplicationEntity = App.Application.Modules.Category.Domain.Entity;

namespace App.UnitTests.Domain.Entity.Category
{
	public class CategoryTest
	{
		[Fact(DisplayName = "Create Category")]
		[Trait("Domain", "Entity - Category")]
		public void CreateCategory()
		{
			// Arrange
			var name = "Category 1";
			var description = "Description 1";

			// Act
			var dateTimeBefore = DateTime.Now;
			var category = new ApplicationEntity.Category(name, description);
			var dateTimeAfter = DateTime.Now;

			// Assert
			Assert.Equal(name, category.Name);
			Assert.Equal(description, category.Description);
			Assert.NotEqual(default, category.Id);
			Assert.NotEqual(default, category.CreatedAt);
			Assert.True(category.CreatedAt > DateTime.MinValue);
			Assert.True(category.CreatedAt < DateTime.MaxValue);
			Assert.True(category.CreatedAt >= dateTimeBefore);
			Assert.True(category.CreatedAt <= dateTimeAfter);
		}

		[Theory(DisplayName = "Create Category - Invalid Name")]
		[Trait("Domain", "Entity - Category")]
		[InlineData(null, "Description 1")]
		[InlineData("", "Description 1")]
		[InlineData("         ", "Description 1")]
		public void CreateCategory_InvalidName(string? name, string description)
		{
			void act() => new ApplicationEntity.Category(name, description);
			var exception = Assert.Throws<EntityValidationException>(act);
			Assert.Equal("Category name cannot be empty.", exception.Message);
		}

		[Theory(DisplayName = "Create Category - Invalid Description")]
		[Trait("Domain", "Entity - Category")]
		[InlineData("Category 1", null)]
		[InlineData("Category 1", "")]
		[InlineData("Category 1", "         ")]
		public void CreateCategory_InvalidDescription(string name, string? description)
		{
			void act() => new ApplicationEntity.Category(name, description);
			var exception = Assert.Throws<EntityValidationException>(act);
			Assert.Equal("Category description cannot be empty.", exception.Message);
		}

		[Fact(DisplayName = "Create Category - Long Description")]
		[Trait("Domain", "Entity - Category")]
		public void CreateCategory_LongName()
		{
			string longDescription = new('a', 501);
			Console.WriteLine(longDescription.Length);
			void act() => new ApplicationEntity.Category("Category 1", longDescription);
			var exception = Assert.Throws<EntityValidationException>(act);
			Assert.Equal("Category description cannot have more than 500 characters.", exception.Message);
		}
	}
}
