using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;

namespace WebApplication1.Game
{
    using BaseClasses;
    public class CultivatorContext : DbContext
    {
        private static object syncRoot = new Object();


        private IMongoDatabase database; // база данных
        private IGridFSBucket gridFS;

        public CultivatorContext()
        {
            // строка подключения
            var connectionString = "mongodb://root:Csharpgovno1@ds151814.mlab.com:51814/gamedb";
            var connection = new MongoUrlBuilder(connectionString);
            
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            
            // получаем доступ к самой базе данных
            database = client.GetDatabase(connection.DatabaseName);
            gridFS = new GridFSBucket(database);
        }

        public IMongoCollection<CCultivator> Collection
        {
            get { return database.GetCollection<CCultivator>("Players"); }
        }

        public async Task Create(CCultivator c)
        {
            await Collection.InsertOneAsync(c);
        }

        public async Task<CCultivator> GetCultivator(string id)
        {
            var filter = Builders<CCultivator>.Filter.Eq("PlayerId", id);
            return await Collection
                .Find(filter)
                .FirstOrDefaultAsync();
        }
    }
}