using App.Application.Shared.Exceptions;

namespace App.Application.Modules.Category.Domain.ValueObjects
{
	public class CategoryName
	{
		public CategoryName(string value)
		{
			Value = Validate(value);
		}

		private string Validate(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new EntityValidationException("Category name cannot be empty.");

			if (value.Length > 100)
				throw new EntityValidationException("Category name cannot have more than 100 characters.");

			if (value.Length < 3)
				throw new EntityValidationException("Category name cannot have less than 3 characters.");

			return value.Trim();
		}

		public string Value { get; private set; }

		public static implicit operator string(CategoryName categoryName) => categoryName.Value;

		public static implicit operator CategoryName(string value) => new CategoryName(value);
	}
}
