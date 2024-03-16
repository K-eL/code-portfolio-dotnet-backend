using App.Application.Shared.Domain.ValueObjects;

namespace App.Application.Shared.Domain.Entity
{
	public abstract class BaseEntity
	{
		public UniqueEntityID Id { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }
		public bool IsActive { get; private set; }

		protected BaseEntity(string? id, DateTime? createdAt, DateTime? updatedAt, bool? isActive)
		{
			Id = string.IsNullOrEmpty(id) ? new UniqueEntityID() : new UniqueEntityID(Guid.Parse(id));
			CreatedAt = createdAt ?? DateTime.Now;
			UpdatedAt = updatedAt ?? DateTime.Now;
			IsActive = isActive == null || (bool)isActive;
		}

		public void Activate()
		{
			IsActive = true;
			UpdateUpdatedAt();
		}

		public void Deactivate()
		{
			IsActive = false;
			UpdateUpdatedAt();
		}

		protected void UpdateUpdatedAt()
		{
			UpdatedAt = DateTime.Now;
		}
	}
}
