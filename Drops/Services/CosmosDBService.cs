using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Data;
using System.Diagnostics;
using Microsoft.Azure.Documents.Linq;
using Xamarin.Forms;
using Drops.Helpers;
using Drops.Models;


namespace Drops.Services
{
    public class CosmosDBService
    {
        static DocumentClient docClient = null;

        static readonly string databaseName = "Drops";
        static readonly string userCollectionName = "Users";
        static readonly string areaCollectionName = "Areas";

        // when is initalize used?
        static async Task<bool> Initialize()
        {
            if (docClient != null)
                return true;

            try
            {
                docClient = new DocumentClient(new Uri(APIKeys.CosmosEndpointUrl), APIKeys.CosmosAuthKey);

                // Create the database - this can also be done through the portal
                await docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

                // Create the collection - make sure to specify the RUs - has pricing implications
                // This can also be done through the portal

                await docClient.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = userCollectionName },
                    new RequestOptions { OfferThroughput = 400 }
                );

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                docClient = null;

                return false;
            }

            return true;
        }

        // USER CONTAINER CRUD METHODS

        // READ
        public async static Task<List<DropsUser>> GetUsers()
        {
            var users = new List<DropsUser>();

            if (!await Initialize())
                return users;

            var todoQuery = docClient.CreateDocumentQuery<DropsUser>(
                UriFactory.CreateDocumentCollectionUri(databaseName, userCollectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .AsDocumentQuery();

            while (todoQuery.HasMoreResults)
            {
                var queryResults = await todoQuery.ExecuteNextAsync<DropsUser>();

                users.AddRange(queryResults);
            }

            return users;
        }

        // CREATE
        //public async static Task InsertToDoItem(ToDoItem item)
        //{
        //    if (!await Initialize())
        //        return;

        //    await docClient.CreateDocumentAsync(
        //        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
        //        item);
        //}

        // DELETE
        //public async static Task DeleteToDoItem(ToDoItem item)
        //{
        //    if (!await Initialize())
        //        return;

        //    var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
        //    await docClient.DeleteDocumentAsync(docUri);
        //}
       

        // UPDATE
        //public async static Task UpdateToDoItem(ToDoItem item)
        //{
        //    if (!await Initialize())
        //        return;

        //    var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
        //    await docClient.ReplaceDocumentAsync(docUri, item);
        //}
        



        // AREA CONTAINER CRUD METHODS
        public async static Task<List<DropsArea>> GetAreas()
        {
            var areas = new List<DropsArea>();

            if (!await Initialize())
                return areas;

            var todoQuery = docClient.CreateDocumentQuery<DropsArea>(
                UriFactory.CreateDocumentCollectionUri(databaseName, areaCollectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .AsDocumentQuery();

            while (todoQuery.HasMoreResults)
            {
                var queryResults = await todoQuery.ExecuteNextAsync<DropsArea>();

                areas.AddRange(queryResults);
            }

            return areas;
        }


        // CREATE
        //public async static Task InsertToDoItem(ToDoItem item)
        //{
        //    if (!await Initialize())
        //        return;

        //    await docClient.CreateDocumentAsync(
        //        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
        //        item);
        //}

        // DELETE
        //public async static Task DeleteToDoItem(ToDoItem item)
        //{
        //    if (!await Initialize())
        //        return;

        //    var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
        //    await docClient.DeleteDocumentAsync(docUri);
        //}


        // UPDATE
        //public async static Task UpdateToDoItem(ToDoItem item)
        //{
        //    if (!await Initialize())
        //        return;

        //    var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
        //    await docClient.ReplaceDocumentAsync(docUri, item);
        //}
    }
}
