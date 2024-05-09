using MongoDB.Driver;

namespace Projeto.Knights.Repository
{
    public class KnightRepository
    {
        private readonly IMongoCollection<Knight> _knightsCollection;

        public KnightRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _knightsCollection = database.GetCollection<Knight>("Knights");
        }

        public Knight GetKnightById(int id)
        {
            return _knightsCollection.Find(knight => knight.Id == id).FirstOrDefault();
        }

        public void AddKnight(Knight knight)
        {
            _knightsCollection.InsertOne(knight);
        }

        public List<Knight> GetAllKnights()
        {
            return _knightsCollection.Find(knight => true).ToList();
        }

        public List<Knight> GetHeroKnights()
        {
            return _knightsCollection.Find(knight => knight.Attributes.Strength > 15).ToList();
        }

        public void DeleteKnight(int id)
        {
            _knightsCollection.DeleteOne(knight => knight.Id == id);
        }

        public void UpdateKnight(Knight knight)
        {
            _knightsCollection.ReplaceOne(k => k.Id == knight.Id, knight);
        }

    }
}
