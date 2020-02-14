using Flunt.Notifications;
using System;
using System.ComponentModel.DataAnnotations;

namespace FCamara.Domain.Entities
{
    public class Entity:Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
    }
}
