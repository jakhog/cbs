using Dolittle.ReadModels;
using Dolittle.ReadModels.MongoDB;
using MongoDB.Driver;

namespace Read
{
    public static class MongoCollectionExtensions
    {
        /// <summary>
        /// Inserts a read model into a MongoCollection
        /// </summary>
        /// <param name="collection">The <see cref="IMongoCollection{T}">collection</see> to insert into</param>
        /// <param name="readModel">The <see cref="IReadModel">read model</see> to insert</param>
        /// <typeparam name="T"></typeparam>
        public static void Insert<T>(this IMongoCollection<T> collection, T readModel) where T : IReadModel
        {
            collection.InsertOne(readModel);
        }

        /// <summary>
        /// Updates an existing read model in a MongoCollection, matching by the Id property
        /// </summary>
        /// <param name="collection">The <see cref="IMongoCollection{T}">collection</see> the read model is stored in</param>
        /// <param name="readModel">The updated <see cref="IReadModel">read model</see>, matched by the Id property</param>
        /// <typeparam name="T"></typeparam>
        public static void Update<T>(this IMongoCollection<T> collection, T readModel) where T : IReadModel
        {
            var id = readModel.GetObjectIdFrom();
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = false });
        }
    }
}