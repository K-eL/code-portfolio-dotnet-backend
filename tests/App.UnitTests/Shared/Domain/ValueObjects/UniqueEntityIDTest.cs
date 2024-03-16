using App.Application.Shared.Domain.ValueObjects;

namespace App.UnitTests.Shared.Domain.ValueObjects
{
	public class UniqueEntityIDTest
	{
		// Fixtures
		private readonly Guid CustomValue = new Guid("00000000-0000-0000-0000-000000000001");

		// Tests
		[Fact(DisplayName = nameof(Constructor_DefaultValue))]
		[Trait("Domain", "ValueObject - UniqueEntityID")]
		public void Constructor_DefaultValue()
		{
			// Act
			var uniqueEntityID = new UniqueEntityID();

			// Assert
			Assert.NotEqual(default, uniqueEntityID.Value);
		}

		[Fact(DisplayName = nameof(Constructor_CustomValue))]
		[Trait("Domain", "ValueObject - UniqueEntityID")]
		public void Constructor_CustomValue()
		{
			// Act
			var uniqueEntityID = new UniqueEntityID(CustomValue);

			// Assert
			Assert.Equal(CustomValue, uniqueEntityID.Value);
		}

		[Fact(DisplayName = nameof(ImplicitOperator_FromUniqueEntityIDToGuid))]
		[Trait("Domain", "ValueObject - UniqueEntityID")]
		public void ImplicitOperator_FromUniqueEntityIDToGuid()
		{
			// Arrange
			var uniqueEntityID = new UniqueEntityID(CustomValue);

			// Act
			Guid guid = uniqueEntityID;

			// Assert
			Assert.Equal(uniqueEntityID.Value, guid);
		}

		[Fact(DisplayName = nameof(ImplicitOperator_FromGuidToUniqueEntityID))]
		[Trait("Domain", "ValueObject - UniqueEntityID")]
		public void ImplicitOperator_FromGuidToUniqueEntityID()
		{
			// Act
			UniqueEntityID uniqueEntityID = CustomValue;

			// Assert
			Assert.Equal(CustomValue, uniqueEntityID.Value);
		}
	}
}
