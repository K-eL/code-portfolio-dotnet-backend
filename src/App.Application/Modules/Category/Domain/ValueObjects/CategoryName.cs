using App.Application.Shared.Exceptions;

namespace App.Application.Modules.Category.Domain.ValueObjects
{
	public class CategoryName
	{
		public CategoryName(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new EntityValidationException("Category name cannot be empty.");

			Value = value;
		}

		public string Value { get; private set; }

		public static implicit operator string(CategoryName categoryName) => categoryName.Value;

		public static implicit operator CategoryName(string value) => new CategoryName(value);
	}
}
