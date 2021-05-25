using Flunt.Notifications;
using System;

namespace DesafioGuilherme.Api.Domain.Core.Entities
{
    public class Entity : Notifiable<Notification>
    {
        public Guid Id { get; protected set; }

        protected Entity() => Id = Guid.NewGuid();
    }
}
