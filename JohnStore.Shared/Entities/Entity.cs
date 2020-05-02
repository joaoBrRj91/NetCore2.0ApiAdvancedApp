
using FluentValidator;
using System;

namespace JohnStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity() => Id = Guid.NewGuid();

        public Guid Id { get; protected set; }

        public virtual void ValidateEntity() { }
    }
}