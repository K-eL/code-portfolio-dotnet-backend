using App.Application.Modules.Category.Domain.ValueObjects;
using App.Application.Shared.Domain.Entity;

namespace App.Application.Modules.Category.Domain.Entity
{
	public class CategoryInput
	{
		public string? Id { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public bool? IsActive { get; set; }
	}

	public class Category : BaseEntity
	{
		public Category(CategoryInput input)
			: base(input.Id, input.CreatedAt, input.UpdatedAt, input.IsActive)
		{
			Name = new CategoryName(input.Name);
			Description = new CategoryDescription(input.Description ?? "");
		}

		public CategoryName Name { get; private set; }
		public CategoryDescription Description { get; private set; }

		public void UpdateName(string name)
		{
			Name = new CategoryName(name);
		}

		public void UpdateDescription(string description)
		{
			Description = new CategoryDescription(description);
		}

		public void Update(string name, string description)
		{
			UpdateName(name);
			UpdateDescription(description);
		}
	}
}
