using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace finance.api.src.category.domain.entity
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public String Id { get; set; }
        [BsonElement("descript")]
        public string Descript { get; set; }
    }
}
