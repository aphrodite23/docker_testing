using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tournament.Models
{
    public class TournamentD
    {
  
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TournamentId { get; set; }
        public int[] matchId      { get; set; }
        public string game        { get; set; }
        public int entryFee       { get; set; }
        public string prize     { get; set; }
        
    }
}
