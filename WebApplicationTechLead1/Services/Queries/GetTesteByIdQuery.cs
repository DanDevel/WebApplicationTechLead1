namespace WebApplicationTechLead1.Services.Queries
{
    public class GetTesteByIdQuery
    {
        public string Id { get; }

        public GetTesteByIdQuery(string id)
        {
            Id = id;
        }
    }
}
