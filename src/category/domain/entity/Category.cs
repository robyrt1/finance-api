using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace finance.api.src.category.domain.entity
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [BsonElement("descript")]
        public string Descript { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }


        public Category() { }

        public Category(Category category) 
        {
            Id = category.Id ?? Guid.NewGuid().ToString();
            Descript = category.Descript;
            Type = category.Type;
        }   
    }
}
