using System.Linq;
using MongoDB.Driver;

namespace Read
{
    //TODO: ADD ERROR HANDLING & REPORTING BACK TO CALLER
    public class MongoDBHandler
    {
        readonly IMongoCollectionFactory _mongoCollectionFactory;

        public MongoDBHandler(IMongoCollectionFactory mongoCollectionFactory)
        {
            _mongoCollectionFactory = mongoCollectionFactory;
        }
        
        /**
         * Gets a queryable for a collection associated with a specific object type
        */
        public IQueryable<T> GetQueryable<T>() where T : BaseReadModel
        {
            var collection = _mongoCollectionFactory.GetCollection<T>(typeof(T).Name);
            return collection.AsQueryable();
        }

        /**
         * Adds generic object to database into collection named as typeof the object
         */
        public void Insert<T>(T record) where T : BaseReadModel
        {
            var collection = _mongoCollectionFactory.GetCollection<T>(typeof(T).Name);
            collection.InsertOneAsync(record);
        }

        /*
         * Provides ability to update a database element T with a given ObjectID
         */
        public void Update<T>(T record) where T : BaseReadModel
        {
            //Get collection associated with this object
            var collection = _mongoCollectionFactory.GetCollection<T>(typeof(T).Name);

            //Create filter to get element to update
            var filter = Builders<T>.Filter.Eq("_id", record.Id);

            //Replace DB element with updated element
            collection.ReplaceOne(filter, record, new UpdateOptions() { IsUpsert = false });
        }
    }
}
