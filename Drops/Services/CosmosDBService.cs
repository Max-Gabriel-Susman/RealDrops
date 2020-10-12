using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Diagnostics;
using Microsoft.Azure.Documents.Linq;
using Drops.Helpers;
using Drops.Models;


namespace Drops.Services
{
    public class CosmosDBService
    {      
        static DocumentClient docClient = null;

        // String constants for database interaction
        static readonly string databaseName = "Drops";
        static readonly string userCollectionName = "Users";
        static readonly string areaCollectionName = "Areas";

        static async Task<bool> Initialize()
        {
            // Returns method if docClient has already been initialized
            if (docClient != null)
                return true;

            // The rest of this Method is executed only once per session
            try
            {
                // assigns a DocumentClient to a null docClient
                docClient = new DocumentClient(new Uri(APIKeys.CosmosEndpointUrl), APIKeys.CosmosAuthKey);

                // Instanttiates the database
                await docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

                // Instanitates the Document Collection and Request options
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

            // Enforces initialization prior to the use of this methods functionality
            if (!await Initialize())
                return users;

            // assings the query to a var
            var query = docClient.CreateDocumentQuery<DropsUser>(
                UriFactory.CreateDocumentCollectionUri(databaseName, userCollectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .AsDocumentQuery();

            // iterates over the query
            while (query.HasMoreResults)
            {
                // assigns an element from the query to queryResults
                var queryResults = await query.ExecuteNextAsync<DropsUser>();

                users.AddRange(queryResults);
            }

            return users;
        }

        // CREATE
        public async static Task InsertUser(DropsUser user)
        {
            // Enforces the Initialize method to be called prior to this one
            if (!await Initialize())
                return;

            // creates document and appends in to container
            await docClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(databaseName, userCollectionName),
                user);
        }

        // DELETE - Not yet implemented
        //public async static Task DeleteUser(DropsUser user)
        //{
        //    if (!await Initialize())
        //        return;

        //    var docUri = UriFactory.CreateDocumentUri(databaseName, userCollectionName, user.ID);
        //    await docClient.DeleteDocumentAsync(docUri);
        //}


        // UPDATE
        public async static Task UpdateUser(DropsUser user)
        {
            // Enforces the Initialize method to be called prior to this one
            if (!await Initialize())
                return;

            // Creates a URI for accessing the Document in the Database
            var docUri = UriFactory.CreateDocumentUri(databaseName, userCollectionName, user.ID);
            await docClient.ReplaceDocumentAsync(docUri, user);
        }

        // I think that we could possibly create a single set of generic methods to encompass the two sets we currently have right here


        // AREA CONTAINER CRUD METHODS

        // READ
        public async static Task<List<DropsArea>> GetAreas()
        {
            var areas = new List<DropsArea>();

            // Enforces the Initialize method to be called prior to this one
            if (!await Initialize())
                return areas;

            // stores the results of the query in a var
            var query = docClient.CreateDocumentQuery<DropsArea>(
                UriFactory.CreateDocumentCollectionUri(databaseName, areaCollectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .AsDocumentQuery();

            // iterates over query elements
            while (query.HasMoreResults)
            {
                // stores next element of query in a var
                var queryResults = await query.ExecuteNextAsync<DropsArea>();
                
                areas.AddRange(queryResults);
            }

            return areas;
        }


        // CREATE
        public async static Task InsertArea(DropsArea area)
        {
            // Enforces the Initialize method to be called prior to this one
            if (!await Initialize())
                return;

            // creates document and appends in to container
            await docClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(databaseName, areaCollectionName),
                area);
        }

        // DELETE - Not Yet Implemented
        //public async static Task DeleteArea(DropsArea area)
        //{
        //    if (!await Initialize())
        //        return;

        //    var docUri = UriFactory.CreateDocumentUri(databaseName, areaCollectionName, area.ID);
        //    await docClient.DeleteDocumentAsync(docUri);
        //}


        // UPDATE 
        public async static Task UpdateArea(DropsArea area)
        {
            // Enforces the Initialize method to be called prior to this one
            if (!await Initialize())
                return;

            // Creates a URI for accessing the Document in the Database
            var docUri = UriFactory.CreateDocumentUri(databaseName, areaCollectionName, area.ID);

            // Replaces the data from the document specified by the uri with the area passed as an argument
            await docClient.ReplaceDocumentAsync(docUri, area);
        }
    }
}
