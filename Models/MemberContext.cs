using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ElaApi.Models
{
    public class MemberContext : IMemberContext
    {
        private readonly IMongoDatabase _db;

        public MemberContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Member> Members => _db.GetCollection<Member>("Members");
    }
}