using App.Application.Shared.Domain.Entity;

namespace App.UnitTests.Shared.Domain.Entity
{
	public class BaseEntityTest
	{
		// Fixtures
		private class TestEntityNull : BaseEntity
		{
			public TestEntityNull()
				: base(null, null, null, null) { }
		}

		private class TestEntityFilled : BaseEntity
		{
			public TestEntityFilled()
				: base(new Guid().ToString(), new DateTime(2021, 12, 31), new DateTime(2021, 12, 31), true)
			{ }
		}

		// Tests
		[Fact(DisplayName = nameof(ActivateBaseEntity))]
		[Trait("Domain", "Entity - BaseEntity")]
		public void ActivateBaseEntity()
		{
			// Arrange
			var entity = new TestEntityNull();

			// Act
			entity.Activate();

			// Assert
			Assert.True(entity.IsActive);
			Assert.NotEqual(default, entity.UpdatedAt);
		}

		[Fact(DisplayName = nameof(DeactivateBaseEntity))]
		[Trait("Domain", "Entity - BaseEntity")]
		public void DeactivateBaseEntity()
		{
			// Arrange
			var entity = new TestEntityNull();

			// Act
			entity.Deactivate();

			// Assert
			Assert.False(entity.IsActive);
			Assert.NotEqual(default, entity.UpdatedAt);
		}

		[Fact(DisplayName = nameof(ActivateBaseEntityFilled))]
		[Trait("Domain", "Entity - BaseEntity")]
		public void ActivateBaseEntityFilled()
		{
			// Arrange
			var entity = new TestEntityFilled();
			var updatedAtBefore = entity.UpdatedAt;

			// Act
			entity.Activate();

			// Assert
			Assert.True(entity.IsActive);
			Assert.NotEqual(updatedAtBefore, entity.UpdatedAt);
		}

		[Fact(DisplayName = nameof(DeactivateBaseEntityFilled))]
		[Trait("Domain", "Entity - BaseEntity")]
		public void DeactivateBaseEntityFilled()
		{
			// Arrange
			var entity = new TestEntityFilled();
			var updatedAtBefore = entity.UpdatedAt;

			// Act
			entity.Deactivate();

			// Assert
			Assert.False(entity.IsActive);
			Assert.NotEqual(updatedAtBefore, entity.UpdatedAt);
		}

		[Fact(DisplayName = nameof(CreateNullBaseEntity))]
		[Trait("Domain", "Entity - BaseEntity")]
		public void CreateNullBaseEntity()
		{
			// Arrange
			var entity = new TestEntityNull();

			// Assert
			Assert.NotNull(entity.Id);
			Assert.NotEqual(default, entity.CreatedAt);
			Assert.NotEqual(default, entity.UpdatedAt);
			Assert.True(entity.IsActive);
		}

		[Fact(DisplayName = nameof(CreateFilledBaseEntity))]
		[Trait("Domain", "Entity - BaseEntity")]
		public void CreateFilledBaseEntity()
		{
			// Arrange
			var entity = new TestEntityFilled();

			// Assert
			Assert.NotNull(entity.Id);
			Assert.NotEqual(default, entity.CreatedAt);
			Assert.NotEqual(default, entity.UpdatedAt);
			Assert.True(entity.IsActive);
		}
	}
}
