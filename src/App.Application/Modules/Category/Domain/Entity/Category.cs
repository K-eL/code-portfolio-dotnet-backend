using App.Application.Modules.Category.Domain.ValueObjects;
using App.Application.Shared.Domain.ValueObjects;

namespace App.Application.Modules.Category.Domain.Entity
{
	public class Category
	{
		public Category(string name, string description, bool isActive = true)
		{
			Id = new UniqueEntityID();
			Name = new CategoryName(name);
			Description = new CategoryDescription(description);
			CreatedAt = DateTime.Now;
			IsActive = isActive;
		}

		public Guid Id { get; private set; }
		public CategoryName Name { get; private set; }
		public CategoryDescription Description { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public bool IsActive { get; private set; }
	}
}
