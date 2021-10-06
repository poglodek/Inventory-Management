using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Management.Database
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
