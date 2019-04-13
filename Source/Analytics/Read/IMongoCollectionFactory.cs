using MongoDB.Driver;

namespace Read
{
    public interface IMongoCollectionFactory
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}