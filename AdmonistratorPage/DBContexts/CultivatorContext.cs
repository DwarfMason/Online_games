using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AdministratorProject.Game
{
    using BaseClasses;
    public class CultivatorContext
    {
        private static CultivatorContext instance;
        private static object syncRoot = new Object();


        private IMongoDatabase database; // база данных
        private IMongoCollection<CCultivator> collection; // база данных

        private CultivatorContext()
        {
            // строка подключения
            string connectionString = "mongodb://localhost:27017";

            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            database = client.GetDatabase("GameDB");
            collection = database.GetCollection<CCultivator>("Cultivators");
        }
        /* public Cultivator getID()
         {
             return 
         }*/
        public static CultivatorContext GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new CultivatorContext();
                }
            }
            return instance;
        }
    }
}