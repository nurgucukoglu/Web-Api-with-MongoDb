using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI2
{

   
    public class Ornek
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email { get; set; }
        public string? gender { get; set; }
        public string? ip_address { get; set; }
    }
}
