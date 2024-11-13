using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace finance.api.src.category.domain.objectValues
{
    public class SubCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [BsonRepresentation(BsonType.String)]
        public string Id_Category { get; set; }

        [BsonElement("descript")]
        public string Descript { get; set; }

        public SubCategory() { }

        public SubCategory(SubCategory input) 
        {
            Id_Category = input.Id ?? Guid.NewGuid().ToString();
            Descript = input.Descript;
        }
    }
}
