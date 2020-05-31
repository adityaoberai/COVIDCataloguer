using System;
using System.Security.Authentication;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Linq;
using MongoDB.Bson;
using RookieHacksCOVID.Models;

namespace RookieHacksCOVID
{
    class MongoService
    {
        string dbName = "rhcovid";
        string collectionName = "patients";

        IMongoCollection<Patient> tasksCollection;
        IMongoCollection<Patient> TasksCollection
        {
            get
            {
                if (tasksCollection == null)
                {
                    var mongoUrl = new MongoUrl("ADD MONGODB API CONNECTION STRING");

                    // APIKeys.Connection string is found in the portal under the "Connection String" blade
                    MongoClientSettings settings = MongoClientSettings.FromUrl(mongoUrl);

                    settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

                    settings.RetryWrites = false;

                    // Initialize the client
                    var mongoClient = new MongoClient(settings);

                    // This will create or get the database
                    var db = mongoClient.GetDatabase(dbName);

                    // This will create or get the collection
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    tasksCollection = db.GetCollection<Patient>(collectionName, collectionSettings);
                }
                return tasksCollection;
            }
        }

        public async Task<List<Patient>> GetAllTasks()
        {
            try
            {
                var allTasks = await TasksCollection
                    .Find(new BsonDocument())
                    .ToListAsync();

                return allTasks;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Patient> GetTaskById(long taskId)
        {
            try
            {
                var singleTask = await TasksCollection
                    .Find(f => f.Id.Equals(taskId))
                    .FirstOrDefaultAsync();

                return singleTask;

            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task CreateTask(Patient task)
        {
            await TasksCollection.InsertOneAsync(task);
        }

        public async Task UpdateTask(Patient task)
        {
            await TasksCollection.ReplaceOneAsync(t => t.Id.Equals(task.Id), task);
        }


    }
}
