namespace App.Application.Shared.Domain.ValueObjects
{
	public class UniqueEntityID
	{
		public UniqueEntityID(Guid value = default)
		{
			if (value == default || value == Guid.Empty)
				value = Guid.NewGuid();

			Value = value;
		}

		public Guid Value { get; private set; }

		public static implicit operator Guid(UniqueEntityID id) => id.Value;

		public static implicit operator UniqueEntityID(Guid value) => new UniqueEntityID(value);
	}
}
