
using FluentValidator;

namespace JohnStore.Shared.Entities
{
  public abstract class Entity : Notifiable
  {
    public Entity() => Id = System.Guid.NewGuid();
    

    public System.Guid Id { get; private set; }

    public virtual void ValidateEntity()
    {
      return;

    }
  }
}