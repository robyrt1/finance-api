using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class UserEntity
{
    //public string Id { get; set; }

    //public string UserName { get; set; }

    //public string Email { get; set; }

    //public string Password { get; set; }
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public String Id { get; set; }
    [BsonElement("UserName")]
    public string UserName { get; set; }
    [BsonElement("Email")]
    public string Email { get; set; }
    [BsonElement("Password")]
    public string Password { get; set; }
}
