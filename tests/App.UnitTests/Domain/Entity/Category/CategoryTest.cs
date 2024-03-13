using ApplicationEntity = App.Application.Domain.Entity;

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
			var category = new ApplicationEntity.Category(name, description);

			// Assert
			Assert.Equal(name, category.Name);
			Assert.Equal(description, category.Description);
		}
	}
}