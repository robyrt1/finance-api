using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace finance.api.src.category.domain.objectValues
{
    public class SubCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public String Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public String Id_Category { get; set; }

        [BsonElement("descript")]
        public String Descript { get; set; }

    }
}
