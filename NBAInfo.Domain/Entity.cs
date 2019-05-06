using System;
using System.ComponentModel.DataAnnotations;

namespace NBAInfo.Domain
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
