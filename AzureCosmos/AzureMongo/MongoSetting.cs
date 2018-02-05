using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Configuration;
using System.Security.Authentication;
using AzureCosmos.Model;

namespace AzureMongo
{
    public class MongoSetting
    {
        //cosmosfun
        string connectionString =  @"YOUR  CONNECTION STRING";
       
        protected string userName = "cosmosfun";
        protected string host = "cosmosfun.documents.azure.com";
        protected string password = "YOUR PASSWORD";
        
        protected string dbName = "cosmosfun";
        protected string collectionName = "Persons";
        protected MongoClient mongoClient = null;

        public MongoSetting()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            mongoClient = new MongoClient(settings);

            var result = mongoClient.GetDatabase(this.dbName).GetCollection<BsonDocument>(this.collectionName);
            if(result == null)
            {
                mongoClient.GetDatabase(this.dbName).CreateCollection(this.collectionName, new CreateCollectionOptions
                {
                    Capped = true,
                    MaxSize = 1024,
                    MaxDocuments = 10,
                });
            }

            
        }



    }
}
