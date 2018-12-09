using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ElaApi.Models;

namespace ElaApi.Infrastructure
{
    public class MemberContext
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