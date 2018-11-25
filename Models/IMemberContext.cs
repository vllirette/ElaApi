using MongoDB.Driver;

namespace ElaApi.Models
{
    public interface IMemberContext
    {
        IMongoCollection<Member> Members {  get;}
    }
}