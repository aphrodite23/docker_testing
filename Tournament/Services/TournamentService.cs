using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Tournament.Models;

namespace Tournament.Services
{
    public class TournamentService
    {
        private readonly IMongoCollection<TournamentD> _tournament;

        public TournamentService(ITournamentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tournament = database.GetCollection<TournamentD>(settings.TournamentCollectionName);
        }
        public List<TournamentD> Get() =>
            _tournament.Find(tournament => true).ToList();
        public TournamentD Get(string id) =>
            _tournament.Find<TournamentD>(Tour => Tour.TournamentId == id).FirstOrDefault();
        public TournamentD Create(TournamentD tour)
        {
            _tournament.InsertOne(tour);
            return tour;
        }
        public void Update(string id, TournamentD tour)=>
            _tournament.ReplaceOne(book=>book.TournamentId==id,tour);
        
        public void Remove(TournamentD tour) =>
            _tournament.DeleteOne(book => book.TournamentId == tour.TournamentId);
        public void Remove(string id) =>
            _tournament.DeleteOne(tour =>tour.TournamentId==id);
    }
}
