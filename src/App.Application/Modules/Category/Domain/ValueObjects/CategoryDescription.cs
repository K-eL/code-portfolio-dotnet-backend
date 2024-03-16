using App.Application.Shared.Exceptions;

namespace App.Application.Modules.Category.Domain.ValueObjects
{
	public class CategoryDescription
	{
		public CategoryDescription(string value)
		{
			Value = Validate(value);
		}

		private string Validate(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new EntityValidationException("Category description cannot be empty.");

			if (value.Length > 500)
				throw new EntityValidationException(
					"Category description cannot have more than 500 characters."
				);

			return value.Trim();
		}

		public string Value { get; private set; }

		public static implicit operator string(CategoryDescription categoryDescription) =>
			categoryDescription.Value;

		public static implicit operator CategoryDescription(string value) =>
			new CategoryDescription(value);
	}
}
