using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        //private readonly IConfiguration _configuration;
        //private readonly IMongoClient _mongoClient;
        public CatalogContext(IMongoClient mongoClient, IConfiguration configuration)
        {
            //_configuration = configuration;
            //_mongoClient = mongoClient;
            // var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = mongoClient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}