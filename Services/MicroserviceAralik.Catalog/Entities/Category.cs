﻿using MongoDB.Bson.Serialization.Attributes;

namespace MicroserviceAralik.Catalog.Entities;

public class Category
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}
