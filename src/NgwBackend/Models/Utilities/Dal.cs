using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace NgwBackend.Models.Utilities
{
    public class Dal
    {
        public string DBName {get; set;}
        private MongoClient MongoClient;
        private static Dal instance;

        private Dal()
        {
            this.DBName = "NgwDemo";
            this.MongoClient = new MongoClient("mongodb://10.0.0.2:27017");
        }

        public static Dal getInstance()
        {
            if(instance == null)
            {
                instance = new Dal();
            }

            return instance;
        }

        public IMongoDatabase GetDB()
        {
            return Dal.getInstance().MongoClient.GetDatabase(this.DBName);
        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return this.GetDB().GetCollection<BsonDocument>(collectionName);
        }
    }
}
