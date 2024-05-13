using MongoDB.Bson;

namespace WebApplicationTechLead1.Domain.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Teste
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Id")]
        public string TesteId { get; set; }

        [BsonElement("NomeEmpresa")]
        public string NomeEmpresa { get; set; }

        [BsonElement("PorteEmpresa")]
        public string PorteEmpresa { get; set; }
    }


}
