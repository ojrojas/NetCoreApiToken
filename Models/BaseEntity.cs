namespace RappiApi.Models
{
    public class BaseEntity :IAggregateRoot
    {
        public string Id { get; set; }
    }
}