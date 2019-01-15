using MongoDB.Driver;
using System;
using System.Text;
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

        public static string getHex(String s)
        {
            char[] chars = s.ToCharArray();
            StringBuilder stringBuilder =  new StringBuilder();
            foreach(char c in chars)
            {
                stringBuilder.Append(((Int16)c).ToString("x"));
            }
            String textAsHex = stringBuilder.ToString();
            return textAsHex;
        }

        public async Task<string> GetName(string id)
        {
            var cult = await GetCultivator(id);
            return cult.Name;
        }
        
        public async Task<CCultivator> GetCultivator(string id)
        {
            id = getHex(id);
            var filter = Builders<CCultivator>.Filter.Eq("PlayerId", id);
            return await Collection
                .Find(filter)
                .FirstOrDefaultAsync();
        }
        
        public async Task Update(CCultivator c)
        {
            await Collection.ReplaceOneAsync(new BsonDocument("_id", c.PlayerId), c);
        }
    }
}